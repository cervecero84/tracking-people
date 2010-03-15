using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TableTopCommunicator;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using WiimoteLib;

namespace FinalSolution
{
    public partial class Main : Form
    {
        Communicator comm = new Communicator();
        Capture camera = new Capture();
        Wiimote wiimote = new Wiimote();

        // Calibration Information
        CalibrationPoints irCalibrationPoints = new CalibrationPoints();
        CalibrationPoints camCalibrationPoints = new CalibrationPoints();
        ColorStateSet colors = new ColorStateSet();
        Warper irToScreenWarper = new Warper();
        Warper screenToCamWarper = new Warper();
        Warper irToCamWarper = new Warper();
        int cameraPixelToRealCmRatio = 1;

        const int TOUCH_MIN_DIST = 20;

        public Main()
        {
            InitializeComponent();
            //camera.FlipHorizontal = true;
            comm.TouchReceived += new Communicator.TouchReceivedHandler(comm_TouchReceived);
            try
            {
                //wiimote.Connect();
                //wiimote.SetReportType(InputReport.IRAccel, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                this.Close();
            }
        }

        private List<WiimoteLib.PointF> FindIRPointsInScreenCoords()
        {
            List<WiimoteLib.PointF> points = new List<WiimoteLib.PointF>();
            WiimoteState ws = wiimote.WiimoteState;

            for (int i = 0; i < 4; i++)
            {
                IRSensor sensor = ws.IRState.IRSensors[i];
                if (sensor.Found)
                {
                    WiimoteLib.PointF p = irToScreenWarper.warp(sensor.RawPosition.X, sensor.RawPosition.Y);
                    // WARNING: A problem may arise here, if calibration used a scaled RawPosition for calibration
                    points.Add(p);
                }
            }

            return points;
        }

        private void comm_TouchReceived(object sender, TouchEventArgs t)
        {
            TouchInfo currTouch = t.Touch;
            Image<Bgr, Byte> cameraImage = camera.QueryFrame();
            Image<Ycc, Byte> cameraImageYcc = cameraImage.Convert<Ycc, Byte>();
            List<WiimoteLib.PointF> irPoints = FindIRPointsInScreenCoords();
            List<Utility.ResolvedIRPoints> resolvedIrPoints = new List<Utility.ResolvedIRPoints>();

            // Measure distance of each point from touch
            for (int i = 0; i < irPoints.Count; i++)
            {
                CalibrationWizard sizeReference = new CalibrationWizard();
                Size IRViewerSize = sizeReference.getIRViewerSize();
                // Normalize takes into account points that are visible to the IR but not to the camera
                // and points in the screen not visible to the camera
                WiimoteLib.PointF camIrPt = Utility.Normalize(irToCamWarper.warp(irPoints[i].X * IRViewerSize.Width / 1024, irPoints[i].Y * IRViewerSize.Height / 768), sizeReference.getCameraViewerSize());
                WiimoteLib.PointF camTouchPt = Utility.Normalize(screenToCamWarper.warp(currTouch.X, currTouch.Y), sizeReference.getCameraViewerSize());
                Rectangle roi = Utility.getROI(camIrPt, camTouchPt);
                // NOTE: The ROIs have to be adjusted. The color band detection should use a smaller ROI

                // Compute Distance of point to touch
                double dist = Math.Pow(irPoints[i].X - currTouch.X, 2) + Math.Pow(irPoints[i].Y - currTouch.Y, 2);
                // Compute color of point
                BandColor bc = ColorState.FindBand(cameraImageYcc.GetSubRect(roi), colors);
                // Compute skin connection probability
                
                double prob = HandProb.SkinConnectedProb(cameraImage, camTouchPt, camIrPt, cameraPixelToRealCmRatio);
                resolvedIrPoints.Add(new Utility.ResolvedIRPoints(camIrPt, camTouchPt, dist, bc, prob));
            }

            #region hide this temporarily
            // NOTE: If point is too close, it's probably not the corresponding point:
            // another person's hand (touch-coord) may have been close to a different band (IR)

            /*
            resolvedIrPoints.Sort((firstPair, nextPair) => {
                double d1 = firstPair.Distance;
                double d2 = nextPair.Distance;
                d1 = (d1 < TOUCH_MIN_DIST) ? Int32.MaxValue - d1 : d1;
                d2 = (d2 < TOUCH_MIN_DIST) ? Int32.MaxValue - d2 : d2;
                return d1.CompareTo(d2); 
            });*/
            #endregion

            // We could try using this purely - the skin probability takes the distance into account
            resolvedIrPoints.Sort((firstPair, nextPair) =>
            {
                return firstPair.SkinProbability.CompareTo(nextPair.SkinProbability);
            });
            Utility.ResolvedIRPoints resolvedPoint;

            // If no IR points were found, set Band Color to NotFound
            if (resolvedIrPoints.Count > 0)
            {
                resolvedPoint = resolvedIrPoints[0];
            }
            else
            {
                resolvedPoint = new Utility.ResolvedIRPoints(new WiimoteLib.PointF(), new WiimoteLib.PointF(), -1, BandColor.NotFound, -1);
            }

            // Update the touch
            currTouch.setInfo((Colors)Enum.Parse(typeof(Colors),Enum.GetName(typeof(BandColor), resolvedPoint.Color),true), 
                (int)(HandProb.getOrientation(resolvedPoint.IRPoint, resolvedPoint.TouchPoint) * 180.0 / Math.PI));
            comm.UpdateTouchInfo(currTouch);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            CalibrationWizard wizard = new CalibrationWizard(camera, wiimote, irCalibrationPoints, camCalibrationPoints, colors,
                irToScreenWarper, screenToCamWarper, irToCamWarper, 1024, 768);
            wizard.Show();
        }
    }
}

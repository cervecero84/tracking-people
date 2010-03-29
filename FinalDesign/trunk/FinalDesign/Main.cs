using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
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
        Stopwatch stopWatch = new Stopwatch();

        // Calibration Information
        CalibrationPoints irCalibrationPoints = new CalibrationPoints();
        CalibrationPoints camCalibrationPoints = new CalibrationPoints();
        ColorStateSet colors = new ColorStateSet();
        Warper screenToCamWarper = new Warper();
        Warper irToCamWarper = new Warper();
        double cameraPixelToRealCmRatio = 1;

        // For size reference of controls used in calibration
        CalibrationWizard sizeReference = new CalibrationWizard();
        
        int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        int screenHeight = Screen.PrimaryScreen.Bounds.Height;

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

        private List<WiimoteLib.PointF> FindIRPointsInWiiCoords()
        {
            List<WiimoteLib.PointF> points = new List<WiimoteLib.PointF>();
            WiimoteState ws = wiimote.WiimoteState;

            for (int i = 0; i < 4; i++)
            {
                IRSensor sensor = ws.IRState.IRSensors[i];
                if (sensor.Found)
                {
                    WiimoteLib.PointF p = new WiimoteLib.PointF();
                    p.X = sensor.RawPosition.X;
                    p.Y = sensor.RawPosition.Y;
                    points.Add(p);
                }
            }

            return points;
        }

        private void clearLog()
        {
            BeginInvoke(new MethodInvoker(delegate() { stopWatch.Reset(); stopWatch.Start(); }));
            BeginInvoke(new MethodInvoker(delegate() { txtOuput.Text = ""; }));
        }

        private void log(String msg)
        {
            BeginInvoke(new MethodInvoker(delegate()
            {
                stopWatch.Stop();
                if (msg == "") msg = "          *** ***         ";
                txtOuput.Text += "[" + stopWatch.ElapsedMilliseconds + " ms]" + msg + Environment.NewLine;
                stopWatch.Start();
            }));
        }

        private void comm_TouchReceived(object sender, TouchEventArgs t)
        {
            clearLog();
            log("Log cleared");

            //camera.QueryFrame();
            //camera.QueryFrame();
            //log("Buffer cleared");

            TouchInfo currTouch = t.Touch;
            log("Touch X: " + currTouch.X + " Touch Y: " + currTouch.Y);

            Image<Bgr, Byte> cameraImage = camera.QueryFrame();
            log("Camera output acuired for processing");
            
            cameraImage = cameraImage.Resize(sizeReference.getCameraViewerSize().Width, sizeReference.getCameraViewerSize().Height, INTER.CV_INTER_LINEAR);
            log("Camera output resized");

            Image<Ycc, Byte> cameraImageYcc = cameraImage.Clone().Convert<Ycc, Byte>();
            log("Image cloned and colorspace converted");

            if (cbxRandomOutput.Checked)
            {
                Random r = new Random();
                currTouch.setInfo((Colors)Enum.Parse(typeof(Colors), Enum.GetName(typeof(BandColor), (BandColor)r.Next(0, 5)), true), 0);
                comm.UpdateTouchInfo(currTouch);
                log("Random output given");
                return;
            }

            if (cbxShowColors.Checked)
            {
                Image<Hsv, Byte> result = new Image<Hsv, byte>(cameraImage.Width, cameraImage.Height);
                Image<Gray, Byte> skin = HandProb.SkinDetect(cameraImage);
                CvInvoke.cvMerge(IntPtr.Zero, skin.Mul(0.5), skin, IntPtr.Zero, result);
                result = result.Or(colors.Red.GetProbabilityImage(cameraImageYcc, new Hsv(0, 1, 1)));
                result = result.Or(colors.Blue.GetProbabilityImage(cameraImageYcc, new Hsv(0.4, 1, 1)));
                result = result.Or(colors.Yellow.GetProbabilityImage(cameraImageYcc, new Hsv(0.1, 1, 1)));
                result = result.Or(colors.Green.GetProbabilityImage(cameraImageYcc, new Hsv(0.3, 1, 1)));
                ibxColors.Image = result;
                log("Colors and skin drawn in secondary monitor");
            }

            List<WiimoteLib.PointF> irPoints = FindIRPointsInWiiCoords();
            log("IR Points obtained from Wiimote");
            List<Utility.ResolvedIRPoints> resolvedIrPoints = new List<Utility.ResolvedIRPoints>();

            double screenWidthInCam = (Math.Max(Math.Abs(camCalibrationPoints.TL.Y - camCalibrationPoints.TR.Y), Math.Abs(camCalibrationPoints.TL.X - camCalibrationPoints.TR.X))
                + Math.Max(Math.Abs(camCalibrationPoints.BL.Y - camCalibrationPoints.BR.Y), Math.Abs(camCalibrationPoints.BL.X - camCalibrationPoints.BR.X))) / 2.0;
            cameraPixelToRealCmRatio = 95.0 / screenWidthInCam;

            //Drawing code for debugging
            Image<Ycc, Byte> cameraImageYccDebug = cameraImageYcc.Clone();
            if (cbxDrawMode.Checked) ibxSource.Image = cameraImageYccDebug;
            log("Clone image for debug output created");

            // Measure distance of each point from touch
            for (int i = 0; i < irPoints.Count; i++)
            {
                log("");
                Size IRViewerSize = sizeReference.getIRViewerSize();

                log("Raw IR X: " + irPoints[i].X + " Raw IR Y: " + irPoints[i].Y);
                // Normalize takes into account points that are visible to the IR but not to the camera
                // and points in the screen not visible to the camera
                WiimoteLib.PointF camIrPt = Utility.Normalize(irToCamWarper.warp(irPoints[i].X * IRViewerSize.Width / screenWidth, irPoints[i].Y * IRViewerSize.Height / screenHeight), sizeReference.getCameraViewerSize());
                WiimoteLib.PointF camTouchPt = Utility.Normalize(screenToCamWarper.warp(currTouch.X, currTouch.Y), sizeReference.getCameraViewerSize());

                log("Warped IR X: " + camIrPt.X + " Warped IR Y: " + camIrPt.Y);
                log("Warped Touch X: " + camIrPt.X + " Warped Touch Y: " + camIrPt.Y);

                //Draw both IR and Screen Points to ibxSource
                if (cbxDrawMode.Checked)
                {
                    cameraImageYccDebug.Draw(new Ellipse(new System.Drawing.PointF(camIrPt.X, camIrPt.Y), new SizeF(1, 1), 0), new Ycc(255, 128, 128), 2);
                    cameraImageYccDebug.Draw(new Ellipse(new System.Drawing.PointF(camTouchPt.X, camTouchPt.Y), new SizeF(1, 1), 0), new Ycc(81, 240, 90), 2);
                }
                if (cbxDrawMode.Checked) ibxSource.Image = cameraImageYccDebug;

                // NOTE: The ROIs have to be adjusted. The color band detection should use a smaller ROI
                Rectangle colorBandRoi = Utility.Normalize(Utility.getBoundingBoxForColor(camIrPt), sizeReference.getCameraViewerSize());
                // Compute color of point
                cameraImageYcc.ROI = colorBandRoi;
                Image<Ycc, Byte> colorBandImage = new Image<Ycc,byte>(colorBandRoi.Size);
                CvInvoke.cvCopy(cameraImageYcc, colorBandImage, IntPtr.Zero);

                BandColor bc = ColorState.FindBand(colorBandImage, colors);
                log("IR Point identified as " + bc.ToString());

                if (cbxDrawMode.Checked)
                {
                    //Draw Rectangle to ibxSource
                    if (bc == BandColor.Red) cameraImageYccDebug.Draw(colorBandRoi, new Ycc(81, 240, 90), 2);
                    if (bc == BandColor.Green) cameraImageYccDebug.Draw(colorBandRoi, new Ycc(144, 34, 53), 2);
                    if (bc == BandColor.Yellow) cameraImageYccDebug.Draw(colorBandRoi, new Ycc(210, 146, 16), 2);
                    if (bc == BandColor.Blue) cameraImageYccDebug.Draw(colorBandRoi, new Ycc(40, 109, 240), 2);
                }

                if (cbxDrawMode.Checked) ibxSource.Image = cameraImageYccDebug;

                // Compute skin connection probability
                double sizeProb = 0, skinProb = 0;
                double prob = HandProb.SkinConnectedProb(cameraImage, camTouchPt, camIrPt, cameraPixelToRealCmRatio, sizeReference.getCameraViewerSize(), ref sizeProb, ref skinProb);
                
                // DEBUG: Calculate hand size just for log output
                double dist = Math.Sqrt(Math.Pow(((camTouchPt.X - camIrPt.X) * cameraPixelToRealCmRatio), 2) + Math.Pow(((camTouchPt.Y - camIrPt.Y) * cameraPixelToRealCmRatio), 2));
                log("Hand size: " + dist);
                log("P-size(touch, IR) = " + sizeProb.ToString());
                log("P-skin(touch, IR) = " + skinProb.ToString());

                Rectangle rectROI = Utility.Normalize(Utility.getBoundingBox(camTouchPt, camIrPt), sizeReference.getCameraViewerSize());
                if (cbxDrawMode.Checked)
                {
                    cameraImageYccDebug.Draw(rectROI, new Ycc(255, 128, 128), 2);
                }
                if (cbxDrawMode.Checked) ibxSource.Image = cameraImageYccDebug;

                // Probability has to be at least 5%
                if (prob > 0.05)
                {
                    resolvedIrPoints.Add(new Utility.ResolvedIRPoints(camIrPt, camTouchPt, bc, prob));
                }
                cameraImageYcc.ROI = new Rectangle(0, 0, cameraImage.Width, cameraImage.Height);
            }

            // We could try using this purely - the skin probability takes the distance into account
            resolvedIrPoints.Sort((firstPair, nextPair) =>
            {
                return firstPair.SkinProbability.CompareTo(nextPair.SkinProbability);
            });

            Utility.ResolvedIRPoints resolvedPoint;
            // If no IR points were found, set Band Color to NotFound
            if (resolvedIrPoints.Count > 0)
            {
                resolvedPoint = resolvedIrPoints[resolvedIrPoints.Count - 1];
            }
            else
            {
                resolvedPoint = new Utility.ResolvedIRPoints(new WiimoteLib.PointF(), new WiimoteLib.PointF(), BandColor.NotFound, -1);
            }

            // Update the touch
            currTouch.setInfo((Colors)Enum.Parse(typeof(Colors),Enum.GetName(typeof(BandColor), resolvedPoint.Color),true), 
                (int)(HandProb.getOrientation(resolvedPoint.IRPoint, resolvedPoint.TouchPoint) * 180.0 / Math.PI));
            log("Orientation of resolved point: " + (int)(HandProb.getOrientation(resolvedPoint.IRPoint, resolvedPoint.TouchPoint) * 180.0 / Math.PI));
            comm.UpdateTouchInfo(currTouch);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            CalibrationWizard wizard = new CalibrationWizard(this, camera, wiimote, irCalibrationPoints, camCalibrationPoints, 
                colors, screenToCamWarper, irToCamWarper, ref screenWidth, ref screenHeight);
            wizard.Show();
        }

        public void setSettings(CalibrationPoints ir, CalibrationPoints cam, ColorStateSet cs, Warper s2C, Warper i2C)
        {
            irCalibrationPoints = ir;
            camCalibrationPoints = cam;
            colors = cs;
            screenToCamWarper = s2C;
            irToCamWarper = i2C;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colors.Red.DilationValue = 5;
            colors.Red.ErosionValue = 5;
            colors.Red.ThresholdValue = 230;
        }
    }
}

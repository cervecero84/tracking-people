using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using WiimoteLib;

namespace FinalSolution
{
    public partial class CalibrationWizard : Form
    {
        Capture camera;
        Wiimote wiimote;
        CalibrationPoints irCalibrationPoints = new CalibrationPoints();
        CalibrationPoints camCalibrationPoints = new CalibrationPoints();
        ColorStateSet colors = new ColorStateSet();
        Warper irToScreenWarper = new Warper();
        Warper screenToCamWarper = new Warper();
        Warper irToCamWarper = new Warper();


        // States 0 - 3: indicate point number (TL, TR, BL, BR)
        // Anything else means program is in non-calibration mode
        int _irCalibrationState = 4;
        int _camCalibrationState = 4;

        public CalibrationWizard(Capture c, Wiimote w, CalibrationPoints irCP, CalibrationPoints camCP, 
            ColorStateSet cs, Warper ir2S, Warper s2Cam, Warper ir2Cam)
        {
            InitializeComponent();
            camera = c;
            wiimote = w;
            irCalibrationPoints = irCP;
            camCalibrationPoints = camCP;
            colors = cs;
            irToScreenWarper = ir2S;
            screenToCamWarper = s2Cam;
            irToCamWarper = ir2Cam;
        }



        private void btnWiimoteCalibrate_Click(object sender, EventArgs e)
        {
            _irCalibrationState = 0;
            lblInstructions.Text = "InfraRed Calibration: Click TopLeft point";
        }

        private void wiiCalibOutput_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_irCalibrationState)
            {
                case 0:
                    irCalibrationPoints.TL.X = e.X;
                    irCalibrationPoints.TL.Y = e.Y;
                    _irCalibrationState += 1;
                    lblInstructions.Text = "InfraRed Calibration: Click TopRight point";
                    break;
                case 1:
                    irCalibrationPoints.TR.X = e.X;
                    irCalibrationPoints.TR.Y = e.Y;
                    _irCalibrationState += 1;
                    lblInstructions.Text = "InfraRed Calibration: Click BottomLeft point";
                    break;
                case 2:
                    irCalibrationPoints.BL.X = e.X;
                    irCalibrationPoints.BL.Y = e.Y;
                    _irCalibrationState += 1;
                    lblInstructions.Text = "InfraRed Calibration: Click BottomRight point";
                    break;
                case 3:
                    irCalibrationPoints.BR.X = e.X;
                    irCalibrationPoints.BR.Y = e.Y;
                    _irCalibrationState += 1;
                    // Save a copy of the image with the calibration markers - create a new object using Clone
                    lblInstructions.Text = "IR Calibration: Complete";
                    // Calibration data acquired. Compute warp
                    _irWarper.setDestination(0, 0, _screenWidth, 0, 0, _screenHeight, _screenWidth, _screenHeight);
                    _irWarper.setSource(irCalibrationPoints.TL.X, irCalibrationPoints.TL.Y,
                        irCalibrationPoints.TR.X, irCalibrationPoints.TR.Y,
                        irCalibrationPoints.BL.X, irCalibrationPoints.BL.Y,
                        irCalibrationPoints.BR.X, irCalibrationPoints.BR.Y);
                    _irWarper.computeWarp();
                    _calibrated = true;
                    lblStatus.Text = "IR Calibration: Complete - Warp computed";
                    break;
                default:
                    if (_calibrated)
                    {
                        lblStatus.Text = "IR Clicked @ " + DateTime.Now.ToShortTimeString();
                        // Compute normalized coordinate
                        WiimoteLib.PointF dst = _irWarper.warp(e.X, e.Y);
                        lblStatus.Text += " in (" + e.X.ToString() + ", " + e.Y.ToString() + ")";
                        lblStatus.Text += " => " + dst.ToString();

                        //showIRPointInCam(Color.PeachPuff, dst);
                    }
                    break;
            }
        }

        private void tkbRedErosion_Scroll(object sender, EventArgs e)
        {
            lblRedErosion.Text = tkbRedErosion.Value.ToString();
        }

        private void tkbRedDilation_Scroll(object sender, EventArgs e)
        {
            lblRedDilation.Text = tkbRedDilation.Value.ToString();
        }

        private void tkbRedThreshold_Scroll(object sender, EventArgs e)
        {
            lblRedThreshold.Text = tkbRedThreshold.Value.ToString();
        }

        private void tkbGreenErosion_Scroll(object sender, EventArgs e)
        {
            lblGreenErosion.Text = tkbGreenErosion.Value.ToString();
        }

        private void tkbGreenDilation_Scroll(object sender, EventArgs e)
        {
            lblGreenDilation.Text = tkbGreenDilation.Value.ToString();
        }

        private void tkbGreenThreshold_Scroll(object sender, EventArgs e)
        {
            lblGreenThreshold.Text = tkbGreenThreshold.Value.ToString();
        }

        private void tkbOrangeErosion_Scroll(object sender, EventArgs e)
        {
            lblOrangeErosion.Text = tkbOrangeErosion.Value.ToString();
        }

        private void tkbOrangeDilation_Scroll(object sender, EventArgs e)
        {
            lblOrangeDilation.Text = tkbOrangeDilation.Value.ToString();
        }

        private void tkbOrangeThreshold_Scroll(object sender, EventArgs e)
        {
            lblOrangeThreshold.Text = tkbOrangeThreshold.Value.ToString();
        }

        private void tkbBlueErosion_Scroll(object sender, EventArgs e)
        {
            lblBlueErosion.Text = tkbBlueErosion.Value.ToString();
        }

        private void tkbBlueDilation_Scroll(object sender, EventArgs e)
        {
            lblBlueDilation.Text = tkbBlueDilation.Value.ToString();
        }

        private void tkbBlueThreshold_Scroll(object sender, EventArgs e)
        {
            lblBlueThreshold.Text = tkbBlueThreshold.Value.ToString();
        }
    }
}

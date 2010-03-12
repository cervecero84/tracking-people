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

        #region Web Camera Calibration
        private void btnCameraCalibrate_Click(object sender, EventArgs e)
        {
            _camCalibrationState = 0;
            lblInstructions.Text = "WebCam Calibration: Click TopLeft point";
        }

        private void cameraCalibOutput_MouseClick(object sender, MouseEventArgs e)
        {
            // Select point (0,0)
            // Select point (screenWidth, 0)
            // Select point (0, screenHeight)
            // Select point (screenWidth, screenHeight)

            // Draw the calibration screen markers
            if (_camCalibrationState >= 0 && _camCalibrationState <= 3)
            {
                _cameraViewAreaGraphics.DrawEllipse(new Pen(Color.Cyan), new Rectangle(new System.Drawing.Point(e.X, e.Y), new Size(2, 2)));
            }

            switch (_camCalibrationState)
            {
                case 0:
                    camCalibrationPoints.TL.X = e.X;
                    camCalibrationPoints.TL.Y = e.Y;
                    _camCalibrationState += 1;
                    lblInstructions.Text = "WebCam Calibration: Click TopRight point";
                    break;
                case 1:
                    camCalibrationPoints.TR.X = e.X;
                    camCalibrationPoints.TR.Y = e.Y;
                    _camCalibrationState += 1;
                    lblInstructions.Text = "WebCam Calibration: Click BottomLeft point";
                    break;
                case 2:
                    camCalibrationPoints.BL.X = e.X;
                    camCalibrationPoints.BL.Y = e.Y;
                    _camCalibrationState += 1;
                    lblInstructions.Text = "WebCam Calibration: Click BottomRight point";
                    break;
                case 3:
                    camCalibrationPoints.BR.X = e.X;
                    camCalibrationPoints.BR.Y = e.Y;
                    _camCalibrationState += 1;
                    lblInstructions.Text = "WebCam Calibration: Complete";
                    // Calibration data acquired. Compute warp for camera
                    _cameraWarper.setDestination(0, 0, _screenWidth, 0, 0, _screenHeight, _screenWidth, _screenHeight);
                    _cameraWarper.setSource(camCalibrationPoints.TL.X, camCalibrationPoints.TL.Y,
                        camCalibrationPoints.TR.X, camCalibrationPoints.TR.Y,
                        camCalibrationPoints.BL.X, camCalibrationPoints.BL.Y,
                        camCalibrationPoints.BR.X, camCalibrationPoints.BR.Y);
                    _cameraWarper.computeWarp();
                    // Calculate the reverse warp matrix
                    _cameraReverseWarper.setDestination(_webCameraSrcPoints[0].X, _webCameraSrcPoints[0].Y,
                        _webCameraSrcPoints[1].X, _webCameraSrcPoints[1].Y,
                        _webCameraSrcPoints[2].X, _webCameraSrcPoints[2].Y,
                        _webCameraSrcPoints[3].X, _webCameraSrcPoints[3].Y);
                    _cameraReverseWarper.setSource(0, 0, _screenWidth, 0, 0, _screenHeight, _screenWidth, _screenHeight);
                    _cameraReverseWarper.computeWarp();

                    _calibrated = true;
                    lblInstructions.Text = "WebCam Calibration: Complete - Warp computed";
                    break;
                default:
                    if (_calibrated)
                    {
                        lblInstructions.Text = "WebCam Viewer Clicked @ " + DateTime.Now.ToLongTimeString();
                        WiimoteLib.PointF dst = _cameraWarper.warp(e.X, e.Y);
                        lblInstructions.Text += " in (" + e.X.ToString() + ", " + e.Y.ToString() + ")";
                        lblInstructions.Text += " => " + dst.ToString();
                    }
                    break;
            }
        }

        #endregion

        #region Infrared Camera Calibration
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
        #endregion

        #region Eriosion Dilation and Threshold events
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
        #endregion

        #region Camera/Video choice
        private void btnCamera_Click(object sender, EventArgs e)
        {
            if (camera != null)
            {
                camera.Dispose();
            }
            try
            {
                camera = new Capture(0);
                lblVideoSource.Text = "Live Web Camera 1";
            }
            catch (Exception)
            {
                camera = new Capture(1);
                lblVideoSource.Text = "Live Web Camera 2";
            }
            
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            String videoSourceFileName = "";
            if (ofdSourceVideo.ShowDialog() == DialogResult.OK)
            {
                videoSourceFileName = ofdSourceVideo.FileName;
                Capture tmp = camera;
                try
                {
                    tmp = new Capture(videoSourceFileName);
                }
                catch (NullReferenceException)
                {
                    // This exception happens when the file that was tried to be opened
                    // was not a readable video file
                    MessageBox.Show("Unreadable video file. No action taken.");
                }
                camera = tmp;
                lblVideoSource.Text = "Video File";
            }
        }

        private void ckbSwitchCamera_CheckedChanged(object sender, EventArgs e)
        {
            if (camera != null) camera.Dispose();
            if (ckbSwitchCamera.Checked)
            {
                camera = new Capture(1);
                lblVideoSource.Text = "Live Web Camera 2";
            }
            else
            {
                camera = new Capture(0);
                lblVideoSource.Text = "Live Web Camera 1";
            }
        }
        #endregion



    }
}

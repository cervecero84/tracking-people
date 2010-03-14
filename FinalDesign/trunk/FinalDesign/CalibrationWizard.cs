﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
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
        //Warper irToScreenWarper = new Warper();
        Warper screenToCamWarper = new Warper();
        Warper irToCamWarper = new Warper();
        int screenWidth = 1024;
        int screenHeight = 768;
        Graphics cameraViewGraphics;
        Graphics irViewGraphics;

        Image<Ycc, byte> lastSelectedImage;
        // States 0 - 3: indicate point number (TL, TR, BL, BR)
        // Anything else means program is in non-calibration mode
        int _irCalibrationState = -1;
        int _camCalibrationState = -1;
        //bool _statusWaitingForBandRegionSelection = false;
        
        Color colorUncalibrated = Color.Salmon;
        Color colorCalibrated = Color.ForestGreen;

        public CalibrationWizard(Capture c, Wiimote w, CalibrationPoints irCP, CalibrationPoints camCP, 
            ColorStateSet cs, Warper ir2S, Warper s2Cam, Warper ir2Cam,int scrW, int scrH)
        {
            InitializeComponent();
            camera = c;
            wiimote = w;
            irCalibrationPoints = irCP;
            camCalibrationPoints = camCP;
            colors = cs;
            //irToScreenWarper = ir2S;
            screenToCamWarper = s2Cam;
            irToCamWarper = ir2Cam;
            screenWidth = scrW;
            screenHeight = scrH;

            btnCameraCalibrate.BackColor = colorUncalibrated;
            btnWiimoteCalibrate.BackColor = colorUncalibrated;
            btnLearnRed.BackColor = colorUncalibrated;
            btnLearnOrange.BackColor = colorUncalibrated;
            btnLearnGreen.BackColor = colorUncalibrated;
            btnLearnBlue.BackColor = colorUncalibrated;

            Application.Idle += new EventHandler(ProcessFrame);
        }

        #region Process Frame
        private void ProcessFrame(object sender, EventArgs e)
        {
            if (cbxVideo.Checked)
            {
                //cameraCalibOutput.Image = camera.QueryFrame().Resize(cameraCalibOutput.Width, cameraCalibOutput.Height, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

                Image<Ycc, Byte> source = camera.QueryFrame().Convert<Ycc, byte>();

                // Reached the last frame in the source - happens in video files
                if (source == null)
                {
                    cbxVideo.Checked = false;
                    camera = new Capture(ofdSourceVideo.FileName);
                    source = camera.QueryFrame().Convert<Ycc, byte>();
                    if (source == null)
                    {
                        lblInstructions.Text = "Video source no longer available";
                        return;
                    }
                }


                source = source.Resize(cameraCalibOutput.Size.Width, cameraCalibOutput.Size.Height, INTER.CV_INTER_CUBIC);

                cameraCalibOutput.Image = source;

                cameraViewGraphics = Graphics.FromImage(cameraCalibOutput.Image.Bitmap);
                //irViewGraphics = Graphics.FromImage(wiiCalibOutput.SourceImage);

                cameraViewGraphics.DrawEllipse(new Pen(Color.Azure), camCalibrationPoints.TL.X, camCalibrationPoints.TL.Y, 3, 3);
                cameraViewGraphics.DrawEllipse(new Pen(Color.Azure), camCalibrationPoints.TR.X, camCalibrationPoints.TR.Y, 3, 3);
                cameraViewGraphics.DrawEllipse(new Pen(Color.Azure), camCalibrationPoints.BL.X, camCalibrationPoints.BL.Y, 3, 3);
                cameraViewGraphics.DrawEllipse(new Pen(Color.Azure), camCalibrationPoints.BR.X, camCalibrationPoints.BR.Y, 3, 3);


                cameraViewGraphics.DrawEllipse(new Pen(Color.Salmon), irCalibrationPoints.TL.X, irCalibrationPoints.TL.Y, 3, 3);
                cameraViewGraphics.DrawEllipse(new Pen(Color.Salmon), irCalibrationPoints.TR.X, irCalibrationPoints.TR.Y, 3, 3);
                cameraViewGraphics.DrawEllipse(new Pen(Color.Salmon), irCalibrationPoints.BL.X, irCalibrationPoints.BL.Y, 3, 3);
                cameraViewGraphics.DrawEllipse(new Pen(Color.Salmon), irCalibrationPoints.BR.X, irCalibrationPoints.BR.Y, 3, 3);

                if (!ckbDilate.Checked) colors.Red.DilationValue = colors.Green.DilationValue = colors.Yellow.DilationValue = colors.Blue.DilationValue = 0;
                if (!ckbErosion.Checked) colors.Red.ErosionValue = colors.Green.ErosionValue = colors.Yellow.ErosionValue = colors.Blue.ErosionValue = 0;
                if (!ckbThreshold.Checked) colors.Red.ThresholdValue = colors.Green.ThresholdValue = colors.Yellow.ThresholdValue = colors.Blue.ThresholdValue = 0;
                

                Image<Hsv, Byte> result = new Image<Hsv, byte>(source.Size);
                if (cbxShowBlue.Checked) result = result.Or(colors.Blue.GetProbabilityImage(source, new Hsv(0,4,1)));
                if (cbxShowOrange.Checked) result = result.Or(colors.Yellow.GetProbabilityImage(source, new Hsv(0.1, 1, 1)));
                if (cbxShowRed.Checked) result = result.Or(colors.Red.GetProbabilityImage(source, new Hsv(0, 1, 1)));
                if (cbxShowGreen.Checked) result = result.Or(colors.Green.GetProbabilityImage(source, new Hsv(0.3, 1, 1)));
                imBoxProbImages.Image = result;
            }
            
            

        }
        #endregion

        #region Camera Output Mouse Cick
        private void cameraCalibOutput_MouseClick(object sender, MouseEventArgs e)
        {
            lblInstructions.Text = "You clicked!";
            // Select point (0,0)
            // Select point (screenWidth, 0)
            // Select point (0, screenHeight)
            // Select point (screenWidth, screenHeight)

            // Draw the calibration screen markers
            if (_camCalibrationState >= 0 && _camCalibrationState <= 3)
            {
                //_cameraViewAreaGraphics.DrawEllipse(new Pen(Color.Cyan), new Rectangle(new System.Drawing.Point(e.X, e.Y), new Size(2, 2)));
            }

            switch (_camCalibrationState)
            {
                case 0:
                    camCalibrationPoints.TL = new System.Drawing.PointF(e.X, e.Y);
                    _camCalibrationState += 1;
                    lblInstructions.Text = "WebCam Calibration: Click TopRight point";
                    break;
                case 1:
                    camCalibrationPoints.TR = new System.Drawing.PointF(e.X, e.Y);
                    _camCalibrationState += 1;
                    lblInstructions.Text = "WebCam Calibration: Click BottomLeft point";
                    break;
                case 2:
                    camCalibrationPoints.BL = new System.Drawing.PointF(e.X, e.Y);
                    _camCalibrationState += 1;
                    lblInstructions.Text = "WebCam Calibration: Click BottomRight point";
                    break;
                case 3:
                    camCalibrationPoints.BR = new System.Drawing.PointF(e.X, e.Y);
                    _camCalibrationState += 1;
                    lblInstructions.Text = "WebCam Calibration: Complete";
                    btnCameraCalibrate.BackColor = colorCalibrated;
                    btnSaveCalibration.BackColor = colorUncalibrated;
                    // Calibration data acquired. Compute warp for camera
                    //_cameraWarper.setDestination(0, 0, _screenWidth, 0, 0, _screenHeight, _screenWidth, _screenHeight);
                    //_cameraWarper.setSource(camCalibrationPoints.TL.X, camCalibrationPoints.TL.Y,
                    //    camCalibrationPoints.TR.X, camCalibrationPoints.TR.Y,
                    //    camCalibrationPoints.BL.X, camCalibrationPoints.BL.Y,
                    //    camCalibrationPoints.BR.X, camCalibrationPoints.BR.Y);
                    //_cameraWarper.computeWarp();
                    // Calculate the reverse warp matrix
                    screenToCamWarper.setDestination(camCalibrationPoints.TL, camCalibrationPoints.TR, camCalibrationPoints.BL, camCalibrationPoints.BR);
                    screenToCamWarper.setSource(0, 0, screenWidth, 0, 0, screenHeight, screenWidth, screenHeight);
                    screenToCamWarper.computeWarp();

                    //_calibrated = true;
                    lblInstructions.Text = "WebCam Calibration: Complete - Warp computed";
                    break;
                default:
                    //    if (_camCalibrationState == 4)
                    //    {
                    //        lblInstructions.Text = "WebCam Viewer Clicked @ " + DateTime.Now.ToLongTimeString();
                    //        WiimoteLib.PointF dst = screenToCamWarper.warp(e.X, e.Y);
                    //        lblInstructions.Text += " in (" + e.X.ToString() + ", " + e.Y.ToString() + ")";
                    //        lblInstructions.Text += " => " + dst.ToString();
                    //    }
                    break;
            }

        }

        private void cameraCalibOutput_MouseUp(object sender, MouseEventArgs e)
        {
            if (cameraCalibOutput.SelectedArea.Size.Height >= 3 && cameraCalibOutput.SelectedArea.Size.Width >= 3)
            {
                lastSelectedImage = new Image<Ycc, byte>(cameraCalibOutput.SelectedArea.Size);
                CvInvoke.cvGetSubRect(cameraCalibOutput.Image.Ptr, lastSelectedImage.Ptr, cameraCalibOutput.SelectedArea);
                imBoxSelection.Image = lastSelectedImage.Resize(imBoxSelection.Width, imBoxSelection.Height);
            }
        }
        #endregion

        #region Web Camera Calibration
        private void btnCameraCalibrate_Click(object sender, EventArgs e)
        {
            _camCalibrationState = 0;
            
            lblInstructions.Text = "WebCam Calibration: Click TopLeft point";
            
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
                    irCalibrationPoints.TL = new System.Drawing.PointF(e.X, e.Y);
                    _irCalibrationState += 1;
                    lblInstructions.Text = "InfraRed Calibration: Click TopRight point";
                    break;
                case 1:
                    irCalibrationPoints.TR = new System.Drawing.PointF(e.X, e.Y);
                    _irCalibrationState += 1;
                    lblInstructions.Text = "InfraRed Calibration: Click BottomLeft point";
                    break;
                case 2:
                    irCalibrationPoints.BL = new System.Drawing.PointF(e.X, e.Y);
                    _irCalibrationState += 1;
                    lblInstructions.Text = "InfraRed Calibration: Click BottomRight point";
                    break;
                case 3:
                    irCalibrationPoints.BR = new System.Drawing.PointF(e.X, e.Y);
                    _irCalibrationState += 1;
                    // Save a copy of the image with the calibration markers - create a new object using Clone
                    lblInstructions.Text = "IR Calibration: Complete";
                    btnWiimoteCalibrate.BackColor = colorCalibrated;
                    btnSaveCalibration.BackColor = colorUncalibrated;
                    // Calibration data acquired. Compute warp
                    irToCamWarper.setDestination(camCalibrationPoints.TL, camCalibrationPoints.TR, camCalibrationPoints.BL, camCalibrationPoints.BR);
                    irToCamWarper.setSource(irCalibrationPoints.TL, irCalibrationPoints.TR, irCalibrationPoints.BL, irCalibrationPoints.BR);
                    irToCamWarper.computeWarp();

                    lblInstructions.Text = "IR Calibration: Complete - Warp computed";
                    break;
                default:
                    if (_irCalibrationState == 4)
                    {
                        lblInstructions.Text = "IR Clicked @ " + DateTime.Now.ToShortTimeString();
                        // Compute normalized coordinate
                        WiimoteLib.PointF dst = irToCamWarper.warp(e.X, e.Y);
                        lblInstructions.Text += " in (" + e.X.ToString() + ", " + e.Y.ToString() + ")";
                        lblInstructions.Text += " => " + dst.ToString();

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

        #region Color Learning
        private void btnLearnRed_Click(object sender, EventArgs e)
        {
            lblInstructions.Text = "Used selection to calculate Red properties";
            btnLearnRed.BackColor = colorCalibrated;
            btnSaveCalibration.BackColor = colorUncalibrated;

            colors.Red.Learn(lastSelectedImage.Convert<Ycc, byte>());
            //_statusWaitingForBandRegionSelection = true;
            //cbxVideo.Checked = false;
            //colors.Red.CbHist.

        }

        private void btnLearnGreen_Click(object sender, EventArgs e)
        {
            lblInstructions.Text = "Used selection to calculate Green properties";
            btnLearnGreen.BackColor = colorCalibrated;
            btnSaveCalibration.BackColor = colorUncalibrated;

            colors.Green.Learn(lastSelectedImage.Convert<Ycc, byte>());
        }

        private void btnLearnOrange_Click(object sender, EventArgs e)
        {
            lblInstructions.Text = "Used selection to calculate Orange properties";
            btnLearnOrange.BackColor = colorCalibrated;
            btnSaveCalibration.BackColor = colorUncalibrated;

            colors.Yellow.Learn(lastSelectedImage.Convert<Ycc, byte>());
        }

        private void btnLearnBlue_Click(object sender, EventArgs e)
        {
            lblInstructions.Text = "Used selection to calculate Blue properties";
            btnLearnBlue.BackColor = colorCalibrated;
            btnSaveCalibration.BackColor = colorUncalibrated;

            colors.Blue.Learn(lastSelectedImage.Convert<Ycc, byte>());
        }

        #endregion

        private void cameraCalibOutput_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            lblInstructions.Text = "Double click fired";
        }

        #region Save Calibration
        private void btnSaveCalibration_Click(object sender, EventArgs e)
        {
            btnSaveCalibration.BackColor = colorCalibrated;

            colors.Red.ErosionValue = tkbRedErosion.Value;
            colors.Red.DilationValue = tkbRedDilation.Value;
            colors.Red.ThresholdValue = tkbRedThreshold.Value;

            colors.Green.ErosionValue = tkbGreenErosion.Value;
            colors.Green.DilationValue = tkbGreenDilation.Value;
            colors.Green.ThresholdValue = tkbGreenThreshold.Value;

            colors.Yellow.ErosionValue = tkbOrangeErosion.Value;
            colors.Yellow.DilationValue = tkbOrangeDilation.Value;
            colors.Yellow.ThresholdValue = tkbOrangeThreshold.Value;

            colors.Blue.ErosionValue = tkbBlueErosion.Value;
            colors.Blue.DilationValue = tkbBlueDilation.Value;
            colors.Blue.ThresholdValue = tkbBlueThreshold.Value;

        }
        #endregion



    }
}
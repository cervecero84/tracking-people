﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace EmguCVTest
{
    /// <summary>
    /// Different types of video sources
    /// Camera: Source of the video is camera
    /// Video: Source of the video is a video file
    /// </summary>
    enum VideoSource { Camera = 0, Video = 1 };

    public partial class Form1 : Form
    {
        Image<Gray, Byte> _backgroundImage;
        Image<Gray, Byte> _lastFrame;
        int _frameWidth = 400;
        int _frameHeight = 300;

        // Background adaptation rate
        double _backgroundAdaptionRate = 0.35;
        // Should background adaptation be done
        bool _adaptiveBackground = true;

        // Specify video source
        VideoSource _source = VideoSource.Camera;
        // If video source is "Video", where is the file located
        //String _videoName = "TestVideos\\color_test1.avi";
        String _videoName = "C:\\Users\\darthmimi\\Documents\\Visual Studio 2008\\Projects\\EmguCVTest\\EmguCVTest\\EmguCVTest\\TestVideos\\color_test1.avi";

        Capture _capture;

        public Form1()
        {
            // Initialize the components
            InitializeComponent();
            _backgroundImage = new Image<Gray, byte>(_frameWidth, _frameHeight);
            InitializeCamera();
            tbrBgAdaptationRate.Value = (int)Math.Round(_backgroundAdaptionRate*100);
            lblBgAdaptationRate.Text = "Rate: " + _backgroundAdaptionRate.ToString();
            updateAPButtonText();
        }

        /// <summary>
        /// This is the function that updates the difference frames, performs
        /// the thresholding on the difference and then does erosion to get rid
        /// of camera noise. This is where all the work is initiated/done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessFrame(object sender, EventArgs e)
        {
            // Get the current frame from the camera - color and gray
            Image<Bgr, Byte> originalFrame = _capture.QueryFrame();

            // This usually occurs when using a video file - after the last frame is read
            // the next frame is null
            if (originalFrame == null)
            {
                // Reset the camera since no frame was captured - for videos, restart the video playback
                ResetCamera();
                originalFrame = _capture.QueryFrame();
            }

            Image<Bgr, Byte> image = originalFrame.Resize(_frameWidth, _frameHeight);
            Image<Gray, Byte> frame = image.Convert<Gray, Byte>();

            // Perform differencing on them to find the "new introductions to the background" and "motions"
            Image<Gray, Byte> BgDifference = new Image<Gray, byte>(_frameWidth, _frameHeight);
            Image<Gray, Byte> FrameDifference = new Image<Gray, byte>(_frameWidth, _frameHeight);
            CvInvoke.cvAbsDiff(_backgroundImage, frame, BgDifference);
            CvInvoke.cvAbsDiff((_lastFrame == null) ? frame : _lastFrame, frame, FrameDifference);

            // Perform thresholding to remove noise and boost "new introductions"
            Image<Gray, Byte> thresholded = new Image<Gray, byte>(_frameWidth, _frameHeight);
            CvInvoke.cvThreshold(BgDifference, thresholded, 20, 255, THRESH.CV_THRESH_BINARY);

            // Perform erosion to remove camera noise
            Image<Gray, Byte> eroded = new Image<Gray, byte>(_frameWidth, _frameHeight);
            CvInvoke.cvErode(thresholded, eroded, IntPtr.Zero, 2);

            // Takes the thresholded image and looks for squares and draws the squares out on top of the current frame
            drawBoxes(eroded, image);

            // Put the captured frame in the imagebox
            capturedImageBox.Image = image;
            // Store the current frame in the _lastFrame variable - it becomes the last frame now
            _lastFrame = image.Convert<Gray, Byte>();

            // Draw the frame-to-frame difference (motion) on to the imgImageBox image box
            imgImageBox.Image = FrameDifference;

            // Draw the thresholded image in the motionImageBox image box - so that we can view it
            motionImageBox.Image = eroded;

            // Move the background close to the current frame
            if (_adaptiveBackground == true)
            {
                Image<Gray, Byte> newBackground = new Image<Gray, byte>(_frameWidth, _frameHeight);
                MoveToward(ref _backgroundImage, ref frame, ref newBackground, _backgroundAdaptionRate);
                _backgroundImage = newBackground;
            }
            grayImageBox.Image = _backgroundImage;
        }
        private void SkinLikelihood(object sender, EventArgs e)
        {
            // Get the current frame from the camera - color and gray
            Image<Bgr, Byte> originalFrame = _capture.QueryFrame();
            
            // This usually occurs when using a video file - after the last frame is read
            // the next frame is null
            if (originalFrame == null)
            {
                // Reset the camera since no frame was captured - for videos, restart the video playback
                ResetCamera();
                originalFrame = _capture.QueryFrame();
            }

            #region Covariance Matrix

            double CbMean = 0.386090697709818;
            double CrMean = 0.606079492993334;

            Matrix<Double>E=new Matrix<double>(2,1);
            E[0,0]=CbMean; E[1,0]=CrMean;

            //covariance matrix taken from matlab skin detection demo mdl
            double K1 = 4662.55882477405;
            double K2 = 4050.89761683218;
            double K3 = 4050.89761683218;
            double K4 = 5961.62013605372;

           


            /*double K1 = 1832.85009482496;	
            double K2 = 2250.67197529579;	
            double K3 = 2250.67197529579;
            double K4 = 6865.825444635298;*/
            
            
            Matrix<double>K=new Matrix<double>(2,2);
            K [0,0]=K1;
            K [1,0]=K2;
            K [0,1]=K3;
            K [0,0]=K4;


            #endregion Covariance Matrix

            //capture image
            Image<Bgr, Byte> image = originalFrame.Resize(_frameWidth, _frameHeight);
            capturedImageBox.Image = image;

            //Image<Bgr, Byte> smoothImage = new Image<Bgr, byte>(_frameWidth, _frameHeight);
            //CvInvoke.cvSmooth(image, smoothImage, SMOOTH_TYPE.CV_BILATERAL, 7, 7, 0.5, 0.5);
           
            //convert to YCbCr colourspace
            Image<Ycc, Byte> yccImage = new Image<Ycc, byte>(_frameWidth, _frameHeight);
            CvInvoke.cvCvtColor(image, yccImage, COLOR_CONVERSION.CV_BGR2YCrCb);

            Image<Gray, Byte> yccBlob = new Image<Gray, Byte>(_frameWidth, _frameHeight);
            
            //Image<Gray, Byte>[] channels = yccImage.Split();
            //Image<Gray, Double> Cr = channels[1].Convert<Gray, Double>();
            //Image<Gray, Double> Cb = channels[2].Convert<Gray, Double>();
            //Matrix<Double> x =new Matrix<double>(2,1);

            //calculation of the likelihood of pixel being skin
            for (int j = 0; j < yccImage.Width; j++)
            {
                for (int i = 0; i < yccImage.Height; i++)
                {
                    double Cb = yccImage[i, j].Cb / 255.0;
                    double Cr = yccImage[i, j].Cr / 255.0;
                    Cb -= CbMean;
                    Cr -= CrMean;
                    //x[0,0]= Cb[i,j].Intensity/255;
                    //x[1,0]= Cr[i,j].Intensity/255;
                    //double dist = CvInvoke.cvMahalanobis(x, E, K);
                    double CbDist = Cb * (K1 * Cb + K3 * Cr);
                    double CrDist = Cr * (K2 * Cb + K4 * Cr);
                    double dist = CbDist + CrDist;
                    yccBlob[i, j] = new Gray(dist);
                }
            }
            
            //display likelihood of skin in grayImageBox
            grayImageBox.Image = yccBlob;

            Image<Gray, Byte> dilated = yccBlob.Dilate(1);

            //inverse thresholding the likelihood to get a binary image
            Image<Gray, Byte> thresholded = dilated.ThresholdBinaryInv(new Gray(dilated.GetAverage().Intensity*0.25),new Gray(255));
            //Double minVal, maxVal;
            //Point minLoc, maxLoc;



            // Perform erosion to remove camera noise
            Image<Gray, Byte> eroded = new Image<Gray, Byte>(_frameWidth, _frameHeight);
            CvInvoke.cvErode(thresholded, eroded, IntPtr.Zero, 2);

            motionImageBox.Image = eroded;

        }


        private void SkinThresh(object sender, EventArgs e)
        {
            // Get the current frame from the camera - color and gray
            Image<Bgr, Byte> originalFrame = _capture.QueryFrame();

            // This usually occurs when using a video file - after the last frame is read
            // the next frame is null
            if (originalFrame == null)
            {
                // Reset the camera since no frame was captured - for videos, restart the video playback
                ResetCamera();
                originalFrame = _capture.QueryFrame();
            }

            Image<Bgr, Byte> image = originalFrame.Resize(_frameWidth, _frameHeight);
            capturedImageBox.Image = image;

            motionImageBox.Image = SkinDetect(image);

        }

        public Image<Gray, byte> SkinDetect(Image<Bgr, byte> Img)
        {
            Image<Gray, byte> R = new Image<Gray, byte>(Img.Width, Img.Height);
            Image<Gray, byte> G = new Image<Gray, byte>(Img.Width, Img.Height);
            Image<Gray, byte> B = new Image<Gray, byte>(Img.Width, Img.Height);

            CvInvoke.cvSplit(Img, B, G, R, IntPtr.Zero);

            Image<Gray, byte> S = new Image<Gray, byte>(Img.Width, Img.Height);
            Image<Gray, byte> skin = new Image<Gray, byte>(Img.Width, Img.Height);

            /* convert RGB color space to IRgBy color space using this formula:
            http://www.cs.hmc.edu/~fleck/naked-skin.html
            I = L(G)
            Rg = L(R) - L(G)
            By = L(B) - [L(G) +L(R)] / 2
            					
            to calculate the hue:
            hue = atan2(Rg,By) * (180 / 3.141592654f)
            Saturation = sqrt(Rg^2 + By^2)
            */
           
            for (int j = 0; j < skin.Width; j++)
            {
                for (int i = 0; i < skin.Height; i++)
                {
                    //double I_val = (Math.Log(R[i, j].Intensity) + Math.Log(B[i, j].Intensity) + Math.Log(G[i, j].Intensity)) / 3;
                    //I[i, j] = new Gray(G[i, j].Intensity);

                    double Rg = Math.Log(R[i, j].Intensity) - Math.Log(G[i, j].Intensity);
                    double By = Math.Log(B[i, j].Intensity) - (Math.Log(G[i, j].Intensity) + Math.Log(R[i, j].Intensity)) / 2;
                    
                    double hue_val= Math.Atan2(Rg, By) * (180 / Math.PI);
                    double sat_val = Math.Sqrt(Rg*Rg+ By *By);


                    if (sat_val * 255 >= 20 && sat_val * 255 <= 130 && hue_val >= 110 && hue_val <= 170) //I simplified the naked people filter's two overlapping criteria
					{
                        S[i, j] = new Gray(255);
					} 
					else
					{
                        S[i, j] = new Gray(0);
					}
                }
            }


            //skin = S.Erode(1);
            skin = S.SmoothMedian(15); // median filter is used so that the image will be kept black and white

            return skin;

        }


        private void btnBgCapture_Click(object sender, EventArgs e)
        {
            // Initialize in case it was destroyed somewhere else
            InitializeCamera();

            if (_source == VideoSource.Camera)
            {
                // Warm up the camera - let it take 100 frames, and finish its auto-adjustment
                for (int i = 0; i < 100; i++)
                {
                    _capture.QueryGrayFrame();
                }
            }
            
            // Actual background capture
            _backgroundImage = _capture.QueryGrayFrame().Resize(_frameWidth, _frameHeight);
            backgroundImage.Image = _backgroundImage.Resize(backgroundImage.Width, backgroundImage.Height);
            MessageBox.Show("Background capture complete");
        }

        /// <summary>
        /// Function takes the source image, and the overlay image and the resulting image. The source image
        /// is moved towards making it the overlay image using a factor of movementFactor. movementFactor = 1
        /// means make the source image the overlay image. This works by: 
        /// res = src + movementFactor * (ovr - src)
        /// </summary>
        /// <param name="src">Source Image - the original image</param>
        /// <param name="ovr">Overlay Image - the new image that you want to change the source to</param>
        /// <param name="res">The resulting image (passed by reference)</param>
        /// <param name="movementFactor">The amount of change of source towards overlay. Range 
        /// is 0 to 1. 1 means source becomes overlay.</param>
        private void MoveToward(ref Image<Gray, Byte> src, ref Image<Gray, Byte> ovr, ref Image<Gray, Byte> res, double movementFactor)
        {
            // If movement factor is in an invalid range, default to 1
            if (movementFactor < 0 || movementFactor > 1)
            {
                movementFactor = 1;
            }

            CvInvoke.cvAddWeighted(src, 1.0 - movementFactor, ovr, movementFactor, 0, res);
        }

        /// <summary>
        /// Initializes the camera resource, *if it does not currently exist*
        /// </summary>
        private void InitializeCamera()
        {
            if (_capture == null)
            {
                ResetCamera();
            }
        }

        /// <summary>
        /// Starts/restarts the capture source - for both video and camera
        /// </summary>
        //private void ResetCamera()
        //{
        //    if (_source == VideoSource.Camera)
        //    {
        //        _capture = new Capture();
        //        _capture.FlipHorizontal = true;
        //    }
        //}
        private void ResetCamera()
        {
            if (_source == VideoSource.Camera)
            {
                _capture = new Capture();
                _capture.FlipHorizontal = true;
            }
            else
            {
                _capture = new Capture(_videoName);
            }
        }

        private void btnBeginDifferencing_Click(object sender, EventArgs e)
        {
            // Initialize the camera - in case it was destroyed somewhere else
            InitializeCamera();
            if (_capture != null)
            {
                Application.Idle -= new EventHandler(SkinThresh);
                // Unregister the event handler *in case* it was already registed (reclick of this button)
                Application.Idle -= new EventHandler(ProcessFrame);
                // Register the event handler
                Application.Idle += new EventHandler(ProcessFrame);
            }
        }

        private void btnShowBackground_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer();
            // Show the background image
            viewer.Image = _backgroundImage;
            backgroundImage.Image = _backgroundImage.Resize(177, 177);

            viewer.ShowDialog();
        }

        /// <summary>
        /// Function takes in a grayscale image and a colour image. Rectangles are located
        /// in the grayscale image (this is usually a thresholded image - so shapes are 
        /// strongly visible) and borders around them are drawn on the same coordinates in
        /// the colour image.
        /// </summary>
        /// <param name="img">Grayscale image where rectangles would be located</param>
        /// <param name="original">Original (colour) image where the rectangle borders will be drawn</param>
        private void drawBoxes(Emgu.CV.Image<Gray, Byte> img, Emgu.CV.Image<Bgr, Byte> original)
        {

            Gray cannyThreshold = new Gray(180);
            Gray cannyThresholdLinking = new Gray(120);
            Gray circleAccumulatorThreshold = new Gray(120);

            Image<Gray, Byte> cannyEdges = img.Canny(cannyThreshold, cannyThresholdLinking);
            LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                1, //Distance resolution in pixel-related units
                Math.PI / 45.0, //Angle resolution measured in radians.
                20, //threshold
                30, //min Line width
                10 //gap between lines
                )[0]; //Get the lines from the first channel


            #region Find rectangles
            List<MCvBox2D> boxList = new List<MCvBox2D>();

            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
                for (Contour<Point> contours = cannyEdges.FindContours(); contours != null; contours = contours.HNext)
                {
                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

                    if (contours.Area > 250) //only consider contours with area greater than 250
                    {
                        if (currentContour.Total == 4) //The contour has 4 vertices.
                        {
                            #region determine if all the angles in the contour are within the range of [80, 100] degree
                            bool isRectangle = true;
                            Point[] pts = currentContour.ToArray();
                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                            for (int i = 0; i < edges.Length; i++)
                            {
                                double angle = Math.Abs(
                                   edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                if (angle < 80 || angle > 100)
                                {
                                    isRectangle = false;
                                    break;
                                }
                            }
                            #endregion

                            if (isRectangle) boxList.Add(currentContour.GetMinAreaRect());
                        }
                    }
                }
            #endregion

            #region draw rectangles
            Image<Bgr, Byte> rectangleImage = new Image<Bgr, byte>(img.Width, img.Height);
            foreach (MCvBox2D box in boxList)
            {
                rectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
                original.Draw(box, new Bgr(Color.DarkOrange), 2);
            }
            
            capturedImageBox.Image = rectangleImage;
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeCamera();

            Image<Gray, Byte> frame = _capture.QueryGrayFrame().Resize(_frameWidth,_frameHeight);
            Image<Gray, Byte> difference = new Image<Gray, byte>(_frameWidth, _frameHeight);
            CvInvoke.cvAbsDiff(_backgroundImage, frame, difference);
            Image<Gray, Byte> thresholded = new Image<Gray, byte>(_frameWidth, _frameHeight);
            thresholded = difference.ThresholdBinary(new Gray(20), new Gray(255));

            //Image<Bgr, Byte> test = new Image<Bgr, byte>("pic3.png");
            
            drawBoxes(thresholded,frame.Convert<Bgr,Byte>());
        }

        private void tbrBgAdaptationRate_Scroll(object sender, EventArgs e)
        {
            _backgroundAdaptionRate = (double)tbrBgAdaptationRate.Value / 100;
            lblBgAdaptationRate.Text = "Rate: " + _backgroundAdaptionRate.ToString();
        }

        private void btnAdaptiveBackground_Click(object sender, EventArgs e)
        {
            _adaptiveBackground = !(_adaptiveBackground);
            updateAPButtonText();
        }

        private void updateAPButtonText()
        {
            if (_adaptiveBackground)
            {
                btnAdaptiveBackground.Text = "TURN OFF AP";
            }
            else
            {
                btnAdaptiveBackground.Text = "TURN ON AP";
            }
        }

        private void DetectSkin_Click(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(ProcessFrame);
            // Unregister the event handler *in case* it was already registed (reclick of this button)
            Application.Idle -= new EventHandler(SkinThresh);
            // Register the event handler
            Application.Idle += new EventHandler(SkinThresh);
 
        }

        private void btnAffineTranform_Click(object sender, EventArgs e)
        {
            AffineTransform form = new AffineTransform(_capture);
            form.ShowDialog();
        }

        private void btnColorSample_Click(object sender, EventArgs e)
        {
            ColorSampleForm form = new ColorSampleForm(_capture);
            form.ShowDialog();
        }
    }
}

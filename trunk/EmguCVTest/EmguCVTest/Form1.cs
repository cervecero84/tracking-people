using System;
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
        String _videoName = "TestVideos\\test_mod.avi";

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
            Image<Gray, Byte> thresholded = new Image<Gray,byte>(_frameWidth, _frameHeight);
            CvInvoke.cvThreshold(BgDifference, thresholded, 20, 255, THRESH.CV_THRESH_BINARY);
            
            // Perform erision to remove camera noise
            Image<Gray, Byte> eroded = new Image<Gray, byte>(_frameWidth, _frameHeight);
            CvInvoke.cvErode(thresholded, eroded, IntPtr.Zero, 2);
            
            // Takes the thresholded image and looks for squares and draws the squares out on top of the current frame
            drawBoxes(eroded,image);
            
            // Put the captured frame in the imagebox
            capturedImageBox.Image = image;
            // Store the current frame in the _lastFrame variable - it becomes the last frame now
            _lastFrame = image.Convert<Gray,Byte>();

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
            _backgroundImage = _capture.QueryGrayFrame().Resize(_frameWidth,_frameHeight);
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
            backgroundImage.Image = _backgroundImage.Resize(177,132);

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
        private void drawBoxes(Emgu.CV.Image<Gray, Byte> img,Emgu.CV.Image<Bgr,Byte> original)
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

            Image<Bgr, Byte> test = new Image<Bgr, byte>("pic3.png");
            
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

        private void btnAffineTranform_Click(object sender, EventArgs e)
        {
            AffineTransform form = new AffineTransform(_capture);
            form.ShowDialog();
        }
    }
}

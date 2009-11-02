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
    public partial class Form1 : Form
    {
        Image<Gray, Byte> _backgroundImage;
        Image<Bgr, Byte> _sqImage;
        int _frameWidth = 400;
        int _frameHeight = 300;
      
        Capture _capture;
        // One instance of the difference viewer
        ImageViewer _differenceViewer;

        public Form1()
        {
            // Initialize the components
            InitializeComponent();
            _backgroundImage = new Image<Gray, byte>(_frameWidth, _frameHeight);
            _differenceViewer = new ImageViewer();
            InitializeCamera();
        }

        // This is the function that updates the difference frames and performs
        // the thresholding on the difference
        private void ProcessFrame(object sender, EventArgs e)
        {
            Point tableTopL = new Point(100, 200);
            Size tableDim = new Size(50, 40);
            
            Image<Bgr, Byte> image = _capture.QuerySmallFrame().PyrUp().Resize(_frameWidth, _frameHeight); //reduce noise from the image
            
            Image<Gray, Byte> frame = _capture.QueryGrayFrame().Resize(_frameWidth, _frameHeight);
            Image<Gray, Byte> difference = new Image<Gray, byte>(_frameWidth, _frameHeight);
            CvInvoke.cvAbsDiff(_backgroundImage, frame, difference);
            Image<Gray, Byte> thresholded = new Image<Gray,byte>(_frameWidth, _frameHeight);
            thresholded = difference.ThresholdBinary(new Gray(20), new Gray(255));
            Rectangle myRectangle = new Rectangle(tableTopL, tableDim);
            //thresholded.Draw(myRectangle, new Gray(255), 2);

            Image<Bgr, Byte> thresholdedPass = thresholded.Convert<Bgr, Byte>();

            drawBoxes(thresholdedPass,image);


         //_differenceViewer.Image = thresholded;
            capturedImageBox.Image = image;

            //Detecting Squares

            //Image<Bgr, Byte> img = image.Resize(400, 400, true);
            //drawBoxes(_sqImage);

            motionImageBox.Image = thresholded;
        }

        private void btnBgCapture_Click(object sender, EventArgs e)
        {
            // Initialize in case it was destroyed somewhere else
            //new comment for svn conflict testing
            InitializeCamera();
            MessageBox.Show("Background capture will happen 5s after you click OK");
            // Warm up the camera - let it take 100 frames, and finish its auto-adjustment
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
                _capture.QueryGrayFrame();
            }
            // Actual background capture
            _backgroundImage = _capture.QueryGrayFrame().Resize(_frameWidth,_frameHeight);
            backgroundImage.Image = _backgroundImage.Resize(177, 177);
            MessageBox.Show("Background capture complete");
        }

        // Initializes the camera resource, if it does not currently exist
        private void InitializeCamera()
        {
            if (_capture == null)
            {
                _capture = new Capture();
                _capture.FlipHorizontal = true;
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

            //_differenceViewer.ShowDialog();    // show the image viewer
        }

        private void btnShowBackground_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer();
            // Show the background image
            viewer.Image = _backgroundImage;
            backgroundImage.Image = _backgroundImage.Resize(177,177);

            viewer.ShowDialog();
        }

        private void drawBoxes(Emgu.CV.Image<Bgr, Byte> img,Emgu.CV.Image<Bgr,Byte> original)
        {

            Gray cannyThreshold = new Gray(180);
            Gray cannyThresholdLinking = new Gray(120);
            Gray circleAccumulatorThreshold = new Gray(120);

            //Image<Bgr, Byte> img = image.Resize(400, 400, true);
            Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();
            grayImageBox.Image = gray;


            CircleF[] circles = gray.HoughCircles(
                cannyThreshold,
                circleAccumulatorThreshold,
                5.0, //Resolution of the accumulator used to detect centers of the circles
                10.0, //min distance 
                5, //min radius
                0 //max radius
                )[0]; //Get the circles from the first channel

            Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
            LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                1, //Distance resolution in pixel-related units
                Math.PI / 45.0, //Angle resolution measured in radians.
                20, //threshold
                30, //min Line width
                10 //gap between lines
                )[0]; //Get the lines from the first channel


            #region Find triangles and rectangles
            List<Triangle2DF> triangleList = new List<Triangle2DF>();
            List<MCvBox2D> boxList = new List<MCvBox2D>();

            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
                for (Contour<Point> contours = cannyEdges.FindContours(); contours != null; contours = contours.HNext)
                {
                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

                    if (contours.Area > 250) //only consider contours with area greater than 250
                    {
                        if (currentContour.Total == 3) //The contour has 3 vertices, it is a triangle
                        {
                            Point[] pts = currentContour.ToArray();
                            triangleList.Add(new Triangle2DF(
                               pts[0],
                               pts[1],
                               pts[2]
                               ));
                        }
                        else if (currentContour.Total == 4) //The contour has 4 vertices.
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


            imgImageBox.Image = img;


            #region draw triangles and rectangles
            Image<Bgr, Byte> triangleRectangleImage = img.CopyBlank();
            foreach (Triangle2DF triangle in triangleList)
            {
                triangleRectangleImage.Draw(triangle, new Bgr(Color.DarkBlue), 2);
            }
            foreach (MCvBox2D box in boxList)
            {
                triangleRectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
                original.Draw(box, new Bgr(Color.DarkOrange), 2);
            }
            imgImageBox.Image = triangleRectangleImage;
            capturedImageBox.Image = triangleRectangleImage;
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeCamera();

                //_capture.QueryGrayFrame();


            //_sqImage = _capture.QuerySmallFrame().PyrUp();

            Image<Gray, Byte> frame = _capture.QueryGrayFrame().Resize(_frameWidth,_frameHeight);
            Image<Gray, Byte> difference = new Image<Gray, byte>(_frameWidth, _frameHeight);
            CvInvoke.cvAbsDiff(_backgroundImage, frame, difference);
            Image<Gray, Byte> thresholded = new Image<Gray, byte>(_frameWidth, _frameHeight);
            thresholded = difference.ThresholdBinary(new Gray(20), new Gray(255));

            //thresholded.Save("thresholded.png");

            //fileNameTextBox.Text = "pic3.png";
            Image<Bgr, Byte> test = new Image<Bgr, byte>("pic3.png");
            //Emgu.CV.Image<Bgr, Byte> test = new Image<Bgr,byte> (pic3.png

            Image<Bgr, Byte> thresholdedPass = thresholded.Convert<Bgr,Byte>();

            drawBoxes(thresholdedPass,frame.Convert<Bgr,Byte>());
            //_sqImage.Save("Test.jpg");
        }
    }
}

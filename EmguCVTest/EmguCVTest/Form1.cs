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
        // One instance of the capture resource
        Capture _capture;
        // One instance of the difference viewer
        ImageViewer _differenceViewer;

        public Form1()
        {
            InitializeComponent();
            // Initialize the components
            _backgroundImage = new Image<Gray, byte>(640, 480);
            _differenceViewer = new ImageViewer();
            InitializeCamera();
        }

        // This is the function that updates the difference frames and performs
        // the thresholding on the difference
        private void ProcessFrame(object sender, EventArgs e)
        {
            Image<Gray, Byte> frame = _capture.QueryGrayFrame();
            Image<Gray, Byte> difference = new Image<Gray, byte>(640, 480);
            CvInvoke.cvAbsDiff(_backgroundImage, frame, difference);
            Image<Gray, Byte> thresholded = new Image<Gray,byte>(640, 480);
            thresholded = difference.ThresholdBinary(new Gray(20), new Gray(255));
            _differenceViewer.Image = thresholded;
        }

        private void btnBgCapture_Click(object sender, EventArgs e)
        {
            // Initialize in case it was destroyed somewhere else
            InitializeCamera();
            MessageBox.Show("Background capture will happen 5s after you click OK");
            // Warm up the camera - let it take 100 frames, and finish its auto-adjustment
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
                _capture.QueryGrayFrame();
            }
            // Actual background capture
            _backgroundImage = _capture.QueryGrayFrame();
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
            
            _differenceViewer.ShowDialog();    // show the image viewer
        }

        private void btnShowBackground_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer();
            // Show the background image
            viewer.Image = _backgroundImage;
            viewer.ShowDialog();
        }
    }
}

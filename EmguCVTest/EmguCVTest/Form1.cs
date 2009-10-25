using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace EmguCVTest
{
    public partial class Form1 : Form
    {

        Image<Gray, Byte> backgroundImage;
        const String DEFAULT_TEXT_BTN_BG_CAPTURE = "Take Background Image [5s]";
        const String DEFAULT_TEXT_BTN_BEGIN_DIFFERENCING = "Begin Differencing";

        public Form1()
        {
            InitializeComponent();
            this.backgroundImage = new Image<Gray, byte>(640, 480);
        }

        private void btnBgCapture_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Background capture will happen 5s after you click OK");

            using (Capture capture = new Capture())
            {
                capture.FlipHorizontal = true;
                for (int i = 0; i < 50; i++)
                {
                    capture.QueryGrayFrame();
                    System.Threading.Thread.Sleep(100);
                }
                this.backgroundImage = capture.QueryGrayFrame();
            }
        }

        private void btnBeginDifferencing_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer(); // create an image viewer

            Capture capture = new Capture(); // create a camera capture
            capture.FlipHorizontal = true;
            Image<Gray, Byte> frame = new Image<Gray, byte>(640,480);
            Application.Idle += new EventHandler(delegate(object newsender, EventArgs newe)
            {   // run this until the application is closed
                System.Threading.Thread.Sleep(50);
                frame = capture.QueryGrayFrame();
                Image<Gray, Byte> difference = new Image<Gray, byte>(640, 480);
                CvInvoke.cvAbsDiff(this.backgroundImage, frame, difference);
                viewer.Image = difference.ThresholdBinary(new Gray(15), new Gray(255));
                //viewer.Image = difference;
            });
            
            viewer.ShowDialog();    // show the image viewer
        }

        private void btnShowBackground_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer();
            viewer.Image = backgroundImage;
            viewer.ShowDialog();
        }
    }
}

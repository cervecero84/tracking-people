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
        public Form1()
        {
            InitializeComponent();

            ImageViewer viewer = new ImageViewer(); // create an image viewer
            Capture capture = new Capture(); // create a camera capture
            Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
                {   // run this until the application is closed
                    viewer.Image = capture.QueryFrame();    // draw the image obtained from the camera
                });
            viewer.ShowDialog();    // show the image viewer

            using (Image<Bgr, Byte> img = new Image<Bgr, byte>(400, 200, new Bgr(255, 0, 0)))
            {
                //Create the font
                MCvFont f = new MCvFont(CvEnum.FONT.CV_FONT_HERSHEY_COMPLEX, 1.0, 1.0);

                //Draw "Hello, world." on the image using the specific font
                img.Draw("Hello, world", ref f, new Point(10, 80), new Bgr(0, 255, 0));

                //Show the image using ImageViewer from Emgu.CV.UI
                ImageViewer.Show(img, "Test Window");
            }
            //new test again2

        }
    }
}

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

            MessageBox.Show("This is a test message");
        }
    }
}

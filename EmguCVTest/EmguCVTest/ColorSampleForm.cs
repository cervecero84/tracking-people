
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
using GroupLab.Networking;




namespace EmguCVTest
{
    
    
    public partial class ColorSampleForm : Form
    {
        int _frameWidth = 400;
        int _frameHeight = 300;
        //int _orgFrameWidth = 640;
        //int _orgFrameHeight = 480;
        
        Image<Bgr,byte> sampleImg;
        Image<Bgr, byte> uiImg;

        //variables used in the identificaiton of ROI
        int ptCounter = 0;
        int _rectTop = 0;
        int _rectLeft = 0;
        int _rectRight = 0;
        int _rectBottom = 0;
        Image<Bgr, byte> roiImg;


        public ColorSampleForm(Capture c)
        {
            InitializeComponent();
            sampleImg = c.QueryFrame();
            sampleImg = sampleImg.Resize(_frameWidth, _frameHeight, true); //resize while maintaining proportion.
            sampleImageBox.Image = sampleImg;
        }

        //will crash if more than one attemp is made at defining ROI. have to reset roiIMG and rect coord somehow
        private void sample_mouseClick(object sender, MouseEventArgs e) //click top left corner first, then bottom right
        {
            switch (ptCounter)
            {
                case 0:
                    ptCounter++;
                    _rectLeft = e.X;
                    _rectTop = e.Y;
                    break;
                case 1:
                    _rectRight = e.X;
                    _rectBottom = e.Y;
                    Rectangle sampleRect = Rectangle.FromLTRB(_rectLeft, _rectTop, _rectRight, _rectBottom);
                    uiImg = sampleImg;
                    uiImg.Draw(sampleRect, new Bgr(Color.AliceBlue), 1);
                    sampleImageBox.Image = uiImg;
                    roiImg = sampleImg;
                    CvInvoke.cvSetImageROI(roiImg, sampleRect);
                    
                //wrong average, for testing purpose only. final averaging algorithm to be implemented separately from this function
                    C1textBox.Text = roiImg.GetAverage().Blue.ToString();
                    C2textBox.Text = roiImg.GetAverage().Red.ToString();
                //
                    break;
            }
        }

        private void btnAvgHS_Click(object sender, EventArgs e)
        {
            Image<Hsv, byte> HsvROI = new Image<Hsv, byte>(roiImg.Width, roiImg.Height);
            CvInvoke.cvCvtColor(roiImg,HsvROI,COLOR_CONVERSION.CV_BGR2HSV);

            textBoxHue.Text=HsvROI.GetAverage().Hue.ToString();
            textBoxSat.Text=HsvROI.GetAverage().Satuation.ToString();
        }


    }
}

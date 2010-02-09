
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
//using GroupLab.Networking;




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
                    uiImg = sampleImg.Clone();
                    uiImg.Draw(sampleRect, new Bgr(Color.AliceBlue), 1);
                    sampleImageBox.Image = uiImg;
                    roiImg = sampleImg.Clone();
                    CvInvoke.cvSetImageROI(roiImg, sampleRect);

                    ptCounter = 0;
                    _rectBottom = 0;
                    _rectLeft = 0;
                    _rectRight = 0;
                    _rectTop = 0;
                    
                //wrong average, for testing purpose only. final averaging algorithm to be implemented separately from this function
                    //C1textBox.Text = roiImg.GetAverage().Blue.ToString();
                    //C2textBox.Text = roiImg.GetAverage().Red.ToString();
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

        private void btnYccParam_Click(object sender, EventArgs e)
        {

        }

        private void btnWPcalib_Click(object sender, EventArgs e)
        {
            
            double[] AdjXYZ = new double[3];
            Xyz WP = new Xyz(95.05, 100.00, 108.88);
            AdjWP(roiImg, WP, AdjXYZ);
            
            //Bgr white = new Bgr(Color.White);
            //CvInvoke.cvCvtColor(white, wp, COLOR_CONVERSION.CV_BGR2XYZ);
            

            Image<Xyz, byte> XYZimg = new Image<Xyz, byte>(sampleImg.Width, sampleImg.Height);
            CvInvoke.cvCvtColor(sampleImg, XYZimg, COLOR_CONVERSION.CV_BGR2XYZ);
            
            Image<Gray, byte> Ximg = new Image<Gray, byte>(sampleImg.Width, sampleImg.Height);
            Image<Gray, byte> Yimg = new Image<Gray, byte>(sampleImg.Width, sampleImg.Height);
            Image<Gray, byte> Zimg = new Image<Gray, byte>(sampleImg.Width, sampleImg.Height);
            //Image<Xyz, byte> unk = new Image<Xyz, byte>(sampleImg.Width, sampleImg.Height);
            CvInvoke.cvSplit(XYZimg, Ximg, Yimg, Zimg, IntPtr.Zero);
            Ximg._Mul(AdjXYZ[0]);
            Yimg._Mul(AdjXYZ[1]);
            Zimg._Mul(AdjXYZ[2]);
            Image<Xyz, byte> XYZimg2 = new Image<Xyz, byte>(sampleImg.Width, sampleImg.Height);
            CvInvoke.cvMerge(Ximg, Yimg, Zimg, IntPtr.Zero , XYZimg2);

            Image<Bgr, byte> wpImg = new Image<Bgr, byte>(sampleImg.Width, sampleImg.Height);

            CvInvoke.cvCvtColor(XYZimg2, wpImg, COLOR_CONVERSION.CV_XYZ2BGR);

            sampleImageBox.Image = wpImg;      
            
        }

        public void AdjWP(Image<Bgr, byte> roiImg, Xyz WP, double[] AdjXYZ)
        {
            //Image<Bgr, byte> roiImg = (Image<Bgr, byte>)roi;
            Image<Xyz, byte> XYZROI = new Image<Xyz, byte>(roiImg.Width, roiImg.Height);
            CvInvoke.cvCvtColor(roiImg, XYZROI, COLOR_CONVERSION.CV_BGR2XYZ);
            double AvgX = XYZROI.GetAverage().X;
            double AvgY = XYZROI.GetAverage().Y;
            double AvgZ = XYZROI.GetAverage().Z;

            double AdjX = Math.Abs(WP.X / AvgX);
            double AdjY = Math.Abs(WP.Y / AvgY);
            double AdjZ = Math.Abs(WP.Z / AvgZ);

            AdjXYZ[0] = AdjX;
            AdjXYZ[1] = AdjY;
            AdjXYZ[2] = AdjZ;

        }
    }
}

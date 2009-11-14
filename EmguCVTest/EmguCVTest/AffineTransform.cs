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
    public partial class AffineTransform : Form
    {
        PointF[] srcpt = new PointF[3];
        PointF[] dstpt = new PointF[3];

        int ptCounter = 0;
        
        int _frameWidth = 400;
        int _frameHeight = 300;
        int _orgFrameWidth = 640;
        int _orgFrameHeight = 480;
        Capture _capture;

        IntPtr warpMat = CvInvoke.cvCreateMat(2, 3, MAT_DEPTH.CV_64F);
        

        Image<Bgr, Byte> imageTransform;
        Image<Bgr, Byte> imageBackup;

        public AffineTransform(Capture c)
        {
            InitializeComponent();
            _capture = c;

            imageTransform = _capture.QueryFrame();
            imageBackup = imageTransform;

            imgImageBox.Image = imageTransform.Resize(_frameWidth, _frameHeight);

            dstpt[0].X = 0;
            dstpt[0].Y = 299;
            dstpt[1].X = 0;
            dstpt[1].Y = 0;
            dstpt[2].X = 399;
            dstpt[2].Y = 0;

        }

        private void btnCapture_Click(object sender, EventArgs e)
        {



            imageTransform = _capture.QueryFrame();
            imageBackup = imageTransform;

            imgImageBox.Image = imageTransform.Resize(_frameWidth,_frameHeight);


            //Cvinvoke.cvGetAffineTransform(srcTri, dstTri, warp_mat);




            //MCvMat warpMat = CvInvoke.cvCreateMat(2, 3, MAT_DEPTH.CV_64F);
        }

        private void imgImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ptCounter == 3)
            {
                ptCounter = 0;
                imageTransform = imageBackup;
            }
            if (ptCounter < 3)
            {
                srcpt[ptCounter].X = e.X * _orgFrameWidth/_frameWidth;
                srcpt[ptCounter].Y = e.Y * _orgFrameHeight/_frameHeight;

                Cross2DF scrCrossTest = new Cross2DF(srcpt[ptCounter], 5, 5);
                imageTransform.Draw(scrCrossTest, new Bgr(Color.Red), 2);
                imgImageBox.Image = imageTransform.Resize(_frameWidth, _frameHeight);

                ptCounter += 1;
            }



        }

        private void btnDrawPnt_Click(object sender, EventArgs e)
        {
            Cross2DF scrCross1 = new Cross2DF(srcpt[0], 5, 5);
            Cross2DF scrCross2 = new Cross2DF(srcpt[1], 5, 5);
            Cross2DF scrCross3 = new Cross2DF(srcpt[2], 5, 5);

            imageTransform.Draw(scrCross1, new Bgr(Color.Red), 2);
            imageTransform.Draw(scrCross2, new Bgr(Color.Red), 2);
            imageTransform.Draw(scrCross3, new Bgr(Color.Red), 2);

            imgImageBox.Image = imageTransform.Resize(_frameWidth, _frameHeight);


        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            PointF[] srcTri = new PointF[] { srcpt[0], srcpt[1], srcpt[2] };
            PointF[] dstTri = new PointF[] { dstpt[0], dstpt[1], dstpt[2] };

            CvInvoke.cvGetAffineTransform(srcTri, dstTri, warpMat);

            MCvScalar fillvar = new MCvScalar(0);
            imageBoxPers.Image = new Image<Bgr, byte>(_frameWidth, _frameHeight, new Bgr(0, 0, 0));
            CvInvoke.cvWarpAffine(imgImageBox.Image.Ptr, imageBoxPers.Image.Ptr, warpMat, 0, fillvar);
        }
    }
}

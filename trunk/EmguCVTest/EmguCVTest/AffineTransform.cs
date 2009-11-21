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
        PointF[] srcpt = new PointF[4];
        PointF[] dstpt = new PointF[4];

        enum Position { BL, TL, TR, BR };

        int ptCounter = 0;
        
        int _frameWidth = 400;
        int _frameHeight = 300;
        int _orgFrameWidth = 640;
        int _orgFrameHeight = 480;
        Capture _capture;

        IntPtr warpMat = CvInvoke.cvCreateMat(3, 3, MAT_DEPTH.CV_64F);
        

        Image<Bgr, Byte> imageTransform;
        Image<Bgr, Byte> imageBackup;

        public AffineTransform(Capture c)
        {
            InitializeComponent();
            _capture = c;

            imageTransform = _capture.QueryFrame();
            imageTransform = imageTransform.Resize(_frameWidth, _frameHeight);
            imageBackup = imageTransform;

            imgImageBox.Image = imageTransform;//.Resize(_frameWidth, _frameHeight);

            dstpt[(int)Position.BL].X = 0;
            dstpt[(int)Position.BL].Y = 399;
            dstpt[(int)Position.TL].X = 0;
            dstpt[(int)Position.TL].Y = 0;
            dstpt[(int)Position.TR].X = 299;
            dstpt[(int)Position.TR].Y = 0;
            dstpt[(int)Position.BR].X = 299;
            dstpt[(int)Position.BR].Y = 399;

        }

        private void btnCapture_Click(object sender, EventArgs e)
        {



            imageTransform = _capture.QueryFrame();
            imageTransform = imageTransform.Resize(_frameWidth, _frameHeight);
            imageBackup = imageTransform;

            imgImageBox.Image = imageTransform;//.Resize(_frameWidth,_frameHeight);


            //Cvinvoke.cvGetAffineTransform(srcTri, dstTri, warp_mat);




            //MCvMat warpMat = CvInvoke.cvCreateMat(2, 3, MAT_DEPTH.CV_64F);
        }

        private void imgImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (ptCounter == 4)
            {
                ptCounter = 0;
                imageTransform = imageBackup;
            }
            if (ptCounter < 4)
            {
                srcpt[ptCounter].X = e.X; //* _orgFrameWidth/_frameWidth;
                srcpt[ptCounter].Y = e.Y; //* _orgFrameHeight/_frameHeight;

                Cross2DF scrCrossTest = new Cross2DF(srcpt[ptCounter], 5, 5);
                imageTransform.Draw(scrCrossTest, new Bgr(Color.Red), 2);
                imgImageBox.Image = imageTransform;//.Resize(_frameWidth, _frameHeight);

                ptCounter += 1;
            }



        }

        private void btnDrawPnt_Click(object sender, EventArgs e)
        {
            Cross2DF scrCross1 = new Cross2DF(srcpt[0], 5, 5);
            Cross2DF scrCross2 = new Cross2DF(srcpt[1], 5, 5);
            Cross2DF scrCross3 = new Cross2DF(srcpt[2], 5, 5);
            Cross2DF scrCross4 = new Cross2DF(srcpt[3], 5, 5);

            imageTransform.Draw(scrCross1, new Bgr(Color.Red), 2);
            imageTransform.Draw(scrCross2, new Bgr(Color.Red), 2);
            imageTransform.Draw(scrCross3, new Bgr(Color.Red), 2);
            imageTransform.Draw(scrCross4, new Bgr(Color.Red), 2);

            imgImageBox.Image = imageTransform;//.Resize(_frameWidth, _frameHeight);


        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            PointF[] srcTri = new PointF[] { srcpt[0], srcpt[1], srcpt[2], srcpt[3] };

            dstpt[(int)Position.BL].X = srcpt[0].X;
            dstpt[(int)Position.BL].Y = srcpt[0].Y;
            dstpt[(int)Position.TL].X = srcpt[0].X;
            dstpt[(int)Position.TL].Y = srcpt[1].Y;
            dstpt[(int)Position.TR].X = srcpt[2].X;
            dstpt[(int)Position.TR].Y = srcpt[1].Y;
            dstpt[(int)Position.BR].X = srcpt[2].X;
            dstpt[(int)Position.BR].Y = srcpt[0].Y;


            Cross2DF dstCross1 = new Cross2DF(dstpt[(int)Position.BL], 5, 5);
            Cross2DF dstCross2 = new Cross2DF(dstpt[(int)Position.TL], 5, 5);
            Cross2DF dstCross3 = new Cross2DF(dstpt[(int)Position.TR], 5, 5);
            Cross2DF dstCross4 = new Cross2DF(dstpt[(int)Position.BR], 5, 5);

            imageTransform.Draw(dstCross1, new Bgr(Color.Orange), 2);
            imageTransform.Draw(dstCross2, new Bgr(Color.Orange), 2);
            imageTransform.Draw(dstCross3, new Bgr(Color.Orange), 2);
            imageTransform.Draw(dstCross4, new Bgr(Color.Orange), 2);

            imgImageBox.Image = imageTransform;//.Resize(_frameWidth, _frameHeight);


            PointF[] dstTri = dstpt;//new PointF[] { dstpt[Position.BL], dstpt[Position.TL], dstpt[Position.TR], dstpt[Position.BL] };

            //CvInvoke.cvGetAffineTransform(srcTri, dstTri, warpMat);
            CvInvoke.cvGetPerspectiveTransform(srcTri, dstTri, warpMat);

            MCvScalar fillvar = new MCvScalar(0);
            imageBoxPers.Image = new Image<Bgr, byte>(_frameWidth, _frameHeight, new Bgr(0, 0, 0));
            //CvInvoke.cvWarpAffine(imgImageBox.Image.Ptr, imageBoxPers.Image.Ptr, warpMat, 0, fillvar);
            CvInvoke.cvWarpPerspective(imgImageBox.Image.Ptr, imageBoxPers.Image.Ptr, warpMat, 0, fillvar);
        }
    }
}

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
    public partial class AffineTransform : Form
    {
        PointF[] srcpt = new PointF[4];
        PointF[] dstpt = new PointF[4];

        PointF[] leftSide = new PointF[1];
        PointF[] leftSideT = new PointF[1];
        PointF[] rightSide = new PointF[1];
        PointF[] rightSideT = new PointF[1];
        //PointF[] rightSideTransform = new PointF[0];

        enum Position { BL, TL, TR, BR };

        int ptCounter = 0;
        
        int _frameWidth = 400;
        int _frameHeight = 300;
        int _orgFrameWidth = 640;
        int _orgFrameHeight = 480;
        Capture _capture;

        int tableTopHeight = 67;
        int tableTopWidth = 108;

        Matrix<double> warpMat = new Matrix<double>(3, 3);// CvInvoke.cvCreateMat(3, 3, MAT_DEPTH.CV_64F);
        Matrix<double> invWarpMat = new Matrix<double>(3, 3); //CvInvoke.cvCreateMat(3, 3, MAT_DEPTH.CV_64F);

        IntPtr leftSideM = CvInvoke.cvCreateMat(3, 1, MAT_DEPTH.CV_64F);
        //IntPtr leftSideTransform = CvInvoke.cvCreateMat(3, 1, MAT_DEPTH.CV_64F);
        IntPtr rightSideM = CvInvoke.cvCreateMat(3, 1, MAT_DEPTH.CV_64F);
        //IntPtr rightSideTransform = CvInvoke.cvCreateMat(3, 1, MAT_DEPTH.CV_64F);
        

        Image<Bgr, Byte> imageTransform;
        Image<Bgr, Byte> imageBackup;
        
        Image<Bgr, Byte> imagePerspective;


        public AffineTransform(Capture c)
        {
            InitializeComponent();
            _capture = c;




            this.subscription1.BeginInit();
            this.subscription1.Pattern = "/coordinates";

            // this next line creates an event handler that will fire when a notification is received
            this.subscription1.Notified += new SubscriptionEventHandler(subscription1_Notified);

            this.subscription1.EndInit();

            this.subscription1.BeginInit();
            this.subscription1.Pattern = "/coordinates/pts";

            // this next line creates an event handler that will fire when a notification is received
            this.subscription1.Notified += new SubscriptionEventHandler(subscription1_Notified);

            this.subscription1.EndInit();

            this.sd.Url = "tcp://localhost:shareD";
            this.sd.Open();


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
            ptCounter = 0;

        }

        private void imgImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            
            //Guid currentCoordinates;
            if (lblCurrentPoint.Text == "Draw Point")
            {
                if (ptCounter == 4)
                {
                    imageTransform = imageBackup;
                    imgImageBox.Image = imageBackup;                        //ADDED this!!!!!
                    ptCounter = 0;

                }
                else if (ptCounter < 4)
                {
                    srcpt[ptCounter].X = e.X; //* _orgFrameWidth/_frameWidth;
                    srcpt[ptCounter].Y = e.Y; //* _orgFrameHeight/_frameHeight;

                    //sd["/coordinates/pts"] = new SharedDictionary.Vector();
                    //sd["/coordinates/pts#0"] = new Point(e.X, e.Y);
                    ////this.sd["/coordinate/pts"] = new SharedDictionary.Vector();
                    ////this.sd["/coordinate/pts#0"] = e.X.ToString();
                    this.sd["/value"] = 5;

                    Cross2DF scrCrossTest = new Cross2DF(srcpt[ptCounter], 5, 5);
                    imageTransform.Draw(scrCrossTest, new Bgr(Color.Red), 2);
                    imgImageBox.Image = imageTransform;//.Resize(_frameWidth, _frameHeight);

                    ptCounter += 1;
                }
            }
            else if (lblCurrentPoint.Text == "Coordinate Transform -->")
            {
                //lblCurrentPoint.Text = "Draw Point";
                //lblCurrentPoint.Text = "Click on left side";
                //currentCoordinates = Guid.NewGuid();
                ////sd["/coordinates/pts"] = new SharedDictionary.Vector();
                ////sd["/coordinates/pts#0"] = new Point ( e.X, e.Y );
                //sd["/coordinates#-0"] = currentCoordinates;

                leftSide[0].X = e.X; //* _orgFrameWidth/_frameWidth;
                leftSide[0].Y = e.Y; //* _orgFrameHeight/_frameHeight;

                CvArray<Byte> arr;
                Matrix<double> m = new Matrix<double>(1, 1, 2);
                Matrix<double> n = new Matrix<double>(1, 1, 2);
                
                double[] data = { leftSide[0].X, leftSide[0].Y};
                m.Data[0, 0] = e.X;
                m.Data[0, 1] = e.Y;

                //Matrix<double> leftSidePtr = new Matrix<double>(data).Transpose();
                //Matrix<double> leftSideTransformed = new Matrix<double>(1, 3);
                //Matrix<double> leftSidePtrT = new Matrix<double>();
                //Matrix<double> wMat = new Matrix<double>(warpMat);
                //CvInvoke.cvTranspose(leftSidePtr, leftSidePtrT);
                //CvInvoke.cvTranspose(leftSideTransformed, leftSideTransformed);
                CvInvoke.cvPerspectiveTransform(m, n, warpMat.Ptr);
                

                leftSideT[0].X = (float)n.Data[0,0];
                leftSideT[0].Y = (float)n.Data[0, 1];

                Cross2DF scrCrossTest2 = new Cross2DF(leftSideT[0], 5, 5);
                imagePerspective.Draw(scrCrossTest2, new Bgr(Color.Green), 2);
                imageBoxPers.Image = imagePerspective;//.Resize(_frameWidth, _frameHeight);


                Cross2DF scrCrossTest1 = new Cross2DF(leftSide[0], 5, 5);
                imageTransform.Draw(scrCrossTest1, new Bgr(Color.Green), 2);
                imgImageBox.Image = imageTransform;//.Resize(_frameWidth, _frameHeight);

                lblTouchPt.Text = "[" + leftSideT[0].X + " , " + leftSideT[0].Y + "]";

            }


        }

        private void imageBoxPers_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (lblCurrentPoint.Text == "Coordinate Transform <--")
            {
                //lblCurrentPoint.Text = "Draw Point";
                //lblCurrentPoint.Text = "Click on left side";
                rightSide[0].X = e.X; //* _orgFrameWidth/_frameWidth;
                rightSide[0].Y = e.Y; //* _orgFrameHeight/_frameHeight;
                //CvInvoke.cvSetData(leftSide, e.X e.Y 1, //leftSide = [e.X, e.Y, 1];

                CvArray<Byte> arr;
                Matrix<double> m = new Matrix<double>(1, 1, 2);
                Matrix<double> n = new Matrix<double>(1, 1, 2);

                double[] data = { rightSide[0].X, rightSide[0].Y };
                m.Data[0, 0] = e.X;
                m.Data[0, 1] = e.Y;

                CvInvoke.cvPerspectiveTransform(m, n, invWarpMat.Ptr);


                rightSideT[0].X = (float)n.Data[0, 0];
                rightSideT[0].Y = (float)n.Data[0, 1];

                Cross2DF scrCrossTest2 = new Cross2DF(rightSideT[0], 5, 5);
                imageTransform.Draw(scrCrossTest2, new Bgr(Color.Green), 2);
                imgImageBox.Image = imageTransform;//.Resize(_frameWidth, _frameHeight);


                Cross2DF scrCrossTest1 = new Cross2DF(rightSide[0], 5, 5);
                imagePerspective.Draw(scrCrossTest1, new Bgr(Color.Green), 2);
                imageBoxPers.Image = imagePerspective;//.Resize(_frameWidth, _frameHeight);
            }
        }

        private void btnDrawPnt_Click(object sender, EventArgs e)
        {
            if (lblCurrentPoint.Text == "Draw Point")
            {
                lblCurrentPoint.Text = "Coordinate Transform -->";
            }
            else if (lblCurrentPoint.Text == "Coordinate Transform -->")
            {
                lblCurrentPoint.Text = "Coordinate Transform <--";
            }
            else if (lblCurrentPoint.Text == "Coordinate Transform <--")
            {
                lblCurrentPoint.Text = "Draw Point";
            }

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

            lblBL.Text = "[" + (int)dstpt[(int)Position.BL].X + " , " + (int)dstpt[(int)Position.BL].Y + "]";
            lblTL.Text = "[" + (int)dstpt[(int)Position.TL].X + " , " + (int)dstpt[(int)Position.TL].Y + "]";
            lblTR.Text = "[" + (int)dstpt[(int)Position.TR].X + " , " + (int)dstpt[(int)Position.TR].Y + "]";
            lblBR.Text = "[" + (int)dstpt[(int)Position.BR].X + " , " + (int)dstpt[(int)Position.BR].Y + "]";




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

            //INVERT_METHOD method = new INVERT_METHOD cv;
            CvInvoke.cvInvert(warpMat, invWarpMat, Emgu.CV.CvEnum.INVERT_METHOD.CV_LU);

            MCvScalar fillvar = new MCvScalar(0);
            imageBoxPers.Image = new Image<Bgr, byte>(_frameWidth, _frameHeight, new Bgr(0, 0, 0));
            //CvInvoke.cvWarpAffine(imgImageBox.Image.Ptr, imageBoxPers.Image.Ptr, warpMat, 0, fillvar);
            CvInvoke.cvWarpPerspective(imgImageBox.Image.Ptr, imageBoxPers.Image.Ptr, warpMat, 0, fillvar);
            //CvInvoke.cvWarpPerspective(imgImageBox.Image.Ptr, imagePerspective.Ptr, warpMat, 0, fillvar);
            imagePerspective = new Image<Bgr,byte>(imageBoxPers.Image.Bitmap);
            //imageBoxPers.Image = imagePerspective;
        }

        private void subscription1_Notified(object sender, SubscriptionEventArgs e)
        {
            int x = (int)e.Entry.Value;
            lblCurrentPoint.Text = x.ToString();
        }

        private void AffineTransform_Load(object sender, EventArgs e)
        {
            //this.sd.Url = "tcp://localhost:shareD";
            //this.sd.Open();
            this.sd["/coordinates"] = 6;

            //sd["/coordinates"] = new SharedDictionary.Vector();
            //sd.Open();
        }

        private void sd_Opened(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void AffineTransform_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.sd.Close();
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _capture.Dispose();
                _capture = new Capture(openFileDialog1.FileName);
            }
        }

        private void btnDrawPt_Click(object sender, EventArgs e)
        {
            int PtX;
            int PtY;
            Int32.TryParse(txtPtX.Text, out PtX);
            Int32.TryParse(txtPtY.Text, out PtY);

            //lblTouchPt.Text = (PtY / tableTopHeight) * ((int)dstpt[(int)Position.BL].Y - (int)dstpt[(int)Position.TL].Y) + (int)dstpt[(int)Position.BL].Y;
            //lblTouchPt.Text = (PtX / tableTopHeight) * ((int)dstpt[(int)Position.BL].X - (int)dstpt[(int)Position.TL].X) + (int)dstpt[(int)Position.BL].X;

            float percentFromLeft = (float) PtX / tableTopWidth;
            float percentFromBottom = (float) PtY / tableTopHeight;

            PointF pointToDraw = new PointF();
            pointToDraw.X = (dstpt[(int)Position.BR].X - dstpt[(int)Position.BL].X) * percentFromLeft + dstpt[(int)Position.BL].X;
            pointToDraw.Y = (dstpt[(int)Position.TL].Y - dstpt[(int)Position.BL].Y) * percentFromBottom + dstpt[(int)Position.BL].Y;

            Cross2DF crossToDraw = new Cross2DF(pointToDraw, 5, 5);
            Image<Bgr, Byte> img = new Image<Bgr, byte>(imageBoxPers.Image.Bitmap);
            img.Draw(crossToDraw, new Bgr(Color.Purple), 3);
            imageBoxPers.Image = img;

            Matrix<double> m = new Matrix<double>(1, 1, 2);
            Matrix<double> n = new Matrix<double>(1, 1, 2);

            //double[] data = { pointToDraw.X, pointToDraw.Y };
            m.Data[0, 0] = pointToDraw.X;
            m.Data[0, 1] = pointToDraw.Y;

            CvInvoke.cvPerspectiveTransform(m, n, invWarpMat.Ptr);

            PointF pointToDrawT = new PointF();

            pointToDrawT.X = (float)n.Data[0, 0];
            pointToDrawT.Y = (float)n.Data[0, 1];

            Cross2DF scrCrossTest2 = new Cross2DF(pointToDrawT, 5, 5);
            imageTransform.Draw(scrCrossTest2, new Bgr(Color.Purple), 2);
            imgImageBox.Image = imageTransform;//.Resize(_frameWidth, _frameHeight);


        }
    }
}

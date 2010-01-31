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
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace IdeaTester
{
    public partial class Main : Form
    {

        Capture _camera;
        int _msPerFrame = (int)(1000.0/30);
        enum BandColor { Red, Green, Orange, Blue };
        DenseHistogram _orangeBandCbHist = new DenseHistogram(16, new RangeF(0, 255));
        DenseHistogram _orangeBandCrHist = new DenseHistogram(16, new RangeF(0, 255));
        DenseHistogram _blueBandCbHist = new DenseHistogram(16, new RangeF(0, 255));
        DenseHistogram _blueBandCrHist = new DenseHistogram(16, new RangeF(0, 255));
        DenseHistogram _greenBandCbHist = new DenseHistogram(16, new RangeF(0, 255));
        DenseHistogram _greenBandCrHist = new DenseHistogram(16, new RangeF(0, 255));
        DenseHistogram _redBandCbHist = new DenseHistogram(16, new RangeF(0, 255));
        DenseHistogram _redBandCrHist = new DenseHistogram(16, new RangeF(0, 255));

        public Main()
        {
            InitializeComponent();
            // Default learning
            learnBandColor(BandColor.Blue, new Image<Ycc, byte>("template/LiveBlueBand.jpg"));
            learnBandColor(BandColor.Green, new Image<Ycc, byte>("template/LiveGreenBand.jpg"));
            learnBandColor(BandColor.Orange, new Image<Ycc, byte>("template/LiveOrangeBand.jpg"));
            learnBandColor(BandColor.Red, new Image<Ycc, byte>("template/LiveRedBand.jpg"));
            cbxFilterType.SelectedIndex = 0; // "None" selected
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Activate the camera
            btnCamera_Click(sender, e);
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            String videoSourceFileName = "";
            if (ofdSourceVideo.ShowDialog() == DialogResult.OK)
            {
                videoSourceFileName = ofdSourceVideo.FileName;
                Capture tmp = _camera;
                try
                {
                    tmp = new Capture(videoSourceFileName);
                }
                catch (NullReferenceException)
                {
                    // This exception happens when the file that was tried to be opened
                    // was not a readable video file
                    MessageBox.Show("Unreadable video file. No action done.");
                }
                _camera = tmp;
                lblVideoSource.Text = "File";
            }
        }

        private void learnBandColor(BandColor bc, Image<Ycc, Byte> bandImage)
        {
            Image<Gray, Byte>[] bandImageChannels = bandImage.Split();

            // Use the whole image
            Image<Gray, Byte> mask = new Image<Gray, byte>(bandImage.Width, bandImage.Height, new Gray(255));

            // Initialization
            int channelIndex;
            IntPtr[] bandImageChannelsPtr = new IntPtr[1];

            DenseHistogram cbHist;
            DenseHistogram crHist;

            switch (bc)
            {
                case BandColor.Blue:
                    cbHist = _blueBandCbHist;
                    crHist = _blueBandCrHist;
                    break;
                case BandColor.Green:
                    cbHist = _greenBandCbHist;
                    crHist = _greenBandCrHist;
                    break;
                case BandColor.Orange:
                    cbHist = _orangeBandCbHist;
                    crHist = _orangeBandCrHist;
                    break;
                case BandColor.Red:
                    cbHist = _redBandCbHist;
                    crHist = _redBandCrHist;
                    break;
                default:
                    return;
            }

            // Use the Cb-channel
            channelIndex = 1;
            bandImageChannelsPtr[0] = bandImageChannels[channelIndex];
            CvInvoke.cvCalcHist(bandImageChannelsPtr, cbHist, false, mask);

            // Use the Cr-channel
            channelIndex = 2;
            bandImageChannelsPtr[0] = bandImageChannels[channelIndex];
            CvInvoke.cvCalcHist(bandImageChannelsPtr, crHist, false, mask);
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            if (_camera != null)
            {
                _camera.Dispose();
            }
            try
            {
                _camera = new Capture(0);
            }
            catch (Exception)
            {
                _camera = new Capture(1);
            }
            lblVideoSource.Text = "Camera";
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            ibxSource.Image = _camera.QueryFrame().Resize(400, 300, INTER.CV_INTER_CUBIC);
        }

        private void cbxVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxVideo.Checked)
            {
                Application.Idle += new EventHandler(processFrame);
            }
            else
            {
                Application.Idle -= new EventHandler(processFrame);
            }
        }

        private void processFrame(object sender, EventArgs e)
        {
            DateTime curr = DateTime.Now;
            performOperation();
            TimeSpan currTime = DateTime.Now - curr;
            Thread.Sleep( (_msPerFrame > currTime.Milliseconds) ? _msPerFrame - currTime.Milliseconds : 0);
            TimeSpan actualTime = DateTime.Now - curr;
            lblFPS.Text = Math.Round(1000.0/actualTime.Milliseconds).ToString() + " fps";
        }

        /// <summary>
        /// This is the ONLY function you would require to modify, you could add other helper functions,
        /// but the other existing functions can stay the way they are
        /// 
        /// All the image processing goes in here
        /// </summary>
        private void performOperation()
        {
            Image<Bgr, Byte> source = _camera.QueryFrame();
            
            // Reached the last frame in the source - happens in video files
            if (source == null)
            {
                cbxVideo.Checked = false;
                _camera = new Capture(ofdSourceVideo.FileName);
                source = _camera.QueryFrame();
                if (source == null)
                {
                    lblStatus.Text = "Video source no longer available";
                    return;
                }
            }

            source = source.Resize(400, 300, INTER.CV_INTER_CUBIC);

            int p1, p2, p3;

            Int32.TryParse(txtParameter1.Text, out p1);
            Int32.TryParse(txtParameter2.Text, out p2);
            Int32.TryParse(txtParameter3.Text, out p3);

            p1 = (p1 == 0) ? 1 : p1;
            p2 = (p2 == 0) ? 1 : p2;
            p3 = (p3 == 0) ? 1 : p3;

            if (cbxFilterType.SelectedItem.ToString() == "Blur")
            {
                source = source.SmoothBlur(p1, p2);
            }
            else if (cbxFilterType.SelectedItem.ToString() == "Median")
            {
                source = source.SmoothMedian(((p1 % 2 == 1) ? p1 : p1 + 1));
            }
            else if (cbxFilterType.SelectedItem.ToString() == "Gaussian")
            {
                source = source.SmoothGaussian(((p1 % 2 == 1) ? p1 : p1 + 1));
            }
            else if (cbxFilterType.SelectedItem.ToString() == "Bilateral")
            {
                source = source.SmoothBilatral(p1, p2, p3);
            }

            txtParameter1.Text = p1.ToString();
            txtParameter2.Text = p2.ToString();
            txtParameter3.Text = p3.ToString();
            
            Image<Hsv, Byte> redResult = new Image<Hsv, byte>(source.Size);
            Image<Hsv, Byte> greenResult = new Image<Hsv, byte>(source.Size);
            Image<Hsv, Byte> orangeResult = new Image<Hsv, byte>(source.Size);
            Image<Hsv, Byte> blueResult = new Image<Hsv, byte>(source.Size);

            Image<Gray, Byte> probRedBand = findBand(_redBandCbHist, _redBandCrHist, source.Convert<Ycc, Byte>(), tkbRedErosion.Value, tkbRedDilation.Value, tkbRedThreshold.Value);
            Image<Gray, Byte> probGreenBand = findBand(_greenBandCbHist, _greenBandCrHist, source.Convert<Ycc, Byte>(), tkbGreenErosion.Value, tkbGreenDilation.Value, tkbGreenThreshold.Value);
            Image<Gray, Byte> probOrangeBand = findBand(_orangeBandCbHist, _orangeBandCrHist, source.Convert<Ycc, Byte>(), tkbOrangeErosion.Value, tkbOrangeDilation.Value, tkbOrangeThreshold.Value);
            Image<Gray, Byte> probBlueBand = findBand(_blueBandCbHist, _blueBandCrHist, source.Convert<Ycc, Byte>(), tkbBlueErosion.Value, tkbBlueDilation.Value, tkbBlueThreshold.Value);

            CvInvoke.cvMerge(probRedBand.Mul(0), probRedBand, probRedBand, IntPtr.Zero, redResult);
            CvInvoke.cvMerge(probGreenBand.Mul(0.3), probGreenBand, probGreenBand, IntPtr.Zero, greenResult);
            CvInvoke.cvMerge(probOrangeBand.Mul(0.1), probOrangeBand, probOrangeBand, IntPtr.Zero, orangeResult);
            CvInvoke.cvMerge(probBlueBand.Mul(0.4), probBlueBand, probBlueBand, IntPtr.Zero, blueResult);

            // Output the source and the result
            ibxSource.Image = source;
            ibxSource.CreateGraphics().DrawRectangle(new Pen(Color.Red), _currentSelection);

            Image<Hsv, Byte> result = new Image<Hsv, byte>(source.Size);
            if (cbxShowBlue.Checked) result = result.Or(blueResult);
            if (cbxShowOrange.Checked) result = result.Or(orangeResult);
            if (cbxShowRed.Checked) result = result.Or(redResult);
            if (cbxShowGreen.Checked) result = result.Or(greenResult);
            ibxOutput.Image = result;
        }

        private Image<Gray, Byte> findBand(DenseHistogram cbHist, DenseHistogram crHist, Image<Ycc, Byte> source, int erosion, int dilation, double lowerThreshold)
        {
            Image<Gray, Byte>[] sourceChannels = source.Split();
            // Use the whole image
            
            // Initialization
            int channelIndex;
            IntPtr[] sourcePtr = new IntPtr[1];
            
            // Use the Cb-channel
            channelIndex = 1;
            sourcePtr[0] = sourceChannels[channelIndex];

            Image<Gray, Byte> backProjectCb = new Image<Gray, byte>(source.Size);
            CvInvoke.cvCalcBackProject(sourcePtr, backProjectCb, cbHist);

            // Use the Cr-channel
            channelIndex = 2;
            sourcePtr[0] = sourceChannels[channelIndex];

            Image<Gray, Byte> backProjectCr = new Image<Gray, byte>(source.Size);
            CvInvoke.cvCalcBackProject(sourcePtr, backProjectCr, crHist);

            // Change color of the detected band in the output image
            Image<Gray, Byte> result = backProjectCr.And(backProjectCb);

            if (ckbThreshold.Checked)
            {
                result = result.ThresholdBinary(new Gray(lowerThreshold), new Gray(255));
            }
            if (ckbErosion.Checked)
            {
                result = result.Erode(erosion);
            }
            if (ckbDilate.Checked)
            {
                result = result.Dilate(dilation);
            }
            return result;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            processFrame(sender, e);
        }

        private void btnSetFrameLimit_Click(object sender, EventArgs e)
        {
            _msPerFrame = (int)(1000.0/Int32.Parse(txtFrameLimit.Text));
        }

        private void tkbRedDilation_Scroll(object sender, EventArgs e)
        {
            lblRedDilation.Text = tkbRedDilation.Value.ToString();
        }

        private void tkbRedErosion_Scroll(object sender, EventArgs e)
        {
            lblRedErosion.Text = tkbRedErosion.Value.ToString();
        }

        private void tkbGreenErosion_Scroll(object sender, EventArgs e)
        {
            lblGreenErosion.Text = tkbGreenErosion.Value.ToString();
        }

        private void tkbGreenDilation_Scroll(object sender, EventArgs e)
        {
            lblGreenDilation.Text = tkbGreenDilation.Value.ToString();
        }

        private void tkbOrangeErosion_Scroll(object sender, EventArgs e)
        {
            lblOrangeErosion.Text = tkbOrangeErosion.Value.ToString();
        }

        private void tkbOrangeDilation_Scroll(object sender, EventArgs e)
        {
            lblOrangeDilation.Text = tkbOrangeDilation.Value.ToString();
        }

        private void tkbBlueErosion_Scroll(object sender, EventArgs e)
        {
            lblBlueErosion.Text = tkbBlueErosion.Value.ToString();
        }

        private void tkbBlueDilation_Scroll(object sender, EventArgs e)
        {
            lblBlueDilation.Text = tkbBlueDilation.Value.ToString();
        }

        private void cbxFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFilterType.SelectedItem.ToString() == "Blur")
            {
                lblStatus.Text = "Parameters: Width, Height, Preserve";
            }
            else if (cbxFilterType.SelectedItem.ToString() == "Median")
            {
                lblStatus.Text = "Parameters: Size";
            }
            else if (cbxFilterType.SelectedItem.ToString() == "Gaussian")
            {
                lblStatus.Text = "Parameters: KernelSize";
            }
            else if (cbxFilterType.SelectedItem.ToString() == "Bilateral")
            {
                lblStatus.Text = "Parameters: KernelSize, ColorSigma, SpaceSigma";
            }
            else
            {
                lblStatus.Text = "No blurring method selected";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Switching cameras");
            if (_camera != null) _camera.Dispose();
            if (ckbSwitchCamera.Checked) _camera = new Capture(1);
            else _camera = new Capture(0);
        }

        private bool _statusWaitingForBandRegionSelection = false;
        private BandColor _waitingToLearnBand = BandColor.Red;

        private void btnPickBandRegion_Click(object sender, EventArgs e)
        {
            _statusWaitingForBandRegionSelection = true;
            if (_waitingToLearnBand == BandColor.Red) lblStatus.Text = "Select the Red band in the source";
        }

        private bool _statusDragStarted = false;
        private Point _dragStartPoint = new Point();
        private Rectangle _currentSelection = new Rectangle();
        private Image<Bgr, Byte> _trueImageBeforeRectangleDrawn;

        private void ibxSource_MouseDown(object sender, MouseEventArgs e)
        {
            if (_statusWaitingForBandRegionSelection)
            {
                lblStatus.Text = "Mouse down. Drag Started @ " + e.X + ", " + e.Y;
                _dragStartPoint = new Point(e.X, e.Y);
                _statusDragStarted = true;
            }

            if (!cbxVideo.Checked)
            {
                // Still picture
                _trueImageBeforeRectangleDrawn = new Image<Bgr, byte>(ibxSource.Image.Bitmap);
            }
        }

        private void ibxSource_MouseUp(object sender, MouseEventArgs e)
        {
            if (_statusWaitingForBandRegionSelection && _statusDragStarted)
            {
                lblStatus.Text = "Mouse up. Drag Ended @ " + e.X + ", " + e.Y;
                Image<Ycc, Byte> source = new Image<Ycc,byte>(ibxSource.Image.Bitmap);
                Image<Ycc, Byte> trainingArea = new Image<Ycc,byte>(_currentSelection.Size);
                CvInvoke.cvGetSubRect(source, trainingArea, _currentSelection);
                cbxVideo.Checked = false;

                MessageBox.Show("Learning " + _waitingToLearnBand.ToString());
                learnBandColor(_waitingToLearnBand, trainingArea);

                switch (_waitingToLearnBand)
                {
                    case BandColor.Red:
                        lblStatus.Text = "Select the Green band in the source";
                        btnLearnBandColors.Text = "Learn Green";
                        _waitingToLearnBand = BandColor.Green;
                        break;
                    case BandColor.Green:
                        lblStatus.Text = "Select the Orange band in the source";
                        btnLearnBandColors.Text = "Learn Orange";
                        _waitingToLearnBand = BandColor.Orange;
                        break;
                    case BandColor.Orange:
                        lblStatus.Text = "Select the Blue band in the source";
                        btnLearnBandColors.Text = "Learn Blue";
                        _waitingToLearnBand = BandColor.Blue;
                        break;
                    case BandColor.Blue:
                        lblStatus.Text = "Learning completed";
                        btnLearnBandColors.Text = "Learn Red";
                        _waitingToLearnBand = BandColor.Red;
                        break;
                }

                _statusWaitingForBandRegionSelection = false;
                ibxOutput.Image = trainingArea;
                _statusDragStarted = false;
                _currentSelection = new Rectangle();
            }
        }

        private void ibxSource_MouseMove(object sender, MouseEventArgs e)
        {

            if (_statusWaitingForBandRegionSelection && _statusDragStarted)
            {
                int width = e.X - _dragStartPoint.X;
                int height = e.Y - _dragStartPoint.Y;
                width = width > 0 ? width : 0;
                height = height > 0 ? height : 0;
                _currentSelection = new Rectangle(_dragStartPoint, new Size(width, height));
                if (!cbxVideo.Checked)
                {
                    // Restore the original still image
                    ibxSource.Image = _trueImageBeforeRectangleDrawn;
                }
                ibxSource.CreateGraphics().DrawRectangle(new Pen(Color.Red), _currentSelection);
            }
        }

        private void ckbFlipHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            _camera.FlipHorizontal = !_camera.FlipHorizontal;
        }

        private void tkbRedThreshold_Scroll(object sender, EventArgs e)
        {
            lblRedThreshold.Text = tkbRedThreshold.Value.ToString();
        }

        private void tkbGreenThreshold_Scroll(object sender, EventArgs e)
        {
            lblGreenThreshold.Text = tkbGreenThreshold.Value.ToString();
        }

        private void tkbOrangeThreshold_Scroll(object sender, EventArgs e)
        {
            lblOrangeThreshold.Text = tkbOrangeThreshold.Value.ToString();
        }

        private void tkbBlueThreshold_Scroll(object sender, EventArgs e)
        {
            lblBlueThreshold.Text = tkbBlueThreshold.Value.ToString();
        }
    }
}

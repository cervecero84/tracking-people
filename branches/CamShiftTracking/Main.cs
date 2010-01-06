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

        public Main()
        {
            InitializeComponent();
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

        private void btnCamera_Click(object sender, EventArgs e)
        {
            if (_camera != null)
            {
                _camera.Dispose();
            }

            _camera = new Capture(0);
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
            Image<Bgr, Byte> result = new Image<Bgr,byte>(source.Size);
            
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
            Image<Bgr, Byte> bandImage = new Image<Bgr, byte>("template/OrangeBand.jpg");

            Image<Gray, Byte>[] bandImageChannels = bandImage.Convert<Ycc, Byte>().Split();
            Image<Gray, Byte>[] sourceChannels = source.Convert<Ycc, Byte>().Split();
            // Use the whole image
            Image<Gray, Byte> mask = new Image<Gray, byte>(bandImage.Width, bandImage.Height, new Gray(255));

            // Initialization
            int channelIndex;
            IntPtr[] bandImageChannelsPtr = new IntPtr[1];
            IntPtr[] sourcePtr = new IntPtr[1];
            DenseHistogram hist = new DenseHistogram(16, new RangeF(0,255));

            // Use the Cb-channel
            channelIndex = 1;
            bandImageChannelsPtr[0] = bandImageChannels[channelIndex];
            sourcePtr[0] = sourceChannels[channelIndex];

            CvInvoke.cvCalcHist(bandImageChannelsPtr, hist, false, mask);
            Image<Gray, Byte> backProjectCb = new Image<Gray,byte>(source.Size);
            CvInvoke.cvCalcBackProject(sourcePtr, backProjectCb, hist);

            // Use the Cr-channel
            channelIndex = 2;
            bandImageChannelsPtr[0] = bandImageChannels[channelIndex];
            sourcePtr[0] = sourceChannels[channelIndex];

            CvInvoke.cvCalcHist(bandImageChannelsPtr, hist, false, mask);
            Image<Gray, Byte> backProjectCr = new Image<Gray, byte>(source.Size);
            CvInvoke.cvCalcBackProject(sourcePtr, backProjectCr, hist);
            
            // Output the source and the result
            ibxSource.Image = source;
            ibxOutput.Image = backProjectCb.And(backProjectCr).ThresholdBinary(new Gray(200), new Gray(255)).Erode(1).Dilate(5);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            processFrame(sender, e);
        }

        private void btnSetFrameLimit_Click(object sender, EventArgs e)
        {
            _msPerFrame = (int)(1000.0/Int32.Parse(txtFrameLimit.Text));
        }
    }
}

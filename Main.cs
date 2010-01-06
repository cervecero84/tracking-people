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
            Image<Ycc, Byte> bandTemplate = new Image<Ycc, byte>("template/OrangeBand.jpg");

            int kSize;
            if (!Int32.TryParse(txtKernelSize.Text.ToString(), out kSize)) kSize = 3;
            int cSigma;
            if (!Int32.TryParse(txtColorSigma.Text.ToString(), out cSigma)) cSigma = 15;
            int sSigma;
            if (!Int32.TryParse(txtSpaceSigma.Text.ToString(), out sSigma)) sSigma = 5;
            txtKernelSize.Text = kSize.ToString();
            txtColorSigma.Text = cSigma.ToString();
            txtSpaceSigma.Text = sSigma.ToString();

            Image<Bgr, Byte> result;
            if (cbxFilterType.SelectedText == "Blur")
            {
                 result = source.SmoothBlur(kSize, cSigma);
            }
            else if (cbxFilterType.SelectedText == "Gaussian")
            {
                result = source.SmoothGaussian(kSize);
            }
            else if (cbxFilterType.SelectedText == "Median")
            {
                result = source.SmoothMedian(kSize);
            }
            else
            {
                result = source.SmoothBilatral(kSize, cSigma, sSigma);
            }
            lblStatus.Text = cbxFilterType.SelectedText + " smoothing being applied: (" + kSize.ToString() + ", " + cSigma.ToString() + ", " + sSigma.ToString() + ")";

            ibxSource.Image = source;
            ibxOutput.Image = result;
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

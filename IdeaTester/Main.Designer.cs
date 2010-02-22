namespace IdeaTester
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.ofdSourceVideo = new System.Windows.Forms.OpenFileDialog();
            this.lblPlayingFrom = new System.Windows.Forms.Label();
            this.lblVideoSource = new System.Windows.Forms.Label();
            this.btnCamera = new System.Windows.Forms.Button();
            this.ibxSource = new Emgu.CV.UI.ImageBox();
            this.ibxOutput = new Emgu.CV.UI.ImageBox();
            this.cbxVideo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWiimoteCalibrate = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbxFlipHorizontal = new System.Windows.Forms.CheckBox();
            this.btnCameraCalibrate = new System.Windows.Forms.Button();
            this.lblFPS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ibxSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibxOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(21, 318);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(156, 32);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Capture + Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.Location = new System.Drawing.Point(782, 318);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(75, 32);
            this.btnVideo.TabIndex = 4;
            this.btnVideo.Text = "Video (...)";
            this.btnVideo.UseVisualStyleBackColor = true;
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // ofdSourceVideo
            // 
            this.ofdSourceVideo.FileName = "openFileDialog1";
            // 
            // lblPlayingFrom
            // 
            this.lblPlayingFrom.AutoSize = true;
            this.lblPlayingFrom.Location = new System.Drawing.Point(535, 328);
            this.lblPlayingFrom.Name = "lblPlayingFrom";
            this.lblPlayingFrom.Size = new System.Drawing.Size(70, 13);
            this.lblPlayingFrom.TabIndex = 5;
            this.lblPlayingFrom.Text = "Playing from: ";
            // 
            // lblVideoSource
            // 
            this.lblVideoSource.AutoSize = true;
            this.lblVideoSource.Location = new System.Drawing.Point(611, 328);
            this.lblVideoSource.Name = "lblVideoSource";
            this.lblVideoSource.Size = new System.Drawing.Size(43, 13);
            this.lblVideoSource.TabIndex = 6;
            this.lblVideoSource.Text = "Camera";
            // 
            // btnCamera
            // 
            this.btnCamera.Location = new System.Drawing.Point(701, 318);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(75, 32);
            this.btnCamera.TabIndex = 7;
            this.btnCamera.Text = "Camera";
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // ibxSource
            // 
            this.ibxSource.BackColor = System.Drawing.SystemColors.ControlText;
            this.ibxSource.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ibxSource.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ibxSource.Location = new System.Drawing.Point(21, 12);
            this.ibxSource.Name = "ibxSource";
            this.ibxSource.Size = new System.Drawing.Size(400, 300);
            this.ibxSource.TabIndex = 8;
            this.ibxSource.TabStop = false;
            this.ibxSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ibxSource_MouseClick);
            // 
            // ibxOutput
            // 
            this.ibxOutput.BackColor = System.Drawing.SystemColors.ControlText;
            this.ibxOutput.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ibxOutput.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ibxOutput.Location = new System.Drawing.Point(457, 12);
            this.ibxOutput.Name = "ibxOutput";
            this.ibxOutput.Size = new System.Drawing.Size(400, 300);
            this.ibxOutput.TabIndex = 9;
            this.ibxOutput.TabStop = false;
            this.ibxOutput.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ibxOutput_MouseClick);
            // 
            // cbxVideo
            // 
            this.cbxVideo.AutoSize = true;
            this.cbxVideo.Location = new System.Drawing.Point(183, 327);
            this.cbxVideo.Name = "cbxVideo";
            this.cbxVideo.Size = new System.Drawing.Size(119, 17);
            this.cbxVideo.TabIndex = 10;
            this.cbxVideo.Text = "Continuous Capture";
            this.cbxVideo.UseVisualStyleBackColor = true;
            this.cbxVideo.CheckedChanged += new System.EventHandler(this.cbxVideo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Camera";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(454, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Wiimote";
            // 
            // btnWiimoteCalibrate
            // 
            this.btnWiimoteCalibrate.Location = new System.Drawing.Point(21, 356);
            this.btnWiimoteCalibrate.Name = "btnWiimoteCalibrate";
            this.btnWiimoteCalibrate.Size = new System.Drawing.Size(156, 32);
            this.btnWiimoteCalibrate.TabIndex = 15;
            this.btnWiimoteCalibrate.Text = "Wiimote IR Calibrate";
            this.btnWiimoteCalibrate.UseVisualStyleBackColor = true;
            this.btnWiimoteCalibrate.Click += new System.EventHandler(this.btnWiimoteCalibrate_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(464, 356);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 16;
            this.lblStatus.Text = "Status";
            // 
            // cbxFlipHorizontal
            // 
            this.cbxFlipHorizontal.AutoSize = true;
            this.cbxFlipHorizontal.Location = new System.Drawing.Point(183, 350);
            this.cbxFlipHorizontal.Name = "cbxFlipHorizontal";
            this.cbxFlipHorizontal.Size = new System.Drawing.Size(92, 17);
            this.cbxFlipHorizontal.TabIndex = 17;
            this.cbxFlipHorizontal.Text = "Flip Horizontal";
            this.cbxFlipHorizontal.UseVisualStyleBackColor = true;
            this.cbxFlipHorizontal.CheckedChanged += new System.EventHandler(this.cbxFlipHorizontal_CheckedChanged);
            // 
            // btnCameraCalibrate
            // 
            this.btnCameraCalibrate.Location = new System.Drawing.Point(21, 394);
            this.btnCameraCalibrate.Name = "btnCameraCalibrate";
            this.btnCameraCalibrate.Size = new System.Drawing.Size(156, 32);
            this.btnCameraCalibrate.TabIndex = 18;
            this.btnCameraCalibrate.Text = "Camera Calibrate";
            this.btnCameraCalibrate.UseVisualStyleBackColor = true;
            this.btnCameraCalibrate.Click += new System.EventHandler(this.btnCameraCalibrate_Click);
            // 
            // lblFPS
            // 
            this.lblFPS.AutoSize = true;
            this.lblFPS.Location = new System.Drawing.Point(308, 328);
            this.lblFPS.Name = "lblFPS";
            this.lblFPS.Size = new System.Drawing.Size(27, 13);
            this.lblFPS.TabIndex = 19;
            this.lblFPS.Text = "FPS";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 435);
            this.Controls.Add(this.lblFPS);
            this.Controls.Add(this.btnCameraCalibrate);
            this.Controls.Add(this.cbxFlipHorizontal);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnWiimoteCalibrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxVideo);
            this.Controls.Add(this.ibxOutput);
            this.Controls.Add(this.ibxSource);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.lblVideoSource);
            this.Controls.Add(this.lblPlayingFrom);
            this.Controls.Add(this.btnVideo);
            this.Controls.Add(this.btnProcess);
            this.Name = "Main";
            this.Text = "Idea Tester";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ibxSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibxOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.OpenFileDialog ofdSourceVideo;
        private System.Windows.Forms.Label lblPlayingFrom;
        private System.Windows.Forms.Label lblVideoSource;
        private System.Windows.Forms.Button btnCamera;
        private Emgu.CV.UI.ImageBox ibxSource;
        private Emgu.CV.UI.ImageBox ibxOutput;
        private System.Windows.Forms.CheckBox cbxVideo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWiimoteCalibrate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox cbxFlipHorizontal;
        private System.Windows.Forms.Button btnCameraCalibrate;
        private System.Windows.Forms.Label lblFPS;
    }
}


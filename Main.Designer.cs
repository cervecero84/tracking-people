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
            this.txtFrameLimit = new System.Windows.Forms.TextBox();
            this.btnSetFrameLimit = new System.Windows.Forms.Button();
            this.txtKernelSize = new System.Windows.Forms.TextBox();
            this.txtColorSigma = new System.Windows.Forms.TextBox();
            this.txtSpaceSigma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbxFilterType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibxSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibxOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(184, 366);
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
            this.ibxSource.Location = new System.Drawing.Point(21, 12);
            this.ibxSource.Name = "ibxSource";
            this.ibxSource.Size = new System.Drawing.Size(400, 300);
            this.ibxSource.TabIndex = 8;
            this.ibxSource.TabStop = false;
            // 
            // ibxOutput
            // 
            this.ibxOutput.BackColor = System.Drawing.SystemColors.ControlText;
            this.ibxOutput.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ibxOutput.Location = new System.Drawing.Point(457, 12);
            this.ibxOutput.Name = "ibxOutput";
            this.ibxOutput.Size = new System.Drawing.Size(400, 300);
            this.ibxOutput.TabIndex = 9;
            this.ibxOutput.TabStop = false;
            // 
            // cbxVideo
            // 
            this.cbxVideo.AutoSize = true;
            this.cbxVideo.Location = new System.Drawing.Point(21, 327);
            this.cbxVideo.Name = "cbxVideo";
            this.cbxVideo.Size = new System.Drawing.Size(119, 17);
            this.cbxVideo.TabIndex = 10;
            this.cbxVideo.Text = "Continuous Capture";
            this.cbxVideo.UseVisualStyleBackColor = true;
            this.cbxVideo.CheckedChanged += new System.EventHandler(this.cbxVideo_CheckedChanged);
            // 
            // txtFrameLimit
            // 
            this.txtFrameLimit.Location = new System.Drawing.Point(146, 325);
            this.txtFrameLimit.Name = "txtFrameLimit";
            this.txtFrameLimit.Size = new System.Drawing.Size(32, 20);
            this.txtFrameLimit.TabIndex = 11;
            // 
            // btnSetFrameLimit
            // 
            this.btnSetFrameLimit.Location = new System.Drawing.Point(184, 318);
            this.btnSetFrameLimit.Name = "btnSetFrameLimit";
            this.btnSetFrameLimit.Size = new System.Drawing.Size(75, 32);
            this.btnSetFrameLimit.TabIndex = 12;
            this.btnSetFrameLimit.Text = "Set F. Limit";
            this.btnSetFrameLimit.UseVisualStyleBackColor = true;
            this.btnSetFrameLimit.Click += new System.EventHandler(this.btnSetFrameLimit_Click);
            // 
            // txtKernelSize
            // 
            this.txtKernelSize.Location = new System.Drawing.Point(23, 373);
            this.txtKernelSize.Name = "txtKernelSize";
            this.txtKernelSize.Size = new System.Drawing.Size(45, 20);
            this.txtKernelSize.TabIndex = 13;
            // 
            // txtColorSigma
            // 
            this.txtColorSigma.Location = new System.Drawing.Point(74, 373);
            this.txtColorSigma.Name = "txtColorSigma";
            this.txtColorSigma.Size = new System.Drawing.Size(45, 20);
            this.txtColorSigma.TabIndex = 14;
            // 
            // txtSpaceSigma
            // 
            this.txtSpaceSigma.Location = new System.Drawing.Point(125, 373);
            this.txtSpaceSigma.Name = "txtSpaceSigma";
            this.txtSpaceSigma.Size = new System.Drawing.Size(45, 20);
            this.txtSpaceSigma.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "kernel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "space";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(457, 366);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status messages go here";
            // 
            // cbxFilterType
            // 
            this.cbxFilterType.FormattingEnabled = true;
            this.cbxFilterType.Items.AddRange(new object[] {
            "Blur",
            "Gaussian",
            "Median",
            "Bilateral"});
            this.cbxFilterType.Location = new System.Drawing.Point(266, 328);
            this.cbxFilterType.Name = "cbxFilterType";
            this.cbxFilterType.Size = new System.Drawing.Size(74, 21);
            this.cbxFilterType.TabIndex = 20;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 405);
            this.Controls.Add(this.cbxFilterType);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSpaceSigma);
            this.Controls.Add(this.txtColorSigma);
            this.Controls.Add(this.txtKernelSize);
            this.Controls.Add(this.btnSetFrameLimit);
            this.Controls.Add(this.txtFrameLimit);
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
        private System.Windows.Forms.TextBox txtFrameLimit;
        private System.Windows.Forms.Button btnSetFrameLimit;
        private System.Windows.Forms.TextBox txtKernelSize;
        private System.Windows.Forms.TextBox txtColorSigma;
        private System.Windows.Forms.TextBox txtSpaceSigma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cbxFilterType;
    }
}


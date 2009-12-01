namespace EmguCVTest
{
    partial class Form1
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
            this.btnBgCapture = new System.Windows.Forms.Button();
            this.btnBeginDifferencing = new System.Windows.Forms.Button();
            this.btnShowBackground = new System.Windows.Forms.Button();
            this.capturedImageBox = new Emgu.CV.UI.ImageBox();
            this.motionImageBox = new Emgu.CV.UI.ImageBox();
            this.backgroundImage = new Emgu.CV.UI.ImageBox();
            this.imgImageBox = new Emgu.CV.UI.ImageBox();
            this.grayImageBox = new Emgu.CV.UI.ImageBox();
            this.detectSQ = new System.Windows.Forms.Button();
            this.tbrBgAdaptationRate = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBgAdaptationRate = new System.Windows.Forms.Label();
            this.btnAdaptiveBackground = new System.Windows.Forms.Button();
            this.DetectSkin = new System.Windows.Forms.Button();
            this.btnAffineTranform = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrBgAdaptationRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBgCapture
            // 
            this.btnBgCapture.Location = new System.Drawing.Point(12, 12);
            this.btnBgCapture.Name = "btnBgCapture";
            this.btnBgCapture.Size = new System.Drawing.Size(177, 52);
            this.btnBgCapture.TabIndex = 0;
            this.btnBgCapture.Text = "Take Background Image [5s]";
            this.btnBgCapture.UseVisualStyleBackColor = true;
            this.btnBgCapture.Click += new System.EventHandler(this.btnBgCapture_Click);
            // 
            // btnBeginDifferencing
            // 
            this.btnBeginDifferencing.Location = new System.Drawing.Point(12, 70);
            this.btnBeginDifferencing.Name = "btnBeginDifferencing";
            this.btnBeginDifferencing.Size = new System.Drawing.Size(177, 52);
            this.btnBeginDifferencing.TabIndex = 1;
            this.btnBeginDifferencing.Text = "Begin Differencing";
            this.btnBeginDifferencing.UseVisualStyleBackColor = true;
            this.btnBeginDifferencing.Click += new System.EventHandler(this.btnBeginDifferencing_Click);
            // 
            // btnShowBackground
            // 
            this.btnShowBackground.Location = new System.Drawing.Point(12, 128);
            this.btnShowBackground.Name = "btnShowBackground";
            this.btnShowBackground.Size = new System.Drawing.Size(177, 52);
            this.btnShowBackground.TabIndex = 2;
            this.btnShowBackground.Text = "Show Background Image";
            this.btnShowBackground.UseVisualStyleBackColor = true;
            this.btnShowBackground.Click += new System.EventHandler(this.btnShowBackground_Click);
            // 
            // capturedImageBox
            // 
            this.capturedImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.capturedImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.capturedImageBox.Location = new System.Drawing.Point(195, 12);
            this.capturedImageBox.Name = "capturedImageBox";
            this.capturedImageBox.Size = new System.Drawing.Size(400, 300);
            this.capturedImageBox.TabIndex = 3;
            this.capturedImageBox.TabStop = false;
            // 
            // motionImageBox
            // 
            this.motionImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.motionImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.motionImageBox.Location = new System.Drawing.Point(601, 12);
            this.motionImageBox.Name = "motionImageBox";
            this.motionImageBox.Size = new System.Drawing.Size(400, 300);
            this.motionImageBox.TabIndex = 4;
            this.motionImageBox.TabStop = false;
            // 
            // backgroundImage
            // 
            this.backgroundImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.backgroundImage.Location = new System.Drawing.Point(12, 441);
            this.backgroundImage.Name = "backgroundImage";
            this.backgroundImage.Size = new System.Drawing.Size(177, 132);
            this.backgroundImage.TabIndex = 5;
            this.backgroundImage.TabStop = false;
            // 
            // imgImageBox
            // 
            this.imgImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.imgImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imgImageBox.Location = new System.Drawing.Point(195, 318);
            this.imgImageBox.Name = "imgImageBox";
            this.imgImageBox.Size = new System.Drawing.Size(400, 300);
            this.imgImageBox.TabIndex = 6;
            this.imgImageBox.TabStop = false;
            // 
            // grayImageBox
            // 
            this.grayImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.grayImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.grayImageBox.Location = new System.Drawing.Point(601, 318);
            this.grayImageBox.Name = "grayImageBox";
            this.grayImageBox.Size = new System.Drawing.Size(400, 300);
            this.grayImageBox.TabIndex = 7;
            this.grayImageBox.TabStop = false;
            // 
            // detectSQ
            // 
            this.detectSQ.Location = new System.Drawing.Point(12, 187);
            this.detectSQ.Name = "detectSQ";
            this.detectSQ.Size = new System.Drawing.Size(177, 51);
            this.detectSQ.TabIndex = 8;
            this.detectSQ.Text = "Detect Squares";
            this.detectSQ.UseVisualStyleBackColor = true;
            this.detectSQ.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbrBgAdaptationRate
            // 
            this.tbrBgAdaptationRate.Location = new System.Drawing.Point(12, 267);
            this.tbrBgAdaptationRate.Maximum = 100;
            this.tbrBgAdaptationRate.Name = "tbrBgAdaptationRate";
            this.tbrBgAdaptationRate.Size = new System.Drawing.Size(177, 45);
            this.tbrBgAdaptationRate.TabIndex = 9;
            this.tbrBgAdaptationRate.Scroll += new System.EventHandler(this.tbrBgAdaptationRate_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Background Adaptation Rate";
            // 
            // lblBgAdaptationRate
            // 
            this.lblBgAdaptationRate.AutoSize = true;
            this.lblBgAdaptationRate.Location = new System.Drawing.Point(13, 299);
            this.lblBgAdaptationRate.Name = "lblBgAdaptationRate";
            this.lblBgAdaptationRate.Size = new System.Drawing.Size(33, 13);
            this.lblBgAdaptationRate.TabIndex = 11;
            this.lblBgAdaptationRate.Text = "Rate:";
            // 
            // btnAdaptiveBackground
            // 
            this.btnAdaptiveBackground.Location = new System.Drawing.Point(12, 318);
            this.btnAdaptiveBackground.Name = "btnAdaptiveBackground";
            this.btnAdaptiveBackground.Size = new System.Drawing.Size(177, 51);
            this.btnAdaptiveBackground.TabIndex = 12;
            this.btnAdaptiveBackground.Text = "TURN ON AP";
            this.btnAdaptiveBackground.UseVisualStyleBackColor = true;
            this.btnAdaptiveBackground.Click += new System.EventHandler(this.btnAdaptiveBackground_Click);
            // 
            // DetectSkin
            // 
            this.DetectSkin.Location = new System.Drawing.Point(12, 384);
            this.DetectSkin.Name = "DetectSkin";
            this.DetectSkin.Size = new System.Drawing.Size(177, 51);
            this.DetectSkin.TabIndex = 13;
            this.DetectSkin.Text = "Detect Skin";
            this.DetectSkin.UseVisualStyleBackColor = true;
            this.DetectSkin.Click += new System.EventHandler(this.DetectSkin_Click);
            // 
            // btnAffineTranform
            // 
            this.btnAffineTranform.Location = new System.Drawing.Point(12, 558);
            this.btnAffineTranform.Name = "btnAffineTranform";
            this.btnAffineTranform.Size = new System.Drawing.Size(177, 46);
            this.btnAffineTranform.TabIndex = 13;
            this.btnAffineTranform.Text = "Affine Transform";
            this.btnAffineTranform.UseVisualStyleBackColor = true;
            this.btnAffineTranform.Click += new System.EventHandler(this.btnAffineTranform_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 631);
            this.Controls.Add(this.DetectSkin);
            this.Controls.Add(this.btnAffineTranform);
            this.Controls.Add(this.btnAdaptiveBackground);
            this.Controls.Add(this.lblBgAdaptationRate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbrBgAdaptationRate);
            this.Controls.Add(this.detectSQ);
            this.Controls.Add(this.grayImageBox);
            this.Controls.Add(this.imgImageBox);
            this.Controls.Add(this.backgroundImage);
            this.Controls.Add(this.motionImageBox);
            this.Controls.Add(this.capturedImageBox);
            this.Controls.Add(this.btnShowBackground);
            this.Controls.Add(this.btnBeginDifferencing);
            this.Controls.Add(this.btnBgCapture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrBgAdaptationRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBgCapture;
        private System.Windows.Forms.Button btnBeginDifferencing;
        private System.Windows.Forms.Button btnShowBackground;
        private Emgu.CV.UI.ImageBox capturedImageBox;
        private Emgu.CV.UI.ImageBox motionImageBox;
        private Emgu.CV.UI.ImageBox backgroundImage;
        private Emgu.CV.UI.ImageBox imgImageBox;
        private Emgu.CV.UI.ImageBox grayImageBox;
        private System.Windows.Forms.Button detectSQ;
        private System.Windows.Forms.TrackBar tbrBgAdaptationRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBgAdaptationRate;
        private System.Windows.Forms.Button btnAdaptiveBackground;
        private System.Windows.Forms.Button DetectSkin;
        private System.Windows.Forms.Button btnAffineTranform;
    }
}


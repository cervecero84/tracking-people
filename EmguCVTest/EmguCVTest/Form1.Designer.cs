﻿namespace EmguCVTest
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
            ((System.ComponentModel.ISupportInitialize)(this.capturedImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grayImageBox)).BeginInit();
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
            this.capturedImageBox.Size = new System.Drawing.Size(400, 400);
            this.capturedImageBox.TabIndex = 3;
            this.capturedImageBox.TabStop = false;
            // 
            // motionImageBox
            // 
            this.motionImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.motionImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.motionImageBox.Location = new System.Drawing.Point(601, 12);
            this.motionImageBox.Name = "motionImageBox";
            this.motionImageBox.Size = new System.Drawing.Size(400, 400);
            this.motionImageBox.TabIndex = 4;
            this.motionImageBox.TabStop = false;
            // 
            // backgroundImage
            // 
            this.backgroundImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.backgroundImage.Location = new System.Drawing.Point(12, 431);
            this.backgroundImage.Name = "backgroundImage";
            this.backgroundImage.Size = new System.Drawing.Size(177, 177);
            this.backgroundImage.TabIndex = 5;
            this.backgroundImage.TabStop = false;
            // 
            // imgImageBox
            // 
            this.imgImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.imgImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.imgImageBox.Location = new System.Drawing.Point(195, 431);
            this.imgImageBox.Name = "imgImageBox";
            this.imgImageBox.Size = new System.Drawing.Size(400, 400);
            this.imgImageBox.TabIndex = 6;
            this.imgImageBox.TabStop = false;
            // 
            // grayImageBox
            // 
            this.grayImageBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.grayImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.grayImageBox.Location = new System.Drawing.Point(601, 431);
            this.grayImageBox.Name = "grayImageBox";
            this.grayImageBox.Size = new System.Drawing.Size(400, 400);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 843);
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
            this.ResumeLayout(false);

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
    }
}

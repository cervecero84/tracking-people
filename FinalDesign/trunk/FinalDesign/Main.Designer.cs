namespace FinalSolution
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
            this.ibxOutput = new Emgu.CV.UI.ImageBox();
            this.ibxSource = new Emgu.CV.UI.ImageBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ibxOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibxSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ibxOutput
            // 
            this.ibxOutput.BackColor = System.Drawing.SystemColors.ControlText;
            this.ibxOutput.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ibxOutput.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ibxOutput.Location = new System.Drawing.Point(465, 28);
            this.ibxOutput.Name = "ibxOutput";
            this.ibxOutput.Size = new System.Drawing.Size(400, 300);
            this.ibxOutput.TabIndex = 11;
            this.ibxOutput.TabStop = false;
            // 
            // ibxSource
            // 
            this.ibxSource.BackColor = System.Drawing.SystemColors.ControlText;
            this.ibxSource.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ibxSource.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.ibxSource.Location = new System.Drawing.Point(29, 28);
            this.ibxSource.Name = "ibxSource";
            this.ibxSource.Size = new System.Drawing.Size(400, 300);
            this.ibxSource.TabIndex = 10;
            this.ibxSource.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Wiimote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Camera";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(32, 335);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 17;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(129, 340);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 394);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ibxOutput);
            this.Controls.Add(this.ibxSource);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ibxOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibxSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ibxOutput;
        private Emgu.CV.UI.ImageBox ibxSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblStatus;
    }
}


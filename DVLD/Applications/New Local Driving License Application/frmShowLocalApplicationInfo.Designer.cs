namespace DVLD.Applications
{
    partial class frmShowLocalApplicationInfo
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
            this.ctrlLocalDrivinglicenseApplicationInfo1 = new DVLD.Applications.New_Local_Driving_License_Application.Controls.ctrlLocalDrivinglicenseApplicationInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivinglicenseApplicationInfo1
            // 
            this.ctrlLocalDrivinglicenseApplicationInfo1.Location = new System.Drawing.Point(-6, 13);
            this.ctrlLocalDrivinglicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlLocalDrivinglicenseApplicationInfo1.Name = "ctrlLocalDrivinglicenseApplicationInfo1";
            this.ctrlLocalDrivinglicenseApplicationInfo1.Size = new System.Drawing.Size(1223, 595);
            this.ctrlLocalDrivinglicenseApplicationInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1004, 603);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(203, 63);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 670);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLocalDrivinglicenseApplicationInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmShowApplicationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowApplicationInfo";
            this.Load += new System.EventHandler(this.frmShowApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private New_Local_Driving_License_Application.Controls.ctrlLocalDrivinglicenseApplicationInfo ctrlLocalDrivinglicenseApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}
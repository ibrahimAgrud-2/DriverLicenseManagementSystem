namespace DVLD.Licenses
{
    partial class frmShowDrivingLicenseInfo
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
            this.ctrlShowLicenseInfo1 = new DVLD.Licenses.Controls.ctrlShowLicenseInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlShowLicenseInfo1
            // 
            this.ctrlShowLicenseInfo1.Location = new System.Drawing.Point(0, 83);
            this.ctrlShowLicenseInfo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlShowLicenseInfo1.Name = "ctrlShowLicenseInfo1";
            this.ctrlShowLicenseInfo1.Size = new System.Drawing.Size(1123, 420);
            this.ctrlShowLicenseInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(437, 519);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(252, 57);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowDrivingLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 588);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlShowLicenseInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmShowDrivingLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowDrivingLicenseInfo";
            this.Load += new System.EventHandler(this.frmShowDrivingLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlShowLicenseInfo ctrlShowLicenseInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}
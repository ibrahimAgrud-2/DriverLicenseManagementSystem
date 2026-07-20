namespace DVLD.Applications.New_Local_Driving_License_Application
{
    partial class frmLDLAInfo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlLDLAInfo1 = new DVLD.Applications.New_Local_Driving_License_Application.Controls.ctrlLDLAInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(836, 423);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlLDLAInfo1
            // 
            this.ctrlLDLAInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLDLAInfo1.Name = "ctrlLDLAInfo1";
            this.ctrlLDLAInfo1.Size = new System.Drawing.Size(950, 403);
            this.ctrlLDLAInfo1.TabIndex = 0;
            // 
            // frmLDLAInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 486);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLDLAInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLDLAInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLDLAInfo";
            this.Load += new System.EventHandler(this.frmLDLAInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlLDLAInfo ctrlLDLAInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}
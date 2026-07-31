namespace DVLD.Licenses
{
    partial class frmIssueDriverLicenseFirstTime
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivinglicenseApplicationInfo1
            // 
            this.ctrlLocalDrivinglicenseApplicationInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLocalDrivinglicenseApplicationInfo1.Location = new System.Drawing.Point(13, 9);
            this.ctrlLocalDrivinglicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLocalDrivinglicenseApplicationInfo1.Name = "ctrlLocalDrivinglicenseApplicationInfo1";
            this.ctrlLocalDrivinglicenseApplicationInfo1.Size = new System.Drawing.Size(1089, 480);
            this.ctrlLocalDrivinglicenseApplicationInfo1.TabIndex = 0;
            this.ctrlLocalDrivinglicenseApplicationInfo1.Load += new System.EventHandler(this.ctrlLocalDrivinglicenseApplicationInfo1_Load);
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(233, 490);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(710, 99);
            this.txtNotes.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(826, 595);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Issue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Note: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(677, 595);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmIssueDriverLicenseFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 647);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.ctrlLocalDrivinglicenseApplicationInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIssueDriverLicenseFirstTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIssueDriverLicenseFirstTime";
            this.Load += new System.EventHandler(this.frmIssueDriverLicenseFirstTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.New_Local_Driving_License_Application.Controls.ctrlLocalDrivinglicenseApplicationInfo ctrlLocalDrivinglicenseApplicationInfo1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}
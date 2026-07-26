namespace DVLD.Test
{
    partial class frmAddUpdateTestAppointment
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblApplicationIDForRetakeTest = new System.Windows.Forms.Label();
            this.lblRetakeTestFees = new System.Windows.Forms.Label();
            this.lblTotalFee = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.ctrlLDLAsTestAppointmentsInfo1 = new DVLD.Test.ctrlLDLAsTestAppointmentsInfo();
            this.lblWarn = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(608, 868);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 11);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(241, 690);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 54);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(179, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Schedule Test";
            // 
            // gbMain
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblApplicationIDForRetakeTest);
            this.groupBox1.Controls.Add(this.lblRetakeTestFees);
            this.groupBox1.Controls.Add(this.lblTotalFee);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 328);
            this.groupBox1.Name = "gbMain";
            this.groupBox1.Size = new System.Drawing.Size(562, 185);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Retake Test Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 25);
            this.label2.TabIndex = 97;
            this.label2.Text = "Retake Test Fee";
            // 
            // lblApplicationIDForRetakeTest
            // 
            this.lblApplicationIDForRetakeTest.AutoSize = true;
            this.lblApplicationIDForRetakeTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblApplicationIDForRetakeTest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblApplicationIDForRetakeTest.Location = new System.Drawing.Point(179, 100);
            this.lblApplicationIDForRetakeTest.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblApplicationIDForRetakeTest.Name = "lblApplicationIDForRetakeTest";
            this.lblApplicationIDForRetakeTest.Size = new System.Drawing.Size(46, 25);
            this.lblApplicationIDForRetakeTest.TabIndex = 99;
            this.lblApplicationIDForRetakeTest.Text = "N/A";
            // 
            // lblRetakeTestFees
            // 
            this.lblRetakeTestFees.AutoSize = true;
            this.lblRetakeTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRetakeTestFees.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRetakeTestFees.Location = new System.Drawing.Point(179, 49);
            this.lblRetakeTestFees.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblRetakeTestFees.Name = "lblRetakeTestFees";
            this.lblRetakeTestFees.Size = new System.Drawing.Size(23, 25);
            this.lblRetakeTestFees.TabIndex = 99;
            this.lblRetakeTestFees.Text = "0";
            // 
            // lblTotalFee
            // 
            this.lblTotalFee.AutoSize = true;
            this.lblTotalFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTotalFee.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalFee.Location = new System.Drawing.Point(436, 49);
            this.lblTotalFee.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalFee.Name = "lblTotalFee";
            this.lblTotalFee.Size = new System.Drawing.Size(23, 25);
            this.lblTotalFee.TabIndex = 99;
            this.lblTotalFee.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(321, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 25);
            this.label7.TabIndex = 99;
            this.label7.Text = "Total Fees";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(17, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 25);
            this.label5.TabIndex = 98;
            this.label5.Text = "Retake App LocalDrivingLicenseApplicationID";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(451, 520);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 54);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.groupBox1);
            this.gbMain.Controls.Add(this.ctrlLDLAsTestAppointmentsInfo1);
            this.gbMain.Controls.Add(this.btnSave);
            this.gbMain.Location = new System.Drawing.Point(35, 102);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(580, 581);
            this.gbMain.TabIndex = 5;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Test Type";
            // 
            // ctrlLDLAsTestAppointmentsInfo1
            // 
            this.ctrlLDLAsTestAppointmentsInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ctrlLDLAsTestAppointmentsInfo1.Location = new System.Drawing.Point(18, 28);
            this.ctrlLDLAsTestAppointmentsInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLDLAsTestAppointmentsInfo1.Name = "ctrlLDLAsTestAppointmentsInfo1";
            this.ctrlLDLAsTestAppointmentsInfo1.Size = new System.Drawing.Size(580, 308);
            this.ctrlLDLAsTestAppointmentsInfo1.TabIndex = 2;
            // 
            // lblWarn
            // 
            this.lblWarn.AutoSize = true;
            this.lblWarn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblWarn.ForeColor = System.Drawing.Color.Red;
            this.lblWarn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWarn.Location = new System.Drawing.Point(134, 56);
            this.lblWarn.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(335, 25);
            this.lblWarn.TabIndex = 98;
            this.lblWarn.Text = "Person Already Sat for Test, cant edit";
            this.lblWarn.Visible = false;
            // 
            // frmAddUpdateTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 750);
            this.Controls.Add(this.lblWarn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddUpdateTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.frmAddUpdateTestAppointment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private ctrlLDLAsTestAppointmentsInfo ctrlLDLAsTestAppointmentsInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRetakeTestFees;
        private System.Windows.Forms.Label lblTotalFee;
        private System.Windows.Forms.Label lblApplicationIDForRetakeTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Label lblWarn;
    }
}
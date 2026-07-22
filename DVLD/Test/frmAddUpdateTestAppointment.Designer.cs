namespace DVLD.Applications
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
            this.gbTestType = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gbRetakeTest = new System.Windows.Forms.GroupBox();
            this.lblTotalFee = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblRetakeDate = new System.Windows.Forms.Label();
            this.retakeTestAppID = new System.Windows.Forms.Label();
            this.RetakeTestFees = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.ctrlTestAppointmentInfo1 = new DVLD.Test.Controls.ctrlTestAppointmentInfo();
            this.gbTestType.SuspendLayout();
            this.gbRetakeTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTestType
            // 
            this.gbTestType.Controls.Add(this.ctrlTestAppointmentInfo1);
            this.gbTestType.Controls.Add(this.button1);
            this.gbTestType.Controls.Add(this.gbRetakeTest);
            this.gbTestType.Location = new System.Drawing.Point(12, 12);
            this.gbTestType.Name = "gbTestType";
            this.gbTestType.Size = new System.Drawing.Size(534, 700);
            this.gbTestType.TabIndex = 0;
            this.gbTestType.TabStop = false;
            this.gbTestType.Text = "Test";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(409, 661);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 39);
            this.button1.TabIndex = 200;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbRetakeTest
            // 
            this.gbRetakeTest.Controls.Add(this.lblTotalFee);
            this.gbRetakeTest.Controls.Add(this.label17);
            this.gbRetakeTest.Controls.Add(this.label18);
            this.gbRetakeTest.Controls.Add(this.lblRetakeDate);
            this.gbRetakeTest.Controls.Add(this.retakeTestAppID);
            this.gbRetakeTest.Controls.Add(this.RetakeTestFees);
            this.gbRetakeTest.Enabled = false;
            this.gbRetakeTest.Location = new System.Drawing.Point(13, 498);
            this.gbRetakeTest.Name = "gbRetakeTest";
            this.gbRetakeTest.Size = new System.Drawing.Size(515, 143);
            this.gbRetakeTest.TabIndex = 199;
            this.gbRetakeTest.TabStop = false;
            this.gbRetakeTest.Text = "Retake Test Info";
            // 
            // lblTotalFee
            // 
            this.lblTotalFee.AutoSize = true;
            this.lblTotalFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFee.Location = new System.Drawing.Point(417, 51);
            this.lblTotalFee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalFee.Name = "lblTotalFee";
            this.lblTotalFee.Size = new System.Drawing.Size(48, 25);
            this.lblTotalFee.TabIndex = 202;
            this.lblTotalFee.Text = "???";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(74, 91);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 25);
            this.label17.TabIndex = 201;
            this.label17.Text = "R.App.ID: ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(294, 51);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 25);
            this.label18.TabIndex = 200;
            this.label18.Text = "Total Fees: ";
            // 
            // lblRetakeDate
            // 
            this.lblRetakeDate.AutoSize = true;
            this.lblRetakeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetakeDate.Location = new System.Drawing.Point(193, 41);
            this.lblRetakeDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRetakeDate.Name = "lblRetakeDate";
            this.lblRetakeDate.Size = new System.Drawing.Size(60, 25);
            this.lblRetakeDate.TabIndex = 200;
            this.lblRetakeDate.Text = "????";
            // 
            // retakeTestAppID
            // 
            this.retakeTestAppID.AutoSize = true;
            this.retakeTestAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retakeTestAppID.Location = new System.Drawing.Point(193, 91);
            this.retakeTestAppID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.retakeTestAppID.Name = "retakeTestAppID";
            this.retakeTestAppID.Size = new System.Drawing.Size(60, 25);
            this.retakeTestAppID.TabIndex = 201;
            this.retakeTestAppID.Text = "Fees";
            // 
            // RetakeTestFees
            // 
            this.RetakeTestFees.AutoSize = true;
            this.RetakeTestFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetakeTestFees.Location = new System.Drawing.Point(7, 41);
            this.RetakeTestFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RetakeTestFees.Name = "RetakeTestFees";
            this.RetakeTestFees.Size = new System.Drawing.Size(182, 25);
            this.RetakeTestFees.TabIndex = 200;
            this.RetakeTestFees.Text = "Retake Test Fees";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(421, 718);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 39);
            this.button2.TabIndex = 200;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ctrlTestAppointmentInfo1
            // 
            this.ctrlTestAppointmentInfo1.Location = new System.Drawing.Point(6, 28);
            this.ctrlTestAppointmentInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlTestAppointmentInfo1.Name = "ctrlTestAppointmentInfo1";
            this.ctrlTestAppointmentInfo1.Size = new System.Drawing.Size(521, 450);
            this.ctrlTestAppointmentInfo1.TabIndex = 201;
            // 
            // frmAddUpdateTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 769);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gbTestType);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddUpdateTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Update Test Appointment";
            this.Load += new System.EventHandler(this.frmAddUpdateAppointment_Load);
            this.gbTestType.ResumeLayout(false);
            this.gbRetakeTest.ResumeLayout(false);
            this.gbRetakeTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTestType;
        private System.Windows.Forms.GroupBox gbRetakeTest;
        private System.Windows.Forms.Label lblTotalFee;
        private System.Windows.Forms.Label retakeTestAppID;
        private System.Windows.Forms.Label RetakeTestFees;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblRetakeDate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Test.Controls.ctrlTestAppointmentInfo ctrlTestAppointmentInfo1;
    }
}
namespace DVLD.Licenses.Controls
{
    partial class ctrlListLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tbLocalLicenses = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicenseList = new System.Windows.Forms.DataGridView();
            this.tbInternationalLicenses = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenseList = new System.Windows.Forms.DataGridView();
            this.lblRecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMain.SuspendLayout();
            this.tbLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseList)).BeginInit();
            this.tbInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseList)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbLocalLicenses);
            this.tbMain.Controls.Add(this.tbInternationalLicenses);
            this.tbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMain.Location = new System.Drawing.Point(3, 3);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(960, 285);
            this.tbMain.TabIndex = 0;
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.tbMain_SelectedIndexChanged);
            // 
            // tbLocalLicenses
            // 
            this.tbLocalLicenses.Controls.Add(this.label1);
            this.tbLocalLicenses.Controls.Add(this.dgvLocalLicenseList);
            this.tbLocalLicenses.Location = new System.Drawing.Point(4, 31);
            this.tbLocalLicenses.Name = "tbLocalLicenses";
            this.tbLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tbLocalLicenses.Size = new System.Drawing.Size(952, 250);
            this.tbLocalLicenses.TabIndex = 0;
            this.tbLocalLicenses.Text = "Local";
            this.tbLocalLicenses.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driving Licenses";
            // 
            // dgvLocalLicenseList
            // 
            this.dgvLocalLicenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenseList.Location = new System.Drawing.Point(3, 59);
            this.dgvLocalLicenseList.Name = "dgvLocalLicenseList";
            this.dgvLocalLicenseList.RowHeadersWidth = 51;
            this.dgvLocalLicenseList.RowTemplate.Height = 24;
            this.dgvLocalLicenseList.Size = new System.Drawing.Size(951, 195);
            this.dgvLocalLicenseList.TabIndex = 0;
            // 
            // tbInternationalLicenses
            // 
            this.tbInternationalLicenses.Controls.Add(this.label2);
            this.tbInternationalLicenses.Controls.Add(this.dgvInternationalLicenseList);
            this.tbInternationalLicenses.Location = new System.Drawing.Point(4, 31);
            this.tbInternationalLicenses.Name = "tbInternationalLicenses";
            this.tbInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternationalLicenses.Size = new System.Drawing.Size(952, 250);
            this.tbInternationalLicenses.TabIndex = 1;
            this.tbInternationalLicenses.Text = "International";
            this.tbInternationalLicenses.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "International Driving Licenses";
            // 
            // dgvInternationalLicenseList
            // 
            this.dgvInternationalLicenseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseList.Location = new System.Drawing.Point(1, 51);
            this.dgvInternationalLicenseList.Name = "dgvInternationalLicenseList";
            this.dgvInternationalLicenseList.RowHeadersWidth = 51;
            this.dgvInternationalLicenseList.RowTemplate.Height = 24;
            this.dgvInternationalLicenseList.Size = new System.Drawing.Size(951, 245);
            this.dgvInternationalLicenseList.TabIndex = 2;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecord.Location = new System.Drawing.Point(116, 291);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(30, 24);
            this.lblRecord.TabIndex = 3;
            this.lblRecord.Text = "??";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Records";
            // 
            // ctrlListLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMain);
            this.Name = "ctrlListLicenses";
            this.Size = new System.Drawing.Size(981, 315);
            this.tbMain.ResumeLayout(false);
            this.tbLocalLicenses.ResumeLayout(false);
            this.tbLocalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseList)).EndInit();
            this.tbInternationalLicenses.ResumeLayout(false);
            this.tbInternationalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tbLocalLicenses;
        private System.Windows.Forms.TabPage tbInternationalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocalLicenseList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseList;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label label3;
    }
}

namespace DVLD.Applications
{
    partial class frmManageLDLA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageLDLA));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblRecords = new System.Windows.Forms.Label();
            this.dgvAppList = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.CancelApplicaitonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ScheduleTestsMenue = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppList)).BeginInit();
            this.cmsApplications.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilet
            // 
            this.txtFilet.Location = new System.Drawing.Point(358, 198);
            this.txtFilet.Multiline = true;
            this.txtFilet.Name = "txtFilet";
            this.txtFilet.Size = new System.Drawing.Size(193, 33);
            this.txtFilet.TabIndex = 40;
            this.txtFilet.Visible = false;
            this.txtFilet.TextChanged += new System.EventHandler(this.txtFilet_TextChanged);
            this.txtFilet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilet_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 29);
            this.label6.TabIndex = 39;
            this.label6.Text = "Filter By: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 595);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 29);
            this.label5.TabIndex = 33;
            this.label5.Text = "# Records";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(513, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 39);
            this.label1.TabIndex = 29;
            this.label1.Text = "Manage Applications\r\n";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(159, 198);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(193, 33);
            this.cbFilterBy.TabIndex = 38;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPerson.Image")));
            this.btnAddPerson.Location = new System.Drawing.Point(1343, 151);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(96, 80);
            this.btnAddPerson.TabIndex = 36;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1343, 595);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 51);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(149, 595);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(37, 29);
            this.lblRecords.TabIndex = 34;
            this.lblRecords.Text = "??";
            // 
            // dgvAppList
            // 
            this.dgvAppList.AllowUserToAddRows = false;
            this.dgvAppList.AllowUserToDeleteRows = false;
            this.dgvAppList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAppList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppList.ContextMenuStrip = this.cmsApplications;
            this.dgvAppList.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.GreenYellow;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppList.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAppList.Location = new System.Drawing.Point(13, 242);
            this.dgvAppList.MultiSelect = false;
            this.dgvAppList.Name = "dgvAppList";
            this.dgvAppList.ReadOnly = true;
            this.dgvAppList.RowHeadersVisible = false;
            this.dgvAppList.RowHeadersWidth = 51;
            this.dgvAppList.RowTemplate.Height = 24;
            this.dgvAppList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppList.Size = new System.Drawing.Size(1426, 328);
            this.dgvAppList.TabIndex = 31;
            this.dgvAppList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppList_CellClick);
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.editToolStripMenuItem,
            this.DeleteApplicationToolStripMenuItem,
            this.toolStripSeparator5,
            this.CancelApplicaitonToolStripMenuItem,
            this.toolStripSeparator1,
            this.ScheduleTestsMenue,
            this.toolStripSeparator3,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.toolStripSeparator4,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator6,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(309, 344);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showDetailsToolStripMenuItem.Text = "&Show Application Details";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(305, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.editToolStripMenuItem.Text = "&Edit Application";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // DeleteApplicationToolStripMenuItem
            // 
            this.DeleteApplicationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("DeleteApplicationToolStripMenuItem.Image")));
            this.DeleteApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteApplicationToolStripMenuItem.Name = "DeleteApplicationToolStripMenuItem";
            this.DeleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.DeleteApplicationToolStripMenuItem.Text = "&Delete Application";
            this.DeleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.DeleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(305, 6);
            // 
            // CancelApplicaitonToolStripMenuItem
            // 
            this.CancelApplicaitonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("CancelApplicaitonToolStripMenuItem.Image")));
            this.CancelApplicaitonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CancelApplicaitonToolStripMenuItem.Name = "CancelApplicaitonToolStripMenuItem";
            this.CancelApplicaitonToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.CancelApplicaitonToolStripMenuItem.Text = "&Cancel Application";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(305, 6);
            // 
            // ScheduleTestsMenue
            // 
            this.ScheduleTestsMenue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.ScheduleTestsMenue.Image = ((System.Drawing.Image)(resources.GetObject("ScheduleTestsMenue.Image")));
            this.ScheduleTestsMenue.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleTestsMenue.Name = "ScheduleTestsMenue";
            this.ScheduleTestsMenue.Size = new System.Drawing.Size(308, 38);
            this.ScheduleTestsMenue.Text = "Sechdule &Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Enabled = false;
            this.scheduleVisionTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleVisionTestToolStripMenuItem.Image")));
            this.scheduleVisionTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Enabled = false;
            this.scheduleWrittenTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleWrittenTestToolStripMenuItem.Image")));
            this.scheduleWrittenTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Enabled = false;
            this.scheduleStreetTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scheduleStreetTestToolStripMenuItem.Image")));
            this.scheduleStreetTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(305, 6);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("issueDrivingLicenseFirstTimeToolStripMenuItem.Image")));
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "&Issue Driving License (First Time)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(305, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseToolStripMenuItem.Image")));
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showLicenseToolStripMenuItem.Text = "Show &License";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(305, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showPersonLicenseHistoryToolStripMenuItem.Image")));
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Completed",
            "Canceled"});
            this.cbStatus.Location = new System.Drawing.Point(358, 198);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(107, 33);
            this.cbStatus.TabIndex = 38;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmManageLDLA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 654);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.txtFilet);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvAppList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageLDLA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManageApplication";
            this.Load += new System.EventHandler(this.frmManageLDLA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppList)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.DataGridView dgvAppList;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem CancelApplicaitonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ScheduleTestsMenue;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbStatus;
    }
}
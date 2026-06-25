namespace DVLD
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
            this.tsmApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmManageUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmApplications
            // 
            this.tsmApplications.AutoSize = false;
            this.tsmApplications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsmApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmApplications.Name = "tsmApplications";
            this.tsmApplications.Size = new System.Drawing.Size(200, 150);
            this.tsmApplications.Text = "Applications";
            // 
            // tsmDrivers
            // 
            this.tsmDrivers.AutoSize = false;
            this.tsmDrivers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsmDrivers.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDrivers.Name = "tsmDrivers";
            this.tsmDrivers.Size = new System.Drawing.Size(151, 150);
            this.tsmDrivers.Text = "Drivers";
            this.tsmDrivers.Click += new System.EventHandler(this.tsmDrivers_Click);
            // 
            // tsmPeople
            // 
            this.tsmPeople.AutoSize = false;
            this.tsmPeople.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsmPeople.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsmPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmPeople.Name = "tsmPeople";
            this.tsmPeople.Size = new System.Drawing.Size(151, 150);
            this.tsmPeople.Text = "People";
            // 
            // tsmManageUsers
            // 
            this.tsmManageUsers.AutoSize = false;
            this.tsmManageUsers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsmManageUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmManageUsers.Name = "tsmManageUsers";
            this.tsmManageUsers.Size = new System.Drawing.Size(200, 150);
            this.tsmManageUsers.Text = "Manage Users";
            // 
            // tsmAccountSettings
            // 
            this.tsmAccountSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tsmAccountSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmAccountSettings.Name = "tsmAccountSettings";
            this.tsmAccountSettings.Size = new System.Drawing.Size(160, 150);
            this.tsmAccountSettings.Text = "Account Settings";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Tan;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmApplications,
            this.tsmDrivers,
            this.tsmPeople,
            this.tsmManageUsers,
            this.tsmAccountSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1005, 154);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(1005, 729);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmApplications;
        private System.Windows.Forms.ToolStripMenuItem tsmDrivers;
        private System.Windows.Forms.ToolStripMenuItem tsmPeople;
        private System.Windows.Forms.ToolStripMenuItem tsmManageUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmAccountSettings;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}


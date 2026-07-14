namespace DVLD
{
    partial class frmAddUpdatePerson
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
            this.lblMode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPersonId = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlAddUpdatePerson1 = new DVLD.Controls.ctrlPeople.ctrlAddUpdatePerson();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.BackColor = System.Drawing.Color.Chartreuse;
            this.lblMode.Location = new System.Drawing.Point(522, 20);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(218, 29);
            this.lblMode.TabIndex = 2;
            this.lblMode.Text = "Add New Person";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "PersonID";
            // 
            // lblPersonId
            // 
            this.lblPersonId.AutoSize = true;
            this.lblPersonId.Location = new System.Drawing.Point(220, 20);
            this.lblPersonId.Name = "lblPersonId";
            this.lblPersonId.Size = new System.Drawing.Size(53, 29);
            this.lblPersonId.TabIndex = 2;
            this.lblPersonId.Text = "N/A";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(527, 582);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(141, 49);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlAddUpdatePerson1
            // 
            this.ctrlAddUpdatePerson1.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlAddUpdatePerson1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAddUpdatePerson1.Location = new System.Drawing.Point(48, 90);
            this.ctrlAddUpdatePerson1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlAddUpdatePerson1.Name = "ctrlAddUpdatePerson1";
            this.ctrlAddUpdatePerson1.Size = new System.Drawing.Size(1174, 565);
            this.ctrlAddUpdatePerson1.TabIndex = 3;
            this.ctrlAddUpdatePerson1.OnSaveComplete += new System.Action<int>(this.ctrlAddUpdatePerson1_OnSaveComplete);
            this.ctrlAddUpdatePerson1.Load += new System.EventHandler(this.ctrlAddUpdatePerson1_Load);
            // 
            // frmAddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 680);
            this.Controls.Add(this.lblPersonId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlAddUpdatePerson1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmAddUpdatePerson";
            this.Text = "frmAddUpdatePerson";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPersonId;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnClose;
        private Controls.ctrlPeople.ctrlAddUpdatePerson ctrlAddUpdatePerson1;
    }
}
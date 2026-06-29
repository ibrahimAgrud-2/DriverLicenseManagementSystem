namespace DVLD
{
    partial class frmAddUpdatePeople
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
            this.ctrlAddPerson1 = new DVLD.ctrlAddPerson();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlAddPerson1
            // 
            this.ctrlAddPerson1.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlAddPerson1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAddPerson1.Location = new System.Drawing.Point(77, 103);
            this.ctrlAddPerson1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlAddPerson1.Name = "ctrlAddPerson1";
            this.ctrlAddPerson1.Size = new System.Drawing.Size(995, 542);
            this.ctrlAddPerson1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(495, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Person";
            // 
            // frmAddUpdatePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1125, 685);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlAddPerson1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdatePeople";
            this.Text = "frmAddUpdatePeople";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlAddPerson ctrlAddPerson1;
        private System.Windows.Forms.Label label1;
    }
}
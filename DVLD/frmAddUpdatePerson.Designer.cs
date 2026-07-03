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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUpdatePerson));
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mskSecondName = new System.Windows.Forms.MaskedTextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.mskPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.lnkLblRemove = new System.Windows.Forms.LinkLabel();
            this.mskLastName = new System.Windows.Forms.MaskedTextBox();
            this.mskThirdName = new System.Windows.Forms.MaskedTextBox();
            this.mskFirstName = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mskNationalNo = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lnklblSetImage = new System.Windows.Forms.LinkLabel();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.cbCountries = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(561, 592);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 55);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(544, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add New Person1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "PersonID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "N/A";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // mskSecondName
            // 
            this.mskSecondName.HidePromptOnLeave = true;
            this.mskSecondName.Location = new System.Drawing.Point(480, 159);
            this.mskSecondName.Mask = "LL???????????????????????????????????????????";
            this.mskSecondName.Name = "mskSecondName";
            this.mskSecondName.PromptChar = ' ';
            this.mskSecondName.Size = new System.Drawing.Size(164, 34);
            this.mskSecondName.TabIndex = 58;
            this.mskSecondName.Leave += new System.EventHandler(this.mskFirstName_Leave);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(262, 463);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(626, 95);
            this.txtAddress.TabIndex = 57;
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            // 
            // mskPhoneNumber
            // 
            this.mskPhoneNumber.HidePromptOnLeave = true;
            this.mskPhoneNumber.Location = new System.Drawing.Point(652, 299);
            this.mskPhoneNumber.Mask = "(999) 000-0000";
            this.mskPhoneNumber.Name = "mskPhoneNumber";
            this.mskPhoneNumber.PromptChar = ' ';
            this.mskPhoneNumber.Size = new System.Drawing.Size(236, 34);
            this.mskPhoneNumber.TabIndex = 56;
            this.mskPhoneNumber.Leave += new System.EventHandler(this.mskFirstName_Leave);
            // 
            // lnkLblRemove
            // 
            this.lnkLblRemove.AutoSize = true;
            this.lnkLblRemove.Location = new System.Drawing.Point(976, 518);
            this.lnkLblRemove.Name = "lnkLblRemove";
            this.lnkLblRemove.Size = new System.Drawing.Size(103, 29);
            this.lnkLblRemove.TabIndex = 55;
            this.lnkLblRemove.TabStop = true;
            this.lnkLblRemove.Text = "Remove";
            this.lnkLblRemove.Visible = false;
            this.lnkLblRemove.Click += new System.EventHandler(this.lnkLblRemove_Click);
            // 
            // mskLastName
            // 
            this.mskLastName.HidePromptOnLeave = true;
            this.mskLastName.Location = new System.Drawing.Point(928, 159);
            this.mskLastName.Mask = "LL???????????????????????????????????????????";
            this.mskLastName.Name = "mskLastName";
            this.mskLastName.PromptChar = ' ';
            this.mskLastName.Size = new System.Drawing.Size(164, 34);
            this.mskLastName.TabIndex = 54;
            this.mskLastName.Leave += new System.EventHandler(this.mskFirstName_Leave);
            // 
            // mskThirdName
            // 
            this.mskThirdName.HidePromptOnLeave = true;
            this.mskThirdName.Location = new System.Drawing.Point(724, 159);
            this.mskThirdName.Mask = "???????????????????????????????????????";
            this.mskThirdName.Name = "mskThirdName";
            this.mskThirdName.PromptChar = ' ';
            this.mskThirdName.Size = new System.Drawing.Size(164, 34);
            this.mskThirdName.TabIndex = 53;
            // 
            // mskFirstName
            // 
            this.mskFirstName.HidePromptOnLeave = true;
            this.mskFirstName.Location = new System.Drawing.Point(262, 159);
            this.mskFirstName.Mask = "LL???????????????????????????????????????????";
            this.mskFirstName.Name = "mskFirstName";
            this.mskFirstName.PromptChar = ' ';
            this.mskFirstName.Size = new System.Drawing.Size(164, 34);
            this.mskFirstName.TabIndex = 52;
            this.mskFirstName.Leave += new System.EventHandler(this.mskFirstName_Leave);
            // 
            // label14
            // 
            this.label14.Image = ((System.Drawing.Image)(resources.GetObject("label14.Image")));
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Location = new System.Drawing.Point(364, 316);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 33);
            this.label14.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(198, 314);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 33);
            this.label4.TabIndex = 50;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(652, 242);
            this.dtpBirthDate.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(236, 34);
            this.dtpBirthDate.TabIndex = 49;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // mskNationalNo
            // 
            this.mskNationalNo.HidePromptOnLeave = true;
            this.mskNationalNo.Location = new System.Drawing.Point(262, 238);
            this.mskNationalNo.Mask = "LAaaaaaaaaaaaaaaa";
            this.mskNationalNo.Name = "mskNationalNo";
            this.mskNationalNo.PromptChar = ' ';
            this.mskNationalNo.Size = new System.Drawing.Size(164, 34);
            this.mskNationalNo.TabIndex = 59;
            this.mskNationalNo.Leave += new System.EventHandler(this.mskNationalNo_Leave);
            // 
            // label5
            // 
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(103, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 32);
            this.label5.TabIndex = 48;
            this.label5.Text = "Name";
            // 
            // label6
            // 
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(104, 466);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 32);
            this.label6.TabIndex = 47;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(104, 387);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 32);
            this.label7.TabIndex = 46;
            this.label7.Text = "Email";
            // 
            // label10
            // 
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(95, 299);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 32);
            this.label10.TabIndex = 45;
            this.label10.Text = "Gender";
            // 
            // label13
            // 
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(494, 241);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 33);
            this.label13.TabIndex = 44;
            this.label13.Text = "Birth Date";
            // 
            // label11
            // 
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(494, 298);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 33);
            this.label11.TabIndex = 43;
            this.label11.Text = "Phone: ";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(724, 595);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 49);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(411, 320);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(84, 33);
            this.rbMale.TabIndex = 41;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // rbFemale
            // 
            this.rbFemale.Location = new System.Drawing.Point(245, 311);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(116, 39);
            this.rbFemale.TabIndex = 40;
            this.rbFemale.Text = "Female";
            this.rbFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.rbFemale_CheckedChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(262, 384);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(174, 34);
            this.txtEmail.TabIndex = 39;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lnklblSetImage
            // 
            this.lnklblSetImage.AutoSize = true;
            this.lnklblSetImage.Location = new System.Drawing.Point(964, 482);
            this.lnklblSetImage.Name = "lnklblSetImage";
            this.lnklblSetImage.Size = new System.Drawing.Size(122, 29);
            this.lnklblSetImage.TabIndex = 38;
            this.lnklblSetImage.TabStop = true;
            this.lnklblSetImage.Text = "Set Image";
            this.lnklblSetImage.Click += new System.EventHandler(this.lnkLblSetImage_LinkClicked);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.Image = ((System.Drawing.Image)(resources.GetObject("pbPersonImage.Image")));
            this.pbPersonImage.Location = new System.Drawing.Point(928, 235);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(189, 226);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonImage.TabIndex = 37;
            this.pbPersonImage.TabStop = false;
            // 
            // cbCountries
            // 
            this.cbCountries.FormattingEnabled = true;
            this.cbCountries.Location = new System.Drawing.Point(652, 361);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(236, 37);
            this.cbCountries.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(995, 118);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 29);
            this.label9.TabIndex = 35;
            this.label9.Text = "Last";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(782, 118);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 29);
            this.label8.TabIndex = 34;
            this.label8.Text = "Third";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(494, 118);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 29);
            this.label12.TabIndex = 33;
            this.label12.Text = "Second";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(286, 118);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 29);
            this.label15.TabIndex = 32;
            this.label15.Text = "First";
            // 
            // label16
            // 
            this.label16.Image = ((System.Drawing.Image)(resources.GetObject("label16.Image")));
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.Location = new System.Drawing.Point(494, 361);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 33);
            this.label16.TabIndex = 30;
            this.label16.Text = "Country:";
            // 
            // label17
            // 
            this.label17.Image = ((System.Drawing.Image)(resources.GetObject("label17.Image")));
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label17.Location = new System.Drawing.Point(95, 235);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(160, 32);
            this.label17.TabIndex = 31;
            this.label17.Text = "NationalNo";
            // 
            // frmAddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 680);
            this.Controls.Add(this.mskSecondName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.mskPhoneNumber);
            this.Controls.Add(this.lnkLblRemove);
            this.Controls.Add(this.mskLastName);
            this.Controls.Add(this.mskThirdName);
            this.Controls.Add(this.mskFirstName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.mskNationalNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lnklblSetImage);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.cbCountries);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmAddUpdatePerson";
            this.Text = "frmAddUpdatePerson";
            this.Load += new System.EventHandler(this.frmAddUpdatePerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MaskedTextBox mskSecondName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.MaskedTextBox mskPhoneNumber;
        private System.Windows.Forms.LinkLabel lnkLblRemove;
        private System.Windows.Forms.MaskedTextBox mskLastName;
        private System.Windows.Forms.MaskedTextBox mskThirdName;
        private System.Windows.Forms.MaskedTextBox mskFirstName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox mskNationalNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.LinkLabel lnklblSetImage;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.ComboBox cbCountries;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}
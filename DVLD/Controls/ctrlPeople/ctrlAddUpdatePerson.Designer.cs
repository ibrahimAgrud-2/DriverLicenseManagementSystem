namespace DVLD.Controls.ctrlPeople
{
    partial class ctrlAddUpdatePerson
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlAddUpdatePerson));
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // mskSecondName
            // 
            this.mskSecondName.HidePromptOnLeave = true;
            this.mskSecondName.Location = new System.Drawing.Point(415, 65);
            this.mskSecondName.Mask = "LL???????????????????????????????????????????";
            this.mskSecondName.Name = "mskSecondName";
            this.mskSecondName.PromptChar = ' ';
            this.mskSecondName.Size = new System.Drawing.Size(164, 32);
            this.mskSecondName.TabIndex = 92;
            this.mskSecondName.Leave += new System.EventHandler(this.mskName_FocusLeave);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(197, 369);
            this.txtAddress.MaxLength = 2000;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(626, 95);
            this.txtAddress.TabIndex = 91;
            this.txtAddress.Leave += new System.EventHandler(this.txtAddress_Leave);
            // 
            // mskPhoneNumber
            // 
            this.mskPhoneNumber.HidePromptOnLeave = true;
            this.mskPhoneNumber.Location = new System.Drawing.Point(587, 205);
            this.mskPhoneNumber.Mask = "(999) 000-0000";
            this.mskPhoneNumber.Name = "mskPhoneNumber";
            this.mskPhoneNumber.PromptChar = ' ';
            this.mskPhoneNumber.Size = new System.Drawing.Size(236, 32);
            this.mskPhoneNumber.TabIndex = 90;
            this.mskPhoneNumber.Leave += new System.EventHandler(this.mskName_FocusLeave);
            // 
            // lnkLblRemove
            // 
            this.lnkLblRemove.AutoSize = true;
            this.lnkLblRemove.Location = new System.Drawing.Point(911, 424);
            this.lnkLblRemove.Name = "lnkLblRemove";
            this.lnkLblRemove.Size = new System.Drawing.Size(94, 26);
            this.lnkLblRemove.TabIndex = 89;
            this.lnkLblRemove.TabStop = true;
            this.lnkLblRemove.Text = "Remove";
            this.lnkLblRemove.Visible = false;
            // 
            // mskLastName
            // 
            this.mskLastName.HidePromptOnLeave = true;
            this.mskLastName.Location = new System.Drawing.Point(863, 65);
            this.mskLastName.Mask = "LL???????????????????????????????????????????";
            this.mskLastName.Name = "mskLastName";
            this.mskLastName.PromptChar = ' ';
            this.mskLastName.Size = new System.Drawing.Size(164, 32);
            this.mskLastName.TabIndex = 88;
            this.mskLastName.Leave += new System.EventHandler(this.mskName_FocusLeave);
            // 
            // mskThirdName
            // 
            this.mskThirdName.HidePromptOnLeave = true;
            this.mskThirdName.Location = new System.Drawing.Point(659, 65);
            this.mskThirdName.Mask = "???????????????????????????????????????";
            this.mskThirdName.Name = "mskThirdName";
            this.mskThirdName.PromptChar = ' ';
            this.mskThirdName.Size = new System.Drawing.Size(164, 32);
            this.mskThirdName.TabIndex = 87;
            // 
            // mskFirstName
            // 
            this.mskFirstName.HidePromptOnLeave = true;
            this.mskFirstName.Location = new System.Drawing.Point(197, 65);
            this.mskFirstName.Mask = "LL???????????????????????????????????????????";
            this.mskFirstName.Name = "mskFirstName";
            this.mskFirstName.PromptChar = ' ';
            this.mskFirstName.Size = new System.Drawing.Size(164, 32);
            this.mskFirstName.TabIndex = 86;
            this.mskFirstName.Leave += new System.EventHandler(this.mskName_FocusLeave);
            // 
            // label14
            // 
            this.label14.Image = ((System.Drawing.Image)(resources.GetObject("label14.Image")));
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Location = new System.Drawing.Point(299, 222);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 33);
            this.label14.TabIndex = 85;
            // 
            // label4
            // 
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(133, 220);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 33);
            this.label4.TabIndex = 84;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(587, 148);
            this.dtpBirthDate.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(236, 32);
            this.dtpBirthDate.TabIndex = 83;
            // 
            // mskNationalNo
            // 
            this.mskNationalNo.HidePromptOnLeave = true;
            this.mskNationalNo.Location = new System.Drawing.Point(197, 144);
            this.mskNationalNo.Name = "mskNationalNo";
            this.mskNationalNo.PromptChar = ' ';
            this.mskNationalNo.Size = new System.Drawing.Size(164, 32);
            this.mskNationalNo.TabIndex = 93;
            this.mskNationalNo.Click += new System.EventHandler(this.cbGender_check);
            this.mskNationalNo.Leave += new System.EventHandler(this.mskNationalNo_Leave);
            // 
            // label5
            // 
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(38, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 32);
            this.label5.TabIndex = 82;
            this.label5.Text = "Name";
            // 
            // label6
            // 
            this.label6.Image = ((System.Drawing.Image)(resources.GetObject("label6.Image")));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(39, 372);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 32);
            this.label6.TabIndex = 81;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(39, 293);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 32);
            this.label7.TabIndex = 80;
            this.label7.Text = "Email";
            // 
            // label10
            // 
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(30, 205);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 32);
            this.label10.TabIndex = 79;
            this.label10.Text = "Gender";
            // 
            // label13
            // 
            this.label13.Image = ((System.Drawing.Image)(resources.GetObject("label13.Image")));
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(429, 147);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 33);
            this.label13.TabIndex = 78;
            this.label13.Text = "Birth Date";
            // 
            // label11
            // 
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(429, 204);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 33);
            this.label11.TabIndex = 77;
            this.label11.Text = "Phone: ";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(659, 501);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 49);
            this.btnSave.TabIndex = 76;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(346, 226);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(77, 30);
            this.rbMale.TabIndex = 75;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.cbGender_check);
            // 
            // rbFemale
            // 
            this.rbFemale.Location = new System.Drawing.Point(180, 217);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(116, 39);
            this.rbFemale.TabIndex = 74;
            this.rbFemale.Text = "Female";
            this.rbFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.CheckedChanged += new System.EventHandler(this.cbGender_check);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(197, 290);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(174, 32);
            this.txtEmail.TabIndex = 73;
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lnklblSetImage
            // 
            this.lnklblSetImage.AutoSize = true;
            this.lnklblSetImage.Location = new System.Drawing.Point(899, 388);
            this.lnklblSetImage.Name = "lnklblSetImage";
            this.lnklblSetImage.Size = new System.Drawing.Size(112, 26);
            this.lnklblSetImage.TabIndex = 72;
            this.lnklblSetImage.TabStop = true;
            this.lnklblSetImage.Text = "Set Image";
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.Image = ((System.Drawing.Image)(resources.GetObject("pbPersonImage.Image")));
            this.pbPersonImage.Location = new System.Drawing.Point(863, 141);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(189, 226);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPersonImage.TabIndex = 71;
            this.pbPersonImage.TabStop = false;
            // 
            // cbCountries
            // 
            this.cbCountries.FormattingEnabled = true;
            this.cbCountries.Location = new System.Drawing.Point(587, 267);
            this.cbCountries.Name = "cbCountries";
            this.cbCountries.Size = new System.Drawing.Size(236, 33);
            this.cbCountries.TabIndex = 70;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(930, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 26);
            this.label9.TabIndex = 69;
            this.label9.Text = "Last";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(717, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 26);
            this.label8.TabIndex = 68;
            this.label8.Text = "Third";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(429, 24);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 26);
            this.label12.TabIndex = 67;
            this.label12.Text = "Second";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(221, 24);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 26);
            this.label15.TabIndex = 66;
            this.label15.Text = "First";
            // 
            // label16
            // 
            this.label16.Image = ((System.Drawing.Image)(resources.GetObject("label16.Image")));
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.Location = new System.Drawing.Point(429, 267);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 33);
            this.label16.TabIndex = 64;
            this.label16.Text = "Country:";
            // 
            // label17
            // 
            this.label17.Image = ((System.Drawing.Image)(resources.GetObject("label17.Image")));
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label17.Location = new System.Drawing.Point(30, 141);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(160, 32);
            this.label17.TabIndex = 65;
            this.label17.Text = "NationalNo";
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
            // ctrlAddUpdatePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlAddUpdatePerson";
            this.Size = new System.Drawing.Size(1104, 558);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

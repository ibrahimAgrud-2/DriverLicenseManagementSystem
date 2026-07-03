using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DVLD.Controls.ctrlPeople
{
    public partial class ctrlAddUpdatePerson : UserControl
    {
        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
        }

        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {

        }

        private int _PersonID;
        public People _Person;

        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode;

        private void _FillCountriesToComboBox()
        {
            DataTable dt = Country.getCountryRecord();

            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr["CountryName"]);
            }
        }


        public void start(int personID)
        {
            if (personID == -1)
            {
                _Mode = enMode.enAddNew;
                _TemLoad();
            }
            else
            {
                _Mode = enMode.enUpdate;
                _PersonID = personID;
                _Person = People.findPersonByID(_PersonID);
            }
            _Load();

        }
        private void _Load()
        {
            _FillCountriesToComboBox();
            cbCountries.SelectedIndex = 8;
            if (rbFemale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png");
            }
            else if (rbMale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png");

            }
            dtpBirthDate.MaxDate = DateTime.Now.AddYears(-18);

            if (_Mode == enMode.enAddNew)
            {
                _Person = new People();
                return;
            }
            mskFirstName.Text = _Person.firstName;
            mskSecondName.Text = _Person.secondName;
            mskThirdName.Text = _Person.thirdName;
            mskLastName.Text = _Person.lastName;
            mskNationalNo.Text = _Person.nationalNo;
            mskPhoneNumber.Text = _Person.phone;
            txtAddress.Text = _Person.address;
            txtEmail.Text = _Person.email;
            

            if (_Person.gender == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            if (_Person.imagePath != string.Empty && File.Exists(_Person.imagePath))
            {
                pbPersonImage.Load(_Person.imagePath);
            }

        }

        private void _TemLoad()
        {
            mskFirstName.Text = "ibrahim";
            mskSecondName.Text = "mustafa";
            mskThirdName.Text = "muhammed";
            mskLastName.Text = "orut";
            mskNationalNo.Text = "N";
            mskPhoneNumber.Text = "12345678919";
            txtAddress.Text = "Syria";

        }



        private void mskFirstName_Leave(object sender, EventArgs e)
        {
            MaskedTextBox msTxt = (MaskedTextBox)sender;

            if (!msTxt.MaskCompleted)
            {
                errorProvider1.SetError(msTxt, "Input is not valid");
            }
            else
            {
                errorProvider1.SetError(msTxt, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_IsAllInputsValid())
            {


                _Person.nationalNo = mskNationalNo.Text;
                _Person.countryID = Country.findCountry(cbCountries.FindString(cbCountries.Text) + 1).countryID;
                _Person.firstName = mskFirstName.Text;
                _Person.secondName = mskSecondName.Text;
                _Person.thirdName = mskThirdName.Text;
                _Person.lastName = mskLastName.Text;
                _Person.dateOfBirth = dtpBirthDate.Value;
                if (rbFemale.Checked)
                {
                    _Person.gender = 1;
                }
                else
                {
                    _Person.gender = 0;
                }
                _Person.phone = mskPhoneNumber.Text;
                _Person.email = txtEmail.Text;
                _Person.address = txtAddress.Text;

                //======
                if (this._Mode == enMode.enAddNew)
                {

               
                    string NewFilePath = @"C:\Images\" + Guid.NewGuid() + ".jpg";
                    MessageBox.Show(pbPersonImage.ImageLocation);
                    File.Copy(pbPersonImage.ImageLocation, NewFilePath, true);
                    _Person.imagePath = NewFilePath;
                }
                else if(this._Mode==enMode.enUpdate)
                {
                    if(File.Exists(_Person.imagePath))
                    {
                        if(_Person.imagePath != pbPersonImage.ImageLocation)
                        {
                            File.Delete(_Person.imagePath);
                            string NewFilePath = @"C:\Images\" + Guid.NewGuid() + ".jpg";
                            File.Copy(pbPersonImage.ImageLocation, NewFilePath, true);
                            _Person.imagePath = NewFilePath;
                        }
                    }

                }


                //======

                if (_Person.save())
                {
                    MessageBox.Show("Saved Successfully");

                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else
            {
                MessageBox.Show("Fill the required area");
            }
        }

        private bool _IsEmailValid(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            return regex.IsMatch(email);
        }


        private void txtEmail_Leave(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;



            if (_IsEmailValid(txt.Text) || txt.Text == string.Empty)
            {
                errorProvider1.SetError(txt, "");

            }
            else
            {
                errorProvider1.SetError(txt, "Email is not valid. Example@gmail.com");
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == string.Empty)
            {
                errorProvider1.SetError(txtAddress, "Enter Address");
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png");
            }
            else if (rbMale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png");
            }
        }
        private bool _IsAllInputsValid()
        {
            return (mskFirstName.MaskCompleted && mskLastName.MaskCompleted && mskSecondName.MaskCompleted && mskNationalNo.MaskCompleted && mskPhoneNumber.MaskCompleted && _IsEmailValid(txtEmail.Text) && (txtAddress.Text != string.Empty));
        }
        private void mskNationalNo_Leave(object sender, EventArgs e)
        {
            if (!mskNationalNo.MaskCompleted)
            {
                errorProvider1.SetError(mskNationalNo, "Enter a valid national no starts with a letter. Example: N10");
                return;
            }
            if (People.isPersonExistByNationalNo(mskNationalNo.Text))
            {
                errorProvider1.SetError(mskNationalNo, "National No is already exist");
            }
            else
            {
                errorProvider1.SetError(mskNationalNo, "");
            }
        }


        private void lnkLblSetImage_LinkClicked(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images";

            openFileDialog1.Title = "This is a title";

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "All Images|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.webp| JPEG Files (*.jpg;*.jpeg)|  PNG Files (*.png)|*.png|";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                lnkLblRemove.Visible = true;


                pbPersonImage.Load(openFileDialog1.FileName);
            }

        }

        private void lnkLblRemove_Click(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png");
            }
            else if (rbMale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png");

            }
        }
    }
}

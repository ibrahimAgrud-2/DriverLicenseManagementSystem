
using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;


namespace DVLD
{
    public partial class ctrlAddPerson : UserControl
    {
        public ctrlAddPerson()
        {
            InitializeComponent();
        }

        private void _FillCountriesToComboBox()
        {
            DataTable dt = Country.getCountryRecord();

            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr["CountryName"]);
            }
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
        private void ctrlAddPerson_Load(object sender, EventArgs e)
        {
            _Load();
            _TemLoad();
        }

        private void mskFirstName_Leave(object sender, EventArgs e)
        {
            MaskedTextBox msTxt = (MaskedTextBox)sender;

            if (!msTxt.MaskCompleted)
            {
                errorProvider1.SetError(msTxt,"Input is not valid");
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
                People p1 = new People();

                p1.nationalNo = mskNationalNo.Text;
                p1.countryID = Country.findCountry(cbCountries.FindString(cbCountries.Text) + 1).countryID;
                p1.firstName = mskFirstName.Text;
                p1.secondName = mskSecondName.Text;
                p1.thirdName = mskThirdName.Text;
                p1.lastName = mskLastName.Text;
                p1.dateOfBirth = dtpBirthDate.Value;
                if (rbFemale.Checked)
                {
                    p1.gender = 1;
                }
                else
                {
                    p1.gender = 0;
                }
                p1.phone = mskPhoneNumber.Text;
                p1.email = txtEmail.Text;
                p1.address = txtAddress.Text;
              
                string NewFilePath = @"C:\Images\" + Guid.NewGuid() + ".jpg";
                File.Copy(openFileDialog1.FileName, NewFilePath, true);
                p1.imagePath = NewFilePath;


                if (p1.save())
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
            TextBox txt =  (TextBox)sender;
            
           

            if(_IsEmailValid(txt.Text)|| txt.Text == string.Empty)
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
            if(txtAddress.Text==string.Empty)
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
            if(rbFemale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png");
            }
            else if(rbMale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png");
            }
        }
        private bool _IsAllInputsValid()
        {
            return (mskFirstName.MaskCompleted && mskLastName.MaskCompleted && mskSecondName.MaskCompleted && mskNationalNo.MaskCompleted && mskPhoneNumber.MaskCompleted&&_IsEmailValid(txtEmail.Text)&&(txtAddress.Text!=string.Empty));
        }
        private void mskNationalNo_Leave(object sender, EventArgs e)
        {
            if(!mskNationalNo.MaskCompleted)
            {
                errorProvider1.SetError(mskNationalNo, "Enter a valid national no starts with a letter. Example: N10");
                return;
            }
            if(People.isPersonExistByNationalNo(mskNationalNo.Text))
            {
                errorProvider1.SetError(mskNationalNo, "National No is already exist");
            }
            else
            {
                errorProvider1.SetError(mskNationalNo, "");
            }
        }

        private void lnklblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void lnkLblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Image.FromFile(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png");
            }
            else if (rbMale.Checked)
            {
                pbPersonImage.Image = Image.FromFile(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png");

            }
        }
    }
}

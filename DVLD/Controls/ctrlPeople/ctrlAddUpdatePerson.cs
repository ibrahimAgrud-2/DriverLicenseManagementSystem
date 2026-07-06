using DVLD_BusinessLayer;
using System;
using System.Data;
using System.IO;

using System.Windows.Forms;


namespace DVLD.Controls.ctrlPeople
{
    public partial class ctrlAddUpdatePerson : UserControl
    {

        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
        }


        private People _Person;
        private int _personID;

        enum enMode { enAddNew=1,enUpdate=2};
       private enMode _Mode;

        //Control için dışardan veriyi property ile verecem. property mantığı gereği ID verildiği anda 
        //set'e yazdığım fonksyionlar çalışacak.
        public int personID
        {
  
            set
            {
                _personID = value;
                if(value<=0)
                {
                    this._Mode = enMode.enAddNew;
                }
                else
                {
                    this._Mode = enMode.enUpdate;
                }
                _Load();
            }
        }


        //_________Temp_________
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
        //_______________________________

        private void _Load()
        {
            _FillCountriesToComboBox();
        

            if(this._Mode==enMode.enAddNew)
            {
                dtpBirthDate.Value = DateTime.Now.AddYears(-18);
                cbCountries.SelectedIndex = 10;
                _Person = new People();
                _TemLoad();
            }
        }


        //________________Validation Fields___________________________________
        private void _FillCountriesToComboBox()
        {
            DataTable dt = Country.getCountryRecord();

            foreach (DataRow data in dt.Rows)
            {
                cbCountries.Items.Add(data["CountryName"]);
            }
         
        }

        private void mskName_FocusLeave(object sender, EventArgs e)
        {
            MaskedTextBox msk = (MaskedTextBox)sender;

            if(!msk.MaskCompleted)
            {
                errorProvider1.SetError(msk, "Is not valid.");
            }
            else
            {
                errorProvider1.SetError(msk, "");
            }
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if(txtAddress.Text==string.Empty)
            {
                errorProvider1.SetError(txtAddress, "Enter a valid Address");
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
            }
        }
        private bool _isEmailInputValid()
        {
            if(txtEmail.Text==string.Empty||Utility.IsEmailValid(txtEmail.Text))
            {
                return true;
            }
            return false;
           
        }
       
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if(!_isEmailInputValid())
            {
                errorProvider1.SetError(txtEmail, "Enter a valid Email");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void mskNationalNo_Leave(object sender, EventArgs e)
        {
            if (People.isPersonExistByNationalNo(mskNationalNo.Text))
            {
                errorProvider1.SetError(mskNationalNo, "National No is already exist");

            }
            else
            {
                errorProvider1.SetError(mskNationalNo, "");
        }   }
      
       private void cbGender_check(object sender, EventArgs e)
        {
            setDefaultImage();
        }

        //__________________^^^^Validation^^^^_________________________________________






        //=======================SAVE========================================

       
        private bool _IsAllInputsValid()
        {
            return (mskFirstName.MaskCompleted && mskLastName.MaskCompleted && mskSecondName.MaskCompleted && mskNationalNo.MaskCompleted && mskPhoneNumber.MaskCompleted && (txtAddress.Text != string.Empty)&&_isEmailInputValid());
        }

        //Update'te yazdıktan sonra sadece image halleden kapsamla bir fonk yazalım.
        //____________SAVE - Image__________________
        private string setDefaultImage()
        {
            string imagePath = "";
            if (rbFemale.Checked)
            {
                imagePath = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png";
                pbPersonImage.Load(imagePath);
            }
            else if (rbMale.Checked)
            {
                imagePath = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png";
                pbPersonImage.Load(imagePath);
            }
            return imagePath;

        }

        public static bool copyImageToNewFolder(ref string imagePath, string destination = @"C:\Images\")
        {
            string newImagePath = destination + Guid.NewGuid() + ".jpg";
            if (!File.Exists(imagePath))
                return false;

            File.Copy(imagePath, newImagePath, true);
            return true;
        }

        private string _SetPersonImage()
        {
            string imagePath = pbPersonImage.ImageLocation;
            if(File.Exists(imagePath))
            {
                copyImageToNewFolder(ref imagePath);
            }
            else
            {
              
            }

            return imagePath;
        }
        //__________________________________________
        
        private bool _FillDataToObject()
        {

            if(_IsAllInputsValid())
                    {
                _Person.firstName = mskFirstName.Text;
                _Person.secondName = mskSecondName.Text;
                _Person.thirdName = mskThirdName.Text;
                _Person.lastName = mskLastName.Text;
                _Person.nationalNo = mskNationalNo.Text;
                _Person.email = txtEmail.Text;
                _Person.address = txtAddress.Text;
                _Person.phone = mskPhoneNumber.Text;
                _Person.countryID = Country.findCountry(cbCountries.SelectedIndex + 1).countryID;
                _Person.imagePath = "";
                return true;
            }
            else
            {
                         return false;
            }

        }
        private void fillObjectDataToField()
        {
            mskFirstName.Text = _Person.firstName;
            mskSecondName.Text = _Person.secondName;
            mskThirdName.Text = _Person.thirdName;
            mskLastName.Text = _Person.lastName;
            mskNationalNo.Text = _Person.nationalNo;
            txtEmail.Text = _Person.email;
            txtAddress.Text = _Person.address;
            mskPhoneNumber.Text = _Person.phone;
            cbCountries.SelectedIndex = _Person.countryID;


            //rbFemal male değişmeli.

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_FillDataToObject())
            {
                MessageBox.Show("Fill required fields ");
                return;
            }
            
            if(_Person.save())
            {
                MessageBox.Show("Saved successfully");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
        //======================= ^^^ SAVE ^^^ ========================================



    }
}

using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Globalization;


namespace DVLD.Controls.ctrlPeople
{
    public partial class ctrlAddUpdatePerson : UserControl
    {

        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
        }

        
       private RegionInfo _Region = RegionInfo.CurrentRegion;


        private People _Person;
        private int _personID;

        enum enMode { enAddNew=1,enUpdate=2};
       private enMode _Mode;


        //________________ V Event V ________________________
        public event Action<int> OnSaveComplete;
        protected virtual void SaveComplete(int result)
        {
            Action<int> test = OnSaveComplete;
            if (test != null)
            {
                test(result);
            }

        }
        //______________ ^^^ Event ^^^ ______________________

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
            mskThirdName.Text = "dad";
            mskLastName.Text = "dad";
            mskNationalNo.Text = "dad";
            txtAddress.Text = "dad";
            mskPhoneNumber.Text = "12312312311";


        }
        //_______________________________

        private void _Load()
        {
            _FillCountriesToComboBox();
  

            if (this._Mode==enMode.enAddNew)
            {
                dtpBirthDate.MaxDate = DateTime.Now.AddYears(-18);
                _Person = new People();
                cbCountries.SelectedItem = _Region.EnglishName;
                _SetDefaultImage();
                setErrors();
                _TemLoad();
                return;
            }

            _Person = People.findPersonByID(_personID);
            fillObjectDataToField(_Person);
          

        }



        //======================= V SAVE V ========================================
        private bool _IsAllInputsValid()
        {
            return (mskFirstName.MaskCompleted && mskLastName.MaskCompleted && mskSecondName.MaskCompleted && mskPhoneNumber.MaskCompleted && _IsNationalNoInputValid()&&(txtAddress.Text != string.Empty)&&_isEmailInputValid());
        }

        //Update'te yazdıktan sonra sadece image halleden kapsamla bir fonk yazalım.
        //____________ ^ SAVE - Image ^ __________________
       
        private void lnkLblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images";

            openFileDialog1.Title = "This is a title";

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "All Images|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.webp| JPEG Files (*.jpg;*.jpeg)|  PNG Files (*.png)|*.png|";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.ImageLocation = openFileDialog1.FileName;
                lnkLblRemove.Visible = true;
            }
       
        }
     
        private string _SetDefaultImage()
        {
            string imagePath = "";
            if (rbFemale.Checked)
            {
                imagePath = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png";
                pbPersonImage.ImageLocation=imagePath;
            }
            else if (rbMale.Checked)
            {
                imagePath = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png";
                pbPersonImage.ImageLocation = imagePath;
            }
            return imagePath;

        }
        private string _handleImage()
        {
            string imagePath = pbPersonImage.ImageLocation;
            //EĞER foto değişmemişse veya direk aynısı seçilmeşise upadate'e gerek yok. Fotoğraflık bir durum yok.
            if (_Mode==enMode.enUpdate&&_Person.imagePath==pbPersonImage.ImageLocation)
            {
                return imagePath;
            }


            Utility.copyImageToNewFolder(ref imagePath);

            if (this._Mode==enMode.enUpdate && _Person.imagePath != pbPersonImage.ImageLocation)
            {
                Utility.DeleteImageFromFolder(_Person.imagePath);
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
                _Person.countryID = Country.findCountryByID(cbCountries.SelectedIndex + 1).countryID;
                _Person.imagePath = _handleImage();
                _Person.gender = (rbFemale.Checked? 1:0);
                
                
                return true;
            }
            else
            {
                return false;
            }

        }
        private void fillObjectDataToField(People person)
        {
            mskFirstName.Text = person.firstName;
            mskSecondName.Text = person.secondName;
            mskThirdName.Text = person.thirdName;
            mskLastName.Text = person.lastName;
            mskNationalNo.Text = person.nationalNo;
            txtEmail.Text = person.email;
            txtAddress.Text = person.address;
            mskPhoneNumber.Text = person.phone;
            cbCountries.SelectedIndex = person.countryID-1;
           

            if(person.gender==0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            if(File.Exists(person.imagePath))
            {
                pbPersonImage.ImageLocation=person.imagePath;
                lnkLblRemove.Visible = true;
            }
            else
            {
                //Fotoğraf eğer yoksa default eklesin. radio button bazı durumlarda olmuyor. Bu yüzden bunu burda halletmelisin.
                _SetDefaultImage();
            }



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
                _Mode = enMode.enUpdate;
              

                //Event tetikleme
                SaveComplete(_Person.personID);
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        //======================= ^^^ SAVE ^^^ ========================================




        //________________Validation Fields___________________________________
        private bool _isEmailInputValid()
        {
            if (txtEmail.Text == string.Empty || Utility.IsEmailValid(txtEmail.Text))
            {
                return true;
            }
            return false;

        }
        private bool _IsNationalNoInputValid()
        {

            if (People.isPersonExistByNationalNo(mskNationalNo.Text))
            {
                if (_Person.nationalNo == mskNationalNo.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        private void msk_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox msk = (MaskedTextBox)sender;

            if (!msk.MaskCompleted)
            {
                errorProvider1.SetError(msk, "Is not valid.");
            }
            else
            {
                errorProvider1.SetError(msk, "");
            }
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtAddress.Text == string.Empty)
            {
                errorProvider1.SetError(txtAddress, "Enter a valid Address");
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
            }
        }
        private void _FillCountriesToComboBox()
        {
            DataTable dt = Country.getCountryRecord();
            foreach (DataRow data in dt.Rows)
            {
                cbCountries.Items.Add(data["CountryName"]);
            }

        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!_isEmailInputValid())
            {
                errorProvider1.SetError(txtEmail, "Enter a valid Email");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }


        private void cbGender_check(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
                _SetDefaultImage();
        }
        private void mskNationalNo_TextChanged(object sender, EventArgs e)
        {
            if(!mskNationalNo.MaskCompleted)
            {
                errorProvider1.SetError(mskNationalNo, "Enter A Valid national No");
                return;
            }
            if (!_IsNationalNoInputValid())
            {
                errorProvider1.SetError(mskNationalNo, "National no already exist");
                return;
            }
            errorProvider1.SetError(mskNationalNo, "");
        }
        //__________________^^^^Validation^^^^_________________________________________




        //________________________ V independent Field V ______________
        private void lnkLblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _SetDefaultImage();
        }

       
        private List<Control> _FormInputFields=new List<Control>();
        private void _AddControlsToTheList()
        {
            _FormInputFields.Add(mskFirstName);
            _FormInputFields.Add(mskSecondName);
            _FormInputFields.Add(mskThirdName);
            _FormInputFields.Add(mskLastName);
            _FormInputFields.Add(mskNationalNo);
            _FormInputFields.Add(mskPhoneNumber);
            _FormInputFields.Add(txtAddress);
        }

        private void setErrors()
        {
            _AddControlsToTheList();


            foreach (Control ctrl in _FormInputFields)
            {
                errorProvider1.SetError(ctrl,"This field is required");
            }
        }



        //________________________ ^^  independent Field ^^  ______________


    }
}

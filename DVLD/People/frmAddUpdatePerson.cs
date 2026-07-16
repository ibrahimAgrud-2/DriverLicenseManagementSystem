using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using PeopleBL = DVLD_BusinessLayer.People;

namespace DVLD
{
    public partial class frmAddUpdatePerson : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);

        public event DataBackEventHandler DataBack;


        private RegionInfo _Region = RegionInfo.CurrentRegion;


        private PeopleBL _Person;
        private int _personID;
        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            this._Mode = enMode.enAddNew;
           

        }

        public frmAddUpdatePerson(int personID)
        {
           
            InitializeComponent();
            this._Mode = enMode.enUpdate;
            _personID = personID;
           
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _Load();
        }
        private void _Load()
        {
            _FillCountriesToComboBox();

            //sadece bir kez eklemelisin. Her fonk çağırılmasında değil. 
            //Ayrıca burada load olmalı. FOrm.Load içinde değil. Yoksa yüklenmez.
            _AddControlsToTheList();

            if (this._Mode == enMode.enAddNew)
            {
                dtpBirthDate.MaxDate = DateTime.Now.AddYears(-18);
                _Person = new PeopleBL();
                lblMode.Text = "Add New Person";
                cbCountries.SelectedItem = _Region.EnglishName;
                if (rbFemale.Checked)
                {
                    pbPersonImage.Image = Resources.Female_512;
                }
                else if (rbMale.Checked)
                {
                    pbPersonImage.Image = Resources.Male_512;
                }
                temp();
                pbPersonImage.ImageLocation = "";
                setErrors();
                return;
            }

            _Person = PeopleBL.find(_personID);
            lblMode.Text = "Update Person";
            fillObjectDataToField(_Person);



        }

        private void _FillCountriesToComboBox()
        {
            DataTable dt = Country.getCountryRecord();
            foreach (DataRow data in dt.Rows)
            {
                cbCountries.Items.Add(data["CountryName"]);
            }

        }

        private void temp()
        {
            mskFirstName.Text = "ibo";
            mskSecondName.Text = "aa";
            mskLastName.Text = "agr";
            mskPhoneNumber.Text = "1234567889";
            txtAddress.Text = "Turkey";
           
        }
        //======================= V SAVE V ========================================

        //____________ ^ SAVE - Image ^ __________________
        private void rbMale_Click(object sender, EventArgs e)
        {
          
            if (pbPersonImage.ImageLocation ==null)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
        }
        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
            {
                pbPersonImage.Image = Resources.Female_512;
            }
        }
     
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
                pbPersonImage.Tag = 0;
            }

        }
        //


 

        //return'e gerek yok. Çünkü _person global
        private bool _handleImage()
        {

         

            //Add new'da yani ilk kez ekleme olacaında ikisi birbirine eşit olmica için true. Update te ise  foto değişmişse birbirne eşit olmaz o zaman da true olur.
            //Yani add new ve foto değişmişse if içine gir. Onun dışında update olduğunda PB'deki foto person'daki ile aynısa zaten güncelleme olmayacak.

            if (_Person.imagePath!=pbPersonImage.ImageLocation)
            {
                //_Person.imagePath eğer boş değilse her türlü sil.
                if (_Person.imagePath != "")
                {

                    try
                    {
                        File.Delete(_Person.imagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }

                }
                //sildikten sonra eğer PB'de foto varsa kopyala eğer PB'de foto yoksa yani foto default kalmışsa kopyalanmaz. Yani default DB'e eklenmez. Sadece programda gösterilir. 
                string imagePath = pbPersonImage.ImageLocation;
                if (pbPersonImage.ImageLocation != null)
                {
                    if (Utility.CopyImageToNewFolder(ref imagePath))
                    {
                        pbPersonImage.ImageLocation = imagePath;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }




            }
            return true;
        }
        //__________________________________________
        private bool _FillDataToObject()
        {

            if (this.ValidateChildren()&&_handleImage())
            {
                _Person.imagePath =pbPersonImage.ImageLocation;
                _Person.firstName = mskFirstName.Text.Trim();
                _Person.secondName = mskSecondName.Text.Trim();
                _Person.thirdName = mskThirdName.Text.Trim();
                _Person.lastName = mskLastName.Text.Trim();
                _Person.nationalNo = mskNationalNo.Text.Trim();
                _Person.email = txtEmail.Text.Trim();
                _Person.address = txtAddress.Text.Trim();
                _Person.phone = mskPhoneNumber.Text.Trim();
                _Person.countryID = Country.findCountry(cbCountries.SelectedIndex + 1).countryID;
                _Person.gender = (rbFemale.Checked ? 1 : 0);


                return true;
            }
            else
            {
                return false;
            }

        }
        private void fillObjectDataToField(PeopleBL person)
        {
            mskFirstName.Text = person.firstName;
            mskSecondName.Text = person.secondName;
            mskThirdName.Text = person.thirdName;
            mskLastName.Text = person.lastName;
            mskNationalNo.Text = person.nationalNo;
            txtEmail.Text = person.email;
            txtAddress.Text = person.address;
            mskPhoneNumber.Text = person.phone;
            cbCountries.SelectedIndex = cbCountries.FindString(person.CountryInfo.countryName);


            if (person.gender == 0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            if (File.Exists(person.imagePath))
            {
                pbPersonImage.ImageLocation = person.imagePath;
                lnkLblRemove.Visible = true;
            }
            else
            {
                pbPersonImage.ImageLocation = "";
                if (rbFemale.Checked)
                {
                    pbPersonImage.Image = Resources.Female_512;
                }
                else if (rbMale.Checked)
                {
                    pbPersonImage.Image = Resources.Male_512;
                }
            }



        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_FillDataToObject())
            {
                MessageBox.Show("Fill required fields ");
                return;
            }

            if (_Person.save())
            {
                MessageBox.Show("Saved successfully");
                _Mode = enMode.enUpdate;

                DataBack?.Invoke(sender,_Person.personID);
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        //======================= ^^^ SAVE ^^^ ========================================



        //-------------  V Validaiton V --------------------


        private void mskValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MaskedTextBox Temp = ((MaskedTextBox)sender);
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }
        private void mskTextChanged(object sender, EventArgs e)
        {
            MaskedTextBox Temp = ((MaskedTextBox)sender);
            if(Temp.MaskCompleted)
            {
                errorProvider1.SetError(Temp, null);
            }
            else
            {
                errorProvider1.SetError(Temp, "This field is required!");
            }
        }

        private bool _isEmailInputValid()
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || Utility.IsEmailValid(txtEmail.Text))
            {
                return true;
            }
            return false;

        }
       private void txtEmail_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_isEmailInputValid())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Enter a valid email");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);

            }
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!_isEmailInputValid())
            {
               
                errorProvider1.SetError(txtEmail, "Enter a valid email");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);

            }
        }


        private void ValidateNationalNo(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mskNationalNo.Text == "")
            {
                errorProvider1.SetError(mskNationalNo, "This field is required!");
                e.Cancel = false;
                return;
            }

            if (PeopleBL.isPersonExist(mskNationalNo.Text))
            {

                /*
                 Bu aslında mod update olduğun'da national no'yu özel olarak kontrol ediyor. Çünkü national no update yaplmas istenirken şu kontrl yapılmalı. O national no hem DB'de başka bir person tarafından kullanılmış olmamalı. Ancak bu mod update olduğu için national no her türlü DB'de olacak çünkü person DB'de halen. Bu yüzden update'te national no update olunca sadece başka personlarda olmamalı. Aynı personda olabilir. Bunuda şu şekilde yuapıyorz. Eğer NO varsa ve naitonalno değişmemişse sıkıntı yok. Ama eğer NO db'de var ve no buradan değişmiş. Bu demek oluyor ki buradan başka bit person'un national NO'su alınmaya çalışılıyopr.*/
                if (_Person.nationalNo == mskNationalNo.Text)
                {
                    errorProvider1.SetError(mskNationalNo, null);
                }
                else
                {
                    errorProvider1.SetError(mskNationalNo, "National no Already exist");
                    e.Cancel = false;
                }
            }
            else
            {
                errorProvider1.SetError(mskNationalNo, null);
            }
        }
        //-------------------****------------------------------------

        //------------ V indepente V ---------------------
        private void lnkLblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbPersonImage.Image = Resources.Female_512;
            }
            else if (rbMale.Checked)
            {
                pbPersonImage.Image = Resources.Male_512;
            }
            pbPersonImage.ImageLocation = null;
        }


        private List<Control> _FormInputFields = new List<Control>();
        private void _AddControlsToTheList()
        {
            _FormInputFields.Add(mskFirstName);
            _FormInputFields.Add(mskSecondName);
            _FormInputFields.Add(mskLastName);
            _FormInputFields.Add(mskNationalNo);
            _FormInputFields.Add(mskPhoneNumber);
            _FormInputFields.Add(txtAddress);
        }

        private void setErrors()
        {
       


            foreach (Control ctrl in _FormInputFields)
            {
                    errorProvider1.SetError(ctrl, "This field is required");   
            }

        }
        private void ValidateEmptyTextBox(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtAddress.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "This field is required");
            }
            else
            {
                errorProvider1.SetError(txtAddress, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

           this.Close();
        }
    }
}

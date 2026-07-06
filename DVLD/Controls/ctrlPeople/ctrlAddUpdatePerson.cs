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
            //nedense load yaparken pb'de image olmasına rağmen imageLocaiton boş oluyor.
            //Bu yüzden load sırasında iamge'i yüklemek lazım.



            if (this._Mode==enMode.enAddNew)
            {
                dtpBirthDate.MaxDate = DateTime.Now.AddYears(-18);
                cbCountries.SelectedIndex = 10;
                _Person = new People();
                setDefaultImage();
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
        private void lnkLblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images";

            openFileDialog1.Title = "This is a title";

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "All Images|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff;*.webp| JPEG Files (*.jpg;*.jpeg)|  PNG Files (*.png)|*.png|";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.Load(openFileDialog1.FileName);
            }
        }
        private string _SetPersonImage()
        {
            string imagePath = pbPersonImage.ImageLocation;

            //Eğer oldu da imagepath boş geldi. Haliyle kopyalama gerçekleşmez. Bu durmda DB'ye boş gitmemesi için default fotoğraf atıyoruz.
            if (!Utility.copyImageToNewFolder(ref imagePath))
            {

                Utility.notifyUser(notifyIcon1, "Having problem with copy image. Saving with Default image", ToolTipIcon.Warning);
                imagePath = setDefaultImage();
                Utility.copyImageToNewFolder(ref imagePath);   
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
                _Person.imagePath = _SetPersonImage();
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
           
             //Mode update olduğunda sistem DB'den yüklenirken gender butonu male/femal durumuna göre işaretlenmeli.
             //İşaretleme sonucu da fotoğraf değişeceği için person'un fotoğrafını değiştirmiş oluruz. Bu yüzden ilk update yaparken radio buttonlar işaretlenmeli ama o kişini fotoğrafı DB'de ne yüklü ise o olmalı. radio buton değiştiği için fotoğraf değişmemeli.
             //Ve bu işlem sadece ilk yükleme sırasında yapılmalı. Sonradan kullanıcı istediğini seçebilir.

            //Bunu için ilk önce gender'ı alıp, sonra fotoğraf yüklenebilir.
            if(person.gender==0)
            {
                rbMale.Checked = true;
            }
            else
            {
                rbMale.Checked = false;
            }
            //gender'ı aldıktan sonra; Eğer DB'de fotoYolu boş deilse ilgili fotoyu gösterir. Yok eğer fotoYolu boşsa, 
            //Default foto zaten bir önceki adımda picturebox'a eklenmil olur
            if(person.imagePath!=string.Empty)
            {
                pbPersonImage.Load(person.imagePath);
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
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        //======================= ^^^ SAVE ^^^ ========================================

        private void lnkLblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            setDefaultImage();
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

            if (!msk.MaskCompleted)
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
            if (txtAddress.Text == string.Empty)
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
            if (txtEmail.Text == string.Empty || Utility.IsEmailValid(txtEmail.Text))
            {
                return true;
            }
            return false;

        }

        private void txtEmail_Leave(object sender, EventArgs e)
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
            setDefaultImage();
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


        private bool _IsNationalNoInputValid()
        {

            if(People.isPersonExistByNationalNo(mskNationalNo.Text))
            {
                if(_Person.nationalNo==mskNationalNo.Text)
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
    }
}

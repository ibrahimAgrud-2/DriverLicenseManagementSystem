using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.IO;
using System.Windows.Forms;
using peoplBl = DVLD_BusinessLayer.People;
namespace DVLD
{
    public partial class ctrlPersonInformation : UserControl
    {
        public ctrlPersonInformation()
        {
            InitializeComponent();
        }


        //bu formun mantığı çok kolay. Eğer yükleme başarılı olursa _PersonID yüklenen kişinin ID si olur 
        // yani -1 olmaz bu sayde yükleme tamamlanmıştır. Yok eğer yükleme başarısız olursa ID -1 kalır ve
        //yükleme başarısız olmuştur.

        private int _PersonID = -1;
        private peoplBl _Person=null;


        public int PersonID { get { return _PersonID; } }

        public peoplBl SelectedPerson { get { return _Person; } }


        public void LoadPersonInfo(int personID)
        {
            _Person = peoplBl.Find(personID);
            if (_Person == null)
            {
                _PersonID = -1;
                ResetForm();   
                MessageBox.Show("No Person with PersonID = " + personID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Load();
        }
        public void LoadPersonInfo(string nationalNo)
        {
            _Person = peoplBl.Find(nationalNo);
            if (_Person == null)
            {
                
                ResetForm();
                MessageBox.Show("No Person with national NO = " + nationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;
            }
            _Load();
        }



        private void _Load()
        {
            _PersonID = _Person.personID;
            fillObjectDataToField(_Person);
            lnklblEditPersonInfo.Enabled = true;

        }

        public void ResetForm()
        {
            //Yükleme başarılı olup olmadığını ID ile biliyoruz. Bu yüzden yükleme başarısız olduğunda 
            //formu temizlerken ID'i de -1 yapıyoruz.
            _PersonID = -1;
            lblName.Text = "????";
            lblPersonID.Text = "????";
            lblNationalNo.Text = "????";
            lblBirthDate.Text = "????";
            lblEmail.Text = "????";
            lblPhone.Text = "????";
            lblAddress.Text = "????";
            lblCountry.Text = "????";
            lblGender.Text = "????";
            pbPersonImage.Image = Resources.Male_512;
        }


        private void fillObjectDataToField(peoplBl person)
        {
            lblName.Text = person.fullName;
            lblPersonID.Text = person.personID.ToString();
            lblNationalNo.Text = person.nationalNo;
            lblBirthDate.Text = person.dateOfBirth.ToString("yyyy/mm/dd");
            lblEmail.Text = person.email;
            lblPhone.Text = person.phone;
            lblAddress.Text = person.address;

            // lblCountry.Text= Country.findCountry(person.countryID).countryName;

            //composition
            lblCountry.Text = person.CountryInfo.countryName;
       



            lblGender.Text = person.gender == 0 ? "Male" : "Female"; 

            if (_Person.imagePath!="")
            {
                if(File.Exists(_Person.imagePath))
                {
                    pbPersonImage.ImageLocation = _Person.imagePath;
                }
                else
                {
                    MessageBox.Show("Could not Find this image: = " + _Person.imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(_Person.gender==1)
            {
                pbPersonImage.Image=Resources.Female_512;
            }
            else
            {
                pbPersonImage.Image = Resources.Male_512;
            }
        }


        private void lnklblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(PersonID);
        }
    }
}

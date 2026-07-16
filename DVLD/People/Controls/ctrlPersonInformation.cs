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

        //Load bitiğinde tetiklernir. paramtere olarak'ta true false yükleme başarılıysa eğer. 
        public event Action<bool> IsLoadCompleted;
        protected virtual void IsLoadCompletedSuccessfully(bool isCompletedSuccessfully)
        {
            Action<bool> test = IsLoadCompleted;
            if (test != null)
            {
                test(isCompletedSuccessfully);
            }

        }



        private int _PersonID;
        private peoplBl _Person;


        public int PersonID { get { return _PersonID; } };
        public void LoadPersonInfo(int personID)
        {
            _Person = peoplBl.find(personID);
            if (_Person == null)
            {
                _ResetForm();
                return;
            }
            _Load();
            IsLoadCompletedSuccessfully(_Person != null);
        }
        public void LoadPersonInfo(string nationalNo)
        {
            _Person = peoplBl.find(nationalNo);
            if (_Person == null)
            {
                _ResetForm();
                return;
            }
            _Load();
            IsLoadCompletedSuccessfully(_Person != null);
        }



        private void _Load()
        {
            fillObjectDataToField(_Person);
            lnklblEditPersonInfo.Enabled = true;
        }

        private void _ResetForm()
        {
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
                pbPersonImage.ImageLocation = _Person.imagePath;
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
            _Load();
        }
    }
}

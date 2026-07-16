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

        public event Action<bool> OnIsLoadCompleted;
        protected virtual void IsLoadCompletedSuccessfully(bool isCompletedSuccessfully)
        {
            Action<bool> test = OnIsLoadCompleted;
            if (test != null)
            {
                test(isCompletedSuccessfully);
            }

        }

        private int _PersonID;
        private peoplBl _Person;


        public int PersonID
        {
            
            set
            {
                _PersonID = value;
                _Load();
            }
            get { return _PersonID;}
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

            lblCountry.Text = Country.findCountry(person.countryID).countryName;



            lblGender.Text = person.gender == 0 ? "Male" : "Female"; 

            if (File.Exists(_Person.imagePath))
            {
                pbPersonImage.ImageLocation = _Person.imagePath;
            }
            else if(_Person.gender==1)
            {
                pbPersonImage.ImageLocation = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png";
            }
            else
            {
                pbPersonImage.ImageLocation = @"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png";
            }
        }

        private void _Load()
        {
            _Person = peoplBl.find(_PersonID);
            if (_Person==null)
            {
                _ResetForm();
                IsLoadCompletedSuccessfully(false);
                return;
            }
            IsLoadCompletedSuccessfully(true);
            fillObjectDataToField(_Person);
            lnklblEditPersonInfo.Enabled = true;
        }

        private void lnklblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            _Load();
        }
    }
}

using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlPersonInformation : UserControl
    {
        public ctrlPersonInformation()
        {
            InitializeComponent();
        }

        private int _PersonID;
        private People _Person;


        public int PersonID
        {
            
            set
            {
                _PersonID = value;
                _loadDataIfPersonExists();
            }
            get { return _PersonID;}
        }
        private void _loadDataIfPersonExists()
        {
            if(!People.isPersonExistByID(_PersonID))
            {
                return;
            }
            else
            {
                _Person = People.findPersonByID(_PersonID);
                _Load();
            }
        }
        private void _Load()
        {

            lblName.Text= _Person.firstName + " " + _Person.secondName + " " + _Person.thirdName + " " + _Person.lastName; ;
            lblPersonID.Text = _Person.personID.ToString();
            lblNationalNo.Text = _Person.nationalNo;
            lblBirthDate.Text = _Person.dateOfBirth.ToString("yyyy/mm/dd");
            lblEmail.Text = _Person.email;
            lblPhone.Text = _Person.phone;

            lblCountry.Text = Country.findCountryByID(_Person.countryID).countryName;
            
            if(_Person.gender==0)
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }

            pbPersonImage.ImageLocation = _Person.imagePath;


        }
    }
}

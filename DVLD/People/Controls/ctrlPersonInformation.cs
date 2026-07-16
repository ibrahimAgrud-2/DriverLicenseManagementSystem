using System.IO;
using DVLD_BusinessLayer;
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

        private int _PersonID;
        private peoplBl _Person;


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
            if(!peoplBl.isPersonExist(_PersonID))
            {
                return;
            }
            else
            {
               
                _Load();
                
            }
        }


        private void fillObjectDataToField(peoplBl person)
        {
            lblName.Text = person.firstName + " " + person.secondName + " " + person.thirdName + " " + person.lastName; ;
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

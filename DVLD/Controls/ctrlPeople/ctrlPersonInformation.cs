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


        private People _Person;


        public void FillPersonInfoIsExists(int personId)
        {
            if (People.isPersonExistByID(personId))
            {
                _Person = People.findPersonByID(personId);
                _Load();
            }
            else
            {
                return;
            }
        }
        public void FillPersonInfoIsExists(string nationalNo)
        {
            if (People.isPersonExistByNationalNo(nationalNo))
            {
                _Person = People.findPersonByNationalNo(nationalNo);
                _Load();
            }
            else
            {
                return;
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
            if(_Person.imagePath!=string.Empty)
            { pbPersonImage.Load(_Person.imagePath); }

          

            lblGender.Text = _Person.personID.ToString();
            lblCountry.Text = _Person.countryID.ToString();

        }

        private void ctrlPersonInformation_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void test(object sender,int personID)
        {
            FillPersonInfoIsExists(personID);
        }
        private void lnklblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(lblPersonID.Text, out int personID))
            {
                frmAddUpdatePerson frm = new frmAddUpdatePerson(personID);
                frm.sendIDBack += test;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("ID is not valid");
            }
        }
    }
}

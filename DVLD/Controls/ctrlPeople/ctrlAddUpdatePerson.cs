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


        int _personID;

        //Control için dışardan veriyi property ile verecem. property mantığı gereği ID verildiği anda 
        //set'e yazdığım fonksyionlar çalışacak.
        public int personID
        {
  
            set
            {
                _personID = value;
                _Load();
            }
        }




        //Bu control'ü bazı formlarda ilk yüklenirken değil de sonradan verilern bir ID üzeridne tetiklenebiliyor 
        //olması lazım. Mesela, user form'a alt kısma bunuda ekledim. Form ilk yüklenirken değilde, belli bir butona
        //basınca ID gitmesini ve conttrolün çalışmasını isticem. Bu gibi durumlarda const işe yaramaz.
        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {

        }

   
        private void _Load()
        {
            dtpBirthDate.Value = DateTime.Now.AddYears(-18);
            _FillCountriesToComboBox();
            cbCountries.SelectedIndex = 10;
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
            if (rbFemale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\Female 512.png");
            }
            else if (rbMale.Checked)
            {
                pbPersonImage.Load(@"C:\Users\ibrah\source\repos\DVLD\Resources\Images\male 512.png");
            }
        }

        //__________________^^^^Validation^^^^_________________________________________

     


    }
}

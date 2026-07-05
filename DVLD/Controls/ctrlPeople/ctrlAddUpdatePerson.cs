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

        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _Load();
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
            if(txtEmail.Text==string.Empty)
            {

            }
        }
    }
}

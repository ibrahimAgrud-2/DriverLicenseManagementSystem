using DVLD_BusinessLayer;
using System;
using PeopleBL = DVLD_BusinessLayer.People;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddUpdateNewUser : Form
    {


        private User _User;
        private int _UserID=-1;
       
        private bool _PersonSelected = false;

        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode = enMode.enAddNew;

        public frmAddUpdateNewUser()
        {
            InitializeComponent();
            this._Mode = enMode.enAddNew;
        }



        public frmAddUpdateNewUser(int userID)
        {
            InitializeComponent();
            this._Mode = enMode.enUpdate;
            _UserID = userID;
        }


        private void fillObjectDataToField(User user)
        {
            if (user == null)
                return;

            txtUserName.Text = user.userName;
            mskPassword.Text = user.password;
            mskConfirmPassword.Text = user.password;
            lblID.Text = user.userID.ToString();
            cbIsActive.Checked = user.isActive;
            this.ctrlPersonInformation1.LoadPersonInfo(user.personID);


        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {

            //when mode is update;
            if (this._Mode==enMode.enUpdate)
            {
                _User = User.Find(_UserID);
                if (_User == null)
                    return;
                lblID.Text = _User.personID.ToString();
                lblMode.Text = "Update User";
                ctrlFindUser1.Enabled = false;
                fillObjectDataToField(_User);

            }
            else
            {
                lblMode.Text = "Add New User";
                _User = new User();
            }
        }


        private void ctrlFindUser1_OnFilteringComplete(int obj)
        {

            if (obj > 0)
            {
                _User.personID = obj;
            }

            this.ctrlPersonInformation1.LoadPersonInfo(obj);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool _FillDataToObject()
        {

            if (this.ValidateChildren())
            {
                _User.userName = txtUserName.Text;
                _User.password = mskPassword.Text;
                _User.isActive = cbIsActive.Checked;
                return true;
            }
            else
            {
                return false;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_FillDataToObject())
            {
                MessageBox.Show("Fill requireds properly");
                return;
            }

            if (_User.save())
            {
                MessageBox.Show("Saved successfully");
                lblID.Text = _User.userID.ToString();
                this._Mode = enMode.enUpdate;
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }

        }


        private void btnNext_Click(object sender, EventArgs e)
        {
     
          
                tbMain.SelectedIndex = 1;
            lblID.Enabled = true;
            txtUserName.Enabled = true;
            lblID.Enabled = true;
            mskConfirmPassword.Enabled = true;
            mskPassword.Enabled = true;
            if (this._Mode == enMode.enAddNew)
                {
                    errorProvider1.SetError(mskPassword, "Password Required");
                    errorProvider1.SetError(txtUserName, "User name must be unique");
                    errorProvider1.SetError(mskConfirmPassword, "Passwords should Match");

                }
                cbIsActive.Enabled = true;
            


        }


        //=========================== ^Next^=====================



        //------------------   V   Validation   V ------------------
        private void txtUserName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtUserName.Text == "")
            {
                errorProvider1.SetError(txtUserName, "This field is required!");
                e.Cancel = false;
                return;
            }

            if (PeopleBL.isPersonExist(txtUserName.Text))
            {
                if (_User.userName == txtUserName.Text)
                {
                    errorProvider1.SetError(txtUserName, null);
                }
                else
                {
                    errorProvider1.SetError(txtUserName, "National no Already exist");
                    e.Cancel = false;
                }
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private bool _isPasswordsMatches()
        {
            return (mskConfirmPassword.Text == mskPassword.Text);
        }
       
        
        private void mskPassword_TextChanged(object sender, EventArgs e)
        {
            if (mskPassword.Text == string.Empty)
            {
                errorProvider1.SetError(mskPassword, "Password required");
            }
            else
            {
                errorProvider1.SetError(mskPassword, "");
            }
        }
        private void mskPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = (mskPassword.Text == string.Empty);
        }

        private void mskConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!_isPasswordsMatches())
            {
                errorProvider1.SetError(mskConfirmPassword, "Password does not match");
            }
            else
            {
                errorProvider1.SetError(mskConfirmPassword, "");
            }
        }
        private void mskConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = (!_isPasswordsMatches());
        }


        //------------------   ^^   Validation   ^^ ------------------

        private void ctrlPersonInformation1_OnIsLoadCompleted(bool obj)
        {
            _PersonSelected= obj;
        }
        private void tbMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_PersonSelected)
            {
                MessageBox.Show("Select a person first");
                e.Cancel = true;
                return;
            }
            if (User.isUserExistByPersonID(_User.personID) && this._Mode == enMode.enAddNew)
            {
                MessageBox.Show("The person is already a user");
                e.Cancel = true;
                return;
            }
            btnSave.Enabled = true;
        }

   
    }
}

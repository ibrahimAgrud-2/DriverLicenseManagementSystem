using DVLD_BusinessLayer;
using System;
using PeopleBL = DVLD_BusinessLayer.People;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddUpdateNewUser : Form
    {


        private User _User;
        private int _UserID;

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
            this.ctrlPersonInformation1.PersonID = user.personID;
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
                _Mode = enMode.enUpdate;
                fillObjectDataToField(_User);

            }
            else
            {
                _User = new User();
            }
        }


        private void ctrlFindUser1_OnFilteringComplete(int obj)
        {

            if (obj > 0)
            {
                _User.personID = obj;
                this.ctrlPersonInformation1.PersonID = obj;
            }
            else
            {
                MessageBox.Show("Person does not exist");
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_User.personID <= 0)
            {
                MessageBox.Show("Select a person first");
                return;
            }
            else if (User.isUserExistByPersonID(_User.personID) && this._Mode == enMode.enAddNew)
            {
                MessageBox.Show("The person is already a user");
                return;
            }
            else
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


        }


        //=========================== ^Next^=====================


        private bool _IsUserNameInputValid()
        {
                
            
            if(User.isUserExist(txtUserName.Text))
            {
                if (_User.userName==txtUserName.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            return (txtUserName.Text!=string.Empty);
             
        }
        private bool _IsAllInputsValid()
        {
            return (mskPassword.Text != string.Empty && _isPasswordsMatches() && _IsUserNameInputValid()); 
        }

        private bool _FillDataToObject()
        {

            if (_IsAllInputsValid())
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

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (!_IsUserNameInputValid())
            {
                errorProvider1.SetError(txtUserName, "User name already taken");
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");

            }
        }
        private bool _isPasswordsMatches()
        {
            return (mskConfirmPassword.Text == mskPassword.Text);
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


    }
}

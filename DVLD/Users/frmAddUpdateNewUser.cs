using DVLD_BusinessLayer;
using System;
using PeopleBL = DVLD_BusinessLayer.People;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddUpdateNewUser : Form
    {
        public frmAddUpdateNewUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }
        private int _personID = -1;
        private int _UserID=-1;
        private User _User = new User();

        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode = enMode.enAddNew;
        private void fillObjectDataToField(User user)
        {

            txtUserName.Text = user.userName;
            mskPassword.Text = user.password;
            mskConfirmPassword.Text = user.password;
            lblID.Text = user.userID.ToString();
            cbIsActive.Checked = user.isActive;
            this.ctrlPersonInformation1.PersonID = user.personID;

        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            if (_UserID > 0)
            {
                lblID.Text = _personID.ToString();
                lblMode.Text = "Update User";
                _User = User.findUserByUserID(_UserID);
                _personID = _User.personID;
                _Mode = enMode.enUpdate;
                fillObjectDataToField(_User);
            }
        }


        //search işlemi bittikten sonra eğer person varsa ID'sini buraya koysun. Person'un olup olmadığını bunla anlicaz

        private void ctrlFindUser1_OnFilteringComplete(int obj)
        {

            if (obj > 0)
            {
                _personID = obj;
                this.ctrlPersonInformation1.PersonID = obj;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_personID <= 0)
            {
                MessageBox.Show("Select a person first");
                return;
            }
            else if (User.isUserExistByPersonID(_personID)&&this._Mode==enMode.enAddNew)
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
                if(this._Mode==enMode.enAddNew)
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
            if(User.isUserExistByID(_UserID))
            {
                if (this._Mode == enMode.enUpdate)
                {
                    return true;
                }
                else
                    return false;
            }
            return true;
             
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
                _User.personID = _personID;
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
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (User.isUserExistByUserName(txtUserName.Text)&&this._Mode!=enMode.enUpdate)
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

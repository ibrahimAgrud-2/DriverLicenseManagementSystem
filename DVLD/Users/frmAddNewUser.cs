using DVLD_BusinessLayer;
using System;
using PeopleBL = DVLD_BusinessLayer.People;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }
        private int _UserID = -1;
        private User _User = new User();


   
        private void fillObjectDataToField(User user)
        {

            txtUserName.Text = user.userName;
            mskConfirmPassword.Text = user.password;
            mskPassword.Text = user.password;
            lblID.Text = user.userID.ToString();
            this.ctrlPersonInformation1.PersonID = user.personID;

        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            if (_UserID > 0)
            {
                lblID.Text = _UserID.ToString();
                lblMode.Text = "Update User";
                _User = User.findUserByUserID(_UserID);
                fillObjectDataToField(_User);
            }
        }


        //search işlemi bittikten sonra eğer person varsa ID'sini buraya koysun. Person'un olup olmadığını bunla anlicaz

        private void ctrlFindUser1_OnFilteringComplete(int obj)
        {

            if (obj > 0)
            {
                _UserID = obj;
                this.ctrlPersonInformation1.PersonID = obj;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_UserID <= 0)
            {
                MessageBox.Show("Select a person first");
                return;
            }
            else if (!PeopleBL.isPersonExistByID(_UserID))
            {
                MessageBox.Show("Person does not exist or deleted");
                return;
            }
            else if (User.isUserExistByPersonID(_UserID))
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
                errorProvider1.SetError(mskPassword, "Password Required");
                errorProvider1.SetError(txtUserName, "User name must be unique");
                errorProvider1.SetError(mskConfirmPassword, "Passwords should Match");
                cbIsActive.Enabled = true;
            }


        }


        //=========================== ^Next^=====================

        private bool _IsAllInputsValid()
        {
            return (mskPassword.Text != string.Empty && _isPasswordsMatches() && !User.isUserExistByUserName(txtUserName.Text));
        }

        private bool _FillDataToObject()
        {

            if (_IsAllInputsValid())
            {
                _User.userName = txtUserName.Text;
                _User.password = txtUserName.Text;
                _User.personID = _UserID;
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
            if (User.isUserExistByUserName(txtUserName.Text))
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

using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {

        private int _UserID = -1;
        private User _user;
        
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _user = User.Find(_UserID);
            if(_user == null)
            {
                MessageBox.Show("User Not Found");
                this.Close();
                return;
            }

            this.ctrlUserInfo1.LoadUserData((_user.userID));
        }



        private bool _IsPasswordsMatch()
        {
            return (mskPassword.Text.Trim()==mskConfirmPassword.Text.Trim());
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Fill Required Fileds");
                return;
            }
            _user.password = mskPassword.Text.Trim(); 
             if(_user.save())
            {
                MessageBox.Show("Saved successfully");
            }
            else
            {
                MessageBox.Show("An Erro Occured, Password did not change.",
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCurrentPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current Password Cant be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(mskPassword, null);
            }

            if (_user.password != txtCurrentPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword,"Current password does not match");
                return;
            }
            else
            {

                errorProvider1.SetError(txtCurrentPassword,null);
            }
        }

        private void mskPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(mskPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(mskPassword, "Enter a Password");
            }
            else
            {
                errorProvider1.SetError(mskPassword, null);
            }
        }
        private void mskConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (_IsPasswordsMatch())
            {
                errorProvider1.SetError(mskConfirmPassword, "");
            }
            else
            {
                errorProvider1.SetError(mskConfirmPassword, "Passwords Does not match");

            }
        }
        private void mskConfirmPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_IsPasswordsMatch())
            {
         
                errorProvider1.SetError(mskConfirmPassword, "");
            }
            else
            {
                errorProvider1.SetError(mskConfirmPassword, "Passwords Does not match");
                e.Cancel = true;
            }
        }
    }
}

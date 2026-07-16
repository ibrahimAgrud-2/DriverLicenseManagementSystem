using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {

        private int _UserID = -1;
        private User _user = new User();
        
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
            User usr = User.Find(_UserID);
            if(usr!=null)
            {
                _user = usr;
                this.ctrlUserInfo1.LoadDataToUserControls(usr.userID, usr.personID);
            }
            errorProvider1.SetError(txtCurrentPassword,"Enter the current password");
            errorProvider1.SetError(mskPassword,"New password");
            errorProvider1.SetError(mskConfirmPassword,"Confirm new password");
        }

        private bool _IsPasswordsMatche()
        {
            return (mskPassword.Text==mskConfirmPassword.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtCurrentPassword.Text!=_user.password)
            {
                MessageBox.Show("Current password is wrong");
                return;
            }
            if(!_IsPasswordsMatche())
            {
                MessageBox.Show("Passwords Does not match");
                return;
            }
            _user.password = mskPassword.Text; 
             if(_user.save())
            {
                MessageBox.Show("Saved successfully");
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void mskConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if(_IsPasswordsMatche())
            {
                errorProvider1.SetError(mskConfirmPassword,"");
            }
        }

        private void mskPassword_TextChanged(object sender, EventArgs e)
        {
            Control msk = (Control)sender;
            if (msk.Text!=string.Empty)
            {
                errorProvider1.SetError(msk, "");
            }
        }
    }
}

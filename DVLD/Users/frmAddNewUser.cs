using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PeopleBL = DVLD_BusinessLayer.People;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
        }
        private int _PeronID = -1;
        private User _user = new User();


        //search işlemi bittikten sonra eğer person varsa ID'sini buraya koysun. Person'un olup olmadığını bunla anlicaz

        private void ctrlFindUser1_OnFilteringComplete(int obj)
        {
           
            if(obj>0)
            {
                _PeronID = obj;
                this.ctrlPersonInformation1.PersonID = obj;
            }
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_PeronID <= 0)
            {
                MessageBox.Show("Select a person first");
                return;
            }
            else if (!PeopleBL.isPersonExistByID(_PeronID))
            {
                MessageBox.Show("Person does not exist or deleted");
                return;
            }
            else if (User.isUserExistByPersonID(_PeronID))
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
            return (mskPassword.Text!=string.Empty&&_isPasswordsMatches()&&!User.isUserExistByUserName(txtUserName.Text));
        }

        private bool _FillDataToObject()
        {

            if (_IsAllInputsValid())
            {
                _user.userName = txtUserName.Text;
                _user.password = txtUserName.Text;
                _user.personID = _PeronID;
                _user.isActive = cbIsActive.Checked;
                return true;
            }
            else
            {
                return false;
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_FillDataToObject())
            {
                MessageBox.Show("Fill requireds properly");
                return;
            }

            if (_user.save())
            {
                MessageBox.Show("Saved successfully");

            }
            else
            {
                MessageBox.Show("Something went wrong");
            }

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if(User.isUserExistByUserName(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName,"User name already taken");
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");

            }
        }
        private bool _isPasswordsMatches()
        {
            return (mskConfirmPassword.Text==mskPassword.Text);
        }

        private void mskConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if(!_isPasswordsMatches())
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
            if (mskPassword.Text==string.Empty)
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

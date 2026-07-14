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

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        //search işlemi bittikten sonra eğer person varsa ID'sini buraya koysun. Person'un olup olmadığını bunla anlicaz
        private int _PeronID = -1;
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
            else if(User.isUserExistByPersonID(_PeronID))
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
                txtPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;
                cbIsActive.Enabled = true;
            }


        }
    }
}

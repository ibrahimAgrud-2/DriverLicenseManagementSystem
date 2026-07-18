using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PeopleBL = DVLD_BusinessLayer.People;

namespace DVLD.Users.Controls
{
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private int _UserID = -1;
        private User _user;

        public int UserID { get { return _UserID; } }
        private void _ResetForm()
        {

            _UserID = -1;
            lblUserID.Text = "?????";
            lblUserName.Text = "?????";
            lblIsActive.Text = "?????";
            this.ctrlPersonInformation1.ResetForm();
        }

        private void _LoadData(int id)
        {
            _user = User.Find(id);
            if(_user != null)
            {
                lblUserID.Text = _user.userID.ToString();
                lblUserName.Text = _user.userName.ToString();
                lblIsActive.Text = ((_user.isActive) ? "Yes" : "No");
                this.ctrlPersonInformation1.LoadPersonInfo(_user.personID);
            }
            else
            {
                MessageBox.Show($"User With ID {id} Not Found");
                _ResetForm();
            }
          
        }
        public void LoadUserData(int userID)
        {
            _LoadData(userID);

        }

    }
}

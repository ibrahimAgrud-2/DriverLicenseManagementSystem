using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using PeopleBL = DVLD_BusinessLayer.People;
using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace DVLD.Users.Controls
{
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private void ctrlLoginInfo_Load(object sender, EventArgs e)
        {

        }

        private void _LoadUserInfo(int id )
        {
            User user = User.findUserByUserID(id);
            if(user!=null)
            {
                lblUserID.Text = user.userID.ToString();
                lblUserName.Text = user.userName.ToString();
                lblIsActive.Text = ((user.isActive) ? "Yes" : "No");
            }
          
        }
        private void _LoadPersonInfo(int id)
        {
           
            if (id >0)
            {
                this.ctrlPersonInformation1.PersonID = id;
            }

        }
        public void LoadDataToUserControls(int userID,int personID)
        {
            _LoadUserInfo(userID);
            _LoadPersonInfo(personID);
        }

        private void lblUserID_Click(object sender, EventArgs e)
        {

        }
    }
}

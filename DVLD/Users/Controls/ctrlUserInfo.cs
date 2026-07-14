using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public void LoadUserINfo(User user)
        {
            if(loginSettings.currentUser!=null)
            {
                lblUserID.Text = user.userID.ToString();
                lblUserName.Text = user.userName.ToString();
                lblIsActive.Text = ((user.isActive) ? "Yes" : "No");
            }
          
        }

        private void lblUserID_Click(object sender, EventArgs e)
        {

        }
    }
}

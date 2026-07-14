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
    public partial class ctrlLoginInfo : UserControl
    {
        public ctrlLoginInfo()
        {
            InitializeComponent();
        }

        private void ctrlLoginInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadUserINfo()
        {
            if(loginSettings.currentUser!=null)
            {
                lblUserID.Text = loginSettings.currentUser.userID.ToString();
                lblUserName.Text = loginSettings.currentUser.userName.ToString();
                lblIsActive.Text = ((loginSettings.currentUser.isActive) ? "Yes" : "No");
            }
          
        }
    }
}

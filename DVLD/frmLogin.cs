using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }       
        private void cbRemeberMe_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            string fileContent = File.ReadAllText(@"C:\Users\ibrah\source\repos\DVLD\DVLD\UserRememberMeJustID.txt");

            if (fileContent != string.Empty)
            {
               int userID= Convert.ToInt32(fileContent);
                loginSettings.currentUser = User.findUser(userID);
                txtUserName.Text = loginSettings.currentUser.userName;
                maskedTextBox1.Text = loginSettings.currentUser.password;
            }
            
                    
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(User.findUser)

            if(cbRemeberMe.Checked)
            {
                File.WriteAllText(@"C:\Users\ibrah\source\repos\DVLD\DVLD\UserRememberMeJustID.txt", loginSettings.currentUser.userID.ToString());
            }
            else
            {
                File.WriteAllText(@"C:\Users\ibrah\source\repos\DVLD\DVLD\UserRememberMeJustID.txt", "");
            }
        }
    }
}

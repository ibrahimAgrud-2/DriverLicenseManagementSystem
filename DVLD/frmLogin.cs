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

        User u1=new User();
        private void frmLogin_Load(object sender, EventArgs e)
        {

            string fileContent = File.ReadAllText(@"C:\Users\ibrah\source\repos\DVLD\DVLD\UserRememberMeJustID.txt");

            if (fileContent != string.Empty)
            {
               int userID= Convert.ToInt32(fileContent);
                u1= User.findUserByUserID(userID);
                txtUserName.Text = u1.userName;
                maskedTextBox1.Text = u1.password;
            }
            
                    
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!User.isUserExistByUserName(txtUserName.Text))
            {
              
                return;
            }
            u1 = User.findUserByUserByUserName(txtUserName.Text);

            if (!User.isUserExistByUserName(txtUserName.Text)||u1.password!=maskedTextBox1.Text)
            {
                MessageBox.Show("User name or  password wrong");
                return;
            }
                     
            if(!u1.isActive)
            {
                MessageBox.Show("User does not active. Contact to your admin");
                return;
            }

            loginSettings.currentUser = u1;

            if (cbRemeberMe.Checked)
            {
                File.WriteAllText(@"C:\Users\ibrah\source\repos\DVLD\DVLD\UserRememberMeJustID.txt", loginSettings.currentUser.userID.ToString());
            }

            frmMain frm = new frmMain();
            frm.ShowDialog();
        }
    }
}

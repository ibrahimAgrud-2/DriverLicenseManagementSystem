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


        private void _fillDataFromFileToField()
        {
            string userName = "";
            string password = "";

            
            if(Global.GetStoredCredential(ref userName, ref password))
            {
                txtUserName.Text = userName;
                maskedTextBox1.Text = password;
                cbRemeberMe.Checked = true; 

            }
            else
            {
                cbRemeberMe.Checked = false;
            }
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            _fillDataFromFileToField();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (User.isUserExistByUserNameAndPassword(txtUserName.Text.Trim(),maskedTextBox1.Text.Trim()))
            {
                User u1 = User.Find(txtUserName.Text.Trim());
                if (u1.password == maskedTextBox1.Text.Trim())
                {

                   
                    if (!u1.isActive)
                    {
                        MessageBox.Show("User is not active. Contact to you admin.");
                        return;
                    }
                    Global.currentUser = u1;


                    if (cbRemeberMe.Checked)
                    {
                        Global.RememberUsernameAndPassword(txtUserName.Text, maskedTextBox1.Text);


                    }
                    else
                    {
                        Global.RememberUsernameAndPassword("", "");
                    }

                    frmMain frm = new frmMain(this);
                    this.Hide();
                    frm.ShowDialog();
                    return;
                }


            }
            else
            {
                MessageBox.Show("Invalid User Name/password");

            }
           
       
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

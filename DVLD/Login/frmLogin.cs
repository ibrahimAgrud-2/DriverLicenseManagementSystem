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


        private void _fillDataFromFileToField(string filePath,string dim="##")
        {


            string fileContent = File.ReadAllText(filePath);
            if (fileContent == string.Empty)
                return;

            int index = fileContent.IndexOf(loginSettings.dim);

            txtUserName.Text = fileContent.Substring(0, index);
            maskedTextBox1.Text = fileContent.Remove(0, index+dim.Length);
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            _fillDataFromFileToField(loginSettings.filePath, loginSettings.dim);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(User.isUserExistByUserName(txtUserName.Text))
            {
                User u1 = User.findUserByUserByUserName(txtUserName.Text);
                if(u1.password==maskedTextBox1.Text)
                {
                    
                    loginSettings.currentUser = u1;

                    if (!u1.isActive)
                    {
                        MessageBox.Show("User is not active. Contact to you admin.");
                        return;
                    }

                    if (cbRemeberMe.Checked)
                    {
                        File.WriteAllText(loginSettings.filePath, u1.userName+loginSettings.dim+u1.password);
                    }
                    else
                    {
                        File.WriteAllText(loginSettings.filePath, "");
                    }

                    frmMain frm = new frmMain();
                    frm.ShowDialog();
                    return;
                }
            }
            MessageBox.Show("Invalid User Name/password");

        }
    }
}

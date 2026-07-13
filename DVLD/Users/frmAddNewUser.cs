using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void ctrlFindUser1_OnFilteringComplete(int obj)
        {
            this.ctrlPersonInformation1.PersonID = obj;
            this.ctrlPersonInformation1.Tag = obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(User.findUserByUserID(Convert.ToInt32(this.ctrlPersonInformation1.Tag))!=null)
            {
                MessageBox.Show("User Exist");
                return;
            }
            else
            {
                tbMain.SelectedIndex = 1;
            }
        }
    }
}

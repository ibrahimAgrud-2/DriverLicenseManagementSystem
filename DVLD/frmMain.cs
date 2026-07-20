using DVLD.Applications;
using DVLD.Applications.Application_Types;
using DVLD.Drivers;
using DVLD.Users;
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

namespace DVLD
{
    public partial class frmMain : Form
    {

        private frmLogin _FrmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _FrmLogin = frm;
        }

        private void tsmDrivers_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();

        }



        private void tsmPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void tsmManageUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();

        }


        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Global.currentUser = null;
            _FrmLogin.Show();
            this.Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmUserDetails frm = new frmUserDetails(Global.currentUser.userID);
            frm.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(Global.currentUser.userID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageLocalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDLA frm = new frmManageLDLA();
            frm.ShowDialog();

        }
    }
}

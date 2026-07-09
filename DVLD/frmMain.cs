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
        public frmMain()
        {
            InitializeComponent();
        }

        private void tsmDrivers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented");

        }



        private void tsmPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void tsmManageUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented");

        }

        private void tsmApplicaitons_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented");
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }
    }
}

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ctrlFindUser1_OnFilteringComplete(int obj)
        {
            this.ctrlPersonInformation1.PersonID = obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
    }
}

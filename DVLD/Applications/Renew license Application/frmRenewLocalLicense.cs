using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using clsApplication = DVLD_BusinessLayer.Applications;
using System.Windows.Forms;

namespace DVLD.Licenses.Detained_Licenses
{
    public partial class frmRenewLocalLicense : Form
    {
        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblFees_Click(object sender, EventArgs e)
        {

        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblIUssueDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblApplicationFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).applicationFee.ToString();
            lblCreatedByUserID.Text = Global.currentUser.userID.ToString();

        }
    }
}

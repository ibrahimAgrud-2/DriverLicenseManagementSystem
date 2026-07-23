using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowDrivingLicenseInfo : Form
    {
        public frmShowDrivingLicenseInfo(int drivingLicenseID)
        {
            InitializeComponent();
            _DrivingLicenseID = drivingLicenseID;
        }

        private int _DrivingLicenseID = -1;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void frmShowDrivingLicenseInfo_Load(object sender, EventArgs e)
        {
            this.ctrlShowLicenseInfo1.LoadLicenseInfo(_DrivingLicenseID);
        }
    }
}

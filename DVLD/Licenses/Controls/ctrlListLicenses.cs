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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlListLicenses : UserControl
    {
        public ctrlListLicenses()
        {
            InitializeComponent();
        }

        private DataTable _DtLocalLicenseList = LocalDrivingLicenseApp.getLocalDrivingLicenseAppRecords();
        private DataTable _InternationalLicensesList = InternationalLicense.getInternationalLicenseRecords();

        public void LoadLicenses()
        {
            dgvLocalLicenseList.DataSource = _DtLocalLicenseList;
            dgvInternationalLicenseList.DataSource = _InternationalLicensesList;
        }

        private void tbMain_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tbMain.SelectedIndex==0)
            {
                lblRecord.Text = dgvLocalLicenseList.Rows.Count.ToString();
            }
            else
            {
                lblRecord.Text = dgvInternationalLicenseList.Rows.Count.ToString();

            }
        }
    }
}

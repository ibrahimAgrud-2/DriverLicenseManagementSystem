using DVLD_BusinessLayer;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using clsApplication = DVLD_BusinessLayer.Applications;
using clsLicense = DVLD_BusinessLayer.Licenses;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        public frmIssueDriverLicenseFirstTime(int LDLAID)
        {
            InitializeComponent();
            _LDLAID = LDLAID;
        }

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);
            if(_LDLA==null)
            {
                MessageBox.Show("LDLA could not found");
                return;
            }

            if (!_LDLA.PassedAlltests())
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.ctrlLocalDrivinglicenseApplicationInfo1.LoadAppInfo(_LDLAID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int issuedLicenseID = _LDLA.IssueLicenseForTheFirtTime(txtNotes.Text,Global.CurrentUser.UserID);

            if (issuedLicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + issuedLicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlLocalDrivinglicenseApplicationInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}

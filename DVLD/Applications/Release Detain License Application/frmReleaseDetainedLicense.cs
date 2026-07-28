using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using clsApplications = DVLD_BusinessLayer.Applications;
using System.Windows.Forms;
using DVLD.Licenses;

namespace DVLD.Applications.Release_Detain_License_Application
{
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        private int _DetainedLicenseID=-1;
        DetainedLicense _DetainedLicense;


        public void LoadData(int LicenseID)
        {
            this.ctrlLicenseInfoWithFilter1.LoadLicenseIndo(LicenseID);
            this.ctrlLicenseInfoWithFilter1.FilterEnabled = false;

        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseLoaded(int obj)
        {
            int selectedLicenseID = obj;

            lblLicenseID.Text = selectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = (selectedLicenseID!=-1);

            if (selectedLicenseID==-1)
            {
                MessageBox.Show("License Not found");
                    return;
            }
            if(!this.ctrlLicenseInfoWithFilter1.selectedLicense.isLicenseDetained)
            {
                MessageBox.Show("License is Not detained");
                return;
            }
            if(!this.ctrlLicenseInfoWithFilter1.selectedLicense.isActive)
            {

                MessageBox.Show("License is Not Active");
                return;
            }
            _DetainedLicense = DetainedLicense.FindByLicenseID(selectedLicenseID);
                _DetainedLicenseID = _DetainedLicense.detainID;
            lblLicenseID.Text = selectedLicenseID.ToString();
            lblCreatedByUser.Text = this.ctrlLicenseInfoWithFilter1.selectedLicense.UserInfo.UserName;
            lblFineFees.Text = _DetainedLicense.fineFees.ToString();
            lblDetainID.Text = _DetainedLicense.detainID.ToString();
            lblDetainedDate.Text = _DetainedLicense.detainDate.ToShortDateString();
            lblApplicationFee.Text = ApplicationTypes.Find((int)clsApplications.enApplicationType.ReleaseDetainedDrivingLicense).applicationFee.ToString();
            lblTotalFee.Text = (Convert.ToInt32(lblApplicationFee.Text) + Convert.ToInt32(lblFineFees.Text)).ToString();
     



            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
           
            if(!_DetainedLicense.Release(this.ctrlLicenseInfoWithFilter1.selectedLicense.ApplicationInfo.ApplicantPersonID, Global.CurrentUser.userID))
            {
                MessageBox.Show("Something went wrong");
                return;

            }

            MessageBox.Show("Released Successfully");
            lblApplicationID.Text = _DetainedLicense.releaseApplicationID.ToString();
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(ctrlLicenseInfoWithFilter1.selectedLicense.ApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(this.ctrlLicenseInfoWithFilter1.LicenseID);
            frm.ShowDialog();
        }

  

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using DVLD.Licenses;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using clsApplication = DVLD_BusinessLayer.Applications;
using clsLicense = DVLD_BusinessLayer.Licenses;


namespace DVLD.Applications.Replace_for_damage_or_lost
{
    public partial class frmReplacementForDamageLostLicense : Form
    {
        public frmReplacementForDamageLostLicense()
        {
            InitializeComponent();
        }
 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int _NewLicenseID = -1;

        private void frmReplacementForDamageLostLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = Global.CurrentUser.UserName;

            if (rbDamagedLicense.Checked)
            {
                lblApplicationFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).applicationFee.ToString();
            }
            else
            {
                lblApplicationFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).applicationFee.ToString();
            }
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseLoaded(int obj)
        {
            int selectedLicenseID = obj;

            lblOldLicenseID.Text = selectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (selectedLicenseID!=-1);
            if(selectedLicenseID==-1)
            {
                return;

            }

            if(!this.ctrlLicenseInfoWithFilter1.selectedLicense.isActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }

            btnRenewLicense.Enabled = true;


        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense newLicense;
            if (rbDamagedLicense.Checked)
            {
                newLicense= this.ctrlLicenseInfoWithFilter1.selectedLicense.Replace(clsApplication.enApplicationType.ReplaceDamagedDrivingLicense,Global.CurrentUser.userID);
            }
            else
            {
                newLicense= this.ctrlLicenseInfoWithFilter1.selectedLicense.Replace(clsApplication.enApplicationType.ReplaceDamagedDrivingLicense, Global.CurrentUser.userID);
            }
            if(newLicense==null)
            {
                 MessageBox.Show("failed to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _NewLicenseID = newLicense.licenseID;
            MessageBox.Show("Licensed Renewed Successfully with ApplicationID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblReplacedApplicationID.Text = newLicense.applicationID.ToString();
            lblReplacedLicenseID.Text = newLicense.licenseID.ToString();
            

            btnRenewLicense.Enabled = false;
            this.ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(this.ctrlLicenseInfoWithFilter1.selectedLicense.ApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicenseInfo frm =  new frmShowDrivingLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked)
            {
                lblApplicationFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.ReplaceLostDrivingLicense).applicationFee.ToString();
            }

        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked)
            {
                lblApplicationFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense).applicationFee.ToString();
            }
        }
    }
}

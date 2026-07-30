using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static DVLD_BusinessLayer.Applications;
using static System.Net.Mime.MediaTypeNames;
using clsApplication = DVLD_BusinessLayer.Applications;
using clsLicense = DVLD_BusinessLayer.Licenses;

namespace DVLD.Licenses.Detained_Licenses
{
    public partial class frmRenewLocalLicense : Form
    {
        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }

        clsLicense _License;
 

        ApplicationTypes _AppType = ApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense);

        void _ResetToDefaultFieldValues()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblIUssueDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblApplicationFees.Text = _AppType.applicationFee.ToString();
            lblCreatedByUser.Text = Global.CurrentUser.UserID.ToString();
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            this.ctrlLicenseInfoWithFilter1.ResetForm();
        }
     
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            _ResetToDefaultFieldValues();
        }
    
        private void FillDefaultValuesToField()
        {
          
            lblLicenseFee.Text = this.ctrlLicenseInfoWithFilter1.selectedLicense.LicenseClassInfo.classFee.ToString();
            lblTotalFees.Text = (Convert.ToInt32(lblLicenseFee.Text) + Convert.ToInt32(lblApplicationFees.Text)).ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(LicenseClass.Find(_License.licenseClassID).defaultValidityLength).ToString();
            lblOldLicenseID.Text = _License.licenseID.ToString();
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseLoaded(int obj)
        {
            _License = clsLicense.Find(obj);
            FillDefaultValuesToField();
            if (!_License.IsLicenseExpired())
            {
                MessageBox.Show($"License not expired yet. Expiration date is {_License.expirationDate}");
                return;
            }
            else if (!_License.isActive)
            {
                MessageBox.Show($"License not Active");
                return;
            }
            btnIssueLicense.Enabled = true;
            llShowLicenseHistory.Enabled=true;
        }
        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _License = ctrlLicenseInfoWithFilter1.selectedLicense.RenewLicense(textBox1.Text.Trim(), Global.CurrentUser.UserID);

            if (_License==null)
            {
                MessageBox.Show("Failed to renew license");
                return;
            }

            lblRenewApplicationID.Text = _License.applicationID.ToString();
            lblRenewedLicenseID.Text = _License.licenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ApplicationID=" + lblRenewedLicenseID.Text, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnIssueLicense.Enabled = false;
            this.ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }





        //-------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
;
            frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(_License.licenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int personID = _License.ApplicationInfo.ApplicantPersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personID);
            frm.ShowDialog();
        }
    }
}

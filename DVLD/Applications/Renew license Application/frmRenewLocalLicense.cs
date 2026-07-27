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

        clsLicense _OldLicense;
        clsLicense _NewLicense;

        ApplicationTypes _AppType = ApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicense);

        void _ResetForm()
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblIUssueDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblApplicationFees.Text = _AppType.applicationFee.ToString();
            lblCreatedByUser.Text = Global.currentUser.userID.ToString();
            llShowLicenseHistory.Enabled = false;
            llShowLicenseInfo.Enabled = false;
            this.ctrlLicenseInfoWithFilter1.ResetForm();
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            _ResetForm();
        }
        private void FillDefaultValuesToField()
        {
            lblApplicationFees.Text = _AppType.applicationFee.ToString();
            lblLicenseFee.Text = LicenseClass.Find(_OldLicense.licenseClassID).classFee.ToString();
            lblTotalFees.Text = (Convert.ToInt32(lblLicenseFee.Text) + Convert.ToInt32(lblApplicationFees.Text)).ToString();
            lblCreatedByUser.Text = Global.currentUser.userName;
            lblExpirationDate.Text = DateTime.Now.AddYears(LicenseClass.Find(_OldLicense.licenseClassID).defaultValidityLength).ToString();
            lblOldLicenseID.Text = _OldLicense.licenseID.ToString();
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseLoaded(int obj)
        {
            _OldLicense = clsLicense.Find(obj);
            FillDefaultValuesToField();
            if (!_OldLicense.IsLicenseExpired())
            {
                MessageBox.Show($"License not expired yet. Expiration date is {_OldLicense.expirationDate}");
                return;
            }
            else if (!_OldLicense.isActive)
            {
                MessageBox.Show($"License not Active");
                return;
            }
            btnIssueLicense.Enabled = true;
            llShowLicenseHistory.Enabled=true;
         


        }


        private bool _AddNewApplication(ref int applicationID)
        {
            clsApplication newApp = _OldLicense.ApplicationInfo;
            newApp.ApplicationDate = DateTime.Now;
            newApp.ApplicationTypeID = _AppType.applicationTypeID;
            newApp.CreatedByUserID = Global.currentUser.userID;
            newApp.PaidFees = _AppType.applicationFee;
            newApp.Mode = clsApplication.enMode.enAddNew;

          
             newApp.save();
            applicationID = newApp.ID;
            return (applicationID != -1);
        }
   
        private void btnIssueLicense_Click(object sender, EventArgs e)
        {

            int applicationID = -1;
            if (!_AddNewApplication(ref applicationID))
            {
                MessageBox.Show("Failed to add new application");
                return ;
            }

            _NewLicense = new clsLicense(_OldLicense);
            _NewLicense.expirationDate = DateTime.Now.AddYears(LicenseClass.Find(_NewLicense.licenseClassID).defaultValidityLength);
            _NewLicense.issueReason = clsLicense.enIssueReason.Renew;
            _NewLicense.issueDate = DateTime.Now;
            _NewLicense.mode = clsLicense.enMode.enAddNew;
            _NewLicense.applicationID = applicationID;
            _NewLicense.isActive = true;

            _OldLicense.isActive = false;
            if(!_OldLicense.save())
            {
                MessageBox.Show("Old license could not updated");
                return;
            }
            
            if(_NewLicense.save())
            {
                MessageBox.Show("Saved Successfully");
                lblRenewApplicationID.Text = _NewLicense.licenseID.ToString();
                lblRenewApplicationID.Text = applicationID.ToString();
                llShowLicenseInfo.Enabled = true;
               

            }
            else
            {
                MessageBox.Show("Could not Saved");
            }
           
        }





        //-------------------------------------------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
;
            frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(_NewLicense.licenseID);
            frm.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int personID = _OldLicense.ApplicationInfo.ApplicantPersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personID);
            frm.ShowDialog();
        }
    }
}

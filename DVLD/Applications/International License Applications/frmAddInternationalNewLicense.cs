using DVLD.Licenses;
using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;
using clsLicenses = DVLD_BusinessLayer.Licenses;
using clsApplication = DVLD_BusinessLayer.Applications;


namespace DVLD.Applications.International_License_Applications
{
    public partial class frmAddNewInternationalLicense : Form
    {
        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
        }

    


        private InternationalLicense _InternationalLicense;

        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblUssueDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).applicationFee.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedByUserID.Text = Global.CurrentUser.userID.ToString();
        }



        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (this.ctrlLicenseInfoWithFilter1.LicenseID > 0)
            {

                int licenseID = this.ctrlLicenseInfoWithFilter1.LicenseID;
                int personID = clsLicenses.Find(licenseID).ApplicationInfo.ApplicantPersonID;
                frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a License First");
            }
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ctrlLicenseInfoWithFilter1.LicenseID > 0)
            {

                int licenseID = this.ctrlLicenseInfoWithFilter1.LicenseID;
                frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(licenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a License First");
            }

        }

        private void FillDataToObject()
        {
            if (this.ctrlLicenseInfoWithFilter1.LicenseID != -1)
            {
                _InternationalLicense = new InternationalLicense();
              _InternationalLicense.ApplicationID = this.ctrlLicenseInfoWithFilter1.selectedLicense.applicationID;
              _InternationalLicense.CreatedByUserID = Global.CurrentUser.userID;
              _InternationalLicense.DriverID = this.ctrlLicenseInfoWithFilter1.selectedLicense.driverID;
              _InternationalLicense.IsActive = true;
              _InternationalLicense.IssuedUsingLocalLicenseID = this.ctrlLicenseInfoWithFilter1.selectedLicense.licenseID;
              _InternationalLicense.IssueDate = DateTime.Now;
               _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1); 
            }
        }

        private void btnIssueLicense_Click(object sender, System.EventArgs e)
        {
            FillDataToObject();
            if (_InternationalLicense.Save())
            {
                MessageBox.Show("Saved");
                lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                llShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Could not saved");

            }
            if (this.ctrlLicenseInfoWithFilter1.selectedLicense != null)
            {
                lblLocalLicenseID.Text = this.ctrlLicenseInfoWithFilter1.selectedLicense.licenseID.ToString();
            }
            btnIssueLicense.Enabled = false;
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseLoaded(int obj)
        {

            int selectedLicenseID = obj;
            lblLocalLicenseID.Text = selectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (selectedLicenseID != -1);

            if (selectedLicenseID == -1)
            {
                MessageBox.Show("Select a License First");
                return;
            }
            if (this.ctrlLicenseInfoWithFilter1.selectedLicense.licenseClassID != 3)
            {
                MessageBox.Show("License for issue must  class-3");
                return;
            }

        
            if (InternationalLicense.GetActiveInternationalLicenseIDByDriverID(this.ctrlLicenseInfoWithFilter1.selectedLicense.driverID)!=-1)
            {
                MessageBox.Show("Driver Already have a Int.License ");
                return;
            }
           
            btnIssueLicense.Enabled = true;
        }

    }
}

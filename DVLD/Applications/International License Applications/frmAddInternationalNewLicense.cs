using DVLD.Licenses;
using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;
using clsLicenses = DVLD_BusinessLayer.Licenses;


namespace DVLD.Applications.International_License_Applications
{
    public partial class frmAddInternationalNewLicense : Form
    {
        public frmAddInternationalNewLicense()
        {
            InitializeComponent();
        }

        private int _licenseID = -1;
        private clsLicenses _License;


        private InternationalLicense _InternationalLicense;
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
            if (_licenseID != -1)
            {
                InternationalLicense Int = new InternationalLicense();
                Int.ApplicationID = _License.applicationID;
                Int.CreatedByUserID = Global.currentUser.userID;
                Int.DriverID = _License.driverID;
                Int.IsActive = true;
                Int.IssuedUsingLocalLicenseID = _licenseID;
                Int.IssueDate = DateTime.Now;
                Int.ExpirationDate = DateTime.Now.AddYears(1);
            }
        }

        private void btnIssueLicense_Click(object sender, System.EventArgs e)
        {
           if(_License==null)
            {
                MessageBox.Show("Select a License First");
                return;
            }
            if (InternationalLicense.isDriverHasInternationalLicense(_License.driverID))
            {
                MessageBox.Show("Driver Already have a Int.License ");
                return;
            }
            FillDataToObject();
            if(_InternationalLicense.save())
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Couold not saved");

            }
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseLoaded(int obj)
        {
            _licenseID = obj;
            _License = clsLicenses.Find(obj);
        }

        private void ctrlLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            
        }
    }
}

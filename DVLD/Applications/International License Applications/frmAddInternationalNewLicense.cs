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
                _InternationalLicense = new InternationalLicense();
              _InternationalLicense.ApplicationID = _License.applicationID;
              _InternationalLicense.CreatedByUserID = Global.CurrentUser.userID;
              _InternationalLicense.DriverID = _License.driverID;
              _InternationalLicense.IsActive = true;
              _InternationalLicense.IssuedUsingLocalLicenseID = _licenseID;
              _InternationalLicense.IssueDate = DateTime.Now;
               _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1); 
            }
        }

        private void btnIssueLicense_Click(object sender, System.EventArgs e)
        {
           if(_License==null)
            {
                MessageBox.Show("Select a License First");
                return;
            }
           if(_License.licenseClassID!=3)
            {
                MessageBox.Show("License for issue must mu class-3");
                return;
            }
            if (InternationalLicense.isInternationalLicenseExistByLicenseID(_License.licenseID))
            {
                MessageBox.Show("Driver Already have a Int.License ");
                return;
            }
            FillDataToObject();
            if(_InternationalLicense.save())
            {
                MessageBox.Show("Saved");
                lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                llShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Couold not saved");

            }
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseLoaded(int obj)
        {
            _License = clsLicenses.Find(obj);
            if(_License!=null)
            {
                _licenseID = _License.licenseID;
                lblLocalLicenseID.Text = _licenseID.ToString();
            }
          
        }

        private void ctrlLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {
            
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblUssueDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).applicationFee.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedByUserID.Text = Global.CurrentUser.userID.ToString();
        }
    }
}

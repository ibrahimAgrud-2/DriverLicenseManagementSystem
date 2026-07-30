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
        private int _InternationalLicenseID = -1;

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
            if(!this.ctrlLicenseInfoWithFilter1.selectedLicense.isActive)
            {
                MessageBox.Show("Selected License should be Active, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.ctrlLicenseInfoWithFilter1.selectedLicense.licenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ActiveInternaionalLicenseID = InternationalLicense.GetActiveInternationalLicenseIDByDriverID(this.ctrlLicenseInfoWithFilter1.selectedLicense.driverID);
            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with LicenseClassID = " + ActiveInternaionalLicenseID, "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llShowLicenseInfo.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssueLicense.Enabled = false;
                return;
            }

            btnIssueLicense.Enabled = true;
        }

        private void frmAddNewInternationalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblUssueDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).applicationFee.ToString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString();
            lblCreatedByUserID.Text = Global.CurrentUser.UserID.ToString();
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
                //Int.License üst sınıfı miras aldığı için önce üst sınıfın verilerini doldurmalısın. Yoksa save yaparken Application save edilemez. 
                _InternationalLicense.ApplicationDate = DateTime.Now;
                _InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.New;
                _InternationalLicense.CreatedByUserID = Global.CurrentUser.UserID;
                _InternationalLicense.PaidFees = ApplicationTypes.Find((int)clsApplication.enApplicationType.NewInternationalLicense).applicationFee;
                _InternationalLicense.LastStatusDate = DateTime.Now;
                _InternationalLicense.ApplicantPersonID = this.ctrlLicenseInfoWithFilter1.selectedLicense.ApplicationInfo.ApplicantPersonID;




              _InternationalLicense.DriverID = this.ctrlLicenseInfoWithFilter1.selectedLicense.driverID;
              _InternationalLicense.IsActive = true;
              _InternationalLicense.IssuedUsingLocalLicenseID = this.ctrlLicenseInfoWithFilter1.selectedLicense.licenseID;
              _InternationalLicense.IssueDate = DateTime.Now;
               _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1); 
            }
        }

        private void btnIssueLicense_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            FillDataToObject();
            if (!_InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;

            }

            MessageBox.Show("International License Issued Successfully with LicenseClassID=" + _InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            _InternationalLicenseID = _InternationalLicense.InternationalLicenseID;
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            llShowLicenseInfo.Enabled = true;

            btnIssueLicense.Enabled = false;
        }

    }
}

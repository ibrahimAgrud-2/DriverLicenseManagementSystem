using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsLicenses = DVLD_BusinessLayer.Licenses;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlShowLicenseInfo : UserControl
    {
        public ctrlShowLicenseInfo()
        {
            InitializeComponent();
        }

        private clsLicenses _License;
        private int _LicenseID = -1;

        public int LicenseID { get { return _LicenseID; } }
        public clsLicenses SelectedLicense { get { return _License; } }

        public void ResetForm()
        {

            _LicenseID = -1;
            lblClass.Text = "????";
            lblDateOfBirth.Text = "????";
            lblDriverID.Text = "????";
            lblExpirationDate.Text = "????";
            lblFullName.Text = "????";
            lblGendor.Text = "????";
            lblIsActive.Text = "????";
            lblLicenseID.Text = "????";
            lblNationalNo.Text = "????";
            lblNotes.Image = Resources.Male_512;
            lblIsDetained.Text= "????";
            lblIssueDate.Text= "????";
            lblIssueReason.Text= "????";

        }
        private void fillObjectDataToField(clsLicenses licenses)
        {
            lblFullName.Text = licenses.ApplicationInfo.ApplicantPerson.fullName;
            lblClass.Text = licenses.LicenseClassInfo.className;
            lblDateOfBirth.Text = licenses.ApplicationInfo.ApplicantPerson.dateOfBirth.ToString("yyyy/MM/dd");
            lblDriverID.Text = licenses.driverID.ToString();
            lblExpirationDate.Text = licenses.expirationDate.ToString("yyyy/MM/dd");
            lblGendor.Text = licenses.ApplicationInfo.ApplicantPerson.gender == 0 ? "Male" : "Female";
            lblIsActive.Text = licenses.isActive.ToString();
            lblLicenseID.Text = licenses.licenseID.ToString();
            lblNationalNo.Text = licenses.ApplicationInfo.ApplicantPerson.nationalNo;
            
            //lblIsDetained.Text = DetainedLicense.findDetainedLicense();
            lblIssueDate.Text = licenses.issueDate.ToString("yyyy/MM/dd");
            lblIssueReason.Text = licenses.issueReason.ToString();

            if (licenses.ApplicationInfo.ApplicantPerson.imagePath != "")
            {
                if (File.Exists(licenses.ApplicationInfo.ApplicantPerson.imagePath))
                {
                    pbPersonImage.ImageLocation = licenses.ApplicationInfo.ApplicantPerson.imagePath;
                }
                else
                {
                    MessageBox.Show("Could not Find this image: = " + licenses.ApplicationInfo.ApplicantPerson.imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (licenses.ApplicationInfo.ApplicantPerson.gender == 1)
            {
                pbPersonImage.Image = Resources.Female_512;
            }
            else
            {
                pbPersonImage.Image = Resources.Male_512;
            }
        }
        private void _Load()
        {
            _LicenseID = _License.licenseID;
            fillObjectDataToField(_License);


        }
        public void LoadLicenseInfo(int licenseID)
        {
            _License = clsLicenses.Find(licenseID);
            if(_License==null)
            {
                MessageBox.Show($"There is no license with LocalDrivingLicenseApplicationID {licenseID}");
                ResetForm();
                return;
            }
            _Load();

        }
    }
}

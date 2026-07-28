using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.International_License_Applications.Controls
{
    public partial class ctrlDriverInternationalLinceseInfo : UserControl
    {
        public ctrlDriverInternationalLinceseInfo()
        {
            InitializeComponent();
        }

        private int _IntLicenseID = -1;
        private InternationalLicense _InternationalLicense1 = null;


        public int InternationalLicenseID { get { return _IntLicenseID; } }

        public InternationalLicense selectedInternationalLicense { get { return _InternationalLicense1; } }



        public void ResetForm()
        {

            _IntLicenseID = -1;
            lblApplicationID.Text = "????";
            lblDateOfBirth.Text = "????";
            lblNationalNo.Text = "????";
            lblDriverID.Text = "????";
            lblFullName.Text = "????";
            lblGendor.Text = "????";
            lblIsActive.Text = "N/A";
            lblLocalLicenseID.Text = "????";
            lblIssueDate.Text = "????";
            pbPersonImage.Image = Resources.Male_512;
            lblExpirationDate.Text = "????";
            lblInternationalLicenseID.Text = "????";
            lblDriverID.Text = "????";


        }
        private void fillObjectDataToField(InternationalLicense IntLicense)
        {



            lblApplicationID.Text = IntLicense.ApplicationID.ToString();
            lblDateOfBirth.Text =IntLicense.ApplicationInfo.ApplicantPerson.dateOfBirth.ToString();
            lblNationalNo.Text = IntLicense.ApplicationInfo.ApplicantPerson.nationalNo;
            lblDriverID.Text = "????";
            lblFullName.Text = IntLicense.ApplicationInfo.ApplicantPerson.fullName;
            lblIsActive.Text = (IntLicense.IsActive ? "Yes" : "No");
            lblLocalLicenseID.Text = IntLicense.IssuedUsingLocalLicenseID.ToString();
            lblIssueDate.Text = IntLicense.IssueDate.ToShortDateString();
            lblExpirationDate.Text = IntLicense.ExpirationDate.ToShortDateString();
            lblInternationalLicenseID.Text = IntLicense.InternationalLicenseID.ToString();
            lblDriverID.Text = IntLicense.DriverID.ToString();


            lblGendor.Text = IntLicense.ApplicationInfo.ApplicantPerson.gender == 0 ? "Male" : "Female";

            if (IntLicense.ApplicationInfo.ApplicantPerson.imagePath != "")
            {
                if (File.Exists(IntLicense.ApplicationInfo.ApplicantPerson.imagePath))
                {
                    pbPersonImage.ImageLocation = IntLicense.ApplicationInfo.ApplicantPerson.imagePath;
                }
                else
                {
                    MessageBox.Show("Could not Find this image: = " + IntLicense.ApplicationInfo.ApplicantPerson.imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (IntLicense.ApplicationInfo.ApplicantPerson.gender == 1)
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
            _IntLicenseID = _InternationalLicense1.InternationalLicenseID;
            fillObjectDataToField(_InternationalLicense1);
        }

        public void LoadPersonInfo(int InternationalLicenseID)
        {
            _InternationalLicense1 = InternationalLicense.Find(InternationalLicenseID);
            if (_InternationalLicense1 == null)
            {
                _IntLicenseID = -1;
                ResetForm();
                MessageBox.Show("No License  with  ID = " + InternationalLicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Load();
        }
    }
}

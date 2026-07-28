using DVLD_BusinessLayer;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using clsApplication = DVLD_BusinessLayer.Applications;
using clsLicense = DVLD_BusinessLayer.Licenses;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        public frmIssueDriverLicenseFirstTime(int LDLAID)
        {
            InitializeComponent();
            _LDLAID = LDLAID;
        }

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);
            if(_LDLA==null)
            {
                MessageBox.Show("LDLA could not found");
                return;
            }
            this.ctrlLocalDrivinglicenseApplicationInfo1.LoadAppInfo(_LDLAID);

        }
        private int _AddDriver()
        {
    
            Driver newDrv = new Driver();
            newDrv.personID = _LDLA.ApplicationInfo.ApplicantPersonID;
            newDrv.createdDate = DateTime.Today;
            newDrv.createdByUserID = Global.CurrentUser.userID;
            
            if(!newDrv.save())
            {
                MessageBox.Show("Could not saved driver for this license");
            }
            return newDrv.driverID;
    
        }
        private clsLicense _LoadInfo()
        {
  
            clsLicense newLicense = new clsLicense();
            Driver drv = Driver.FindByPersonID(_LDLA.ApplicationInfo.ApplicantPersonID);
            if (drv != null)
            {
                newLicense.driverID = drv.driverID;
            }
            else
            {
                newLicense.driverID = _AddDriver();
            }
                
            newLicense.notes = txtNotes.Text;
            newLicense.applicationID = _LDLA.applicationID;
            newLicense.paidFees = LicenseClass.Find(_LDLA.licenseClassID).classFee;
            newLicense.isActive = true;
            newLicense.expirationDate = DateTime.Now.AddYears(LicenseClass.Find(_LDLA.licenseClassID).defaultValidityLength);
            newLicense.issueDate = DateTime.Now;
            newLicense.createdByUserID = Global.CurrentUser.userID;
            newLicense.licenseClassID = _LDLA.licenseClassID;

            
            return newLicense;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLicense newL = _LoadInfo();

            if (newL.save())
            {
                _LDLA.ApplicationInfo.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                _LDLA.ApplicationInfo.LastStatusDate = DateTime.Now;
                _LDLA.ApplicationInfo.Save();

                MessageBox.Show($"Saved successfully with license {newL.licenseID}");

            }
            else
            {
                MessageBox.Show("Something went wrong");
                return;
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

using DVLD.Licenses;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using clsLicenses = DVLD_BusinessLayer.Licenses;
using System.Windows.Forms;

namespace DVLD.Applications.New_Local_Driving_License_Application.Controls
{
    public partial class ctrlLocalDrivinglicenseApplicationInfo : UserControl
    {
        public ctrlLocalDrivinglicenseApplicationInfo()
        {
            InitializeComponent();
        }


        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA = null;
        public int LocalLicenseAppID { get { return _LDLAID; } }

        public LocalDrivingLicenseApp SelectedLocalLicenseApp { get { return _LDLA; } }


        private void fillObjectDataToField(LocalDrivingLicenseApp LDLA)
        {
            this.ctrlApplicationInfo1.LoadAppInfo(LDLA.ApplicationID);

            lblLDLAID.Text = LDLA.LocalDrivingLicenseApplicationID.ToString() ;
            lblAppliedForLicense.Text = LDLA.LicenseClassInfo.className;
            lblPassedTestCount.Text = LDLA.GetPassedTestCount().ToString();
        }



        private void _Load()
        {
            _LDLAID = _LDLA.LocalDrivingLicenseApplicationID;
            fillObjectDataToField(_LDLA);
            if(_LDLA.ApplicationStatus==DVLD_BusinessLayer.Applications.enApplicationStatus.Completed)
            {
                lblEditLicenseInfo.Enabled = true;
            }
          

        }

        private void ResetForm()
        {
            //Yükleme başarılı olup olmadığını LocalDrivingLicenseApplicationID ile biliyoruz. Bu yüzden yükleme başarısız olduğunda 
            //formu temizlerken LocalDrivingLicenseApplicationID'i de -1 yapıyoruz.


            lblLDLAID.Text = "???";
            lblAppliedForLicense.Text = "???";
    

        }
        public void LoadAppInfo(int LocalLicenseAppID)
        {
            _LDLA = LocalDrivingLicenseApp.Find(LocalLicenseAppID);
            if (_LDLA == null)
            {
                _LDLAID = -1;
                ResetForm();
                MessageBox.Show("No Person with PersonID = " + LocalLicenseAppID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Load();
        }

        private void lnklblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            clsLicenses L1 = clsLicenses.FindByApplicationID(_LDLA.ApplicationID);
            if(L1!=null)
            {
                frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(L1.licenseID);
                frm.ShowDialog();    
            }
            else
            {
                MessageBox.Show("License Could not found");
            }
        }
    }
}

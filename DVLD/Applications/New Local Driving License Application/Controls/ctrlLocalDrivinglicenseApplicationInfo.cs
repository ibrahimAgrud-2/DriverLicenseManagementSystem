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






        private void _Load()
        {
            _LDLAID = _LDLA.LocalDrivingLicenseApplicationID;
            this.ctrlApplicationInfo1.LoadAppInfo(_LDLA.ApplicationID);

            
            lblLDLAID.Text = _LDLA.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = _LDLA.LicenseClassInfo.className;
            lblPassedTestCount.Text = _LDLA.GetPassedTestCount() + "/3";
            if (_LDLA.GetActiveLicenseID()!=-1)
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
                MessageBox.Show("No Application with ApplicationID = " + LocalLicenseAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Load();
        }

        private void lnklblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            int licenseID = _LDLA.GetActiveLicenseID();

            if(licenseID!=-1)
            {
                frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(licenseID);
                frm.ShowDialog();    
            }
            else
            {
                MessageBox.Show("License Could not found");
            }
        }
    }
}

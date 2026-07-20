using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD.Applications.New_Local_Driving_License_Application.Controls
{
    public partial class ctrlLDLAInfo : UserControl
    {
        public ctrlLDLAInfo()
        {
            InitializeComponent();
        }


        public event Action<int> OnApplicationLoaded;
        // Create a protected method to raise the event with a parameter
        protected virtual void ApplicationLoaded(int PersonID)
        {
            Action<int> handler = OnApplicationLoaded;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        LocalDrivingLicenseApp _LDLA;

        public void LoadData(int LDLAID)
        {
            _LDLA = LocalDrivingLicenseApp.Find(LDLAID);
            if (_LDLA == null)
            {
                MessageBox.Show("LDLA could not found");
                return;
            }
                
            lblLocalDrivingLicenseApplicationID.Text = _LDLA.ID.ToString();
            lblAppliedFor.Text = _LDLA.ApplicationInfo.ApplicationTypeInfo.applicantTypeTitle;
            lblPassedTests.Text ="2";
            this.ctrlApplicationBasicInfo1.LoadAppInfo(_LDLA.applicationID);


        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmLicense
        }
    }
}

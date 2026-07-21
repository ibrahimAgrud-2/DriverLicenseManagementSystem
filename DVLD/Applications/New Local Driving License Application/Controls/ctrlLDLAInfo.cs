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
        protected virtual void ApplicationLoaded(int LDLAID)
        {
            Action<int> handler = OnApplicationLoaded;
            if (handler != null)
            {
                handler(LDLAID); // Raise the event with the parameter
            }
        }

        LocalDrivingLicenseApp _LDLA;
        private int _LDLAID=-1;

        public int AppID
        {
            get { return this.ctrlApplicationBasicInfo1.AppID; }
        }

        public int LDLAID
        {
            get { return this._LDLAID; }
        }


        public void LoadData(int LDLAID)
        {
            _LDLA = LocalDrivingLicenseApp.Find(LDLAID);
            if (_LDLA == null)
            {
                MessageBox.Show("LDLA could not found");
                return;
            }
            _LDLAID = LDLAID;
            lblLocalDrivingLicenseApplicationID.Text = _LDLA.ID.ToString();
            lblAppliedFor.Text = _LDLA.LicenseClassInfo.className;
            lblPassedTests.Text ="2";
            this.ctrlApplicationBasicInfo1.LoadAppInfo(_LDLA.applicationID);

            if(OnApplicationLoaded!=null)
            {
                ApplicationLoaded(LDLAID);
            }

        }

        private void llShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmLicense
        }
    }
}

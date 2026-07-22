using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.ctrlApplicationInfo1.LoadAppInfo(LDLA.applicationID);

            lblLDLAID.Text = LDLA.ID.ToString() ;
            lblAppliedForLicense.Text = LDLA.LicenseClassInfo.className;
            lblPassedTestCount.Text = LDLA.GetPassedTestCount().ToString();
        }



        private void _Load()
        {
            _LDLAID = _LDLA.ID;
            fillObjectDataToField(_LDLA);
            lnklblEditPersonInfo.Enabled = true;

        }

        public void ResetForm()
        {
            //Yükleme başarılı olup olmadığını ID ile biliyoruz. Bu yüzden yükleme başarısız olduğunda 
            //formu temizlerken ID'i de -1 yapıyoruz.


            lblLDLAID.Text = "???";
            lblAppliedForLicense.Text = "???";
            //lblPassedTestCount.Text

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

    }
}

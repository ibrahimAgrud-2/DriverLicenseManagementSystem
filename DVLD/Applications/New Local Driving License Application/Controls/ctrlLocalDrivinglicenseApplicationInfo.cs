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


        private void fillObjectDataToField(LocalDrivingLicenseApp App)
        {
            this.ctrlApplicationInfo1.LoadAppInfo(App.applicationID);

            lblLDLAID.Text = App.ID.ToString() ;
            lblAppliedForLicense.Text = App.LicenseClassInfo.className;
            //lblPassedTestCount.Text
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

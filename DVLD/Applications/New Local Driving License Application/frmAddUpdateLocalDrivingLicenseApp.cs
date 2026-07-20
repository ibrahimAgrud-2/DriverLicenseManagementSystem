using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ApplicationsDb = DVLD_BusinessLayer.Applications;
using System.Windows.Forms;

namespace DVLD.Applications.New_Local_Driving_License_Application
{
    public partial class frmAddUpdateLocalDrivingLicenseApp : Form
    {

        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode = enMode.enAddNew;


        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;

        private int _ApplicationID = -1;
        private ApplicationsDb App;


        public frmAddUpdateLocalDrivingLicenseApp()
        {
            InitializeComponent();
            this._Mode = enMode.enAddNew;
        }
        public frmAddUpdateLocalDrivingLicenseApp(int LocalApplicationID)
        {
            InitializeComponent();
            _LDLAID = LocalApplicationID;
            this._Mode = enMode.enUpdate;
        }     
        
        private void _FillLicenseClassToComboBox()
        {
            DataTable dt = LicenseClass.getAllRecords();
            foreach(DataRow row in dt.Rows)
            {
                cbLicenseClasses.Items.Add(row["ClassName"]);
            }
        }

        private void fillObjectDataToField()
        {
            if (_LDLA == null&&_LDLA.ApplicationInfo==null)
                return;

            lblID.Text = _LDLA.ID.ToString();
            lblAppDate.Text = _LDLA.ApplicationInfo.ApplicationDate.ToString("yyyy/mm/dd");
            lblAppFees.Text = _LDLA.ApplicationInfo.PaidFees.ToString();
            lblCreatedByUserID.Text = _LDLA.ApplicationInfo.CreatedByUserID.ToString();
            cbLicenseClasses.SelectedIndex = _LDLA.licenseClassID;

            this.ctrlPersonCardWithFilter1.LoadData(_LDLA.ApplicationInfo.ApplicantPersonID);
        }
 
        private void frmAddUpdateLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            _FillLicenseClassToComboBox();
            //when mode is update;
            if (this._Mode == enMode.enUpdate)
            {
                _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);
                
                if (_LDLA == null)
                {
                    MessageBox.Show("No LDLA with ID = " + _LDLAID, "LDLA Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                App = ApplicationsDb.FindApplication(_LDLA.applicationID);
                if (App == null)
                {
                    MessageBox.Show("No Application with ID = " + _ApplicationID, "_App Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                lblMode.Text = "Update User";
                this.Text = "Update User";
                tpAppllicationInfo.Enabled = true;
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                fillObjectDataToField();

            }
            else
            {
                lblMode.Text = "Add New User";
                tpAppllicationInfo.Enabled = false;
                lblAppFees.Text = ApplicationTypes.Find(1).applicationFee.ToString();
                lblCreatedByUserID.Text = "1";
                lblAppDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                cbLicenseClasses.SelectedIndex = 3;
                _LDLA = new LocalDrivingLicenseApp();
                 App = new ApplicationsDb();

            }

        }
        private bool _FillDataToObject()
        {

            if (this.ValidateChildren())
            {
                _LDLA.licenseClassID = LicenseClass.Find(cbLicenseClasses.Text).ID;
                _LDLA.applicationID = App.ID;
                return true;
            }
            else
            {
                return false;
            }

        }

        /*
     Önce kayıt ekleme işlemi burada olmalı. Çünkü DL, henüz 2 tanbloya nasıl veri ekleriz bilmiyorzu. BL'de ise LocalApp sınıfından personID'e direk erişim yok. Bu yüzden buradan eklenmeli.
   */
        private bool _AddNewApplication()
        {
            App.ApplicantPersonID = ctrlPersonCardWithFilter1.personID;
            App.ApplicationDate = DateTime.Now;
            App.ApplicationTypeID = 1;
            App.ApplicationStatus = ApplicationsDb.enApplicationStatus.New;
            App.LastStatusDate = DateTime.Now;
            App.PaidFees = ApplicationTypes.Find(App.ApplicationTypeID).applicationFee;
            // _App.CreatedByUserID = loginSettings.currentUser.userID;
            App.CreatedByUserID = 1;


            return App.save(); ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!_AddNewApplication())
            {
                MessageBox.Show("Could not save new _App");
                return;
            }
            if (!_FillDataToObject())
            {
                MessageBox.Show("Fill requireds properly");
                return;
            }

            if (_LDLA.Save())
            {
                MessageBox.Show("Saved successfully");
                this._Mode = enMode.enUpdate;
                lblMode.Text = "Update User";
                this.Text = "Update User";
                lblID.Text = _LDLA.ID.ToString();

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (this.ctrlPersonCardWithFilter1.personID <= 0)
            {
                MessageBox.Show("Select a person first");
                e.Cancel = true;
                return;
            }
            if (ApplicationsDb.isApplicationExistByPersonID(ctrlPersonCardWithFilter1.personID,1)&& this._Mode == enMode.enAddNew)
            {
                MessageBox.Show("The person has the same kind of active application");

                e.Cancel = true;
                return;
            }


            btnSave.Enabled = true;
            tpAppllicationInfo.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbMain.SelectedIndex = 1;
        }
    }
}

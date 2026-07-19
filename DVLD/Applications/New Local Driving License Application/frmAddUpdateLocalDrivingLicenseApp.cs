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


        private int _LocalDrivingLicenseAppID = -1;
        private LocalDrivingLicenseApp _LDLA;

        public frmAddUpdateLocalDrivingLicenseApp()
        {
            InitializeComponent();
            this._Mode = enMode.enAddNew;
        }
        public frmAddUpdateLocalDrivingLicenseApp(int LocalApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID = LocalApplicationID;
            this._Mode = enMode.enUpdate;
        }
        private void _FillLicenseClassToComboBox()
        {
            DataTable dt = LicenseClass.getAllClassLicenseRecords();
            foreach (DataRow row in dt.Rows)
            {
                cbLicenseClasses.Items.Add(row["className"]);
            }
        }
        private void _LoadData()
        {

            if (this._Mode == enMode.enUpdate)
            {
                _LDLA = LocalDrivingLicenseApp.Find(_LocalDrivingLicenseAppID);

                if (_LDLA == null)
                {
                    MessageBox.Show("No User with ID = " + _LDLA.id, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                lblID.Text = _LDLA.id.ToString();
                lblMode.Text = "Update Local Driving License Application";
                this.Text = "Update";
                tpAppllicationInfo.Enabled = true;
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                lblAppDate.Text = _LDLA.ApplicationInfo.applicationDate.ToShortDateString();


                cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(_LDLA.ApplicationInfo.ApplicationTypeInfo.applicantTypeTitle);
                lblID.Text = _LDLA.id.ToString();
                this.ctrlPersonCardWithFilter1.LoadData(_LDLA.ApplicationInfo.applicantPersonID);

            }
            else
            {
                lblMode.Text = "Add Local Driving License Application";
                tpAppllicationInfo.Enabled = false;
                _LDLA = new LocalDrivingLicenseApp();
                lblAppDate.Text = DateTime.Now.ToString();

            }


            lblAppFees.Text = ApplicationTypes.Find((ApplicationTypes.enApplicationType.NewLocalDrivingLicenseService)).applicationFee.ToString();
            // lblCreatedByUserID.Text = loginSettings.currentUser.userID.ToString();
            lblCreatedByUserID.Text = Convert.ToString(1);

        }
        private void frmAddUpdateLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            _FillLicenseClassToComboBox();
            _LoadData();

        }
   

        /*
         Önce kayıt ekleme işlemi burada olmalı. Çünkü DL, henüz 2 tanbloya nasıl veri ekleriz bilmiyorzu. BL'de ise LocalApp sınıfından personID'e direk erişim yok. Bu yüzden buradan eklenmeli.
       */
        private int saveNewApplication()
        {
            _LDLA.ApplicationInfo = new ApplicationsDb();
            _LDLA.ApplicationInfo.applicantPersonID = 1;
            _LDLA.ApplicationInfo.applicationDate = DateTime.Now;
            _LDLA.ApplicationInfo.applicationTypeID = ApplicationTypes.enApplicationType.NewLocalDrivingLicenseService;
            _LDLA.ApplicationInfo.applicationStatus = ApplicationsDb.enApplicationStatus.New;
            _LDLA.ApplicationInfo.lastStatusDate = DateTime.Now;
            _LDLA.ApplicationInfo.paidFee = ApplicationTypes.Find(_LDLA.ApplicationInfo.applicationTypeID).applicationFee;
            //   NewApplication.createdByUserID = loginSettings.currentUser.userID;
            _LDLA.ApplicationInfo.createdByUserID = 1;
            _LDLA.ApplicationInfo.save();
            return _LDLA.ApplicationInfo.applicationID;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.ValidateChildren())
            {

            }
            if (_LDLA.Save())
            {
                MessageBox.Show("Saved successfully");
                this._Mode = enMode.enUpdate;
                lblMode.Text = "Update Local Driving License Application";
                this.Text = "Update";
                lblID.Text = _LDLA.id.ToString();

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
            saveNewApplication();

            if (ApplicationsDb.isApplicationExistByPersonID(_LDLA.ApplicationInfo.applicantPersonID,(ApplicationTypes.enApplicationType)1)&& this._Mode == enMode.enAddNew)
            {
                MessageBox.Show("The person has same application");

                e.Cancel = true;
                return;
            }


            btnSave.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbMain.SelectedIndex = 1;
            if (tbMain.SelectedIndex == 1)
            {
                tpAppllicationInfo.Enabled = true;
            }
        }
    }
}

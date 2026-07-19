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
            ApplicationsDb NewApplication = new ApplicationsDb();
            NewApplication.applicantPersonID = 1;
            NewApplication.applicationDate = DateTime.Now;
            NewApplication.applicationTypeID = ApplicationTypes.enApplicationType.NewLocalDrivingLicenseService;
            NewApplication.applicationStatus = ApplicationsDb.enApplicationStatus.New;
            NewApplication.lastStatusDate = DateTime.Now;
            NewApplication.paidFee = ApplicationTypes.Find(NewApplication.applicationTypeID).applicationFee;
            //   NewApplication.createdByUserID = loginSettings.currentUser.userID;
            NewApplication.createdByUserID = 1;
            return NewApplication.applicationID;



        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void tbMain_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (this.ctrlPersonCardWithFilter1.personID <= 0)
            {
                MessageBox.Show("Select a person first");
                e.Cancel = true;
                return;
            }

            //checked if person have same uncompleted app 

            //if (User.isUserExistByPersonID(this.ctrlPersonCardWithFilter1.personID) && this._Mode == enMode.enAddNew)
            //{
            //    MessageBox.Show("The person is already a user");

            //    e.Cancel = true;
            //    return;
            //}


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

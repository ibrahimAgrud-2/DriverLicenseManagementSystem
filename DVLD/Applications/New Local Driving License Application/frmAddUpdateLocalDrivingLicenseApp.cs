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

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

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

        private void frmAddUpdateLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {

        }
    }
}

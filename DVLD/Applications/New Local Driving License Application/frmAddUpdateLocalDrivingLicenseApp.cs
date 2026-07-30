using DVLD_BusinessLayer;
using System;
using System.Data;
using clsLicense = DVLD_BusinessLayer.Licenses;
using clsApplication = DVLD_BusinessLayer.Applications;
using System.Windows.Forms;

namespace DVLD.Applications.New_Local_Driving_License_Application
{
    public partial class frmAddUpdateLocalDrivingLicenseApp : Form
    {

        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode = enMode.enAddNew;


        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;




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

        private void frmAddUpdateLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            _Load();
        }
        private void _Load()
        {
            _FillLicenseClassToComboBox();
            //when Mode is update;
            if (this._Mode == enMode.enUpdate)
            {
                _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);

                if (_LDLA == null)
                {
                    MessageBox.Show("No LDLA with LocalDrivingLicenseApplicationID = " + _LDLAID, "LDLA Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }

                lblMode.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";
                tpAppllicationInfo.Enabled = true;
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                fillObjectDataToField();

            }
            else
            {
                lblMode.Text = "Add New Local Driving License Application";
                this.Text = "Add New Local Driving License Application";
                tpAppllicationInfo.Enabled = false;
                lblAppFees.Text = ApplicationTypes.Find(1).applicationFee.ToString();
                lblCreatedByUserID.Text = Global.CurrentUser.UserID.ToString();
                lblAppDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                cbLicenseClasses.SelectedIndex = 3;
                _LDLA = new LocalDrivingLicenseApp();

            }

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
            if (_LDLA == null)
                return;
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(_LDLA.LicenseClassInfo.className);
            lblID.Text = _LDLA.LocalDrivingLicenseApplicationID.ToString();
            lblAppDate.Text = _LDLA.ApplicationDate.ToString("yyyy/mm/dd");
            lblAppFees.Text = _LDLA.PaidFees.ToString();
            lblCreatedByUserID.Text = _LDLA.CreatedByUserID.ToString();


            this.ctrlPersonCardWithFilter1.LoadData(_LDLA.ApplicantPersonID);
        }

        private void _FillDataToObject()
        {
            _LDLA.ApplicationDate = DateTime.Now;
            _LDLA.LastStatusDate = DateTime.Now;
            _LDLA.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LDLA.ApplicationTypeID = (int)clsApplication.enApplicationType.NewDrivingLicense;
            _LDLA.ApplicantPersonID = this.ctrlPersonCardWithFilter1.personID;
            _LDLA.CreatedByUserID = Global.CurrentUser.UserID;
            _LDLA.licenseClassID = LicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;
            _LDLA.PaidFees = ApplicationTypes.Find((int)clsApplication.enApplicationType.NewDrivingLicense).applicationFee;
        }


     

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ApplicationID = LocalDrivingLicenseApp.GetActiveApplicationIDForLicenseClass(this.ctrlPersonCardWithFilter1.personID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClass.Find(cbLicenseClasses.Text).LicenseClassID);

            if (ApplicationID!=-1)     
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int LicenseClassID = LicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;

            if (clsLicense.isLicenseExistByPersonID(this.ctrlPersonCardWithFilter1.personID, LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillDataToObject();
            
            if (_LDLA.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this._Mode = enMode.enUpdate;
                lblMode.Text = "Update User";
                this.Text = "Update User";
                lblID.Text = _LDLA.LocalDrivingLicenseApplicationID.ToString();

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
          
            btnSave.Enabled = true;
            tpAppllicationInfo.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbMain.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

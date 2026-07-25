using DVLD.People.Controls;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using clsApplication = DVLD_BusinessLayer.Applications;
using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class frmAddUpdateTestAppointment : Form
    {
        public frmAddUpdateTestAppointment()
        {
            InitializeComponent();
            this._Mode = enMode.enAddNew;
        }
        public frmAddUpdateTestAppointment(int testAppointmentID)
        {
            InitializeComponent();
            this._Mode = enMode.enUpdate;
            _TestAppointmentID = testAppointmentID;
        }

        private void frmAddUpdateTestAppointment_Load(object sender, EventArgs e)
        {
            if(this._Mode==enMode.enUpdate)
            {
                _TestAppointment = TestAppointments.Find(_TestAppointmentID);
                _LDLA = LocalDrivingLicenseApp.Find(_TestAppointment.localDrivingLicenseApplicationID);
                _LDLAID = _LDLA.ID;
            }
            this.ctrlLDLAsTestAppointmentsInfo1.LoadAppInfo(LDLAID);
            _TestType = (TestTypes.enTestTypes)_LDLA.GetPassedTestCount()+1;
            gbMain.Text = _TestType.ToString()+" Test";

            if (_LDLA.GetFailedTestCount((int)_TestType) >= 1)
            {
                groupBox1.Enabled = true;
                lblRetakeTestFees.Text = ApplicationTypes.Find(7).applicationFee.ToString();
                lblTotalFee.Text = LicenseClass.Find(_LDLA.licenseClassID).classFee + ApplicationTypes.Find(7).applicationFee.ToString();
            }
        }
        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode = enMode.enAddNew;

        private TestTypes.enTestTypes _TestType;

        private int _LDLAID = -1;

        //contructor ile testAppID verirken bu property ile de LDLAID'i alıyorum ki formdaki usercontrol'e atabileyim.
        public int LDLAID { set { _LDLAID = value; } get { return _LDLAID; } }
        private LocalDrivingLicenseApp _LDLA;

        private TestAppointments _TestAppointment;
        private int _TestAppointmentID = -1;

  




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private int _AddApplication()
        {
            clsApplication app = new clsApplication();
            app.ApplicationStatus = clsApplication.enApplicationStatus.New;
            app.ApplicantPersonID = this.ctrlLDLAsTestAppointmentsInfo1.SelectedLocalLicenseApp.ApplicationInfo.ApplicantPersonID;
            app.ApplicationDate = DateTime.Now;
            app.ApplicationTypeID = 7;
            app.CreatedByUserID = Global.currentUser.userID;
            app.PaidFees = ApplicationTypes.Find(7).applicationFee;
            app.LastStatusDate = DateTime.Now;
            if(!app.save())
            {
                MessageBox.Show("Could not saved app for retake");
                return -1;

            }
            return app.ID;

        }
        //Incase mode add
        private void _FillDataToObject()
        {
            _TestAppointment.createdByUserID = Global.currentUser.userID;
            _TestAppointment.appointmentDate = DateTime.Now;
            _TestAppointment.isLocked = false;
            _TestAppointment.paidFees = TestTypes.Find(_TestType).TestTypeFees;
            _TestAppointment.testTypeID = (int)_TestType;
            _TestAppointment.localDrivingLicenseApplicationID = _LDLAID;
           

            if(_LDLA.GetFailedTestCount((int)_TestType)>=1)
            {
              
               _TestAppointment.retakeTestApplicationID= _AddApplication();
                lblApplicationIDForRetakeTest.Text = _TestAppointment.retakeTestApplicationID.ToString();
            }
           
               

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this._Mode==enMode.enAddNew)
            {

                _TestAppointment = new TestAppointments();
                _FillDataToObject();
               
            }
            else
            {
                _TestAppointment.appointmentDate = this.ctrlLDLAsTestAppointmentsInfo1.getDate;
            }

            if (_TestAppointment.save())
            {
                MessageBox.Show("Saved successfully");
                this._Mode = enMode.enUpdate;
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
    }
}

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
using System.Threading.Tasks;
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
        public frmAddUpdateTestAppointment(int testAppointment)
        {
            InitializeComponent();
            this._Mode = enMode.enUpdate;
            _TestAppointmentID = testAppointment;
        }


        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode = enMode.enAddNew;

        public enum enTestType { Vision = 0, Written = 1, Street = 2 };
        public enTestType testType;

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

        private TestType.enTestTypes _GetTestType()
        {
            return (TestType.enTestTypes)(_LDLA.GetPassedTestCount()+1);
        }


        //Incase mode add
        private bool _FillDataToObject()
        {
            _TestAppointment.createdByUserID = Global.currentUser.userID;
            _TestAppointment.appointmentDate = DateTime.Now;
            _TestAppointment.isLocked = false;
            _TestAppointment.paidFees = TestType.Find(_GetTestType()).TestTypeFees;
            _TestAppointment.testTypeID = (int)_GetTestType();
            _TestAppointment.localDrivingLicenseApplicationID = _LDLAID;
           
            //İlk başarısız sınavın retake id'si her türlü boş olacak. Ancak ondan sonra her o tür sınav randevusu için app tablosunda bir record oluşturup retake ID'e eklicek.
            if(_LDLA.GetFailedTestCount()>1)
            {
                MessageBox.Show("Now retake record added");
            }
           
                return false ;

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

        private void frmAddUpdateTestAppointment_Load(object sender, EventArgs e)
        {
            this.ctrlLDLAsTestAppointmentsInfo1.LoadAppInfo(LDLAID);
            _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);

        }
    }
}

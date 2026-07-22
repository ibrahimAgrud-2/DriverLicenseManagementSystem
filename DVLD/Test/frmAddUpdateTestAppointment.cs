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
using static clsTestType;

namespace DVLD.Applications
{
    public partial class frmAddUpdateTestAppointment : Form
    {
        public frmAddUpdateTestAppointment(int LDLAID)
        {
            InitializeComponent();
            _LDLAID = LDLAID;
        }

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;
        enum enTestType { Vision = 1, Written = 2, Street = 3 }
        enTestType TestType = enTestType.Vision;



       

        private void fillObjectDataToField()
        {
            _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);
            if (_LDLA == null)
                return;

            this.ctrlTestAppointmentInfo1.LoadData(_LDLAID);
            TestType = (enTestType)LocalDrivingLicenseApp.GetTotalCompletedTests(_LDLA.ApplicationInfo.ApplicantPerson.nationalNo)+1;

            //fill the group box incase new retake test app added.


        }

        private void frmAddUpdateAppointment_Load(object sender, EventArgs e)
        {

            fillObjectDataToField();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TestAppointments testAppointment = new TestAppointments();

            testAppointment.isLocked = false;
            testAppointment.localDrivingLicenseApplicationID = _LDLAID;
            testAppointment.testTypeID = (int)TestType;
            testAppointment.appointmentDate = DateTime.Now;
            testAppointment.paidFees = clsTestType.Find(clsTestType.enTestTypes.VisionTest).TestTypeFees;
            testAppointment.createdByUserID = Global.currentUser.userID;

            if(testAppointment.save())
            {
                MessageBox.Show("Yes");
            }
            else
            {
                MessageBox.Show("NO");
            }



        }
    }
}

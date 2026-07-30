using DVLD.Properties;
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

namespace DVLD.Test.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

     private TestAppointments _TestAppointment;
        private int _TestAppointmentID = -1;

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;

        private int _TestID=-1;



        public int TestAppointmentID { get { return _TestAppointmentID; } }
        public int TestID { get { return _TestAppointment.GetTestID(); } }


        private TestTypes.enTestTypes _TestTypeID ;
        public TestTypes.enTestTypes TestType
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case TestTypes.enTestTypes.Vision:
                        {
                            gbTestType.Text = "Vision Test";
                            break;
                        }

                    case TestTypes.enTestTypes.Written:
                        {
                            gbTestType.Text = "Written Test";
                            break;
                        }
                    case TestTypes.enTestTypes.Street:
                        {
                            gbTestType.Text = "Street Test";
                            break;


                        }
                }
            }
        }



        public void LoadTest(int testAppointmentID)
        {
            _TestAppointment =  TestAppointments.Find(testAppointmentID);

            if(_TestAppointment==null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + testAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.GetTestID();

            _TestAppointmentID = testAppointmentID;
            _LDLA = LocalDrivingLicenseApp.Find(_TestAppointment.localDrivingLicenseApplicationID);
            _LDLAID = _LDLA.LocalDrivingLicenseApplicationID;

            if (_LDLA == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LDLAID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingLicenseAppID.Text = _LDLA.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LDLA.LicenseClassInfo.className;
            lblFullName.Text = _LDLA.ApplicantPerson.fullName;


            //this will show the trials for this test before 
            lblTrial.Text = _LDLA.TotalTrialsPerTest(_TestTypeID).ToString();



            lblDate.Text = _TestAppointment.appointmentDate.ToShortDateString();
            lblFees.Text = _TestAppointment.paidFees.ToString();
            lblTestID.Text = (_TestAppointment.GetTestID() == -1) ? "Not Taken Yet" : _TestAppointment.GetTestID().ToString();

        }

    }
}

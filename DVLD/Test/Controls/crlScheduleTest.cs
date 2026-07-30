using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsApplication = DVLD_BusinessLayer.Applications;

namespace DVLD.Test.Controls
{
    public partial class crlScheduleTest : UserControl
    {
        public crlScheduleTest()
        {
            InitializeComponent();
        }

        enum enCreationMode {enFirstTimeSchedule=1,enRetakeTestSchedule=2 };
        enCreationMode _CreationMode = enCreationMode.enFirstTimeSchedule;

        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode = enMode.enAddNew;



        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;
        private TestAppointments _TestAppointment;
        private int _TestAppointmentID = -1;
        private TestTypes.enTestTypes _TestTypeID;

        public TestTypes.enTestTypes TestTypeID
        {
            get
            {
                return (TestTypes.enTestTypes)_TestTypeID;
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


        public void LoadData(int localDrivingLicenseID, int testAppointmentID = -1) 
        {

            //Bu aşamda schedule test yapılıyor. Bu aşamaya gelmeden kişimnin o testti geçitiği veya aynı test türünden aktif başvurusunu olup olmadığı kontrol edilniş olur.

            if(testAppointmentID==-1)
            {
                this._Mode = enMode.enAddNew;
            }
            else
            {
                this._Mode = enMode.enUpdate;
            }

            _LDLAID = localDrivingLicenseID;
            _LDLA = LocalDrivingLicenseApp.Find(localDrivingLicenseID);

            _TestAppointmentID = testAppointmentID;
            _TestAppointment = TestAppointments.Find(testAppointmentID);

            if(_LDLA==null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LDLAID.ToString(),
                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if(_LDLA.DoesAttendTestType(_TestTypeID))
            {
                _CreationMode = enCreationMode.enRetakeTestSchedule;
            }
            else
            {
                _CreationMode = enCreationMode.enFirstTimeSchedule;
            }

            if(_CreationMode==enCreationMode.enFirstTimeSchedule)
            {
                gbRetakeTestInfo.Enabled = false;
                lblTitle.Text = "Schedule Test";
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
             
                lblRetakeAppFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).applicationFee.ToString();
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
            }

            lblLocalDrivingLicenseAppID.Text = _LDLAID.ToString();
            lblDrivingClass.Text = _LDLA.LicenseClassInfo.className;
            lblFullName.Text = _LDLA.ApplicantPerson.fullName;

            lblTrial.Text = _LDLA.TotalTrialsPerTest(_TestTypeID).ToString();

            if(this._Mode==enMode.enAddNew)
            {
                lblFees.Text = TestTypes.Find(_TestTypeID).TestTypeFees.ToString();
                dtpTestDate.MinDate = DateTime.Now;
                lblRetakeTestAppID.Text = "N/A";

                _TestAppointment = new TestAppointments();
            }
            else
            {
                if(!_LoadTestAppointmentData())
                {
                    return;
                }
            }
            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRetakeAppFees.Text)).ToString();


            if (!_HandleActiveTestAppointmentConstraint())
                return;
            if (!_HandleAppointmentLockedConstraint())
                return;
            if (!_HandlePreviousTestConstraint())
                return;
        }

        //update test appointment (schedule)
        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = TestAppointments.Find(_TestAppointmentID);

            if(_TestAppointment==null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

            lblFees.Text = _TestAppointment.paidFees.ToString();
            
            //Update Modunda olduğunda sınav tarihi sınav başvurusu yapmadan önceki tarihten geride olmamalı.
            if(DateTime.Compare(DateTime.Now,_TestAppointment.appointmentDate)<0)
            {
                dtpTestDate.MinDate = DateTime.Now;
            }
            else
            {
                dtpTestDate.MinDate = _TestAppointment.appointmentDate;
            }

            if(_TestAppointment.retakeTestApplicationID<=0)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";

            }
            else
            {
                lblRetakeAppFees.Text = ApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).applicationFee.ToString();
                lblRetakeTestAppID.Text = "N/A";
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Rate Test";
                lblRetakeTestAppID.Text = _TestAppointment.retakeTestApplicationID.ToString();
            }
            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if(_Mode==enMode.enAddNew&&LocalDrivingLicenseApp.IsThereAnActiveScheduledTest(_LDLAID, (int)_TestTypeID))
            {
                lblUserMessage.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }
            else
            {
                return true;
            }
        }


        private bool _HandleAppointmentLockedConstraint()
        {
            if(_TestAppointment.isLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment loacked.";
                dtpTestDate.Enabled = false;
                btnSave.Enabled = false;
                return false;
            }
            return true;
        }
    
        private bool _HandlePreviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case TestTypes.enTestTypes.Vision:
                    //in this case no required prvious test to pass.
                    lblUserMessage.Visible = false;

                    return true;

                case TestTypes.enTestTypes.Written:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LDLA.DoesPassTestType(TestTypes.enTestTypes.Vision))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

                case TestTypes.enTestTypes.Street:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LDLA.DoesPassTestType(TestTypes.enTestTypes.Written))
                    {
                        lblUserMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        lblUserMessage.Visible = true;
                        btnSave.Enabled = false;
                        dtpTestDate.Enabled = false;
                        return false;
                    }
                    else
                    {
                        lblUserMessage.Visible = false;
                        btnSave.Enabled = true;
                        dtpTestDate.Enabled = true;
                    }


                    return true;

            }
            return true;
        }

        private bool _HandleRetakeTestApplication()
        {
           
            if (_Mode == enMode.enAddNew && _CreationMode == enCreationMode.enRetakeTestSchedule)
            {
             
                clsApplication Application = new clsApplication();

                Application.ApplicantPersonID = _LDLA.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = ApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeTest).applicationFee;
                Application.CreatedByUserID = Global.CurrentUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.retakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.retakeTestApplicationID = Application.ApplicationID;

            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeTestApplication())
                return;



            _TestAppointment.testTypeID =(int)_TestTypeID;
            _TestAppointment.localDrivingLicenseApplicationID = _LDLA.LocalDrivingLicenseApplicationID;
            _TestAppointment.appointmentDate = dtpTestDate.Value;
            _TestAppointment.paidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.createdByUserID = Global.CurrentUser.UserID;

            if (_TestAppointment.save())
            {
                _Mode = enMode.enUpdate;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

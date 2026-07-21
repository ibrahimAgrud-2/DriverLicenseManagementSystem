using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class TestAppointments
    {
        public int testAppointmentID { get; set; }
        public int testTypeID { get; set; }
        public clsTestType TestTypeInfo { get; set; }

        public int localDrivingLicenseApplicationID { get; set; }
        public LocalDrivingLicenseApp LDLAInfo { get; set; }

        public DateTime appointmentDate { get; set; }
        public double paidFees { get; set; }
        public int createdByUserID { get; set; }
        public User UserInfo { get; set; }
        public bool isLocked { get; set; }
        public int retakeTestApplicationID { get; set; }

        enum enMode {enAddNew=1,enUpdate=2 }
        enMode mode = enMode.enAddNew;

        public TestAppointments()
        {
            this.testAppointmentID = -1;
            this.testTypeID = -1;
            this.localDrivingLicenseApplicationID = -1;
            this.appointmentDate = DateTime.Now;
            this.paidFees = 0.0;
            this.createdByUserID = -1;
            this.isLocked = false;
            this.retakeTestApplicationID = 0;
        }

        private TestAppointments(int testAppointmentID, int testTypeID, int localDrivingLicenseApplicationID,
            DateTime appointmentDate, double paidFees, int createdByUserID, bool isLocked, int retakeTestApplicationID)
        {
            this.testAppointmentID = testAppointmentID;
            this.testTypeID = testTypeID;
            this.localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this.appointmentDate = appointmentDate;
            this.paidFees = paidFees;
            this.createdByUserID = createdByUserID;
            this.isLocked = isLocked;
            this.retakeTestApplicationID = retakeTestApplicationID;
        }

        public static DataTable getTestAppointmentsRecords()
        {
            DataTable dt = new DataTable();
            dt = TestAppointmentsDataAccess.getTestAppointmentsRecords();
            return dt;
        }

        public static TestAppointments findTestAppointment(int testAppointmentID)
        {
            int testTypeID = -1;
            int localDrivingLicenseApplicationID = -1;
            DateTime appointmentDate = DateTime.Now;
            double paidFees = 0.0;
            int createdByUserID = -1;
            bool isLocked = false;
            int retakeTestApplicationID = 0;

            if (TestAppointmentsDataAccess.findTestAppointment(testAppointmentID, ref testTypeID,
                ref localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees,
                ref createdByUserID, ref isLocked, ref retakeTestApplicationID))
            {
                return new TestAppointments(testAppointmentID, testTypeID, localDrivingLicenseApplicationID,
                    appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);
            }
            return null;
        }

        public static bool isTestAppointmentExist(int testAppointmentID)
        {
            return TestAppointmentsDataAccess.isTestAppointmentExist(testAppointmentID);
        }

        public bool save()
        {
            switch (this.mode)
            {
                case enMode.enAddNew:
                    if (_addNewTestAppointment())
                    {
                        this.mode = enMode.enAddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.enUpdate:
                    return _updateTestAppointment();
                default:
                    return false;
            }
        }

        private bool _addNewTestAppointment()
        {
            this.testAppointmentID = TestAppointmentsDataAccess.addTestAppointment(
                this.testTypeID,
                this.localDrivingLicenseApplicationID,
                this.appointmentDate,
                this.paidFees,
                this.createdByUserID,
                this.isLocked,
                this.retakeTestApplicationID
            );

            return (this.testAppointmentID != -1);
        }

        private bool _updateTestAppointment()
        {
            return TestAppointmentsDataAccess.updateTestAppointment(
                this.testAppointmentID,
                this.testTypeID,
                this.appointmentDate,
                this.paidFees,
                this.isLocked,
                this.retakeTestApplicationID
            );
        }

        public static bool deleteTestAppointment(int testAppointmentID)
        {
            return TestAppointmentsDataAccess.deleteTestAppointment(testAppointmentID);
        }
    }
}
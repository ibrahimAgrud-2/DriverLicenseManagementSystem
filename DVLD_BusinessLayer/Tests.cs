    using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class Tests
    {

        enum enMode { enAddNew = 1, enUpdate = 2 };
        enMode mode = enMode.enAddNew;
        public int testID { get; set; }
        public int testAppointmentID { get; set; }
        public TestAppointments testAppointmentInfo { get; set; }
        public int testResult { get; set; }
        public string notes { get; set; }
        public int createdByUserID { get;  set; }

   



        public Tests()
        {
            this.testID = -1;
            this.testAppointmentID = -1;
            this.testResult = 0;
            this.notes = null;
            this.createdByUserID = -1;
            this.mode = enMode.enAddNew;
        }

        private Tests(int testID, int testAppointmentID, int testResult, string notes, int createdByUserID)
        {
            this.testID = testID;
            this.testAppointmentID = testAppointmentID;
            this.testResult = testResult;
            this.notes = notes;
            this.createdByUserID = createdByUserID;
            this.mode = enMode.enUpdate;
            this.testAppointmentInfo=TestAppointments.Find(testAppointmentID);
        }

        public static DataTable getTestRecords()
        {
            DataTable dt = new DataTable();
            dt = clsTestDataAccess.getTestRecords();
            return dt;
        }

        public static Tests Find(int testID)
        {
            int testAppointmentID = -1;
            int testResult = 0;
            string notes = null;
            int createdByUserID = -1;

            if (clsTestDataAccess.findTestByID(testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
            {
                return new Tests(testID, testAppointmentID, testResult, notes, createdByUserID);
            }
            return null;
        }

        public static bool isTestExist(int testID)
        {
            return clsTestDataAccess.isTestExist(testID);
        }

        public bool save()
        {
            switch (this.mode)
            {
                case enMode.enAddNew:
                    if (_addNewTest())
                    {
                        this.mode = enMode.enAddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.enUpdate:
                    return _updateTest();
                default:
                    return false;
            }
        }

        private bool _addNewTest()
        {
            this.testID = clsTestDataAccess.addTest(
                this.testAppointmentID,
                this.testResult,
                this.notes,
                this.createdByUserID
            );

            return (this.testID != -1);
        }

        private bool _updateTest()
        {
            return clsTestDataAccess.updateTest(
                this.testID,
                this.testAppointmentID,
                this.testResult,
                this.notes
            );
        }


        //-------------------------------------------------------------------
        public static int GetPassedTestCount(int LDLAID)
        {
            return clsTestDataAccess.GetPassedTestCount(LDLAID);
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }


        public static Tests FindLastTestPerPersonAndLicenseClass(int personID,int licenseClassID,TestTypes.enTestTypes testTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;
            if (clsTestDataAccess.GetLastTestByPersonAndTestTypeAndLicenseClass
                  (personID, licenseClassID, (int)testTypeID,ref  TestID,
              ref TestAppointmentID, ref TestResult,
              ref Notes, ref CreatedByUserID))

                return new Tests(TestID,
                        TestAppointmentID, Convert.ToInt32(TestResult),
                        Notes, CreatedByUserID);
            else
                return null;


        }

    }
}
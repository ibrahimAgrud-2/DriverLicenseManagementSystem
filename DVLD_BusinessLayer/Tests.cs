using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class Tests
    {
        public int testID { get; set; }

        public int testAppointmentID { get; set; }
        public TestAppointments testAppointmentInfo { get; set; }
        public bool testResult { get; set; }
        public string notes { get; set; }
        public int createdByUserID { get;  set; }
        public User createdByUserInfo { get; set; }


        enum enMode {enAddNew=1,enUpdate=2 };
        enMode mode = enMode.enAddNew;
        public Tests()
        {
            this.testID = -1;
            this.testAppointmentID = -1;
            this.testResult = false;
            this.notes = null;
            this.createdByUserID = -1;
            this.mode = enMode.enAddNew;
        }

        private Tests(int testID, int testAppointmentID, bool testResult, string notes, int createdByUserID)
        {
            this.testID = testID;
            this.testAppointmentID = testAppointmentID;
            this.testResult = testResult;
            this.notes = notes;
            this.createdByUserID = createdByUserID;
            this.mode = enMode.enUpdate;
        }

        public static DataTable getTestRecords()
        {
            DataTable dt = new DataTable();
            dt = clsTestDataAccess.getTestRecords();
            return dt;
        }

        public static Tests findTest(int testID)
        {
            int testAppointmentID = -1;
            bool testResult = false;
            string notes = null;
            int createdByUserID = -1;

            if (clsTestDataAccess.findTest(testID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
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

        public static bool deleteTest(int testID)
        {
            return clsTestDataAccess.deleteTest(testID);
        }
    }
}
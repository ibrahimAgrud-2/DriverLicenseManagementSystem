using DVLD_DataAccessLayer;
using System;
using System.Data;
using System.Runtime.CompilerServices;
using ApplicationDb=DVLD_BusinessLayer.Applications;


namespace DVLD_BusinessLayer
{
    public class LocalDrivingLicenseApp : ApplicationDb
    {
        public enum enMode { enAddNew = 1, enUpdate = 2 };
        public enMode Mode;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int applicationID { set; get; }
        public ApplicationDb ApplicationInfo;

        public int licenseClassID { set; get; }
        public LicenseClass LicenseClassInfo { set; get; }
     
  

        public LocalDrivingLicenseApp()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.applicationID = -1;
            this.licenseClassID = -1;
            this.Mode = enMode.enAddNew;
        }

        private LocalDrivingLicenseApp(int id, int applicationID, int licenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = id;
            this.applicationID = applicationID;
            this.ApplicationInfo = ApplicationDb.Find(applicationID);

            this.licenseClassID = licenseClassID;
            this.LicenseClassInfo = LicenseClass.Find(licenseClassID);

            this.Mode = enMode.enUpdate;
        }
        private LocalDrivingLicenseApp(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.applicationID = applicationID;
            this.ApplicationInfo = ApplicationDb.Find(applicationID);
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.licenseClassID = licenseClassID;
            this.LicenseClassInfo = LicenseClass.Find(licenseClassID);
            Mode = enMode.enUpdate;
        }

        public static DataTable getLocalDrivingLicenseAppRecords()
        {
            DataTable dt = new DataTable();

            dt = clsLocalDrivingLicenseAppDataAccess.getAllLocalDrivingLicenseApps();
            return dt;
        }



        public static LocalDrivingLicenseApp Find(int id)
        {
              int applicationID=0,
              licenseClassID=0;

            if (clsLocalDrivingLicenseAppDataAccess.Find(id, ref applicationID, ref licenseClassID))
            {
                return new LocalDrivingLicenseApp(id, applicationID, licenseClassID);
            }
            return null;
        }


        private bool _AddNewLocalDriverLicenseApp()
        {



            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseAppDataAccess.AddLocalDrivingLicense( this.applicationID,(int) this.licenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);

        }
        private bool _UpdateDLocalDriverLicenseAppInfo()
        {

            return clsLocalDrivingLicenseAppDataAccess.UpdateLocalDrivingLicenseInfo(this.LocalDrivingLicenseApplicationID, this.applicationID,(int)this.licenseClassID);
        }
        public static bool IsLocalDriverLicenseExist(int id)
        {
            return clsLocalDrivingLicenseAppDataAccess.isLocalDrivingLicenseAppExistByID(id);
        }
       
        public bool deleteLocalDrivingLicenseApp(int ID)
        {
            return clsLocalDrivingLicenseAppDataAccess.deleteLocalDrivingLicenseApp(ID);
        }

        public bool deleteLocalDrivingLicenseApp()
        {
            bool isBaseApplicationDeleted = false;
            bool isLocalApplicationDeleted = false;

            isLocalApplicationDeleted = LocalDrivingLicenseApp.deleteApplication(this.LocalDrivingLicenseApplicationID);

            if (!isLocalApplicationDeleted)
                return false;


            isBaseApplicationDeleted = base.deleteApplication();
            return isBaseApplicationDeleted;

        }

        public bool Save(   )
        {
            switch (this.Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewLocalDriverLicenseApp())
                    {
                        this.Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.enUpdate:
                    return _UpdateDLocalDriverLicenseAppInfo();
                default:
                    return false;
            }
        }

        public bool Save(int a)
        {

            //Because of inheritance first we call the save method in the base class,
            //it will take care of adding all information to the application table.
            base.Mode = (ApplicationDb.enMode)Mode;
            if (!base.save())
                return false;

            //After we save the main application now we save the sub application.
            switch (this.Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewLocalDriverLicenseApp())
                    {
                        this.Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.enUpdate:
                    return _UpdateDLocalDriverLicenseAppInfo();
                default:
                    return false;
            }
        }


        public static bool HasPendingOrCompletedApplication(int personID,int AppForLicenseClassID)
        {
            return clsLocalDrivingLicenseAppDataAccess.HasPendingOrCompletedApplication(personID,AppForLicenseClassID);
        }
        public  int GetPassedTestCount()
        {
            return clsLocalDrivingLicenseAppDataAccess.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public int GetFailedTestCount(int testTypeID)
        {
            return clsLocalDrivingLicenseAppDataAccess.GetFailedTestCount(this.LocalDrivingLicenseApplicationID,testTypeID);
        }

        //------------------------------------------------------
        public bool DoesPassTestType(TestTypes.enTestTypes TestTypeID)

        {
            return clsLocalDrivingLicenseAppDataAccess.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, TestTypes.enTestTypes TestTypeID)

        {
            return clsLocalDrivingLicenseAppDataAccess.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesAttendTestType(TestTypes.enTestTypes TestTypeID)

        {
            return clsLocalDrivingLicenseAppDataAccess.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(TestTypes.enTestTypes TestTypeID)
        {
            return clsLocalDrivingLicenseAppDataAccess.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, TestTypes.enTestTypes TestTypeID)

        {

            return clsLocalDrivingLicenseAppDataAccess.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
    
        public Tests FindLastTestPerPersonAndLicenseClass ()
        {
            return clsTestDataAccess.GetLastTestByPersonAndTestTypeAndLicenseClass();
        }



    }
}

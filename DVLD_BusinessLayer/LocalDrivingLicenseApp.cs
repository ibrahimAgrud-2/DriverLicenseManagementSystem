using DVLD_DataAccessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using ApplicationDb=DVLD_BusinessLayer.Applications;


namespace DVLD_BusinessLayer
{
    public class LocalDrivingLicenseApp :ApplicationDb
    {
        public enum enMode { enAddNew = 1, enUpdate = 2 };
        public enMode Mode;

        public int LocalDrivingLicenseApplicationID { set; get; }
        public int licenseClassID { set; get; }
        public LicenseClass LicenseClassInfo { set; get; }
     
  

        public LocalDrivingLicenseApp()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.licenseClassID = -1;
            this.Mode = enMode.enAddNew;
        }

        private LocalDrivingLicenseApp(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             double PaidFees, int CreatedByUserID)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)ApplicationDb.enApplicationType.NewDrivingLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;
            base.ApplicantPerson = Person.Find(ApplicantPersonID);

            this.licenseClassID = LicenseClassID;
            this.LicenseClassInfo = LicenseClass.Find(LicenseClassID);
            this.Mode = enMode.enUpdate;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
        }

        public static DataTable getLocalDrivingLicenseAppRecords()
        {
            return clsLocalDrivingLicenseAppDataAccess.getAllLocalDrivingLicenseApps();
        }



        public static LocalDrivingLicenseApp Find(int LDLAID)
        {
              int applicationID=0,
              licenseClassID=0;

            if (clsLocalDrivingLicenseAppDataAccess.Find(LDLAID, ref applicationID, ref licenseClassID))
            {

                ApplicationDb app = ApplicationDb.Find(applicationID);

                return new LocalDrivingLicenseApp(LDLAID, applicationID, licenseClassID, app.ApplicantPersonID,app.ApplicationDate,ApplicationDb.enApplicationStatus.New,app.LastStatusDate,app.PaidFees,app.CreatedByUserID);
            }
            return null;
        }


        private bool _AddNewLocalDriverLicenseApp()
        {



            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseAppDataAccess.AddLocalDrivingLicense( this.ApplicationID,(int) this.licenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);

        }
        private bool _UpdateDLocalDriverLicenseAppInfo()
        {

            return clsLocalDrivingLicenseAppDataAccess.UpdateLocalDrivingLicenseInfo(this.LocalDrivingLicenseApplicationID, this.ApplicationID, (int)this.licenseClassID);
        }
        public static bool IsLocalDriverLicenseExist(int id)
        {
            return clsLocalDrivingLicenseAppDataAccess.isLocalDrivingLicenseAppExistByID(id);
        }

        public bool deleteLocalDrivingLicenseApp()
        {
            bool isBaseApplicationDeleted = false;
            bool isLocalApplicationDeleted = false;

            isLocalApplicationDeleted = clsLocalDrivingLicenseAppDataAccess.deleteLocalDrivingLicenseApp(this.LocalDrivingLicenseApplicationID);
            if (!isLocalApplicationDeleted)
                return false;


            isBaseApplicationDeleted = ApplicationDb.Delete(this.ApplicationID);
            return isBaseApplicationDeleted;

        }

        public bool Save()
        {

            base.Mode = (ApplicationDb.enMode)Mode;
            if(!base.Save())
            {
                return false;
            }
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



       //✅ 
        public  bool IsLicenseIssued()
        {
           return Licenses.GetActiveLicenseIDByPersonID(this.ApplicantPersonID,this.licenseClassID)!=-1;
        }
        //✅
        public bool DoesPassTestType(TestTypes.enTestTypes TestTypeID)

        {
            return clsLocalDrivingLicenseAppDataAccess.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        //✅
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, TestTypes.enTestTypes TestTypeID)

        {
            return clsLocalDrivingLicenseAppDataAccess.DoesPassTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
  
    
    }
}

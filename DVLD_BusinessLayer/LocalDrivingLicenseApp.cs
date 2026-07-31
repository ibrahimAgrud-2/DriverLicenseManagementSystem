using DVLD_DataAccessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Net.Security;
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

    
    
        //------------------------------------------------------


        //Kişi ilgili sınava girmiş mi.Bu sayede mode retake test olur eğer girmemişse mod first time olur.
        public bool DoesAttendTestType(TestTypes.enTestTypes TestTypeID)

        {
            return clsLocalDrivingLicenseAppDataAccess.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        //✅ LDLA'in belirlenene test türünden aktif sınavı var mı

        public byte TotalTrialsPerTest(TestTypes.enTestTypes TestTypeID)
        {
            return clsLocalDrivingLicenseAppDataAccess.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        //✅ LDLA'in belirlenene test türünden aktif sınavı var mı
        public bool IsThereAnActiveScheduledTest( TestTypes.enTestTypes TestTypeID)

        {

            return clsLocalDrivingLicenseAppDataAccess.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        //✅ LDLA'in belirlenene test türünden aktif sınavı var mı
        public static bool IsThereAnActiveScheduledTest(int LDLAID,int TestTypeID)

        {

            return clsLocalDrivingLicenseAppDataAccess.IsThereAnActiveScheduledTest(LDLAID, (int)TestTypeID);
        }


        //İlgili LDLA için aktif License ID (varsa) ✅
        public int GetActiveLicenseID()
        {
            return Licenses.GetActiveLicenseIDByPersonID(this.ApplicantPersonID,this.licenseClassID);
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
  
        public Tests GetLastTestPerTestType(TestTypes.enTestTypes testTypeID)
        {
            return Tests.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID,this.licenseClassID ,testTypeID);
        }


        //✅
        public int IssueLicenseForTheFirtTime(string notes,int createdByUserID)
        {
            int driverID = -1;

            Driver driver = Driver.FindByPersonID(this.ApplicantPersonID);

            if(driver==null)
            {
                Driver newDriver = new Driver();
                newDriver.personID = this.ApplicantPersonID;
                newDriver.createdByUserID = createdByUserID;
                newDriver.createdDate = DateTime.Now;
                
                if(newDriver.save())
                {
                    driverID = newDriver.driverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                driverID = driver.driverID;
            }

            Licenses License = new Licenses();
            License.applicationID = this.ApplicationID;
            License.driverID = driverID;
            License.licenseClassID = this.licenseClassID;
            License.issueDate = DateTime.Now;
            License.expirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.defaultValidityLength);
            License.notes = notes;
            License.PaidFees = this.LicenseClassInfo.classFee;
            License.isActive = true;
            License.issueReason = Licenses.enIssueReason.FirstTime;
            License.createdByUserID = CreatedByUserID;

            if (License.save())
            {
                //now we should set the application status to complete.
                this.setComplete();

                return License.licenseID;
            }

            else
                return -1;

        }

        //✅
        public bool PassedAlltests()
        {
            return Tests.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public int PassedTestCount()
        {
            return Tests.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
    }
}

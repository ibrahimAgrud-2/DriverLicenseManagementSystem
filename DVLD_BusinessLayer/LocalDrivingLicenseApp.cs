using DVLD_DataAccessLayer;
using System;
using System.Data;
using ApplicationDb=DVLD_BusinessLayer.Applications;


namespace DVLD_BusinessLayer
{
    public class LocalDrivingLicenseApp
    {

        public int ID { set; get; }
        public int applicationID { set; get; }
        public ApplicationDb ApplicationInfo;

        public int licenseClassID { set; get; }
        public LicenseClass LicenseClassInfo { set; get; }
     
        public enum enMode { enAddNew = 1, enUpdate = 2 };
        public enMode mode;

        public LocalDrivingLicenseApp()
        {
            this.ID = -1;
            this.applicationID = -1;
            this.licenseClassID = -1;
            this.mode = enMode.enAddNew;
        }

        private LocalDrivingLicenseApp(int id, int applicationID, int licenseClassID)
        {
            this.ID = id;
            this.applicationID = applicationID;
            this.ApplicationInfo = ApplicationDb.FindApplication(applicationID);

            this.licenseClassID = licenseClassID;
            this.LicenseClassInfo = LicenseClass.Find(licenseClassID);

            this.mode = enMode.enUpdate;
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



            this.ID = clsLocalDrivingLicenseAppDataAccess.AddLocalDrivingLicense( this.applicationID,(int) this.licenseClassID);
            return (this.ID != -1);

        }
        private bool _UpdateDLocalDriverLicenseAppInfo()
        {

            return clsLocalDrivingLicenseAppDataAccess.UpdateLocalDrivingLicenseInfo(this.ID, this.applicationID,(int)this.licenseClassID);
        }

            
  
        public static bool IsLocalDriverLicenseExist(int id)
        {
            return clsLocalDrivingLicenseAppDataAccess.isLocalDrivingLicenseAppExistByID(id);
        }

        public static bool deleteLocalDrivingLicenseApp(int DriverID)
        {
       
            return clsLocalDrivingLicenseAppDataAccess.deleteLocalDrivingLicenseApp(DriverID);

        }

        public static int GetTotalCompletedTests(string nationalNo)
        {

            return clsLocalDrivingLicenseAppDataAccess.GetTotalCompletedTests(nationalNo);

        }


        public bool Save()
        {
            switch (this.mode)
            {
                case enMode.enAddNew:
                    if (_AddNewLocalDriverLicenseApp())
                    {
                        this.mode = enMode.enUpdate;
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
    }
}

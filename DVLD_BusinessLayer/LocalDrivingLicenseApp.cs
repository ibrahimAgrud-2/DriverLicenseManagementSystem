using DVLD_DataAccessLayer;
using System;
using System.Data;
using ApplicationDb=DVLD_BusinessLayer.Applications;


namespace DVLD_BusinessLayer
{
    public class LocalDrivingLicenseApp
    {

        public int id { set; get; }
        public int applicationID { set; get; }
        public ApplicationDb ApplicationInfo;
        public LicenseClass.enLicenseClass licenseClassID { set; get; }
     
        public enum enMode { enAddNew = 1, enUpdate = 2 };
        public enMode mode;

        public LocalDrivingLicenseApp()
        {
            this.id = -1;
            this.applicationID = -1;
            this.licenseClassID = LicenseClass.enLicenseClass.OrdinaryDrivingLicense;
            this.mode = enMode.enAddNew;
        }

        private LocalDrivingLicenseApp(int id, int applicationID, LicenseClass.enLicenseClass licenseClassID)
        {
            this.id = id;
            this.applicationID = applicationID;
            this.licenseClassID = licenseClassID;
            this.ApplicationInfo = ApplicationDb.findApplication(applicationID);
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
                return new LocalDrivingLicenseApp(id, applicationID, (LicenseClass.enLicenseClass) licenseClassID);
            }
            return null;
        }


        private bool _AddNewLocalDriverLicenseApp()
        {



            this.id = clsLocalDrivingLicenseAppDataAccess.AddLocalDrivingLicense( this.applicationID,(int) this.licenseClassID);
            return (this.id != -1);

        }
        private bool _UpdateDLocalDriverLicenseAppInfo()
        {

            return clsLocalDrivingLicenseAppDataAccess.UpdateLocalDrivingLicenseInfo(this.id, this.applicationID,(int)this.licenseClassID);
        }

            
  
        public static bool IsLocalDriverLicenseExist(int id)
        {
            return clsLocalDrivingLicenseAppDataAccess.isLocalDrivingLicenseAppExistByID(id);
        }

        public static bool deleteLocalDrivingLicenseApp(int DriverID)
        {
       
            return clsLocalDrivingLicenseAppDataAccess.deleteLocalDrivingLicenseApp(DriverID);

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

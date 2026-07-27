using DVLD_DataAccessLayer;
using System;
using System.Data;
using System.Diagnostics;


namespace DVLD_BusinessLayer
{
    public class DetainedLicense
    {
         public int detainID { set; get; }
       public int licenseID { set; get; }
        public Licenses LicenseInfo { set; get; }

            public  DateTime detainDate { set; get; }
           public   double fineFees { set; get; }
        public int CreatedByUserID { set; get; }
      
           public  bool isReleased { set; get; }
          public  DateTime releaseDate { set; get; }

        public int releasedByUserID { set; get; }
          public  int releaseApplicationID { set; get; }

        enum enMode { enAddNew=1,enUpdate=2};
        enMode mode=enMode.enAddNew;


      public  DetainedLicense()
        {
            this.licenseID = -1;
            this.licenseID = -1;
            this.detainDate = DateTime.Now;
            this.fineFees = 0.0;
            this.CreatedByUserID = -1;
            this.isReleased = false;
            this.releaseDate = DateTime.Now;
            this.releasedByUserID = -1;
            this.releaseApplicationID = -1;
            this.mode = enMode.enAddNew;
        }
       private DetainedLicense(int detainID, int licensedID,  DateTime detainDate,  double fineFees,  int createdByUserID,  bool isReleased,  DateTime releaseDate,  int releasedByUserID,  int releaseApplicationID)
        {
            this.detainID = detainID;
            this.licenseID = licensedID;
            this.detainDate = detainDate;
            this.fineFees = fineFees;
            this.CreatedByUserID = createdByUserID;
            this.isReleased = isReleased;
            this.releaseDate = releaseDate;
            this.releasedByUserID = releasedByUserID;
            this.releaseApplicationID = releaseApplicationID;
            this.mode = enMode.enUpdate;
        }

        static DataTable getDetainedLicenseRecords()
        {
            return DetainedLicensesDataAccess.getDetainedLicenseRecords();
        }
          
       public static DetainedLicense Find(int detainID)
        {
          int licenseID = -1, releaseApplicationID=-1, releasedByUserID=-1, createdByUserID=-1;
              DateTime detainDate = DateTime.Now, releaseDate = DateTime.Now;
            double fineFees = 0.0;
            bool isReleased = false;

            if (DetainedLicensesDataAccess.findDetainedLicense(detainID, ref licenseID,ref detainDate, ref fineFees, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new DetainedLicense(detainID, licenseID, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            return null;



        }
        public static DetainedLicense FindByLicenseID(int licenseID)
        {
            int detainedID = -1, releaseApplicationID = -1, releasedByUserID = -1, createdByUserID = -1;
            DateTime detainDate = DateTime.Now, releaseDate = DateTime.Now;
            double fineFees = 0.0;
            bool isReleased = false;

            if (DetainedLicensesDataAccess.findDetainedLicenseByLicenseID(ref detainedID,  licenseID, ref detainDate, ref fineFees, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
            {
                return new DetainedLicense(detainedID, licenseID, detainDate, fineFees, createdByUserID, isReleased, releaseDate, releasedByUserID, releaseApplicationID);
            }
            return null;



        }



        private bool _addNewDetainedLicense()
        {

            this.detainID = DetainedLicensesDataAccess.addDetainedLicense(this.licenseID, this.detainDate, this.fineFees, this.CreatedByUserID, this.isReleased, this.releaseDate, this.releasedByUserID, this.releaseApplicationID);

            return (this.detainID != -1);

        }

        private bool _updateDetainedLicense()
        {
            this.CreatedByUserID = 1;
            this.releasedByUserID = 1;
            this.fineFees = 12;
            this.detainDate = DateTime.Now;
            this.releaseDate = DateTime.Now;
            

            return DetainedLicensesDataAccess.updateDetainedLicense(this.detainID,this.licenseID, this.detainDate, this.fineFees, this.CreatedByUserID, this.isReleased, this.releaseDate, this.releasedByUserID, this.releaseApplicationID);
        }
        public static bool isDetainedLicenseExist(int detainID)
        {
            return DetainedLicensesDataAccess.isDetainedLicenseExist(detainID);
        }
        public static bool isLicenseDetained(int licenseID)
        {
            return DetainedLicensesDataAccess.isLicenseDetained(licenseID);
        }


        public bool save()
        {
            switch(this.mode)
            {
                case enMode.enAddNew:
                    if (_addNewDetainedLicense())
                    {
                        this.mode = enMode.enUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.enUpdate:
                    return _updateDetainedLicense();
                default:
                    return false;
            }
        }


        public bool Release(int PersonID,int releasedByUserID)
        {
            Applications newApplication = new Applications();
            newApplication.ApplicantPersonID = PersonID;
            newApplication.ApplicationDate = DateTime.Now;
            newApplication.ApplicationTypeID = (int)Applications.enApplicationType.ReleaseDetainedDrivingLicense;
            newApplication.ApplicationStatus = Applications.enApplicationStatus.Completed;
            newApplication.LastStatusDate = DateTime.Now;
            newApplication.PaidFees = ApplicationTypes.Find((int)Applications.enApplicationType.ReleaseDetainedDrivingLicense).applicationFee;
            newApplication.CreatedByUserID = releasedByUserID;
            

            if(!newApplication.save())
            {
                return false;
            }

            this.releaseApplicationID = newApplication.ID;
            this.isReleased = true;
            this.releasedByUserID = releasedByUserID;
            this.releaseDate = DateTime.Now;
            if(!this.save())
            {
                return false;
            }

            return true;
       

        }
    }
}

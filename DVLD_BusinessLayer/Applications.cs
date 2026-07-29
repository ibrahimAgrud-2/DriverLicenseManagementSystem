using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;


namespace DVLD_BusinessLayer
{
    public class Applications
    {
        public enum enApplicationStatus { New = 1, Canceled = 2, Completed = 3 };
        //Application type'i elle yazmak yerine enum ile verebilirsin.
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };



        public int ApplicationID { set; get; }
        public int ApplicationTypeID { set; get; }
        public ApplicationTypes ApplicationTypeInfo { set; get; }
        public int ApplicantPersonID { set; get; }
        public Person ApplicantPerson { set; get; }
        public DateTime ApplicationDate { set; get; }
        public enApplicationStatus ApplicationStatus;
        public DateTime LastStatusDate { set; get; }
        public double PaidFees { set; get; }
        public int CreatedByUserID { set; get; }
        public User CreatedByUserInfo { set; get; }
        public enum enMode { enAddNew = 1, enUpdate = 2};
        public enMode Mode;
      

        public Applications()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.CreatedByUserID = -1;
            this.ApplicationDate=DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0.0;
            this.Mode = enMode.enAddNew;
        }

        private Applications(int applicationID, int applicantPersonID, DateTime ApplicationDate, int applicationTypeID,
           enApplicationStatus applicationStatus, DateTime LastStatusDate, double paidFee, int createdByUserID)
        {

            this.ApplicationID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = paidFee;
            this.ApplicationTypeInfo = ApplicationTypes.Find(applicationTypeID);
            this.ApplicantPerson = Person.Find(applicantPersonID);
            this.CreatedByUserID = createdByUserID;
            this.CreatedByUserInfo = User.Find(CreatedByUserID);
            this.Mode = enMode.enUpdate;

        }
     
        
        public static DataTable getApplicationsRecord()
        {
            DataTable dt = new DataTable();

            dt = ApplicationsDataAccess.getApplicationsRecord();
            return dt;
        }
        private bool _AddNewApplication()
        {

            this.ApplicationID = ApplicationsDataAccess.addApplication(this.ApplicantPersonID,this.ApplicationDate,this.ApplicationTypeID,(byte)this.ApplicationStatus,this.LastStatusDate,this.PaidFees,this.CreatedByUserID);
            return (this.ApplicationID != -1);

        }

        private bool _UpdateApplication()
        {

            return ApplicationsDataAccess.updateApplicationInfo(this.ApplicationID,this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, Convert.ToByte(this.ApplicationStatus), this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static bool Delete(int applicationID)
        {
            if (isApplicationExist(applicationID))
            {
                return ApplicationsDataAccess.deleteApplication(applicationID);
            }
            return false;

        }
        public bool Delete  ()
        {
            if (isApplicationExist(this.ApplicationID))
            {
                return ApplicationsDataAccess.deleteApplication(this.ApplicationID);
            }
            return false;

        }
     
        public static bool isApplicationExist(int applicationID)
        {
            return ApplicationsDataAccess.isApplicationExistByID(applicationID);
        }

        public static Applications Find(int applicationID)
        {

            int applicantPersonID = -1, createdByUserID = -1, applicationTypeID = -1;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;
            byte applicationStatus = 0;
            double paidFee = 0.0;



            if (ApplicationsDataAccess.findApplication(applicationID, ref applicantPersonID, ref applicationDate, ref applicationTypeID, ref
            applicationStatus, ref lastStatusDate, ref paidFee, ref createdByUserID))
            {
                return new Applications(applicationID, applicantPersonID, applicationDate, applicationTypeID,
            (enApplicationStatus)applicationStatus, lastStatusDate, paidFee, createdByUserID);

            }
            return null;
        }



        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewApplication())
                    {
                        this.Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.enUpdate:
                    return _UpdateApplication();
                default:
                    return false;
            }
        }


        public bool cancel()
        {
            bool canceledSuccessfully= ApplicationsDataAccess.updateStatus(this.ApplicationID, 2);
            if(canceledSuccessfully)
            {
                this.ApplicationStatus = enApplicationStatus.Canceled;
            }
            return canceledSuccessfully;
        }
        public bool setComplete()
        {
            bool canceledSuccessfully = ApplicationsDataAccess.updateStatus(this.ApplicationID, 3);
            if (canceledSuccessfully)
            {
                this.ApplicationStatus = enApplicationStatus.Completed;
            }
            return canceledSuccessfully;
        }
        

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, Applications.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return ApplicationsDataAccess.GetActiveApplicationIDForLicenseClass(PersonID,(int) ApplicationTypeID, LicenseClassID);
        }

    }
}

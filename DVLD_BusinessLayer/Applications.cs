using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;


namespace DVLD_BusinessLayer
{
    public class Applications
    {


        public int ID { set; get; }

        public int ApplicantPersonID { set; get; }
        public People ApplicantPerson { set; get; }

        public DateTime ApplicationDate { set; get; }

        public int ApplicationTypeID { set; get; }
        public ApplicationTypes ApplicationTypeInfo { set; get; }

        public enum enApplicationStatus {New=1,Canceled=2,Completed=3 };
        public enApplicationStatus ApplicationStatus;

        public  DateTime LastStatusDate{ set; get; }

        public double PaidFees { set; get; }


        public int CreatedByUserID { set; get; }


        public enum enMode { enAddNew = 1, enUpdate = 2};
        public enMode Mode;












        public Applications()
        {
            this.ID = -1;
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

            this.ID = applicationID;
            this.ApplicantPersonID = applicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationStatus = applicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = paidFee;
            this.ApplicationTypeInfo = ApplicationTypes.Find(applicationTypeID);
            this.ApplicantPerson = People.Find(applicantPersonID);
            this.CreatedByUserID = createdByUserID;
            this.Mode = enMode.enUpdate;

        }
     
        
        public static DataTable getApplicationsRecord()
        {
            DataTable dt = new DataTable();

            dt = ApplicationsDataAccess.getApplicationsRecord();
            return dt;
        }



        public static Applications FindApplication(int applicationID)
        {

            int applicantPersonID = -1, createdByUserID=-1, applicationTypeID=-1;
            DateTime applicationDate = DateTime.Now, lastStatusDate=DateTime.Now;
            byte applicationStatus = 0;
            double paidFee = 0.0;



            if (ApplicationsDataAccess.findApplication( applicationID, ref  applicantPersonID, ref  applicationDate, ref  applicationTypeID, ref
            applicationStatus, ref lastStatusDate, ref  paidFee, ref  createdByUserID))
            {
                return new Applications(applicationID,  applicantPersonID,  applicationDate, applicationTypeID, 
            (enApplicationStatus)applicationStatus,  lastStatusDate,  paidFee,  createdByUserID);

            }
            return null;
        }


        private bool _AddNewApplication()
        {

            this.ID = ApplicationsDataAccess.addApplication(ApplicantPersonID,ApplicationTypeID,Convert.ToByte(ApplicationStatus),LastStatusDate,PaidFees,CreatedByUserID);
            return (this.ID != -1);

        }

        //Update yaparken lastStatus güncellenmeli.
        private bool _UpdateApplication()
        {
            this.LastStatusDate = DateTime.Now;
            return ApplicationsDataAccess.updateApplicationInfo(this.ID,this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, Convert.ToByte(this.ApplicationStatus), this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }



        public static bool isApplicationExist(int applicationID)
        {
            return ApplicationsDataAccess.isApplicationExistByID(applicationID);
        }

        //Kişinin o başvuru türünden atif bir başvurusu var mı?
        public static bool isApplicationExistByPersonID(int personID,int appType)
        {
           return ApplicationsDataAccess.isApplicationExistByPersonID(personID, appType);
        }
        public static bool deleteApplication(int applicationID)
        {
            if (isApplicationExist(applicationID))
            {
                return ApplicationsDataAccess.deleteApplication(applicationID);
            }
            return false;

        }

        public bool save()
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


    }
}

using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class ApplicationTypes
    {

        public enum enApplicationType
        {
            NewLocalDrivingLicenseService = 1, RenewDrivingLicenseService = 2, ReplacementForLostDrivingLicense = 3, ReplacementForDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicenses = 5,
            NewInternationalLicense = 6, RetakeTest = 7
        }
        public enApplicationType applicationTypeID { set; get; }
        public string applicantTypeTitle { set; get; }

        public double applicationFee { set; get; }



        public ApplicationTypes()
        {
            this.applicationTypeID =enApplicationType.NewLocalDrivingLicenseService ;
            this.applicantTypeTitle = "";
            this.applicationFee = 0.0;

        }

        private ApplicationTypes(enApplicationType applicationTypeID, string applicantTypeTitle, double paidFees)
        {

            this.applicationTypeID = applicationTypeID;
            this.applicantTypeTitle = applicantTypeTitle;
            this.applicationFee = paidFees;
          

        }
        public static DataTable getApplicationTypeRecords()
        {
            DataTable dt = new DataTable();

            dt = ApplicationTypesDataAccess.getApplicationTypesRecords();
            return dt;
        }



        public static ApplicationTypes Find(enApplicationType applicationID)
        {

     
            string applicantTypeTitle = "";
            double paidFees = 0.0;


            if (ApplicationTypesDataAccess.findApplicationType((int)applicationID,ref applicantTypeTitle, ref paidFees))
             
                {
                return new ApplicationTypes(applicationID, applicantTypeTitle, paidFees);
            }
            return null;
        }



        public static bool isApplicationTypeExist(string applicationTypeTitle)
        {
            return ApplicationTypesDataAccess.isApplicationTypeExists(applicationTypeTitle);
        }

        public  bool UpdateApplicationType()
        {
            return ApplicationTypesDataAccess.UpdateApplicationType((int)this.applicationTypeID,this.applicantTypeTitle,this.applicationFee);
        }


    }
}

using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class Licenses
    {
        public int licenseID { set; get; }

        public int applicationID { set; get; }
        public Applications ApplicationInfo;

        public int driverID { set; get; }
        public Driver DriverInfo;


        public int licenseClassID { set; get; }
        public LicenseClass LicenseClassInfo;


        public DateTime issueDate { set; get; }
        public DateTime expirationDate { set; get; }

        public string notes { set; get; }

        
        public double paidFees { set; get; }

        public bool isActive { set; get; }

        public int createdByUserID { set; get; }
        public User UserInfo { set; get; } 


        public double PaidFees { set; get; }

        public enum enMode { enAddNew = 1, enUpdate = 2 }; 
        public enMode mode;
        public enum enIssueReason {FirstTime=1, Renew=2, ReplacementForDamaged =3, ReplacementForLost = 4 };
        public enIssueReason issueReason;




        public Licenses()
        {
            this.licenseID = -1;
            this.applicationID = -1;
            this.driverID = -1;
            this.licenseClassID = -1;
            this.issueDate = DateTime.Now;
            this.expirationDate = DateTime.Now.AddYears(5);
            this.notes = null;
            this.paidFees = 0.0;
            this.isActive = true;
            this.createdByUserID = -1;
            this.PaidFees = 0.0;
            this.issueReason = enIssueReason.FirstTime;
            this.mode = enMode.enAddNew;
        }

        private Licenses(int licenseID, int applicationID, int driverID, int licenseClassID,
            DateTime issueDate, DateTime expirationDate, string notes, double paidFees,
            bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            this.licenseID = licenseID;
            this.applicationID = applicationID;
            this.ApplicationInfo = Applications.Find(applicationID);
            this.driverID = driverID;
            this.DriverInfo = Driver.Find(driverID);
            this.licenseClassID = licenseClassID;
            this.LicenseClassInfo = LicenseClass.Find(licenseClassID);
            this.issueDate = issueDate;
            this.expirationDate = expirationDate;
            this.notes = notes;
            this.paidFees = paidFees;
            this.isActive = isActive;
            this.issueReason = issueReason;
            this.createdByUserID = createdByUserID;
            this.UserInfo = User.Find(createdByUserID);
            this.PaidFees = paidFees;
            this.issueReason = issueReason;
            this.mode = enMode.enUpdate;
        }
        public static DataTable getLicenseRecords()
        {
            DataTable dt = new DataTable();

            dt = LicensesDataAccess.getLicenseRecords();
            return dt;
        }

        public static DataTable getAllLocalLicenseByPersonID(int personID)
        {
            DataTable dt = new DataTable();

            dt = LicensesDataAccess.getAllLocalLicenseByPersonID(personID);
            return dt;
        }

        public static DataTable getAllInternationalLicenseByPersonID(int personID)
        {
            DataTable dt = new DataTable();

            dt = LicensesDataAccess.getAllInternationalLicenseByPersonID(personID);
            return dt;
        }


        public static Licenses Find(int licenseID)
        {
            int applicationID = -1, driverID = -1, licenseClass = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = "";
            double paidFees = 0;
            bool isActive = false;
            int issueReasonInt = 1;

            if (LicensesDataAccess.findLicense(licenseID, ref applicationID, ref driverID, ref licenseClass,
                ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReasonInt, ref createdByUserID))
            {
                return new Licenses(licenseID, applicationID, driverID, licenseClass,
                    issueDate, expirationDate, notes, paidFees, isActive, (enIssueReason)issueReasonInt, createdByUserID);
            }

            return null;
        }

        public static Licenses FindByApplicationID(int applicationID)
        {
            int licenseID = -1, driverID = -1, licenseClass = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = "";
            double paidFees = 0;
            bool isActive = false;
            int issueReasonInt = 1;

            if (LicensesDataAccess.findLicenseByApplicationID(ref licenseID,  applicationID, ref driverID, ref licenseClass,
                ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReasonInt, ref createdByUserID))
            {
                return new Licenses(licenseID, applicationID, driverID, licenseClass,
                    issueDate, expirationDate, notes, paidFees, isActive, (enIssueReason)issueReasonInt, createdByUserID);
            }

            return null;
        }


        private bool _addNewLicense()
        {



            this.licenseID = LicensesDataAccess.addLicense(this.applicationID,this.driverID,this.licenseClassID,this.issueDate,this.expirationDate,this.notes,this.paidFees,this.isActive,Convert.ToInt32(this.issueReason),this.createdByUserID);
            return (this.applicationID != -1);

        }

        private bool _updateLicense()
        {

            return LicensesDataAccess.updateLicenseInfo(this.licenseID,this.driverID,this.licenseClassID,this.expirationDate,this.notes    ,this.paidFees,this.isActive,Convert.ToInt32( this.issueReason));
        }


        public static bool isLicenseExist(int licenseID )
        {
            return LicensesDataAccess.isLicenseExist(licenseID);
        }

        public static bool deleteLicense(int licenseID)
        {
            if (isLicenseExist(licenseID))
            {
                return LicensesDataAccess.deleteLicense(licenseID);
            }
            return false;

        }

        public bool save()
        {
            switch (this.mode)
            {
                case enMode.enAddNew:
                    if (_addNewLicense())
                    {
                        this.mode = enMode.enUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.enUpdate:
                    return _updateLicense();
                default:
                    return false;
            }
        }

        
    }
}

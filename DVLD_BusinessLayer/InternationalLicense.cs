using DVLD_DataAccessLayer;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;


namespace DVLD_BusinessLayer
{
    public class InternationalLicense : Applications
    {

        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public enum enMode { enAddNew = 1, enUpdate = 2 };
        public enMode mode;

        public InternationalLicense()
        {
            this.InternationalLicenseID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddYears(1);
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.mode = enMode.enAddNew;
            //International License için eklenen Application'nin Type'ı  NewInternationalLicense olmalı.  
            this.ApplicationTypeID = (int)Applications.enApplicationType.NewInternationalLicense;

        }

        private InternationalLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             double PaidFees, int CreatedByUserID, int InternationalLicenseID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive)
        {

            base.ApplicationID = ApplicationID;
            base.ApplicantPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;
            base.ApplicationTypeID = (int)Applications.enApplicationType.NewInternationalLicense;
            //base class'ta bulunan person sadece parametreli const içinde find oluyor. O constructor ise burada çağırılmadı için base class'ta person objesi boş kalıyor. Yani Int.Licnse'in base class App dolu ama içinde person boş kalıyor. Bu yüzden person'u burada find yaptık
            base.ApplicantPerson = People.Find(ApplicantPersonID);
          
       

            this.InternationalLicenseID = InternationalLicenseID;
               this.DriverID = driverID;
            this.IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.IsActive = isActive;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationID = ApplicationID;
            this.mode = enMode.enUpdate;
        }


        private bool _AddNewInternationalLicenseInfo()
        {


            this.InternationalLicenseID = InternationalLicenseDataAccess.AddInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
            return (this.InternationalLicenseID != -1);

        }
        private bool _UpdateInternationalLicenseInfo()
        {

            return InternationalLicenseDataAccess.UpdateInternationalLicenseInfo(this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.IssueDate, this.ExpirationDate, this.IsActive, this.CreatedByUserID);
        }


        public static DataTable getInternationalLicenseRecords()
        {
            return InternationalLicenseDataAccess.getInternationalLicenseRecords(); ;
        }
        //bir driver yani bir *kişini* sistemdeli International eyliyetleri  
        public static DataTable getAllInternationalLicenseByPersonID(int DriverID)
        {
            return InternationalLicenseDataAccess.getAllInternationalLicenseByPersonID(DriverID);
        }

//Bir license Finde ederken onun Application bilgilerini de üst sınıfa atmamız gerekir. Bu yüzdene Application'i Find edip constructor içinde üst sınıfa gönderiyoprz.
        public static InternationalLicense Find(int InternationalLicenseID)
        {
           int issuedUsingLocalLicenseID = -1,  createdByUserID = -1, ApplicationID=-1, DriverID=-1;

           DateTime issueDate = DateTime.MinValue,  expirationDate = DateTime.MinValue;

            bool isActive = true;


            if (InternationalLicenseDataAccess.Find(InternationalLicenseID,ref ApplicationID,ref DriverID, ref issuedUsingLocalLicenseID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
            {

                //Aşağıda Applications.Find() ile elde edilen nesne, InternationalLicense nesnesinin base kısmı değildir. O sadece verileri okumak için kullanılan bağımsız bir Applications nesnesidir. InternationalLicense oluşturulurken bu veriler constructor aracılığıyla o anki international license'in base (Applications) kısmına kopyalanır. 
                Applications App = Applications.Find(ApplicationID);

                return new InternationalLicense(App.ApplicationID,App.ApplicantPersonID,App.ApplicationDate,App.ApplicationStatus,App.LastStatusDate,App.PaidFees,App.CreatedByUserID,InternationalLicenseID,  DriverID,  issuedUsingLocalLicenseID,  issueDate,  expirationDate,  isActive);
            }
            return null;
        }


     
        public bool Save()
        {

            //Bu sınıf App'ten inheritance olduğu için save yaptığımızda önce üst sınıf save olmalı sonra bu sınıf. Zaten DB'de de International license tablosında APP ID isteniyor. bu yüzden Önce APP kayıt etmelisin sonra Int.License kayıt etmelisin.
            base.Mode = (Applications.enMode)mode;
            if (!base.Save())
                return false;

            switch (this.mode)
            {
                case enMode.enAddNew:
                    if (_AddNewInternationalLicenseInfo())
                    {
                        this.mode = enMode.enUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.enUpdate:
                    return _UpdateInternationalLicenseInfo();
                default:
                    return false;
            }
        }



        //Bir driver'İn yani *kişinin* Aktif Int.License varsa ID'sini dönderir.
        public static int GetActiveInternationalLicenseIDByDriverID(int driverID)
        {
            return InternationalLicenseDataAccess.GetActiveInternationalLicenseIDByDriverID(driverID);
        }

    }
}

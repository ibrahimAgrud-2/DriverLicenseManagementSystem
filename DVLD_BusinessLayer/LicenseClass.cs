using DVLD_DataAccessLayer;
using System;
using System.Data;


namespace DVLD_BusinessLayer
{
    public class LicenseClass
    {
        public enum enLicenseClass
        {
            SmallMotorcycle = 1, HeavyMotorcycleLicense = 2, OrdinaryDrivingLicense = 3, Commercial = 4, Agricultural = 5, SmallAndMediumBus = 6, TruckAndHeavyVehicle = 7
        }


        public enLicenseClass ID { set; get; }

        string className { set; get; }
        string classDescription { set; get; }
        int minimumAge { set; get; }
        int defaultValidityLength { set; get; }
        double classFee { set; get; }

       public LicenseClass()
        {
            this.ID = enLicenseClass.OrdinaryDrivingLicense;
            this.className = "";
            this.classDescription = "";
            this.minimumAge = 0;
            this.defaultValidityLength = 0;
            this.classFee = 0.0;
        }


        public LicenseClass(enLicenseClass licenseClassID,  string className,  string classDescription,  int minimumAge,  int defaultValidityLength, double classFee)
        {
            this.ID = licenseClassID;
            this.className = className;
            this.classDescription = classDescription;
            this.minimumAge = minimumAge;
            this.defaultValidityLength = defaultValidityLength;
            this.classFee = classFee;
        }

        public static DataTable getAllClassLicenseRecords()
        {
            return LicenseClassesDataAccess.getLicenseClassesRecords();
        }

        public static LicenseClass findLicenseClass(enLicenseClass licenseClassID)
        {
            string className="", classDescription="";
            int minimumAge=1, defaultValidityLength=1;
            double classFee=0.0;

            if (LicenseClassesDataAccess.findLicenseClass((int)licenseClassID,ref className, ref classDescription, ref minimumAge, ref defaultValidityLength, ref classFee))
            {
                return new LicenseClass(licenseClassID,  className,  classDescription,  minimumAge,  defaultValidityLength,  classFee);

            }
            return null;
        }

        public static bool isCLicenseClassExist(int licenseClassID)
        {
            return LicenseClassesDataAccess.isLicenseClassExit(licenseClassID);
        }


    }
}

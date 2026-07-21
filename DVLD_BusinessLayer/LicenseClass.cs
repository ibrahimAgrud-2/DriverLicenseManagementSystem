using DVLD_DataAccessLayer;
using System;
using System.Data;


namespace DVLD_BusinessLayer
{
    public class LicenseClass
    {



        public int ID { set; get; }

        public string className { set; get; }
        public string classDescription { set; get; }
        public int minimumAge { set; get; }
        public int defaultValidityLength { set; get; }
        public double classFee { set; get; }

       public LicenseClass()
        {
            this.ID = -1;
            this.className = "";
            this.classDescription = "";
            this.minimumAge = 0;
            this.defaultValidityLength = 0;
            this.classFee = 0.0;
        }


        public LicenseClass(int licenseClassID,  string className,  string classDescription,  int minimumAge,  int defaultValidityLength, double classFee)
        {
            this.ID = licenseClassID;
            this.className = className;
            this.classDescription = classDescription;
            this.minimumAge = minimumAge;
            this.defaultValidityLength = defaultValidityLength;
            this.classFee = classFee;
        }

        public static DataTable getAllRecords()
        {
            return LicenseClassesDataAccess.getLicenseClassesRecords();
        }

        public static LicenseClass Find(int licenseClassID)
        {
            string className="", classDescription="";
            int minimumAge=1, defaultValidityLength=1;
            double classFee=0.0;

            if (LicenseClassesDataAccess.findLicenseClassByID(licenseClassID,ref className, ref classDescription, ref minimumAge, ref defaultValidityLength, ref classFee))
            {
                return new LicenseClass(licenseClassID,  className,  classDescription,  minimumAge,  defaultValidityLength,  classFee);

            }
            return null;
        }
        public static LicenseClass Find(string licenseClassTitle)
        {
            string classDescription = "";
            int minimumAge = 1, defaultValidityLength = 1,classID=-1;
            double classFee = 0.0;

            if (LicenseClassesDataAccess.findLicenseClassByClassName(ref classID, licenseClassTitle, ref classDescription, ref minimumAge, ref defaultValidityLength, ref classFee))
            {
                return new LicenseClass(classID, licenseClassTitle, classDescription, minimumAge, defaultValidityLength, classFee);

            }
            return null;
        }

        public static bool isCLicenseClassExist(int licenseClassID)
        {
            return LicenseClassesDataAccess.isLicenseClassExit(licenseClassID);
        }


    }
}

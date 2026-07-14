using DVLD_DataAccessLayer;
using System;
using System.Data;



namespace DVLD_BusinessLayer
{
    public class People
    {
  
        public int personID { set; get; }
        public string nationalNo { set; get; }
        public string firstName { set; get; }
        public string secondName { set; get; }
        public string thirdName { set; get; }
        public string lastName { set; get; }
        public DateTime dateOfBirth { set; get; }
        public int gender { set; get; }
        public string address { set; get; }
        public string email { set; get; }
        public string phone { set; get; }
        public string imagePath { set; get; }


        public int countryID { set; get; }

        private Country _Country1;
        public Country Country
        {
            get
            {
                if (_Country1 == null)
                    _Country1 = Country.findCountryByID(countryID);
                return _Country1;
            }
        }

        public enum enMode { enAddNew = 1, enUpdate = 2 };
        //Her object 2 farklı modu olur. Ya yeni üretilmiştir modu add ya da sitemde zaten vardır
        //ki bunuda find ile bulmuşuzdur modu update. Bunuda diğer propertylerden farkı yoktur.
        public enMode mode=enMode.enAddNew;


        //static olmalı çünkü obje oluşturulmadan erişebilmeliyiz.
        public static DataTable getAllPersonRecords()
        {
            return PeopleDataAccess.getAllPeople();
        }




        //[TR]
        //Bu const'ı private yaptık ki dışardan erişilmesin. Çünkü bu constractır bir objenin ID dahil
        //tüm bilgilerini ister, dolaysıyla dışardan hiç bir şekilde ID'e direk erişim olmadığı için
        //bu const ile dışarda obje oluşturamayız. * Bu const ile sadece DB'de var olan contact'ı/objeyi sistemde
        //kullanmak istediğimiz zaman bu const ile oluştururuz.
        //Mesela bunu find fonksiyonunda kullandık. Çünkü bir contact DB de bulunursa sistemde
        //kullanılabilmesi için bu const gerekir.
        private People(int personID,string nationalNo, string firstName, string secondName,
           string thirdName, string lastName, DateTime dateOfBirth,
           int gender, string address, string email, string phone,
           int countryID, string imagePath)
        {

            this.personID = personID;
            this.nationalNo = nationalNo;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
            this.address = address;
            this.email = email;
            this.phone = phone;
            this.countryID = countryID;
            this.imagePath = imagePath;
            //[TR]
            //Bu cost DB'de var olan bir objeyi sistemde oluşturmak için kullanıldığı için
            //modu add olamaz. update olmalı; çünkü zaten sistemde var.
            this.mode = enMode.enUpdate;
        }



        private bool _addNewRecord()
        {

            //[TR]
            //ID otomatik olarak verildiği için database ID veremeyiz;çünkü ID identicle yani DB tradında ototmatik veriliyor.
            // executeScaler'de kullanrak eklenen satırın ID'sini alıyoruz ve bunu ID'siz olan objecte ekliyoruz.
            //burada göderdiğimiz objeler ekleme yapılmadan önce ID'si olmuyor biz kullanıcıdan ID istemiyoruz ID database atıyor. 
            //burda eğer this.ID= demeseydik ilgili objenin ID'sı DB'de olursa ama burada henüz gelmemiş olurdu bizde eğer direk o objeyi sistemde kullanmaya kalkarsak ID'den hata alırız.

            this.personID = PeopleDataAccess.AddNewPerson(this.nationalNo, this.firstName, this.secondName, this.thirdName, this.lastName, this.dateOfBirth, this.gender, this.address, this.email, this.phone, this.countryID, this.imagePath);

            return (this.personID != -1);
        }




        
        //[TR] Sadece parametresiz const public. Ayrıca parametresiniz const ile oluşturacağımız objenin mode add;
        //çünkü sistemde henüz yok, eğer olmayan obje için save fonksiyonu çağırılırsa add yapılsın yani sisteme eklensin diye.
        public  People()
        {
            this.personID = -1;
            this.nationalNo = "";
            this.firstName = "";
            this.secondName = "";
            this.thirdName = "";
            this.lastName =  "";
            this.dateOfBirth = DateTime.Now;
            this.gender = 0;
            this.address =   "";
            this.email =   "";
            this.phone =  "";
            this.countryID = -1;
            this.imagePath = ""; ;
            this.mode = enMode.enAddNew;
            
        }

        //Find ile bulunan obje parametreli const ile oluşturulduğu için modu update olsun çünkü artık obje var ve add'lik bir durum kalmamış. Artık yaparsak update yaparız
        public static People findPersonByID(int personID)
        {
            
            string nationalNo="", firstName = "", secondName = "",thirdName = "",lastName = "", address = "", email = "", phone = "", imagePath = "";
            DateTime dateOfBirth=DateTime.Now;
            int gender=-1,countryID=-1;
            
           
            if (PeopleDataAccess.findPersonByID(personID, ref nationalNo, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender, ref address, ref email, ref phone, ref countryID, ref imagePath))
            {
                return new People(personID, nationalNo, firstName, secondName, thirdName, lastName, dateOfBirth, gender, address, email, phone, countryID, imagePath);
              
            }
            return null;
        }

        public static People findPersonByNationalNo(string nationalNo)
        {

            string firstName = "", secondName = "", thirdName = "", lastName = "", address = "", email = "", phone = "", imagePath = "";
            DateTime dateOfBirth = DateTime.Now;
            int personID=-1, gender = -1, countryID = -1;


    

            if (PeopleDataAccess.findPersonByNationalNo(ref personID, nationalNo, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender, ref address, ref email, ref phone, ref countryID, ref imagePath))
            {
                return new People(personID, nationalNo, firstName, secondName, thirdName, lastName, dateOfBirth, gender, address, email, phone, countryID, imagePath);
            }
            return null;
        }


        //bu fonkisyonun parameter almasında gerek yok çünkü ben bir objeyinin istediğimi kısımlarını güncellerim sonra save ile update yaparım.
        private bool _updateInfo()
        {
          
            return PeopleDataAccess.UpdatePersonInfo(this.personID, this.nationalNo, this.firstName, this.secondName, this.thirdName, this.lastName, this.dateOfBirth, this.gender, this.address, this.email, this.phone, this.countryID, this.imagePath);
        }

        //ID vermelisin çünkü bu fonk obje olmadan çağıralacak.
        public static bool isPersonExistByID(int personID)
        {
            return PeopleDataAccess.IsPersonExist(personID);
        }
        //TC sistemde var mı yoku kontrol edeceğiz bu sayede aynı TC ile sisteme kayıt olunmasın. Şu anlık DB'de bunu nasıl kontrol ederiz bilemiyorum. Veya bu yöntem daha hızlı olduğu için bunu tercih ederim.
        public static bool isPersonExistByNationalNo(string NationalNo)
        {
            return PeopleDataAccess.IsPersonExist(NationalNo);
        }



        //bir objeyi silmek için onu ayrıyeten DB'den programam yüklemem gerek yok bu yüzden static yapıp sadece ID alarak silmek istedim. static olmayadabilirdi. Bu durumda fonk public olur ve obje.delete diyeceğimiz için ID'İ parametre olarak bu fonksyion'a vermemiz gerekmezdi, this kullanarak ID alırdık (çünkü program o anki obje üzerin olurdu)
        public static bool delete(int personID)
        {
            if (isPersonExistByID(personID))
            { 
                return PeopleDataAccess.DeletePerson(personID);
            }
            return false;
          
        }
        
        public bool save()
        {
            switch (this.mode)
            {
                case enMode.enAddNew:
                    if(_addNewRecord())
                    {
                        //[TR]
                        //ekleme tamamlandığı için ve dolaysıyla bu contact sistemde olduğu için artık
                        //modu add yerine update yaparız. Save update için de kullanıldığı için
                        //eğer o anki objeyi update yapmak istediğindinde sisteme tekrar kayıt eder.
                        this.mode = enMode.enUpdate;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.enUpdate:
                            return _updateInfo();
                        default:
                            return false;
                        }
        }


        public bool sendEmail(string from ,string to,string body)
        {
            return false;
        }
        public bool call(string phoneNumber)
        {
            return false;
        }

    }
   
}

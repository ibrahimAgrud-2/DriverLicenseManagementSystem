using DVLD_BusinessLayer;
using System;


namespace DVLD
{
    public class loginSettings
    {

        public static User currentUser;
        public static string filePath = @"C:\Users\ibrah\source\repos\DVLD\DVLD\UserRememberMeJustID.txt";
        //the separator in file. Example: user1##password
        public static string dim = "##";
    }

}

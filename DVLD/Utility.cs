using System;
using System.Text.RegularExpressions;


namespace DVLD
{
    public class Utility
    {
        public bool IsEmailValid(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            return regex.IsMatch(email);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Global_Classes
{
    internal class Validation
    {
        public static bool IsEmailValid(string email)
        {
            var regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            return regex.IsMatch(email);
        }

    }
}

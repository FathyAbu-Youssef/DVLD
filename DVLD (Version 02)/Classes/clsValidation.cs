using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD__Version_02_.Classes
{
    public static class clsValidation
    {
        public static bool ValidateEmail(string EmailText)
        {
            string Pattern = @"^[\w\.-]+@([\w-]+\.)+[a-zA-Z]{2,}$";

            Regex reg = new Regex(Pattern);

            return reg.IsMatch(EmailText);      
        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateNumber(string Number)
        {
            return ValidateFloat(Number) || ValidateInteger(Number);
        }
    }
}

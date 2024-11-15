using DevExpress.XtraBars.Ribbon.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank.Global_Classes
{
    public static class clsValidations
    {
        public static bool IsValidEmail(string Email)
        {
            string Patern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(Patern);
            return regex.IsMatch(Email);
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

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }
    }
}

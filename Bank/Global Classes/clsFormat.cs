using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Global_Classes
{
    public static class clsFormat
    {
        public static string GetDateFormat(DateTime date)
        {
            return date.ToString("dd/MMM/yyyy");
        }
    }
}

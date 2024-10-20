using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBussiness
{
    public class clsCountry
    { 
        public int CountryID {  get; set; } 
        public string CountryName { get; set; }

        clsCountry(int CountryID,string CountryName) 
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry FindByID(int CountryID)
        {
            string CountryName = "";
            if (clsCountryData.GetCountryByID(CountryID,ref CountryName))
            {
                return new clsCountry(CountryID,CountryName);
            }else
            {
                return null;
            }
        }

        public static clsCountry FindByName(string CountryName)
        {
            int CountryID = -1;
            if (clsCountryData.GetCountryByName(CountryName,ref CountryID))
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetAllCountries()
        {
           return clsCountryData.GetAllCountries();
        }
    
    }
}

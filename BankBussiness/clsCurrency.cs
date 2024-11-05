using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataAccess;
namespace BankBussiness
{



    public class clsCurrencie
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;



        public int CurrencyID { set; get; }
        public string CountryName { set; get; }
        public string CurrencyCode { set; get; }
        public string CurrencyName { set; get; }
        public float Rate { set; get; }


        public clsCurrencie()
        {
            this.CurrencyID = default;
            this.CountryName = default;
            this.CurrencyCode = default;
            this.CurrencyName = default;
            this.Rate = default;
            _Mode = enMode.enAddNew;
        }


        private clsCurrencie(int CurrencyID, string CountryName, string CurrencyCode, string CurrencyName, float Rate)
        {
            this.CurrencyID = CurrencyID;
            this.CountryName = CountryName;
            this.CurrencyCode = CurrencyCode;
            this.CurrencyName = CurrencyName;
            this.Rate = Rate;
            _Mode = enMode.enUpdate;
        }



        private bool _AddNewCurrency()
        {
            CurrencyID = clsCurrencyData.AddNewCurrency( CountryName, CurrencyCode, CurrencyName, Rate);

            return (CurrencyID != -1);
        }


        private bool _UpdateCurrencie()
        {
            return clsCurrencyData.UpdateCurrencyByID(CurrencyID, CountryName, CurrencyCode, CurrencyName, Rate);
        }


        public static clsCurrencie FindCurrencieByID(int CurrencyID)
        {
      
            string CountryName = default;
            string CurrencyCode = default;
            string CurrencyName = default;
            float Rate = default;
            if (clsCurrencyData.GetCurrencyByID( CurrencyID, ref CountryName, ref CurrencyCode, ref CurrencyName, ref Rate))
            {
                return new clsCurrencie(CurrencyID, CountryName, CurrencyCode, CurrencyName, Rate);
            }
            else
            {
                return null;
            }
        }


        public static bool IsExistByCurrencieID(int CurrencyID)
        {
            return clsCurrencyData.IsCurrencyExistByCurrencyID(CurrencyID);
        }


        public static bool DeleteCurrencie(int CurrencyID)
        {
            return clsCurrencyData.DeleteCurrencyByID(CurrencyID);
        }


        public static DataTable GetCurrenciesList()
        {
            return clsCurrencyData.GetAllCurrencies();
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewCurrency())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateCurrencie())
                        return true;
                    else
                        return false;
            }
            return false;
        }
    }
}

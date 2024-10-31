using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBussiness
{
    public class clsAccountType
    {
        /*
         int    AccountTypeID
         string AccountTypeName
         float  InterestRate
         double WithdrawalLimit
         double MinimumBalance
         string Description
         */
        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;
        public int AccountTypeID { set; get; }
        public string AccountTypeName { set; get; }
        public float InterestRate { set; get; }
        public double WithdrawalLimit { set; get; }
        public double MinimumBalance { set; get; }
        public string Description { set; get; }
       

        public clsAccountType()
        {
            this.AccountTypeID = -1;
            this.AccountTypeName = "";
            this.InterestRate = 0.0f;
            this.WithdrawalLimit = 0.0d;
            this.MinimumBalance = 0.0d;
            this.Description = "";
            

            _Mode = enMode.enAddNew;
        }
        private clsAccountType(int AccountTypeID, string AccountTypeName, float InterestRate, double WithdrawalLimit, double MinimumBalance, string Description)
        {
            this.AccountTypeID = AccountTypeID;
            this.AccountTypeName = AccountTypeName;
            this.InterestRate = InterestRate;
            this.WithdrawalLimit = WithdrawalLimit;
            this.MinimumBalance = MinimumBalance;
            this.Description = Description;

            _Mode = enMode.enUpdate;
        }
        private bool _AddNewAccountType()
        {
            return true;
        }
        private bool _UpdateAccountType()
        {
            return clsAccountTypeData.UpdateAccountTypeByID(AccountTypeID, AccountTypeName, InterestRate,WithdrawalLimit,MinimumBalance,Description);
        }
        public static clsAccountType FindAccountTypeByID(int AccountTypeID)
        {
            string AccountTypeName = "";
            float InterestRate = 0.0f;
            double WithdrawalLimit = 0.0d;
            double MinimumBalance = 0.0d;
            string Description = "";
           

            if (clsAccountTypeData.GetAccountTypeByID(AccountTypeID, ref AccountTypeName, ref InterestRate, ref WithdrawalLimit, ref MinimumBalance, ref Description))
            {
                return new clsAccountType(AccountTypeID, AccountTypeName, InterestRate, WithdrawalLimit, MinimumBalance, Description);
            }
            else
            {
                return null;
            }
        }
        public static clsAccountType FindAccountTypeByName(string AccountTypeName)
        {
            int AccountTypeID = -1;           
            float InterestRate = 0.0f;
            double WithdrawalLimit = 0.0d;
            double MinimumBalance = 0.0d;
            string Description = "";

            if (clsAccountTypeData.GetAccountTypeByName(AccountTypeName, ref AccountTypeID, ref InterestRate, ref WithdrawalLimit, ref MinimumBalance, ref Description))
            {
                return new clsAccountType(AccountTypeID, AccountTypeName, InterestRate, WithdrawalLimit, MinimumBalance, Description);
            }
            else
            {
                return null;
            }
        }
        public static bool DeleteAccountType(int AccountTypeID)
        {
            return clsAccountTypeData.DeleteAccountTypeByID(AccountTypeID);
        }
        public static DataTable GetAccountTypesList()
        {
            return clsAccountTypeData.GetAllAccountTypes();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewAccountType())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateAccountType())
                        return true;
                    else
                        return false;
            }
            return false;
        }
    }
}

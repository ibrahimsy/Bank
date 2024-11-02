using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBussiness
{
    /*
        int         AccountID
        int         ClientID
        string      AccountNumber
        bool        IsPrimary
        int         AccountID
        double      Balance
        byte        AccountStatus
        DateTime    DateOpened
        DateTime    DateClosed
        int         BranchID
        DateTime    LastTransactionDate
        string      Notes
        int         CreatedBy
     */
    public class clsAccount
    {
        public enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        public enum enAccountStatus { Active = 1,InActive = 2,Closed = 3,Pending = 4,Frozen = 5,Blocked = 6}

        public int AccountID { get; set; }
        public int ClientID { get; set; }

        public clsClient ClientInfo;
        public string AccountNumber { get; set; }

        public bool IsPrimary {  get; set; }
        public int AccountTypeID { get; set; }

        public clsAccountType AccountTypeInfo;
  
        public double Balance { get; set; }
        public byte AccountStatus { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public int BranchID { get; set; }

        public clsBranch BranchInfo;
        public DateTime? LastTransactionDate { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }

        public clsUser UserInfo;
        public clsAccount()
        {
            this.AccountID = -1;
            this.ClientID = -1;
            this.AccountNumber = "";
            this.AccountTypeID = -1;
            this.IsPrimary = false;
            this.Balance = 0d;
            this.AccountStatus = 1;
            this.DateOpened = DateTime.Now;
            this.DateClosed = DateTime.Now;
            this.BranchID = -1;
            this.LastTransactionDate = DateTime.Now;
            this.Notes = "";
            this.CreatedBy = -1;
           
        }

        private clsAccount(int AccountID, int ClientID, string AccountNumber,bool IsPrimary, int AccountTypeID, double Balance,
                byte AccountStatus,DateTime DateOpened,DateTime? DateClosed,int BranchID,DateTime? LastTransactionDate,string Notes,int CreatedBy)
        {
             this.AccountID = AccountID;
             this.ClientID = ClientID;
             this.ClientInfo = clsClient.FindClientByID(this.AccountID);
             this.AccountNumber = AccountNumber;
             this.AccountTypeID = AccountTypeID;
             this.AccountTypeInfo = clsAccountType.FindAccountTypeByID(this.AccountTypeID);
             this.IsPrimary = IsPrimary;
             this.Balance = Balance;
             this.AccountStatus = AccountStatus;
             this.DateOpened = DateOpened;
             this.DateClosed = DateClosed;
             this.BranchID = BranchID;
             this.BranchInfo = clsBranch.FindBranchByID(this.BranchID);
             this.LastTransactionDate = LastTransactionDate;
             this.Notes = Notes;
             this.CreatedBy = CreatedBy;
             this.UserInfo = clsUser.FindUserByID(this.CreatedBy);
        }

        private bool _AddNewAccount()
        {
            AccountID = clsAccountData.AddNewAccount( ClientID,  AccountNumber,IsPrimary,  AccountTypeID,  Balance,
                                 AccountStatus,  DateOpened,  DateClosed,  BranchID,  LastTransactionDate,  Notes,  CreatedBy);

            return (AccountID != -1);
        }

        private bool _UpdateAccount()
        {
            return clsAccountData.UpdateAccountByID(AccountID, ClientID,  AccountNumber,IsPrimary,  AccountTypeID,  Balance,
                                 AccountStatus,  DateOpened,  DateClosed,  BranchID,  LastTransactionDate,  Notes,  CreatedBy);
        }

        public static clsAccount FindAccountByID(int AccountID)
        {
            int ClientID = -1;
            string AccountNumber = "";
            int AccountTypeID = -1;
            bool IsPrimary = false;
            double Balance = 0d;
            byte AccountStatus = 1;
            DateTime DateOpened = DateTime.Now;
            DateTime? DateClosed = DateTime.Now;
            int BranchID = -1;
            DateTime? LastTransactionDate = DateTime.Now;
            string Notes = "";
            int CreatedBy = -1;


            if (clsAccountData.GetAccountByID(AccountID,ref ClientID,ref AccountNumber,ref IsPrimary,ref AccountTypeID,ref Balance,
                                 ref AccountStatus,ref DateOpened,ref DateClosed,ref BranchID,ref LastTransactionDate,ref Notes,ref CreatedBy))
            {
                return new clsAccount(AccountID ,ClientID,  AccountNumber,IsPrimary,  AccountTypeID,Balance,
                                  AccountStatus,  DateOpened, DateClosed, BranchID,  LastTransactionDate,  Notes,  CreatedBy);
            }
            else
            {
                return null;
            }
        }

        public static clsAccount FindAccountByAccountNumber(string AccountNumber)
        {
            int AccountID = -1;
            int ClientID = -1;
            int AccountTypeID = -1;
            bool IsPrimary = false;
            double Balance = 0d;
            byte AccountStatus = 1;
            DateTime DateOpened = DateTime.Now;
            DateTime? DateClosed = DateTime.Now;
            int BranchID = -1;
            DateTime? LastTransactionDate = DateTime.Now;
            string Notes = "";
            int CreatedBy = -1;

            if (clsAccountData.GetAccountByAccountNumber(AccountNumber, ref AccountID, ref ClientID,ref IsPrimary, ref AccountTypeID,  ref Balance,
                                 ref AccountStatus, ref DateOpened, ref DateClosed, ref BranchID, ref LastTransactionDate, ref Notes, ref CreatedBy))
            {
                return new clsAccount(AccountID, ClientID, AccountNumber,IsPrimary, AccountTypeID,  Balance,
                                  AccountStatus, DateOpened, DateClosed, BranchID, LastTransactionDate, Notes, CreatedBy);
            }
            else
            {
                return null;
            }
        }

        public static clsAccount FindPrimaryAccountByClientID(int ClientID)
        {
            int AccountID = -1;
            string AccountNumber = "";
            int AccountTypeID = -1;
            bool IsPrimary = false;
            double Balance = 0d;
            byte AccountStatus = 1;
            DateTime DateOpened = DateTime.Now;
            DateTime? DateClosed = DateTime.Now;
            int BranchID = -1;
            DateTime? LastTransactionDate = DateTime.Now;
            string Notes = "";
            int CreatedBy = -1;

            if (clsAccountData.GetPrimaryAccountNumberByClientID(ClientID, ref AccountID, ref AccountNumber, ref IsPrimary, ref AccountTypeID, ref Balance,
                                 ref AccountStatus, ref DateOpened, ref DateClosed, ref BranchID, ref LastTransactionDate, ref Notes, ref CreatedBy))
            {
                return new clsAccount(AccountID, ClientID, AccountNumber, IsPrimary, AccountTypeID, Balance,
                                  AccountStatus, DateOpened, DateClosed, BranchID, LastTransactionDate, Notes, CreatedBy);
            }
            else
            {
                return null;
            }
        }
       
        public static bool IsExistByAccountID(int AccountID)
        {
            return clsAccountData.IsAccountExistByAccountID(AccountID);
        }

        public static bool IsExistByAccountNumber(string AccountNumber)
        {
            return clsAccountData.IsAccountExistByAccountNumber(AccountNumber);
        }

        public static bool DeleteAccount(int AccountID)
        {
            return clsAccountData.DeleteAccountByID(AccountID);
        }
       
        public static DataTable GetAccountsList()
        {
            return clsAccountData.GetAllAccounts();
        }
        
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewAccount())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateAccount())
                        return true;
                    else
                        return false;
            }
            return false;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBussiness
{
    /*
        int         AccountID
        int         ClientID
        string      AccountNumber
        int         AccountID
        short       PinCode
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

        enum enAccountStatus { Active = 1,InActive = 2,Closed = 3,Pending = 4,Frozen = 5,Blocked = 6}

        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public string AccountNumber { get; set; }
        public int AccountTypeID { get; set; }
        public short PinCode { get; set; }
        public double Balance { get; set; }
        public byte AccountStatus { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime DateClosed { get; set; }
        public int BranchID { get; set; }
        public DateTime LastTransactionDate { get; set; }
        public string Notes { get; set; }
        public int CreatedBy { get; set; }

        public clsAccount()
        {
            this.AccountID = -1;
            this.ClientID = -1;
            this.AccountNumber = "";
            this.AccountTypeID = -1;
            this.PinCode = 0;
            this.Balance = 0d;
            this.AccountStatus = 1;
            this.DateOpened = DateTime.Now;
            this.DateClosed = DateTime.Now;
            this.BranchID = -1;
            this.LastTransactionDate = DateTime.Now;
            this.Notes = "";
            this.CreatedBy = -1;
        }

        private clsAccount(int AccountID, int ClientID, string AccountNumber, int AccountTypeID, short PinCode, double Balance,
                byte AccountStatus,DateTime DateOpened,DateTime DateClosed,int BranchID,DateTime LastTransactionDate,string Notes,int CreatedBy)
        {
             this.AccountID = AccountID;
             this.ClientID = ClientID;
             this.AccountNumber = AccountNumber;
             this.AccountTypeID = AccountTypeID;
             this.PinCode = PinCode;
             this.Balance = Balance;
             this.AccountStatus = AccountStatus;
             this.DateOpened = DateOpened;
             this.DateClosed = DateClosed;
             this.BranchID = BranchID;
             this.LastTransactionDate = LastTransactionDate;
             this.Notes = Notes;
             this.CreatedBy = CreatedBy;
        }
    }
}

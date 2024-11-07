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



    public class clsTransaction
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        public enum enTransactionType { Withdraw = 1,Deposit = 2,Transfer = 3 };
        public enum enTransactionStatus { Completed = 1,Cancelled = 2,Faild = 3 };
        public int TransactionID { set; get; }
        public int AccountID { set; get; }
        public DateTime TransactionDate { set; get; }
        public byte TransactionType { set; get; }
        public decimal Amount { set; get; }
        public decimal BalanceAfterTransaction { set; get; }
        public int CurrencyID { set; get; }
        public string Description { set; get; }
        public byte Status { set; get; }
        public string ReferenceNumber { set; get; }
        public int SourceAccountID { set; get; }
        public int DestinationAccountID { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
      


        public clsTransaction()
        {
            this.TransactionID = -1;
            this.AccountID = -1;
            this.TransactionDate = DateTime.Now;
            this.TransactionType = (byte)enTransactionType.Deposit;
            this.Amount = 0;
            this.BalanceAfterTransaction = 0;
            this.CurrencyID = -1;
            this.Description = "";
            this.Status = (byte)enTransactionStatus.Completed;
            this.ReferenceNumber = "";
            this.SourceAccountID = -1;
            this.DestinationAccountID = -1;
            this.CreatedBy = -1;
            this.CreatedDate = DateTime.Now;
            
            _Mode = enMode.enAddNew;
        }

        private clsTransaction(int TransactionID, int AccountID, DateTime TransactionDate, byte TransactionType, decimal Amount, decimal BalanceAfterTransaction, int CurrencyID, string Description, byte Status, string ReferenceNumber, int SourceAccountID, int DestinationAccountID, int CreatedBy, DateTime CreatedDate)
        {
            this.TransactionID = TransactionID;
            this.AccountID = AccountID;
            this.TransactionDate = TransactionDate;
            this.TransactionType = TransactionType;
            this.Amount = Amount;
            this.BalanceAfterTransaction = BalanceAfterTransaction;
            this.CurrencyID = CurrencyID;
            this.Description = Description;
            this.Status = Status;
            this.ReferenceNumber = ReferenceNumber;
            this.SourceAccountID = SourceAccountID;
            this.DestinationAccountID = DestinationAccountID;
            this.CreatedBy = CreatedBy;
            this.CreatedDate = CreatedDate;
           
            _Mode = enMode.enUpdate;
        }


        private bool _AddNewTransaction()
        {
            TransactionID = clsTransactionData.AddTransaction(AccountID, TransactionDate, TransactionType, Amount, BalanceAfterTransaction, CurrencyID, Description, Status, SourceAccountID, DestinationAccountID, CreatedBy, CreatedDate);

            return (TransactionID != -1);
        }


        private bool _UpdateTransaction()
        {
            return clsTransactionData.UpdateTransactionByID(TransactionID, AccountID, TransactionDate, TransactionType, Amount, BalanceAfterTransaction, CurrencyID, Description, Status, SourceAccountID, DestinationAccountID, CreatedBy, CreatedDate);
        }


        public static clsTransaction FindTransactionByID(int TransactionID)
        {

            int AccountID = -1;
            DateTime TransactionDate = DateTime.Now;
            byte TransactionType = 1;
            decimal Amount = 0;
            decimal BalanceAfterTransaction = 0;
            int CurrencyID = -1;
            string Description = "";
            byte Status = 1;
            string ReferenceNumber = "";
            int SourceAccountID = -1;
            int DestinationAccountID = -1;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
           
            if (clsTransactionData.GetTransactionByID(TransactionID, ref AccountID, ref TransactionDate, ref TransactionType, ref Amount, ref BalanceAfterTransaction, ref CurrencyID, ref Description, ref Status, ref ReferenceNumber, ref SourceAccountID, ref DestinationAccountID, ref CreatedBy, ref CreatedDate))
            {
                return new clsTransaction(TransactionID, AccountID, TransactionDate, TransactionType, Amount, BalanceAfterTransaction, CurrencyID, Description, Status, ReferenceNumber, SourceAccountID, DestinationAccountID, CreatedBy, CreatedDate);
            }
            else
            {
                return null;
            }
        }


        public static bool IsExistByTransactionID(int TransactionID)
        {
            return clsTransactionData.IsTransactionExistByTransactionID(TransactionID);
        }


        public static bool DeleteTransaction(int TransactionID)
        {
            return clsTransactionData.DeleteTransactionByID(TransactionID);
        }


        public static DataTable GetTransactionsList()
        {
            return clsTransactionData.GetAllTransactions();
        }

       


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewTransaction())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateTransaction())
                        return true;
                    else
                        return false;
            }
            return false;
        }


    }
}

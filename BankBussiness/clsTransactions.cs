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
        public string SourceAccountID { set; get; }
        public string DestinationAccountID { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public int UpdatedBy { set; get; }
        public DateTime UpdatedDate { set; get; }


        public clsTransaction()
        {
            this.TransactionID = default;
            this.AccountID = default;
            this.TransactionDate = default;
            this.TransactionType = default;
            this.Amount = default;
            this.BalanceAfterTransaction = default;
            this.CurrencyID = default;
            this.Description = default;
            this.Status = default;
            this.ReferenceNumber = default;
            this.SourceAccountID = default;
            this.DestinationAccountID = default;
            this.CreatedBy = default;
            this.CreatedDate = default;
            this.UpdatedBy = default;
            this.UpdatedDate = default;
            _Mode = enMode.enAddNew;
        }

        private clsTransaction(int TransactionID, int AccountID, DateTime TransactionDate, byte TransactionType, decimal Amount, decimal BalanceAfterTransaction, int CurrencyID, string Description, byte Status, string ReferenceNumber, string SourceAccountID, string DestinationAccountID, int CreatedBy, DateTime CreatedDate, int UpdatedBy, DateTime UpdatedDate)
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
            this.UpdatedBy = UpdatedBy;
            this.UpdatedDate = UpdatedDate;
            _Mode = enMode.enUpdate;
        }


        private bool _AddNewTransaction()
        {
            TransactionID = clsTransactionData.AddTransaction(AccountID, TransactionDate, TransactionType, Amount, BalanceAfterTransaction, CurrencyID, Description, Status, ReferenceNumber, SourceAccountID, DestinationAccountID, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate);

            return (TransactionID != -1);
        }


        private bool _UpdateTransaction()
        {
            return clsTransactionData.UpdateTransactionByID(TransactionID, AccountID, TransactionDate, TransactionType, Amount, BalanceAfterTransaction, CurrencyID, Description, Status, ReferenceNumber, SourceAccountID, DestinationAccountID, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate);
        }


        public static clsTransaction FindTransactionByID(int TransactionID)
        {

            int AccountID = default;
            DateTime TransactionDate = default;
            byte TransactionType = default;
            decimal Amount = default;
            decimal BalanceAfterTransaction = default;
            int CurrencyID = default;
            string Description = default;
            byte Status = default;
            string ReferenceNumber = default;
            string SourceAccountID = default;
            string DestinationAccountID = default;
            int CreatedBy = default;
            DateTime CreatedDate = default;
            int UpdatedBy = default;
            DateTime UpdatedDate = default;
            if (clsTransactionData.GetTransactionByID(TransactionID, ref AccountID, ref TransactionDate, ref TransactionType, ref Amount, ref BalanceAfterTransaction, ref CurrencyID, ref Description, ref Status, ref ReferenceNumber, ref SourceAccountID, ref DestinationAccountID, ref CreatedBy, ref CreatedDate, ref UpdatedBy, ref UpdatedDate))
            {
                return new clsTransaction(TransactionID, AccountID, TransactionDate, TransactionType, Amount, BalanceAfterTransaction, CurrencyID, Description, Status, ReferenceNumber, SourceAccountID, DestinationAccountID, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate);
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

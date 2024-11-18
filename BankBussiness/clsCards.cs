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



    public class clsCard
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        public enum enCardStatus { Active = 1, InActive = 2, Blocked = 3 }

        public int CardID { set; get; }
        public int AccountID { set; get; }
        public string CardNumber { set; get; }
        public string PinCode { set; get; }
        public string CVV { set; get; }
        public DateTime ExpirationDate { set; get; }
        public enCardStatus Status { set; get; }
        public string CardStatus
        {
            get
            {
                switch (Status)
                {
                    case enCardStatus.Active:
                        return "Active";
                    case enCardStatus.InActive:
                        return "InActive";
                    case enCardStatus.Blocked:
                        return "Blocked";
                }
                return "";
            }
        }
        public int CardTypeID { set; get; }
        public DateTime IssueDate { set; get; }


        public clsCard()
        {
            this.CardID = default;
            this.AccountID = default;
            this.CardNumber = default;
            this.PinCode = default;
            this.CVV = default;
            this.ExpirationDate = default;
            this.Status = default;
            this.CardTypeID = default;
            this.IssueDate = default;
            _Mode = enMode.enAddNew;
        }




        private clsCard(int CardID, int AccountID, string CardNumber, string PinCode, string CVV, DateTime ExpirationDate, enCardStatus Status, int CardTypeID, DateTime IssueDate)
        {
            this.CardID = CardID;
            this.AccountID = AccountID;
            this.CardNumber = CardNumber;
            this.PinCode = PinCode;
            this.CVV = CVV;
            this.ExpirationDate = ExpirationDate;
            this.Status = Status;
            this.CardTypeID = CardTypeID;
            this.IssueDate = IssueDate;
            _Mode = enMode.enUpdate;
        }



        private bool _AddCard()
        {
            CardID = clsCardData.AddCard(AccountID, CardNumber, PinCode, CVV, ExpirationDate,(byte) Status, CardTypeID, IssueDate);

            return (CardID != -1);
        }


        private bool _UpdateCard()
        {
            return clsCardData.UpdateCardByID(CardID, AccountID, CardNumber, PinCode, CVV, ExpirationDate, (byte)Status, CardTypeID, IssueDate);
        }


        public static clsCard FindCardByID(int CardID)
        {
            int AccountID = default;
            string CardNumber = default;
            string PinCode = default;
            string CVV = default;
            DateTime ExpirationDate = default;
            byte Status = (byte)enCardStatus.Active;
            int CardTypeID = default;
            DateTime IssueDate = default;
            if (clsCardData.GetCardByID( CardID, ref AccountID, ref CardNumber, ref PinCode, ref CVV, ref ExpirationDate,ref Status, ref CardTypeID, ref IssueDate))
            {
                return new clsCard(CardID, AccountID, CardNumber, PinCode, CVV, ExpirationDate,(enCardStatus) Status, CardTypeID, IssueDate);
            }
            else
            {
                return null;
            }
        }


        public static bool IsExistByCardID(int CardID)
        {
            return clsCardData.IsCardExistByCardID(CardID);
        }


        public static bool DeleteCard(int CardID)
        {
            return clsCardData.DeleteCardByID(CardID);
        }


        public static DataTable GetCardsList()
        {
            return clsCardData.GetAllCards();
        }


        public static int GetActiveCardForAccountID(int AccountID,int CardTypeID)
        {
            return clsCardData.GetActiveCardForAccountAndCardType(AccountID, CardTypeID);
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddCard())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateCard())
                        return true;
                    else
                        return false;
            }
            return false;
        }


    }
}

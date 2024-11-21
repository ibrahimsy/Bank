using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataAccess;
using static BankBussiness.clsApplication;

namespace BankBussiness
{



    public class clsCard
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        public enum enIssueReason { FirstTime = 1,Renew = 2,ReplacmentForLost = 3,ReplacmentForDamage = 4}
        public enum enCardStatus { Active = 1,InActive = 2,Frozen = 3,Blocked = 4}
        public enum enCardType { Debit = 1,Credit = 2,Platinum = 3,Prepaid = 4,Travel = 5}
        public string IssueReasonText
        {
            get
            {
                return GetReasonText();
            }
        }

        public int CardID { set; get; }
        public int AccountID { set; get; }
        public clsAccount AccountInfo;
        public string CardNumber { set; get; }
        public string PinCode { set; get; }
        public string CVV { set; get; }
        public DateTime ExpirationDate { set; get; }
        public enCardStatus Status { set; get; }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case enCardStatus.Active:
                        return "Active";
                    case enCardStatus.InActive:
                        return "InActive";
                    case enCardStatus.Frozen:
                        return "Frozen";
                    case enCardStatus.Blocked:
                        return "Blocked";
                    default:
                        return "Active";
                }
            }
        }

        public bool IsActive
        {
            get { return this.Status == enCardStatus.Active; }
        }
        public int CardTypeID { set; get; }
        public clsCardType CardTypeInfo;
        public DateTime IssueDate { set; get; }
        public int ApplicationID { set; get; }
        public clsApplication ApplicationInfo;
        public enIssueReason IssueReason { set; get; }
        public int CreatedBy { set; get; }

        public clsUser UserInfo;

        public clsCard()
        {
            this.CardID = -1;
            this.AccountID = -1;
            this.CardNumber = "";
            this.PinCode = "";
            this.CVV = "";
            this.ExpirationDate = DateTime.MaxValue;
            this.Status = enCardStatus.Active;
            this.CardTypeID = -1;
            this.IssueDate = DateTime.MaxValue;
            this.ApplicationID = -1;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedBy = -1;
            _Mode = enMode.enAddNew;
        }




        private clsCard(int CardID, int AccountID, string CardNumber, string PinCode, string CVV, DateTime ExpirationDate, enCardStatus Status, int CardTypeID, DateTime IssueDate, int ApplicationID, enIssueReason IssueReason, int CreatedBy)
        {
            this.CardID = CardID;
            this.AccountID = AccountID;
            this.AccountInfo = clsAccount.FindAccountByID(AccountID);
            this.CardNumber = CardNumber;
            this.PinCode = PinCode;
            this.CVV = CVV;
            this.ExpirationDate = ExpirationDate;
            this.Status = Status;
            this.CardTypeID = CardTypeID;
            this.CardTypeInfo = clsCardType.FindCardTypeByID(CardTypeID);
            this.IssueDate = IssueDate;
            this.ApplicationID = ApplicationID;
            this.ApplicationInfo = clsApplication.FindApplicationByID(ApplicationID);
            this.IssueReason = IssueReason;
            this.CreatedBy = CreatedBy;
            this.UserInfo = clsUser.FindUserByID(CreatedBy);
            _Mode = enMode.enUpdate;
        }

        string GetReasonText()
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacmentForLost:
                    return "Replacment For Lost";
                case enIssueReason.ReplacmentForDamage:
                    return "Replacment For Damage";
                default:
                    return "First Time";
            }
        }

        private bool _AddCard()
        {
            CardID = clsCardData.AddNewCard(AccountID, CardNumber, PinCode, CVV, ExpirationDate,(byte) Status, CardTypeID, IssueDate, ApplicationID, (byte)IssueReason, CreatedBy);

            return (CardID != -1);
        }

        private bool _UpdateCard()
        {
            return clsCardData.UpdateCardByID(CardID, AccountID, CardNumber, PinCode, CVV, ExpirationDate,(byte) Status, CardTypeID, IssueDate, ApplicationID,(byte) IssueReason, CreatedBy);
        }

        public static clsCard FindCardByID(int CardID)
        {

            int AccountID = -1;
            string CardNumber = "";
            string PinCode = "";
            string CVV = "";
            DateTime ExpirationDate = DateTime.MaxValue;
            byte Status = 1;
            int CardTypeID = -1;
            DateTime IssueDate = DateTime.MaxValue;
            int ApplicationID = -1;
            byte IssueReason = 1;
            int CreatedBy = -1;
            if (clsCardData.GetCardByID(CardID, ref AccountID, ref CardNumber, ref PinCode, ref CVV, ref ExpirationDate, ref Status, ref CardTypeID, ref IssueDate, ref ApplicationID, ref IssueReason, ref CreatedBy))
            {
                return new clsCard(CardID, AccountID, CardNumber, PinCode, CVV, ExpirationDate,(enCardStatus) Status, CardTypeID, IssueDate, ApplicationID,(enIssueReason) IssueReason, CreatedBy);
            }
            else
            {
                return null;
            }
        }

        public static clsCard FindCardByCardNumber(string CardNumber)
        {
            int CardID = -1;
            int AccountID = -1;
            string PinCode = "";
            string CVV = "";
            DateTime ExpirationDate = DateTime.MaxValue;
            byte Status = 1;
            int CardTypeID = -1;
            DateTime IssueDate = DateTime.MaxValue;
            int ApplicationID = -1;
            byte IssueReason = 1;
            int CreatedBy = -1;
            if (clsCardData.GetCardByCardNumber(ref CardID, ref AccountID, CardNumber, ref PinCode, ref CVV, ref ExpirationDate, ref Status, ref CardTypeID, ref IssueDate, ref ApplicationID, ref IssueReason, ref CreatedBy))
            {
                return new clsCard(CardID, AccountID, CardNumber, PinCode, CVV, ExpirationDate, (enCardStatus)Status, CardTypeID, IssueDate, ApplicationID, (enIssueReason)IssueReason, CreatedBy);
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

        bool DeactivateCard()
        {
            return clsCardData.DeactivateCardByID(this.CardID);
        }
        public clsCard Replace(enIssueReason IssueReason,int CreatedByUserID)
        {
            //First Create An Application
            clsApplication Application = new clsApplication();

            Application.ApplicantAccountID = this.AccountID;
            Application.ApplicationTypeID = (IssueReason == enIssueReason.ReplacmentForDamage)?
                (int)clsApplication.enApplicationTypes.ReplacementDamageCard:
                (int)clsApplication.enApplicationTypes.ReplacementLostCard;
            Application.ApplicationDate = DateTime.Now;
            Application.Status = enApplicationStatus.Completed;
            Application.PaidFees = clsApplicationType.FindApplicationTypeByID(Application.ApplicationTypeID).Fees;
            Application.CreatedBy = CreatedByUserID;


            if (!Application.Save())
            {
                return null;
            }

            clsCard NewCard = new clsCard();

            NewCard.AccountID = this.AccountID;
            NewCard.CardNumber = this.CardNumber;
            NewCard.PinCode = this.PinCode;
            NewCard.CVV = this.CVV;
            NewCard.IssueDate = DateTime.Now;
            NewCard.ExpirationDate = this.ExpirationDate;
            NewCard.Status = enCardStatus.Active;
            NewCard.CardTypeID = this.CardTypeID;
            NewCard.ApplicationID = Application.ApplicationID;
            NewCard.IssueReason = IssueReason;
            NewCard.CreatedBy = CreatedByUserID;

            if (!NewCard.Save())
            {
                return null;
            }
            //DeActivate Old Card
            DeactivateCard();

            return NewCard;
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

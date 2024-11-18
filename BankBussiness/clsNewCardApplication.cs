using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataAccess;
using System.Globalization;


namespace BankBussiness
{



    public class clsNewCardApplication:clsApplication
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;


        public int NewCardApplicationID { set; get; }
        public string PersonFullName
        {
            get
            {
                return base.ApplicantFullName;
            }
        }

        public clsUser UserInfo
        {
            get
            {
                return base.UserInfo;
            }
        }
        public String AccountNumber
        {
            get
            {
                return base.ApplicantAccountNumber;
            }
        }
        public int CardTypeID { set; get; }

        public clsCardType CardTypeInfo;
        public clsNewCardApplication()
        {
            this.NewCardApplicationID = -1;
            this.CardTypeID = -1;
            _Mode = enMode.enAddNew;
        }

        private clsNewCardApplication(int NewCardApplicationID,int ApplicationID,int ApplicantClientID,
                        int ApplicationTypeID,DateTime ApplicationDate, enApplicationStatus Status,
                        Decimal PaidFees,int CreatedByUserID, int CardTypeID)
        {
            this.NewCardApplicationID = NewCardApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantAccountID = ApplicantClientID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationDate = ApplicationDate;
            this.Status = Status;
            this.PaidFees = PaidFees;
            this.CreatedBy = CreatedByUserID;
            this.CardTypeID = CardTypeID;
            CardTypeInfo = clsCardType.FindCardTypeByID(CardTypeID);
            _Mode = enMode.enUpdate;
        }

        private bool _AddNewCardApplication()
        {
            this.NewCardApplicationID = clsNewCardApplicationData.AddNewCardApplicationByID( ApplicationID, CardTypeID);

            return (NewCardApplicationID != -1);
        }


        private bool _UpdateNewCardApplication()
        {
            return clsNewCardApplicationData.UpdateNewCardApplicationsByID(NewCardApplicationID, ApplicationID, CardTypeID);
        }

        public static clsNewCardApplication FindNewCardApplicationByID(int NewCardApplicationID)
        {
            int ApplicationID = -1;
            int CardTypeID = -1;
            if (clsNewCardApplicationData.GetNewCardApplicationsByID( NewCardApplicationID, ref ApplicationID, ref CardTypeID))
            {
                //return new clsNewCardApplication(NewCardApplicationID, ApplicationID, CardTypeID);
                clsApplication BaseApplication = clsApplication.FindApplicationByID( ApplicationID );
                return new clsNewCardApplication(NewCardApplicationID,ApplicationID, BaseApplication.ApplicantAccountID,
                        BaseApplication.ApplicationTypeID, BaseApplication.ApplicationDate, BaseApplication.Status,
                        BaseApplication.PaidFees, BaseApplication.CreatedBy,CardTypeID);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExistByNewCardApplicationID(int NewCardApplicationID)
        {
            return clsNewCardApplicationData.IsNewCardApplicationsExistByID(NewCardApplicationID);
        }
        public bool Delete()
        {
            bool IsNewCardApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;

            IsNewCardApplicationDeleted = clsNewCardApplicationData.DeleteNewCardApplicationsByID(this.NewCardApplicationID);
            if (!IsNewCardApplicationDeleted)
                return false;
            IsBaseApplicationDeleted = base.Delete();

            return IsBaseApplicationDeleted;
        }

        public static DataTable GetNewCardApplicationsList()
        {
            return clsNewCardApplicationData.GetAllNewCardApplications();
        }

        //public static bool DoesHaveActiveApplication(int NewCardApplicationID,string AccountNumber,int CardTypeID)
        //{
        //    return clsNewCardApplicationData.DoesHaveActiveCardApplication(NewCardApplicationID, AccountNumber, CardTypeID);
        //}
        //public bool DoesHaveActiveApplication(string AccountNumber, int CardTypeID)
        //{
        //    return clsNewCardApplicationData.DoesHaveActiveCardApplication(this.NewCardApplicationID, AccountNumber, CardTypeID);
        //}
        public bool Save()
        {
           base.Mode = (clsApplication.enMode)_Mode;
            if (!base.Save())
                return false;
            
            
             switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewCardApplication())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateNewCardApplication())
                        return true;
                    else
                        return false;
            }
            return false;
        }

        public int GetActiveCard()
        {
            return clsCardData.GetActiveCardForAccountAndCardType(this.ApplicantAccountID,this.CardTypeID);
        }
    }
}

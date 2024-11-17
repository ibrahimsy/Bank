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



    public class clsApplication
    {

        public enum enMode { enAddNew = 1, enUpdate = 2 }
        public enMode Mode = enMode.enAddNew;

        public enum enApplicationStatus { Pending = 1,Canceled = 2,Completed = 3 }
        public enum enApplicationTypes
        {
            IssueNewCard = 1, ReplacementLostCard = 2,
            ReplacementDamageCard = 3, ResetPINCard = 4,
            UnblockCard = 5, IssueAccountStatment = 6
        }

        public int ApplicationID { set; get; }
        public int ApplicantAccountID { set; get; }

        public clsAccount AccountInfo;
        public string ApplicantFullName
        {
            get
            {
                return clsAccount.FindAccountByID(ApplicantAccountID).ClientInfo.PersonInfo.FullName;
            }
        }

        public string ApplicantAccountNumber
        {
            get
            {
                return clsAccount.FindAccountByID(ApplicantAccountID).AccountNumber;
            }
        }

        public int ApplicationTypeID { set; get; }

        public clsApplicationType ApplicationTypeInfo;
        public DateTime ApplicationDate { set; get; }
        public enApplicationStatus Status { set; get; }
        public string StatusText 
        {
            get
            {
                switch (Status)
                {
                    case enApplicationStatus.Pending:
                        return "Pending";
                    case enApplicationStatus.Canceled:
                        return "Canceled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                }
                return "";
            }

        }
        public Decimal PaidFees { set; get; }
        public int CreatedBy { set; get; }

        public clsUser UserInfo;


    public clsApplication()
    {
        this.ApplicationID = -1;
        this.ApplicantAccountID = -1;
        this.ApplicationTypeID = -1;
        this.ApplicationDate = DateTime.Now;
        this.Status = enApplicationStatus.Pending;
        this.PaidFees = 0;
        this.CreatedBy = -1;

        Mode = enMode.enAddNew;
    }

    private clsApplication(int ApplicationID,int ApplicantAccountID, int ApplicationTypeID, DateTime ApplicationDate,
                            enApplicationStatus Status, Decimal PaidFees, int CreatedBy)
    {
        this.ApplicationID = ApplicationID;
        this.ApplicantAccountID = ApplicantAccountID;
        this.AccountInfo = clsAccount.FindAccountByID(ApplicantAccountID);
        this.ApplicationTypeID = ApplicationTypeID;
        this.ApplicationTypeInfo = clsApplicationType.FindApplicationTypeByID(ApplicationTypeID);
        this.ApplicationDate = ApplicationDate;
        this.Status = Status;
        this.PaidFees = PaidFees;
        this.CreatedBy = CreatedBy;
        this.UserInfo = clsUser.FindUserByID(CreatedBy);
        
            Mode = enMode.enUpdate;
    }



    private bool _AddApplication()
    {
        ApplicationID = clsApplicationData.AddNewApplication(ApplicantAccountID, ApplicationTypeID, ApplicationDate,(byte)Status, PaidFees, CreatedBy);

        return (ApplicationID != -1);
    }


    private bool _UpdateApplication()
    {
        return clsApplicationData.UpdateApplicationByID(ApplicationID, ApplicantAccountID, ApplicationTypeID, ApplicationDate, (byte)Status, PaidFees, CreatedBy);
    }


    public static clsApplication FindApplicationByID(int ApplicationID)
    {
        int ApplicantAccountID = -1;
        int ApplicationTypeID = -1;
        DateTime ApplicationDate = DateTime.Now;
        byte Status = (byte)enApplicationStatus.Pending;
        Decimal PaidFees = 0;
        int CreatedBy = -1;
        if (clsApplicationData.GetApplicationByID(ApplicationID, ref ApplicantAccountID, ref ApplicationTypeID, ref ApplicationDate, ref Status, ref PaidFees, ref CreatedBy))
        {
            return new clsApplication(ApplicationID, ApplicantAccountID, ApplicationTypeID, ApplicationDate,(enApplicationStatus) Status, PaidFees, CreatedBy);
        }
        else
        {
            return null;
        }
    }


    public static bool IsExistByApplicationID(int ApplicationID)
    {
        return clsApplicationData.IsApplicationExistByApplicationID(ApplicationID);
    }


    public static bool DeleteApplication(int ApplicationID)
    {
        return clsApplicationData.DeleteApplicationByID(ApplicationID);
    }


    public static DataTable GetApplicationsList()
    {
        return clsApplicationData.GetAllApplications();
    }

    public static int GetActiveApplicationIDForCardType(int AccountID,clsApplication.enApplicationTypes ApplicationType,int CardTypeID)
    {
            return clsApplicationData.GetActiveApplicationForCardType(AccountID,(int)ApplicationType,CardTypeID);
    }

        public bool Save()
    {
        switch (Mode)
        {
            case enMode.enAddNew:
                if (_AddApplication())
                {
                    Mode = enMode.enUpdate;
                    return true;
                }
                else
                    return false;

            case enMode.enUpdate:
                if (_UpdateApplication())
                    return true;
                else
                    return false;
        }
        return false;
    }


}}

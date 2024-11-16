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

        public enum enApplicationStatus { New = 1,Canceled = 2,Completed = 3 }
        public enum enApplicationTypes
        {
            IssueNewCard = 1, ReplacementLostCard = 2,
            ReplacementDamageCard = 3, ResetPINCard = 4,
            UnblockCard = 5, IssueAccountStatment = 6
        }

        public int ApplicationID { set; get; }
        public int ApplicantClientID { set; get; }

        public clsClient ClientInfo;
        public string ApplicantFullName
        {
            get
            {
                return clsClient.FindClientByID(ApplicantClientID).PersonInfo.FullName;
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
                    case enApplicationStatus.New:
                        return "New";
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
        this.ApplicantClientID = -1;
        this.ApplicationTypeID = -1;
        this.ApplicationDate = DateTime.Now;
        this.Status = enApplicationStatus.New;
        this.PaidFees = 0;
        this.CreatedBy = -1;

        Mode = enMode.enAddNew;
    }

    private clsApplication(int ApplicationID,int ApplicantClientID, int ApplicationTypeID, DateTime ApplicationDate,
                            enApplicationStatus Status, Decimal PaidFees, int CreatedBy)
    {
        this.ApplicationID = ApplicationID;
        this.ApplicantClientID = ApplicantClientID;
        this.ClientInfo = clsClient.FindClientByID(ApplicantClientID);
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
        ApplicationID = clsApplicationData.AddNewApplication(ApplicantClientID, ApplicationTypeID, ApplicationDate,(byte)Status, PaidFees, CreatedBy);

        return (ApplicationID != -1);
    }


    private bool _UpdateApplication()
    {
        return clsApplicationData.UpdateApplicationByID(ApplicationID, ApplicantClientID, ApplicationTypeID, ApplicationDate, (byte)Status, PaidFees, CreatedBy);
    }


    public static clsApplication FindApplicationByID(int ApplicationID)
    {
        int ApplicantClientID = -1;
        int ApplicationTypeID = -1;
        DateTime ApplicationDate = DateTime.Now;
        byte Status = (byte)enApplicationStatus.New;
        Decimal PaidFees = 0;
        int CreatedBy = -1;
        if (clsApplicationData.GetApplicationByID(ApplicationID, ref ApplicantClientID, ref ApplicationTypeID, ref ApplicationDate, ref Status, ref PaidFees, ref CreatedBy))
        {
            return new clsApplication(ApplicationID, ApplicantClientID, ApplicationTypeID, ApplicationDate,(enApplicationStatus) Status, PaidFees, CreatedBy);
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
using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BankBussiness
{
    public class clsClient
    {
        public enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        enum enAccountStatus { Active = 1,InActive = 2 }
        /*
         ClientID
         PersonID
         PrimaryAccountNumber
         AccountStatus
         CreatedBy
         CreatedDate
         UpdatedDate
         BranchID
         Notes
         */
        public int ClientID { get; set; }
        public int PersonID { get; set; }

        public clsPerson PersonInfo;
        public string PrimaryAccountNumber { get; set; }
        public byte AccountStatus { get; set; }
        public int CreatedBy { get; set; }
        
        public clsUser UserInfo;
        public DateTime CreatedDate { get; set; }  
        public DateTime? UpdatedDate  {  get; set; }
        public int BranchID { get; set; }

        public clsBranch BranchInfo;
        public string Notes { get; set; }

        public clsClient()
        {
            this.ClientID = -1;
            this.PersonID = -1;
            this.PrimaryAccountNumber = "";
            this.AccountStatus = 1;
            this.CreatedBy = -1;
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = null;
            this.BranchID = -1;
            this.Notes = "";
            _Mode = enMode.enAddNew;
        }

        private clsClient(int ClientID, int PersonID, string PrimaryAccountNumber, byte AccountStatus,
                         int CreatedBy, DateTime CreatedDate, DateTime? UpdatedDate, int BranchID, string Notes)
        {
            this.ClientID = ClientID;
            this.PersonID = PersonID;
            PersonInfo = clsPerson.FindPersonByID(PersonID);
            this.PrimaryAccountNumber = PrimaryAccountNumber;
            this.AccountStatus = AccountStatus;
            this.CreatedBy = CreatedBy;
            UserInfo = clsUser.FindUserByID(CreatedBy);
            this.CreatedDate = CreatedDate;
            this.UpdatedDate = UpdatedDate;
            this.BranchID = BranchID;
            BranchInfo = clsBranch.FindBranchByID(BranchID);    
            this.Notes = Notes;
            _Mode = enMode.enUpdate;
        }

        private bool _AddNewClient()
        {
            ClientID = clsClientData.AddNewClient( PersonID,  PrimaryAccountNumber,  AccountStatus,
                          CreatedBy,  CreatedDate,  UpdatedDate,  BranchID,  Notes);

            return (ClientID != -1);
        }

        private bool _UpdateClient()
        {
            return clsClientData.UpdateClientByID(ClientID, PersonID, PrimaryAccountNumber, AccountStatus,
                                                     CreatedBy, CreatedDate, UpdatedDate, BranchID, Notes);
        }

        public static clsClient FindClientByID(int ClientID)
        {
           
            int PersonID = -1;
            string PrimaryAccountNumber = "";
            byte AccountStatus = 1;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime? UpdatedDate = null;
            int BranchID = -1;
            string Notes = "";

            if (clsClientData.GetClientByID(ClientID,ref PersonID,ref PrimaryAccountNumber,ref AccountStatus,
                                                     ref CreatedBy,ref CreatedDate,ref UpdatedDate,ref BranchID,ref Notes))
            {
                return new clsClient(ClientID,  PersonID,  PrimaryAccountNumber,  AccountStatus,
                                                      CreatedBy,  CreatedDate,  UpdatedDate,  BranchID,  Notes);
            }
            else
            {
                return null;
            }
        }

        public static clsClient FindClientByPersonID(int PersonID)
        {
            int ClientID = -1;
            string PrimaryAccountNumber = "";
            byte AccountStatus = 1;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime? UpdatedDate = null;
            int BranchID = -1;
            string Notes = "";
            if (clsClientData.GetClientByPersonID(PersonID, ref ClientID, ref PrimaryAccountNumber, ref AccountStatus,
                                                     ref CreatedBy, ref CreatedDate, ref UpdatedDate, ref BranchID, ref Notes))
            {
                return new clsClient(ClientID, PersonID, PrimaryAccountNumber, AccountStatus,
                                                      CreatedBy, CreatedDate, UpdatedDate, BranchID, Notes);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExistByClientID(int ClientID)
        {
            return clsClientData.IsClientExistByClientID(ClientID);
        }
       
        public static bool IsExistByPersonID(int PersonID)
        {
            return clsClientData.IsClientExistByPersonID(PersonID);
        }

        public static bool DeleteClient(int ClientID)
        {
            return clsClientData.DeleteClientByID(ClientID);
        }
        public static DataTable GetClientsList()
        {
            return clsClientData.GetAllClients();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewClient())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateClient())
                        return true;
                    else
                        return false;
            }
            return false;
        }
            
    }
}

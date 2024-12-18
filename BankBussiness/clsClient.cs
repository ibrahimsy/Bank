﻿using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        public enum enClientStatus { Active = 1,InActive = 2 }
        /*
         ClientID
         PersonID
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
        public bool AccountStatus { get; set; }
        public int CreatedBy { get; set; }
        
        public clsUser UserInfo;
        public DateTime CreatedDate { get; set; }  
        public DateTime UpdatedDate  {  get; set; }
        public int BranchID { get; set; }

        public clsBranch BranchInfo;
        public string Notes { get; set; }

        public clsClient()
        {
            this.ClientID = -1;
            this.PersonID = -1;
            this.AccountStatus = true;
            this.CreatedBy = -1;
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.MaxValue;
            this.BranchID = -1;
            this.Notes = "";
            _Mode = enMode.enAddNew;
        }

        private clsClient(int ClientID, int PersonID,bool AccountStatus,
                         int CreatedBy, DateTime CreatedDate, DateTime UpdatedDate, int BranchID, string Notes)
        {
            this.ClientID = ClientID;
            this.PersonID = PersonID;
            PersonInfo = clsPerson.FindPersonByID(PersonID);  
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
            ClientID = clsClientData.AddNewClient( PersonID,  AccountStatus,
                          CreatedBy,  CreatedDate,DateTime.MaxValue,  BranchID,  Notes);

            return (ClientID != -1);
        }

        private bool _UpdateClient()
        {
            return clsClientData.UpdateClientByID(ClientID, PersonID, AccountStatus,
                                                     CreatedBy, CreatedDate, UpdatedDate, BranchID, Notes);
        }

        public static clsClient FindClientByID(int ClientID)
        {
           
            int PersonID = -1;
          
            bool AccountStatus = true;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime UpdatedDate = DateTime.MaxValue;
            int BranchID = -1;
            string Notes = "";

            if (clsClientData.GetClientByID(ClientID,ref PersonID,ref AccountStatus,
                                                     ref CreatedBy,ref CreatedDate,ref UpdatedDate,ref BranchID,ref Notes))
            {
                return new clsClient(ClientID,  PersonID,  AccountStatus,
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
          
            bool AccountStatus = true;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime UpdatedDate = DateTime.MaxValue;
            int BranchID = -1;
            string Notes = "";
            if (clsClientData.GetClientByPersonID(PersonID, ref ClientID,  ref AccountStatus,
                                                     ref CreatedBy, ref CreatedDate, ref UpdatedDate, ref BranchID, ref Notes))
            {
                return new clsClient(ClientID, PersonID, AccountStatus,
                                                      CreatedBy, CreatedDate, UpdatedDate, BranchID, Notes);
            }
            else
            {
                return null;
            }
        }

        public static clsClient FindClientByPhoneNumber(string PhoneNumber)
        {
            int ClientID = -1;
            int PersonID = -1;
            bool AccountStatus = true;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime UpdatedDate = DateTime.MaxValue;
            int BranchID = -1;
            string Notes = "";
            if (clsClientData.GetClientByPhoneNumber(PhoneNumber, ref ClientID,ref PersonID, ref AccountStatus,
                                                     ref CreatedBy, ref CreatedDate, ref UpdatedDate, ref BranchID, ref Notes))
            {
                return new clsClient(ClientID, PersonID, AccountStatus,
                                                      CreatedBy, CreatedDate, UpdatedDate, BranchID, Notes);
            }
            else
            {
                return null;
            }
        }
        
        public static clsClient FindClientByNationalNo(string NationalNo)
        {
            int ClientID = -1;
            int PersonID = -1;
            bool AccountStatus = true;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime UpdatedDate = DateTime.MaxValue;
            int BranchID = -1;
            string Notes = "";
            if (clsClientData.GetClientByNationalNumber(NationalNo, ref ClientID,ref PersonID, ref AccountStatus,
                                                     ref CreatedBy, ref CreatedDate, ref UpdatedDate, ref BranchID, ref Notes))
            {
                return new clsClient(ClientID, PersonID, AccountStatus,
                                                      CreatedBy, CreatedDate, UpdatedDate, BranchID, Notes);
            }
            else
            {
                return null;
            }
        }

        public static clsClient FindClientByPrimaryAccountNumber(string PrimaryAccountNumber)
        {
            int ClientID = -1;
            int PersonID = -1;
            bool AccountStatus = true;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime UpdatedDate = DateTime.MaxValue;
            int BranchID = -1;
            string Notes = "";
            if (clsClientData.GetClientByPrimaryAccountNumber(PrimaryAccountNumber, ref ClientID, ref PersonID, ref AccountStatus,
                                                     ref CreatedBy, ref CreatedDate, ref UpdatedDate, ref BranchID, ref Notes))
            {
                return new clsClient(ClientID, PersonID, AccountStatus,
                                                      CreatedBy, CreatedDate, UpdatedDate, BranchID, Notes);
            }
            else
            {
                return null;
            }
        }

        public static clsClient FindClientByAccountNumber(string AccountNumber)
        {
            int ClientID = -1;
            int PersonID = -1;
            bool AccountStatus = true;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime UpdatedDate = DateTime.MaxValue;
            int BranchID = -1;
            string Notes = "";
            if (clsClientData.GetClientByAccountNumber(AccountNumber, ref ClientID, ref PersonID, ref AccountStatus,
                                                     ref CreatedBy, ref CreatedDate, ref UpdatedDate, ref BranchID, ref Notes))
            {
                return new clsClient(ClientID, PersonID, AccountStatus,
                                                      CreatedBy, CreatedDate, UpdatedDate, BranchID, Notes);
            }
            else
            {
                return null;
            }
        }

        public static clsClient FindClientByAccountID(int AccountID)
        {
            int ClientID = -1;
            int PersonID = -1;
            bool AccountStatus = true;
            int CreatedBy = -1;
            DateTime CreatedDate = DateTime.Now;
            DateTime UpdatedDate = DateTime.MaxValue;
            int BranchID = -1;
            string Notes = "";
            if (clsClientData.GetClientByAccountID(AccountID, ref ClientID, ref PersonID, ref AccountStatus,
                                                     ref CreatedBy, ref CreatedDate, ref UpdatedDate, ref BranchID, ref Notes))
            {
                return new clsClient(ClientID, PersonID, AccountStatus,
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

        public bool IsClientOwnAccount(string AccountNumber)
        {
            return clsClientData.DoesHasAccount(this.ClientID,AccountNumber);
        }

        public bool DoesClientHaveBeneficiary(int BeneficiaryAccountNumber)
        {
            return clsBeneficiary.IsExistByClientIDAndAccountID(this.ClientID, BeneficiaryAccountNumber);
        }

        public DataTable GetClientBeneficiaries()
        {
            return clsBeneficiaryData.GetAllBeneficiariesByClientID(this.ClientID);
        }

        public static bool DeleteClient(int ClientID)
        {
            return clsClientData.DeleteClientByID(ClientID);
        }
        public static DataTable GetClientsList()
        {
            return clsClientData.GetAllClients();
        }

        public static int GetClientsCount() 
        {
            return clsClientData.GetClientsCount();
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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataAccess;
using System.Net.Http.Headers;
namespace BankBussiness
{



    public class clsBeneficiary
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        public enum enBeneficiaryStatus { Active = 1,InActive = 2,PendingApproval = 3,Blocked = 4}

        public int BeneficiaryID { set; get; }
        public int ClientID { set; get; }
        public int AccountID { set; get; }
        public string Name { set; get; }
        public string MobileNumber { set; get; }
        public string Nickname { set; get; }
        public DateTime CreatedDate { set; get; }
        public byte Status { set; get; }


        public clsBeneficiary()
        {
            this.BeneficiaryID = default;
            this.ClientID = default;
            this.AccountID = default;
            this.Name = default;
            this.MobileNumber = default;
            this.Nickname = default;
            this.CreatedDate = default;
            this.Status = default;
            _Mode = enMode.enAddNew;
        }




        private clsBeneficiary(int BeneficiaryID, int ClientID, int AccountID, string Name, string MobileNumber, string Nickname, DateTime CreatedDate, byte Status)
        {
            this.BeneficiaryID = BeneficiaryID;
            this.ClientID = ClientID;
            this.AccountID = AccountID;
            this.Name = Name;
            this.MobileNumber = MobileNumber;
            this.Nickname = Nickname;
            this.CreatedDate = CreatedDate;
            this.Status = Status;
            _Mode = enMode.enUpdate;
        }



        private bool _AddBeneficiary()
        {
            
            BeneficiaryID = clsBeneficiaryData.AddBeneficiary(ClientID, AccountID,Nickname, CreatedDate, Status);

            return (BeneficiaryID != -1);
        }


        private bool _UpdateBeneficiarie()
        {
            return clsBeneficiaryData.UpdateBeneficiaryByID(BeneficiaryID, ClientID, AccountID, Nickname, CreatedDate, Status);
        }


        public static clsBeneficiary FindBeneficiarieByID(int BeneficiaryID)
        {
            int ClientID = default;
            int AccountID = default;
            string Name = default;
            string MobileNumber = default;
            string Nickname = default;
            DateTime CreatedDate = default;
            byte Status = default;
            if (clsBeneficiaryData.GetBeneficiariesByID( BeneficiaryID, ref ClientID, ref AccountID, ref Name, ref MobileNumber, ref Nickname, ref CreatedDate, ref Status))
            {
                return new clsBeneficiary(BeneficiaryID, ClientID, AccountID, Name, MobileNumber, Nickname, CreatedDate, Status);
            }
            else
            {
                return null;
            }
        }


        public static bool IsExistByBeneficiarieID(int BeneficiaryID)
        {
            return clsBeneficiaryData.IsBeneficiariesExistByBeneficiaryID(BeneficiaryID);
        }

        public static bool IsExistByClientID(int ClientID)
        {
            return IsExistByClientID(ClientID);
        }

        public static bool IsExistByClientIDAndAccountID(int ClientID,int AccountID)
        {
            return clsBeneficiaryData.IsExistBySenderClientIDAndRecepientAccountID(ClientID, AccountID);
        }

        public static bool DeleteBeneficiarie(int BeneficiaryID)
        {
            return clsBeneficiaryData.DeleteBeneficiariesByID(BeneficiaryID);
        }


        public static DataTable GetBeneficiariesList()
        {
            return clsBeneficiaryData.GetAllBeneficiaries();
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddBeneficiary())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateBeneficiarie())
                        return true;
                    else
                        return false;
            }
            return false;
        }


    }
}

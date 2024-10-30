using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankBussiness
{
      /*
         int    BranchID
         string BranchName
         string Address
         string PhoneNumber
         string Email
         string OpeningHours
                Status
       */
    public class clsBranch
    {
        enum enMode { enAddNew = 1,enUpdate = 2}
        enMode _Mode = enMode.enAddNew;
        public enum enBranchStatus { Active = 1, Inactive = 2, UnderConstruction = 3, Closed = 4, TemporarilyClosed = 5 }
        public int BranchID { set; get; }
        public string BranchName { set; get; }
        public string Address { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string OpeningHours { set; get; }
        public byte Status {  set; get; }

        public clsBranch()
        {
            this.BranchID = -1;
            this.BranchName = "";
            this.Address = "";
            this.PhoneNumber = "";
            this.Email = "";
            this.OpeningHours = "";
            this.Status = (byte)enBranchStatus.Active;

            _Mode = enMode.enAddNew;
        }
        private clsBranch(int BranchID,string BranchName,string Address,string PhoneNumber,string Email,string OpeningHours,byte Status)
        {
            this.BranchID = BranchID;
            this.BranchName = BranchName;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.OpeningHours = OpeningHours;
            this.Status = Status;

            _Mode = enMode.enUpdate;
        }
        private bool _AddNewBranch()
        {
            return true;
        }
        private bool _UpdateBranch()
        {
            return clsBranchData.UpdateBranchByID(BranchID, BranchName, Address, PhoneNumber, Email, OpeningHours, Status);
        }
        public static clsBranch FindBranchByID(int BranchID)
        {
            string BranchName = "";
            string Address = "";
            string PhoneNumber = "";
            string Email = "";
            string OpeningHours = "";
            byte Status = (byte)1;

            if (clsBranchData.GetBranchByID( BranchID,ref BranchName,ref Address,ref PhoneNumber,ref Email,ref OpeningHours,ref Status))
            {
                return new clsBranch(BranchID, BranchName, Address, PhoneNumber, Email, OpeningHours, Status);
            }
            else
            {
                return null;
            }
        }
        public static clsBranch FindBranchByBranchName(string BranchName)
        {
            int BranchID = -1;
            string Address = "";
            string PhoneNumber = "";
            string Email = "";
            string OpeningHours = "";
            byte Status = 1;

            if (clsBranchData.GetBranchByBranchName(BranchName, ref BranchID, ref Address, ref PhoneNumber, ref Email, ref OpeningHours, ref Status))
            {
                return new clsBranch(BranchID, BranchName, Address, PhoneNumber, Email, OpeningHours, Status);
            }
            else
            {
                return null;
            }
        }     
        public static bool IsExistByBranchID(int BranchID)
        {
            return clsBranchData.IsBranchExistByBranchID(BranchID);
        }
        public static bool IsExistByBranchName(string BranchName)
        {
            return clsBranchData.IsBranchExistByBranchName(BranchName);
        }
        public static bool DeleteBranch(int BranchID)
        {
            return clsBranchData.DeleteBranchByID(BranchID);
        }
        public static DataTable GetBranchsList()
        {
            return clsBranchData.GetAllBranchs();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewBranch())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateBranch())
                        return true;
                    else
                        return false;
            }
            return false;
        }

    }
}

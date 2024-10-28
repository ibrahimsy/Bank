using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBussiness
{
    public class clsUser
    {

        public enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        public enum enPermission { AddPerson = 1,EditPerson = 2,DeletePerson = 4,ShowPersonInfo = 8,
                                   UserManagment = 16,AddClient = 32,EditClient = 64,DeleteClient = 128,
                                   ShowClientInfo = 256,ChangePinCode = 512,Transaction = 1024 }
        enPermission _Permission;
        public int UserID { get; set; }
        public int PersonID { get; set; }

        public clsPerson PersonInfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Permission {  get; set; }
      
        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.Permission = -1;
            _Mode = enMode.enAddNew;
        }

        private clsUser(int UserID,int PersonID,string UserName,string Password,bool IsActive,int Permission)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.FindPersonByID(PersonID);
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;  
            this.Permission = Permission;

            _Mode = enMode.enUpdate;
        }

        private bool _AddNewUser()
        {
            UserID = clsUserData.AddNewUser(PersonID,UserName,Password,IsActive,Permission);

            return (UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUserByID(UserID,PersonID, UserName, Password, IsActive, Permission);
        }

        public static clsUser FindUserByID(int UserID)
        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            int Permission = -1;
            bool IsActive = false;
            

            if (clsUserData.GetUserByID(UserID,ref PersonID,ref UserName,ref Password,ref IsActive,ref Permission))
            {
                return new clsUser(UserID, PersonID,UserName,Password,IsActive, Permission);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindUserByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;
            int Permission = -1;

            if (clsUserData.GetUserByPersonID(ref UserID,PersonID, ref UserName, ref Password, ref IsActive,ref Permission))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive, Permission);
            }
            else
            {
                return null;
            }
        }

        public static clsUser FindUserByUserName(string UserName)
        {
            int UserID = -1;
            int PersonID = -1;
            string Password = "";
            int Permission = -1;
            bool IsActive = false;

            if (clsUserData.GetUserByUserName(ref UserID,ref PersonID, UserName, ref Password, ref IsActive,ref Permission))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive, Permission);
            }
            else
            {
                return null;
            }
        }
        public static bool IsExistByUserID(int UserID)
        {
            return clsUserData.IsUserExistByUserID(UserID);
        }

        public static bool IsExistByUserName(string UserName)
        {
            return clsUserData.IsUserExistByUserName(UserName);
        }

        public static bool IsExistByUserNameAndPassword(string UserName,string Password)
        {
            return clsUserData.IsUserExistByUsernameAndPassword(UserName,Password);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUserByID(UserID);
        }
        public static DataTable GetUsersList()
        {
            return clsUserData.GetAllUsers();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateUser())
                        return true;
                    else
                        return false;
            }
            return false;
        }
    }
}

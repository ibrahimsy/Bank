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



    public class clsNewCardApplication:clsApplication
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;


        public int NewCardApplicationID { set; get; }
        public int ApplicationID { set; get; }
        public int CardTypeID { set; get; }

        public clsNewCardApplication()
        {
            this.NewCardApplicationID = default;
            this.ApplicationID = default;
            this.CardTypeID = default;
            _Mode = enMode.enAddNew;
        }

        private clsNewCardApplication(int NewCardApplicationID, int ApplicationID, int CardTypeID)
        {
            this.NewCardApplicationID = NewCardApplicationID;
            this.ApplicationID = ApplicationID;
            this.CardTypeID = CardTypeID;
            _Mode = enMode.enUpdate;
        }

        private bool _AddNewCardApplication()
        {
            int NewCardApplicationID = clsNewCardApplicationData.AddNewCardApplicationByID( ApplicationID, CardTypeID);

            return (NewCardApplicationID != -1);
        }


        private bool _UpdateNewCardApplication()
        {
            return clsNewCardApplicationData.UpdateNewCardApplicationsByID(NewCardApplicationID, ApplicationID, CardTypeID);
        }

        public static clsNewCardApplication FindNewCardApplicationByID(int NewCardApplicationID)
        {
            int ApplicationID = default;
            int CardTypeID = default;
            if (clsNewCardApplicationData.GetNewCardApplicationsByID( NewCardApplicationID, ref ApplicationID, ref CardTypeID))
            {
                return new clsNewCardApplication(NewCardApplicationID, ApplicationID, CardTypeID);
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
        public static bool DeleteNewCardApplication(int NewCardApplicationID)
        {
            return clsNewCardApplicationData.DeleteNewCardApplicationsByID(NewCardApplicationID);
        }

        public static DataTable GetNewCardApplicationsList()
        {
            return clsNewCardApplicationData.GetAllNewCardApplications();
        }

        public bool Save()
        {
           // base.Mode = _Mode;
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


    }
}

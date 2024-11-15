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



    public class clsApplicationType
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        

        public int TypeID { set; get; }
        public string TypeTitle { set; get; }
        public Decimal Fees { set; get; }


        public clsApplicationType()
        {
            this.TypeID = -1;
            this.TypeTitle = default;
            this.Fees = default;
            _Mode = enMode.enAddNew;
        }




        private clsApplicationType(int TypeID, string TypeTitle, Decimal Fees)
        {
            this.TypeID = TypeID;
            this.TypeTitle = TypeTitle;
            this.Fees = Fees;
            _Mode = enMode.enUpdate;
        }



        private bool _AddApplicationType()
        {
            TypeID =  clsApplicationTypeData.AddApplicationTypes(TypeTitle, Fees);

            return (TypeTitle != "");
        }


        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationTypesByID((int)TypeID, TypeTitle, Fees);
        }


        public static clsApplicationType FindApplicationTypeByID(int TypeID)
        {
           
            string TypeTitle = "";
            Decimal Fees = 0;
            if (clsApplicationTypeData.GetApplicationTypesByID(TypeID, ref TypeTitle, ref Fees))
            {
                return new clsApplicationType(TypeID, TypeTitle, Fees);
            }
            else
            {
                return null;
            }
        }


        public static bool IsExistByApplicationTypeID(int TypeID)
        {
            return clsApplicationTypeData.IsApplicationTypesExistByTypeID((int)TypeID);
        }


        public static bool DeleteApplicationType(int TypeID)
        {
            return clsApplicationTypeData.DeleteApplicationTypesByID((int)TypeID);
        }


        public static DataTable GetApplicationTypesList()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddApplicationType())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateApplicationType())
                        return true;
                    else
                        return false;
            }
            return false;
        }


    }
}

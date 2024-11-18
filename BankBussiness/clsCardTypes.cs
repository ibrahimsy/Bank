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



    public class clsCardType
    {

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        public int CardTypeID { set; get; }
        public string CardName { set; get; }
        public string Description { set; get; }
        public byte DefaultValidationLength { set; get; }
        public float IssueFees { set; get; }


        public clsCardType()
        {
            this.CardTypeID = -1;
            this.CardName = "";
            this.Description = "";
            this.DefaultValidationLength = 0;
            this.IssueFees = 0;
            _Mode = enMode.enAddNew;
        }

        private clsCardType(int CardTypeID, string CardName, string Description, byte DefaultValidationLength, float IssueFees)
        {
            this.CardTypeID = CardTypeID;
            this.CardName = CardName;
            this.Description = Description;
            this.DefaultValidationLength = DefaultValidationLength;
            this.IssueFees = IssueFees;
            _Mode = enMode.enUpdate;
        }

        private bool _AddCardType()
        {
            CardTypeID = clsCardTypeData.AddCardType( CardName, Description, DefaultValidationLength, IssueFees);

            return (CardTypeID != -1);
        }


        private bool _UpdateCardType()
        {
            return clsCardTypeData.UpdateCardTypeByID(CardTypeID, CardName, Description, DefaultValidationLength, IssueFees);
        }

        public static clsCardType FindCardTypeByID(int CardTypeID)
        {
            string CardName = "";
            string Description = "";
            byte DefaultValidationLength = 0;
            float IssueFees = 0;
            if (clsCardTypeData.GetCardTypeByID(CardTypeID, ref CardName, ref Description, ref DefaultValidationLength, ref IssueFees))
            {
                return new clsCardType(CardTypeID, CardName, Description, DefaultValidationLength, IssueFees);
            }
            else
            {
                return null;
            }
        }

        public static clsCardType FindCardTypeByName(string  CardTypeName)
        {
            int CardTypeID = -1;
            string Description = "";
            byte DefaultValidationLength = 0;
            float IssueFees = 0;
            if (clsCardTypeData.GetCardTypeByTypeName(ref CardTypeID, CardTypeName, ref Description, ref DefaultValidationLength, ref IssueFees))
            {
                return new clsCardType(CardTypeID, CardTypeName, Description, DefaultValidationLength, IssueFees);
            }
            else
            {
                return null;
            }
        }
       
        public static bool IsExistByCardTypeID(int CardTypeID)
        {
            return clsCardTypeData.IsCardTypeExistByCardTypeID(CardTypeID);
        }

        public static bool DeleteCardType(int CardTypeID)
        {
            return clsCardTypeData.DeleteCardTypeByID(CardTypeID);
        }

        public static DataTable GetCardTypesList()
        {
            return clsCardTypeData.GetAllCardTypes();
        }
       
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.enAddNew:
                    if (_AddCardType())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    if (_UpdateCardType())
                        return true;
                    else
                        return false;
            }
            return false;
        }


    }
}

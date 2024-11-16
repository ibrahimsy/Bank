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


        public clsCardType()
        {
            this.CardTypeID = default;
            this.CardName = default;
            this.Description = default;
            _Mode = enMode.enAddNew;
        }




        private clsCardType(int CardTypeID, string CardName, string Description)
        {
            this.CardTypeID = CardTypeID;
            this.CardName = CardName;
            this.Description = Description;
            _Mode = enMode.enUpdate;
        }



        private bool _AddCardType()
        {
            CardTypeID = clsCardTypesData.AddCardTypes(CardName, Description);

            return (CardTypeID != -1);
        }


        private bool _UpdateCardType()
        {
            return clsCardTypesData.UpdateCardTypesByID(CardTypeID, CardName, Description);
        }


        public static clsCardType FindCardTypeByID(int CardTypeID)
        {
            
            string CardName = default;
            string Description = default;
            if (clsCardTypesData.GetCardTypesByID( CardTypeID, ref CardName, ref Description))
            {
                return new clsCardType(CardTypeID, CardName, Description);
            }
            else
            {
                return null;
            }
        }

        public static clsCardType FindCardTypeByName(string CardName)
        {

            int CardTypeID = -1;
            string Description = "";
            if (clsCardTypesData.GetCardTypesByCardName(ref CardTypeID, CardName, ref Description))
            {
                return new clsCardType(CardTypeID, CardName, Description);
            }
            else
            {
                return null;
            }
        }


        public static bool IsExistByCardTypeID(int CardTypeID)
        {
            return clsCardTypesData.IsCardTypesExistByCardTypeID(CardTypeID);
        }


        public static bool DeleteCardType(int CardTypeID)
        {
            return clsCardTypesData.DeleteCardTypesByID(CardTypeID);
        }


        public static DataTable GetCardTypesList()
        {
            return clsCardTypesData.GetAllCardTypes();
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

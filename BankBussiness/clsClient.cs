using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBussiness
{
    public class clsClient
    {
        public enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;
        public int ClientID { get; set; }
        public int PersonID { get; set; }

        public clsPerson PersonInfo;
        public string AccountNumber { get; set; }
        public short PinCode { get; set; }
        public double Balance { get; set; }

        public clsClient()
        {
            this.ClientID = -1;
            this.PersonID = -1;
            this.AccountNumber = "";
            this.PinCode = -1;
            this.Balance = 0;

            _Mode = enMode.enAddNew;
        }

        private clsClient(int ClientID, int PersonID, string AccountNumber, short PinCode, double Balance)
        {
            this.ClientID = ClientID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.FindPersonByID(PersonID);
            this.AccountNumber = AccountNumber;
            this.PinCode = PinCode;
            this.Balance = Balance;

            _Mode = enMode.enUpdate;
        }

        private bool _AddNewClient()
        {
            ClientID = clsClientData.AddNewClient(PersonID, AccountNumber, PinCode, Balance);

            return (ClientID != -1);
        }

        private bool _UpdateClient()
        {
            return clsClientData.UpdateClientByID(ClientID, PersonID, AccountNumber, PinCode, Balance);
        }

        public static clsClient FindClientByID(int ClientID)
        {
            int PersonID = -1;
            string AccountNumber = "";
            short PinCode = -1;
            double Balance = 0;


            if (clsClientData.GetClientByID(ClientID, ref PersonID, ref AccountNumber, ref PinCode, ref Balance))
            {
                return new clsClient(ClientID, PersonID, AccountNumber, PinCode, Balance);
            }
            else
            {
                return null;
            }
        }

        public static clsClient FindClientByPersonID(int PersonID)
        {
            int ClientID = -1;
            string AccountNumber = "";
            short PinCode = -1;
            double Balance = 0;

            if (clsClientData.GetClientByPersonID(ref ClientID, PersonID, ref AccountNumber, ref PinCode, ref Balance))
            {
                return new clsClient(ClientID, PersonID, AccountNumber, PinCode, Balance);
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

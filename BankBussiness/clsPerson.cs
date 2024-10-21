using BankDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankBussiness
{
    public class clsPerson
    {
        public enum enMode { enAddNew = 1,enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + SecondName + ThirdName + LastName;
            }
        }
        public short Gendor { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityCountryID { get; set; }
        public clsCountry Country;
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }


        private clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.NationalityCountryID = -1;
            this.Gendor = 0;
            this.DateOfBirth = DateTime.Now;
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.ImagePath = "";

            _Mode = enMode.enAddNew;
        }

        public clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName,
                                            short Gendor, DateTime DateOfBirth, int NationalityCountryID, string Phone, string Email,
                                            string Address, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalityCountryID = NationalityCountryID;
            this.Country = clsCountry.FindByID(NationalityCountryID);
            this.Gendor = Gendor;
            this.DateOfBirth = DateOfBirth;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.ImagePath = ImagePath;

            _Mode = enMode.enUpdate;
        }

        private bool _AddNewPerson()
        {
            PersonID = clsPersonData.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName,
                Gendor, DateOfBirth, NationalityCountryID, Phone, Email, Address, ImagePath);

            return (PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePersonByID(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                 Gendor, DateOfBirth, NationalityCountryID, Phone, Email, Address, ImagePath);
        }

        public static clsPerson FindPersonByID(int PersonID)
        {

            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            int NationalityCountryID = -1;

            short Gendor = 0;
            DateTime DateOfBirth = DateTime.Now;
            string Phone = "";
            string Email = "";
            string Address = "";
            string ImagePath = "";

            if (clsPersonData.GetPersonByID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref Gendor, ref DateOfBirth, ref NationalityCountryID, ref Phone, ref Email, ref Address, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                 Gendor, DateOfBirth, NationalityCountryID, Phone, Email, Address, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static clsPerson FindPersonByNationalNo(string NationalNo)
        {

            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            int NationalityCountryID = -1;

            short Gendor = 0;
            DateTime DateOfBirth = DateTime.Now;
            string Phone = "";
            string Email = "";
            string Address = "";
            string ImagePath = "";

            if (clsPersonData.GetPersonByNationalNo(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
                ref Gendor, ref DateOfBirth, ref NationalityCountryID, ref Phone, ref Email, ref Address, ref ImagePath))
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                 Gendor, DateOfBirth, NationalityCountryID, Phone, Email, Address, ImagePath);
            }
            else
            {
                return null;
            }
        }

        public static bool IsExistByPersonID(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }
        
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePersonByID(PersonID);
        }

        public static DataTable GetPeopleList()
        {
            return clsPersonData.GetAllPeople();
        }
    
        public bool Save()
        {
            switch (_Mode) 
            {
                case enMode.enAddNew:
                    if (_AddNewPerson())
                    {
                        _Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;
                    
                case enMode.enUpdate:
                    if (_UpdatePerson())
                        return true;
                    else
                        return false;
            }
            return false;
        }
    }
}

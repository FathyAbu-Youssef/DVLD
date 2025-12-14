using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 1, Update = 2 }

        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }

        public string NationalNo { set; get; }

        public string FirstName { set; get; }

        public string SecondName { set; get; }

        public string ThirdName { set; get; }

        public string LastName { set; get; }

        public string FullName
        {
            get
            {
                return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; ; }
        }

        public DateTime DateOfBirth { set; get; }

        public byte Gendor { set; get; }

        public string GendorText
        {
            get
            {
                if (Gendor == 0)
                    return "Male";

                return "Female";
            }
        }

        public string Address { set; get; }

        public string Phone { set; get; }

        public string Email { set; get; }

        public int NationalityCountryID { set; get; }

        public string ImagePath { set; get; }

        public clsCounty CountryInfo;

        public clsPerson()
        {
            PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gendor = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            CountryInfo = new clsCounty();
            ImagePath = string.Empty;
        }

        private clsPerson(
            int PersonID,
            string NationalNo,
            string FirstName,
            string SecondName,
            string ThirdName,
            string LastName,
            DateTime DateOfBirth,
            byte Gendor,
            string Address,
            string Phone,
            string Email,
            int NationalityCountryID,
            string ImagePath
        )
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.CountryInfo = clsCounty.GetCountryInfoByID(NationalityCountryID);
            this.ImagePath = ImagePath;
            this.Mode = enMode.Update;
        }

        private bool _AddNewPerson() 
        {
             PersonID= clsPersonData.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, ThirdName, this.LastName, this.DateOfBirth,
                               this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
            return this.PersonID != -1;
        }
     
        private bool _UpdatPerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, ThirdName, this.LastName, this.DateOfBirth,
                                this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static clsPerson FindPersonByID(int PersonID)
        {
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = 0;
            string ImagePath = "";


            bool IsFound = clsPersonData.GetPerosonInfoByID(PersonID,ref NationalNo,ref FirstName,ref SecondName,ref ThirdName,ref LastName,
              ref DateOfBirth,ref Gendor,ref Address,ref Phone,ref Email,ref NationalityCountryID,ref ImagePath);
            
            if (IsFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);

            }
            else
            {
                return null;
            }
        }

        public static clsPerson FindPersonByNO(string NationalNo)
        {
            int PersonID = 0;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            string Address = "";
            string Phone = "";
            string Email = "";
            int NationalityCountryID = 0;
            string ImagePath = "";


            bool IsFound = clsPersonData.GetPerosonInfoByNo(NationalNo,ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName,
              ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);

            if (IsFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                                    DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);

            }
            else
            {
                return null;
            }
        }

        public bool Save() 
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    Mode = enMode.Update;
                    return _AddNewPerson();

                case enMode.Update:
                    return _UpdatPerson();

            }
            return false;
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        static public bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static bool IsPersonExist(int PersonID) 
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExists(int NationalNumber)
        {
            return clsPersonData.IsPersonExist(NationalNumber);
        }
    }
}

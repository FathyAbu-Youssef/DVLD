using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsCounty
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCounty()
        {
            CountryID = 0;
            CountryName = string.Empty;
        }

        private clsCounty(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCounty GetCountryInfoByID(int NationalityCountryID)
        {
            string CountryName = string.Empty;

            if (clsCountryData.GetCountryInfoByID(NationalityCountryID, ref CountryName)) 
            {
                return new clsCounty(NationalityCountryID, CountryName);
            }
            return null;
        }

        public static clsCounty GetCountryInfoByName(string CountryName)
        {
            int CountryID = -1;

            if (clsCountryData.GetCountryInfoByName(ref CountryID ,CountryName))
            {
                return new clsCounty(CountryID, CountryName); ;
            }
            return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

    }
}
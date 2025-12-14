using DVLD_DataAccess;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsDetainedLicense
    {
        enum enMode {AddNew =1,Update =2 }
        enMode Mode;

        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate { set; get; }
        public float FineFees { set; get; } 
        public int CreatedByUserID { set; get; }
        public clsUser CreatedByUserInfo { set; get; }
        public bool IsReleased { set; get; }    
        public DateTime ReleaseDate { set; get; }
        public int ReleaseByUserID { set; get; }
        public clsUser ReleaseByUserInfo { set; get; }  
        public int ReleaseApplicationID { set; get; }

        public clsDetainedLicense() 
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.MinValue;
            FineFees = 0;
            CreatedByUserID = -1;
            CreatedByUserInfo = new clsUser();
            IsReleased = false;
            ReleaseDate = DateTime.MinValue;
            ReleaseByUserID = -1;
            ReleaseByUserInfo = new clsUser();
            ReleaseApplicationID = -1;
            Mode = enMode.AddNew;
        }

        private clsDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID, bool IsReleased,
             DateTime ReleaseDate, int ReleaseByUserID, int ReleaseApplicationID)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleaseByUserID = ReleaseByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.CreatedByUserInfo = clsUser.FindByUserID(this.CreatedByUserID);
            this.ReleaseByUserInfo = clsUser.FindByUserID(this.ReleaseByUserID);
            this.Mode = enMode.Update;
        }

        private bool _AddNewDetainedLicesne() 
        {
            this.DetainID = clsDetainedLicenseData.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID);
            return this.DetainID != -1;
        }

        private bool _UpdateDetainedLicesne()
        {
            return clsDetainedLicenseData.UpdateDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID);
        }

        public static clsDetainedLicense Find(int DetainID)
        {
            int LicenseID = -1;
            DateTime DetainDate = DateTime.MinValue;
            DateTime ReleaseDate = DateTime.MinValue;
            float FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            bool IsLicenseFound = clsDetainedLicenseData.GetDetainedLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate,
                ref ReleasedByUserID, ref ReleaseApplicationID);

            if (IsLicenseFound)
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
        }

        public static DataTable GetAllDetainedLicenses() 
        {
            return clsDetainedLicenseData.GetAllDetainedLicenses();
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.MinValue;
            DateTime ReleaseDate = DateTime.MinValue;
            float FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;

            bool IsLicenseFound = clsDetainedLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate,
                ref ReleasedByUserID, ref ReleaseApplicationID);

            if (IsLicenseFound)
            {
                return new clsDetainedLicense(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
        }

        public bool Save() 
        {
            bool IsSaved = false;
            switch (Mode) 
            {
                case enMode.AddNew:
                    IsSaved = _AddNewDetainedLicesne();
                    Mode = enMode.Update;
                    break;

                case enMode.Update:
                    IsSaved = _UpdateDetainedLicesne();
                    break;
            }
            return IsSaved;
        }

        public static bool IsLicenseDetained(int LicenseID) 
        {
            return clsDetainedLicenseData.IsLicenseDetained(LicenseID);
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return clsDetainedLicenseData.ReleaseDetainedLicense(this.DetainID, ReleasedByUserID, ReleaseApplicationID);
        }
    }
}

using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicense
    {
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForLost = 3, ReplacementForDamage = 4 }
        enum enMode {AddNew =1,Update = 2 }

        private enMode _Mode;
        public int LicenseID { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public int DriverID { get; set; }
        public DateTime IssueDate { get; set; }
        public float PaidFees { get; set; }
        public int LicenseClass { get; set; }
        public int ApplicationID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CreatedByUserID { get; set; }
        public enIssueReason IssueReason { get; set; }
        public bool IsDetained
        { get { return clsDetainedLicense.IsLicenseDetained(LicenseID); } }
        public clsDriver DriverInfo { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public clsDetainedLicense DetainedLicenseInfo { get; set; }
      
        public clsLicense()
        {
            this.LicenseID = 0;
            this.Notes = string.Empty;
            this.IsActive = false;
            this.DriverID = 0;
            this.IssueDate = DateTime.Now;
            this.PaidFees = 0;
            this.LicenseClass = 0;
            this.ApplicationID = 0;
            this.ExpirationDate = DateTime.Now;
            this.CreatedByUserID = 0;
            this.IssueReason = 0;
            this._Mode = enMode.AddNew;
        }

        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DetainedLicenseInfo = clsDetainedLicense.FindByLicenseID(LicenseID);
            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseClassInfo = clsLicenseClass.Find(this.LicenseClass);
            _Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 
            return clsLicenseData.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static clsLicense Find(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0; bool IsActive = true; int CreatedByUserID = -1;
            byte IssueReason = 1;

            if (clsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }
            else
                return null;
        }

        public static DataTable GetAllLicenses()
        {
            return clsLicenseData.GetAllLicenses();
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();
            }
            return false;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, byte LicenseClassID)
        {
            return GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID) 
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetDriverLicenses(DriverID);
        }

        public bool IsLicenseExpired()
        {
            return ExpirationDate < DateTime.Now;
        }

        public bool DeactivateCurrentLicense() 
        {
            return clsLicenseData.DeactivateLicense(LicenseID);
        }

        public string GetIssueReason()
        {
            return GetIssueReasonText(this.IssueReason);
        }
        public static string GetIssueReasonText(enIssueReason IssueReason) 
        {
            switch (IssueReason) 
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementForDamage:
                    return "Replacement for Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        
        }

        public int Detain(int CreatedByUserID, float FineFees) 
        {
            clsDetainedLicense NewDetainedLicense = new clsDetainedLicense();
            NewDetainedLicense.LicenseID = this.LicenseID;
            NewDetainedLicense.DetainDate = DateTime.Now;
            NewDetainedLicense.CreatedByUserID =CreatedByUserID;
            NewDetainedLicense.FineFees = FineFees;

            if (!NewDetainedLicense.Save())
            {
                return -1;
            }
            return NewDetainedLicense.DetainID;
        }

        private int _GetNewApplicationID(clsApplication.enApplicationType ApplicationType,int CreatedByUserID) 
        {
            clsApplication Application = new clsApplication();
            Application.ApplicantPersonID = DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = ApplicationType;
            Application.ApplicationStatus = clsApplication.enStatus.Complete;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)Application.ApplicationTypeID).Fees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return -1;
            }

            return Application.ApplicationID;
        }

        public bool ReleaseDetainedLicesne(int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            ApplicationID = _GetNewApplicationID(clsApplication.enApplicationType.ReleaseDetainedDrivingLicense, CreatedByUserID);

            if (ApplicationID != -1)  
            {
                ReleaseApplicationID = ApplicationID;
                return this.DetainedLicenseInfo.ReleaseDetainedLicense(ReleasedByUserID, ReleaseApplicationID);
            }
            return false;
        }

        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {
            //incase if the user used this function without making validation in interface layer 
            if (!IsLicenseExpired() || !IsActive)
            {
                return null;
            }

            int RenewApplicationID = _GetNewApplicationID(clsApplication.enApplicationType.RenewDrivingLicense, CreatedByUserID);
            clsLicense License = new clsLicense();

            License.LicenseClass = this.LicenseClass;
            License.ApplicationID = RenewApplicationID;
            License.DriverID=this.DriverID;
            License.IsActive = true;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.Notes=Notes;
            License.IssueReason = enIssueReason.Renew;
            License.CreatedByUserID= CreatedByUserID;

            if (!License.Save())  
            {
                return null;
            }

            this.DeactivateCurrentLicense();
            return License;
        }

        public clsLicense Replace(enIssueReason IssueReason, int CreatedByUserID,string Notes)
        {

            clsApplication.enApplicationType ApplicationType =
                IssueReason == enIssueReason.ReplacementForLost ? 
                clsApplication.enApplicationType.ReplaceLostDrivingLicense 
                : clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;

            int ReplaceApplicationID = _GetNewApplicationID(ApplicationType, CreatedByUserID);

            clsLicense License = new clsLicense();
            License.ApplicationID= ReplaceApplicationID;
            License.DriverID = this.DriverID;
            License.LicenseClass = this.LicenseClass;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = this.ExpirationDate;
            License.Notes = Notes;
            License.PaidFees = 0;
            License.IsActive = true;
            License.IssueReason= IssueReason;
            License.CreatedByUserID= CreatedByUserID;

            if (!License.Save())  
                return null;

            this.DeactivateCurrentLicense();
            return License;
        }

    }
}

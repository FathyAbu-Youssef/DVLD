using DVLD_DataAccess;
using System;
using System.Data;
using System.Diagnostics;

namespace DVLD_Business
{
    public class clsInternationalLicense : clsApplication
    {
        //We Can Use Composition Instead Of Inheritance And It Is Better Than Inheritance But,
        //I Buit It Using Inheritance As A Different Solution 

        private new enum enMode {AddNew =1, Update =2 };
        private enMode Mode = enMode.AddNew;

        public int IssuedUsingLocalLicenseID {  get; set; }
        public int InternationalLicenseID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public clsDriver DriverInfo { get; set; }
        public DateTime IssueDate { get; set; }
        public int DriverID { get; set; }
        public bool IsActive { get; set; }

        public clsInternationalLicense() : base()
        {
            this.ApplicationTypeID = enApplicationType.NewInterNationalLicense;
            this.IssuedUsingLocalLicenseID = -1;
            this.InternationalLicenseID = -1;
            this.ExpirationDate = DateTime.MinValue;
            this.IssueDate = DateTime.MinValue;
            this.DriverID = -1;
            this.DriverInfo = new clsDriver();
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        }

        public clsInternationalLicense(int ApplicationID, int ApplicantPersonID, int CreatedByUserID, DateTime ApplicationDate,
            DateTime LastStatusDate, float PaidFees, enApplicationType ApplicationType, enStatus ApplicationStatus,
            int IssuedUsingLocalLicenseID, int InternationalLicenseID, DateTime ExpirationDate, DateTime IssueDate, int DriverID, bool IsActive)
            : base(ApplicationID, ApplicantPersonID, CreatedByUserID, ApplicationDate, LastStatusDate, ApplicationType, ApplicationStatus,
                  PaidFees)
        {
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.InternationalLicenseID = InternationalLicenseID;
            this.ExpirationDate = ExpirationDate;
            this.IssueDate = IssueDate;
            this.DriverID = DriverID;
            DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            Mode = enMode.Update;
        }

        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicenseData.AddNewInternationalLicense(this.ApplicationID, DriverID, IssuedUsingLocalLicenseID
                , IssueDate, ExpirationDate, this.IsActive, this.CreatedByUserID);

            return this.InternationalLicenseID != -1;
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public override bool Save()
        {

            if (!base.Save())
            {
                return false;
            }


            bool IsSaved = false;

            switch (Mode)
            {
                case enMode.Update:
                    IsSaved = _UpdateInternationalLicense();
                    break;

                case enMode.AddNew:
                    IsSaved = _AddNewInternationalLicense();
                    break;
            }

            Mode = enMode.Update;
            return IsSaved;
        }

        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int IssuedUsingLocalLicenseID = -1;
            int ApplicationID = -1;
            int CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            int DriverID = -1;
            bool IsActive = false;


            bool IsLicenseFound = clsInternationalLicenseData.GetInternationalLicenseInfoByID(InternationalLicenseID, ref ApplicationID,
                ref DriverID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID);


            if (IsLicenseFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

                return new clsInternationalLicense(Application.ApplicationID, Application.ApplicantPersonID, Application.CreatedByUserID
                    , Application.ApplicationDate, Application.LastStatusDate, Application.PaidFees, Application.ApplicationTypeID
                    , Application.ApplicationStatus, IssuedUsingLocalLicenseID, InternationalLicenseID, ExpirationDate, IssueDate, DriverID, IsActive);
            }
            else 
            {
                return null;
            }
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        public static DataTable GetDriverInternationalicenses(int DriverID) 
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }
    }
}

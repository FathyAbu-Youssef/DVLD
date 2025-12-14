using DVLD_DataAccess;
using System;
using System.CodeDom;
using System.Data;

namespace DVLD_Business
{
    public class clsTest
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsTestAppointment TestAppointtmentInfo { get; set; }

        public clsTest()
        {
            TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
            TestAppointtmentInfo = null;
            _Mode = enMode.AddNew;
        }
        private clsTest(int TestID , int TestAppointmentID , bool TestResult , string Notes , int CreatedByUserID) 
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            TestAppointtmentInfo = clsTestAppointment.Find(this.TestAppointmentID);
            _Mode = enMode.Update;
        }

        private bool _AddNewTest() 
        {
            this.TestID = clsTestData.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return this.TestID != -1;
        }

        private bool _UpdateTest() 
        {
            return clsTestData.UpdateTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
        }

        public static clsTest FindTestByTestID(int TestID)
        {
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = string.Empty;
            int CreatedByUserID = 0;

            bool IsFound = clsTestData.GetTestByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);
            
            if (IsFound) 
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            return null;
        }

        public static clsTest FindLastTestByPersonIDAndLicenseClassIDAndTestType(int PersonID, int LicenseClassID, clsTestType.enTestType TestType)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false;
            string Notes = string.Empty;
            int CreatedByUserID = 0;

            bool IsFound = clsTestData.GetLastTestByPersonAndLicenseID(PersonID,LicenseClassID,(byte)TestType,ref TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);

            if (IsFound)
            {
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            return null;

        }

        public static DataTable GetAllTests()
        {
            return clsTestData.GetAllTests();
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTest();

            }

            return false;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }

  
    }

}
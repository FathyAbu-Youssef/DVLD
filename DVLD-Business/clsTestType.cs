using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestType
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }

        public enMode Mode = enMode.AddNew;

        public enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        public clsTestType()
        {
            TestTypeID = enTestType.VisionTest;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;
        }

        private clsTestType(enTestType TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestFees;
            this.Mode = enMode.Update;
        }

        private bool _AddNewTestType()
        {
            int NewTestID = clsTestTypeData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
            return NewTestID != -1;
        }

        private bool _UpdatTestType()
        {
            return clsTestTypeData.UpdatTestType((int)this.TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        public static clsTestType FindTestType(enTestType TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            float TestFees = 0;

            if (clsTestTypeData.GetTestTypeByID((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription, ref TestFees))
            {
                return new clsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestFees);
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            switch (this.Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {
                        this.Mode = enMode.AddNew;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatTestType();

            }

            return false;
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
    }
}

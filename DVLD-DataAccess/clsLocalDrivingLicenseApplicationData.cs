using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool IsApplicationFound = false;

            SqlConnection Connection = new SqlConnection(clsDatatAccessSettings.ConnectionString);
            string Query = @"Select * From LocalDrivingLicenseApplications Where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    IsApplicationFound = true;
                    ApplicationID = (int)Reader["ApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    Reader.Close();
                }
            }
            catch (Exception ex)
            {
                //Error Message: ex.Message
                IsApplicationFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsApplicationFound;
        }

        public bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool IsApplicationFound = false;

            SqlConnection Connection = new SqlConnection(clsDatatAccessSettings.ConnectionString);
            string Query = @"Select * From LocalDrivingLicenseApplications Where ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    IsApplicationFound = true;
                    LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)Reader["LicenseClassID"];
                    Reader.Close();
                }
            }
            catch (Exception ex)
            {
                //Error Message: ex.Message
                IsApplicationFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsApplicationFound;
        }


    }
}

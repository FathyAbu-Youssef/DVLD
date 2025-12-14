using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestData
    {
        public static bool GetTestByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool IsTestFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From Tests Where TestID=@TestID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    Reader.Read();
                    IsTestFound = true;
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult =Convert.ToBoolean(Reader["TestResult"]);
                    if (Reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    Reader.Close();
                }
            }
            catch (Exception ex)
            {
                IsTestFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsTestFound;
        }

        public static bool GetLastTestByPersonAndLicenseID(int PersonID, int LicenseClassID, byte TestTypeID,
            ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)

        {
            bool IsTestFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select Top 1 T.* From Applications A 
                              join LocalDrivingLicenseApplications LA ON A.ApplicationID = LA.ApplicationID
                              join TestAppointments TA On LA.LocalDrivingLicenseApplicationID=TA.LocalDrivingLicenseApplicationID
                              join Tests T On TA.TestAppointmentID = T.TestAppointmentID
                              Where A.ApplicantPersonID=@PersonID And LA.LicenseClassID =@LicenseClassID And TA.TestTypeID=@TestTypeID
                              Order By T.TestAppointmentID DESC ";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    IsTestFound = true;
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    TestResult = (bool)Reader["TestResult"];
                    Notes = (string)Reader["Notes"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    Reader.Close();
                }
            }
            catch (Exception ex)
            {
                IsTestFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsTestFound;
        }

        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Tests order by TestID";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID) 
        {
            int NewTestID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Insert Into Tests (TestAppointmentID,TestResult,Notes,CreatedByUserID)
                             Values (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);

                              Update TestAppointments Set IsLocked=1 
                              Where TestAppointmentID=@TestAppointmentID;

                              Select Scope_Identity()";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);

            if (!string.IsNullOrEmpty(Notes))
                Command.Parameters.AddWithValue("@Notes", TestResult);
            else
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);

            try 
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    NewTestID =Convert.ToInt32(Result);
                }
            }
            catch 
            {
                NewTestID = -1;
            }
            finally { Connection.Close(); }
           
            return NewTestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
             string Notes, int CreatedByUserID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Tests  
                            set TestAppointmentID = @TestAppointmentID,
                                TestResult=@TestResult,
                                Notes = @Notes,
                                CreatedByUserID=@CreatedByUserID
                                where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                rowsAffected = 0;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
                }
            }

            catch (Exception ex)
            {
                PassedTestCount = 0;
            }

            finally
            {
                connection.Close();
            }

            return PassedTestCount;

        }
        

    }
}

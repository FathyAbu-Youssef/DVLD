using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref byte LicenseClassID)
        {
            bool isApplicationFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isApplicationFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = Convert.ToByte(reader["LicenseClassID"]);
                }
                else
                {
                    isApplicationFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isApplicationFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isApplicationFound;
        }

        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID,ref byte LicenseClassID)
        {
            bool isApplicationFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isApplicationFound = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (byte)reader["LicenseClassID"];
                }
                else
                {
                    isApplicationFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                isApplicationFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isApplicationFound;
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dtLocalDrivingLicenseApplications = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View order by ApplicationDate Desc";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dtLocalDrivingLicenseApplications.Load(reader);
                reader.Close();
            }

            catch (Exception ex)
            {
                //Error Message
            }
            finally
            {
                connection.Close();
            }
            return dtLocalDrivingLicenseApplications;
        }

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Insert Into LocalDrivingLicenseApplications(ApplicationID , LicenseClassID)
                            Values(@ApplicationID,@LicenseClassID)
                            Select Scope_Identity()";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID",ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (int.TryParse(Result.ToString(), out int ID))
                {
                    LocalDrivingLicenseApplicationID = ID;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                Connection.Close();
            }
            return LocalDrivingLicenseApplicationID;
        }

        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int AffectedRows = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update  LocalDrivingLicenseApplications  
                            set ApplicationID = @ApplicationID,
                                LicenseClassID = @LicenseClassID
                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (AffectedRows > 0);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID) 
        {
            bool IsPassed = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select top(1) T.TestResult From LocalDrivingLicenseApplications LA  
                              Inner Join TestAppointments TA On LA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                              join Tests T On T.TestAppointmentID = TA.TestAppointmentID
                              Where LA.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID And Ta.TestTypeID=@TestTypeID
                              Order By TA.TestAppointmentID DESC"; 

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && bool.TryParse(Result.ToString(), out bool TestResult)) 
                {
                    IsPassed = TestResult;
                }
            }
            catch (Exception ex) 
            {
                //Error Message
                IsPassed = false;
            }
            finally
            {
                Connection.Close(); 
            }
            return IsPassed;
        }

        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsAttented = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select top(1) T.TestResult From LocalDrivingLicenseApplications LA  
                              Inner Join TestAppointments TA On LA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                              join Tests T On T.TestAppointmentID = TA.TestAppointmentID
                              Where LA.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID And Ta.TestTypeID=@TestTypeID
                              Order By TA.TestAppointmentID DESC";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null )
                {
                    IsAttented = true;
                }
            }
            catch (Exception ex)
            {
                //Error Message
                IsAttented = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsAttented;
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID) 
        {
            byte TotalTrialsPerTest = 0;
           
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select Count(*) As TotalTrialsPerTest from 
                             TestAppointments TA join Tests T On TA.TestAppointmentID = T.TestAppointmentID
                             where TA.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TA.TestTypeID=@TestTypeID";

            SqlCommand Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID",TestTypeID);

            try 
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    TotalTrialsPerTest = Convert.ToByte(Result);
                }
            }
            catch (Exception ex) 
            {
                TotalTrialsPerTest = 0;
            }
            finally 
            {
                Connection.Close();
            }
                return TotalTrialsPerTest;
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicnseApplicationID, int TestTypeID)
        {
            bool Result = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicnseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    Result = true;
                }
            }

            catch (Exception ex)
            {
                //Error Message
            }

            finally
            {
                connection.Close();
            }
            return Result;

        }

    }
}

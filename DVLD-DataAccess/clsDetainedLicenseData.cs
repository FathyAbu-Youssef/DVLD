using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseInfoByID(int DetainID, ref int LicenseID, ref DateTime DetainDate,
            ref float FineFees, ref int CreatedByUserID, 
            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From DetainedLicenses  Where DetainID=@DetainID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DetainID", DetainID);
            SqlDataReader Reader = Command.ExecuteReader();

            try
            {
                Connection.Open();
                Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    Reader.Read();
                    IsFound = true;

                    LicenseID = (int)Reader["LicenseID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = (float)Reader["FineFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];

                    if (Reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                }
                else 
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
                Reader.Close();
            }
            return IsFound;
        }

        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int DetainID , ref DateTime DetainDate, ref float FineFees, ref int CreatedByUserID, 
            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)

        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select Top 1 * From DetainedLicenses  Where LicenseID=@LicenseID
                             Order By DetainID Desc";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
 

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    IsFound = true;

                    DetainID = (int)Reader["DetainID"];
                    DetainDate = (DateTime)Reader["DetainDate"];
                    FineFees = Convert.ToSingle(Reader["FineFees"]);
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    IsReleased = (bool)Reader["IsReleased"];

                    if (Reader["ReleaseDate"] == DBNull.Value)
                        ReleaseDate = DateTime.MaxValue;
                    else
                        ReleaseDate = (DateTime)Reader["ReleaseDate"];

                    if (Reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)Reader["ReleasedByUserID"];

                    if (Reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleaseApplicationID = -1;
                    else
                        ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                }
                else 
                {
                    IsFound = false;
                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dtAllDetainedLicenses = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            /*
             View's Query:

            Select DL.DetainID,L.LicenseID,Dl.DetainDate , DL.IsReleased,DL.FineFees,DL.ReleaseDate,P.NationalNo,
            P.FirstName+' '+P.SecondName+' '+ISNULL(P.ThirdName,' ')+' '+P.LastName As [Full Name],Dl.ReleaseApplicationID
            From People P 
            inner join Drivers D On P.PersonID=D.PersonID
            inner join Licenses L On L.DriverID = D.DriverID 
            inner join DetainedLicenses DL On DL.LicenseID = L.LicenseID 
             */

            string Query = @"Select * From DetainedLicenses_View order by IsReleased Desc";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                dtAllDetainedLicenses.Load(Reader);
                Reader.Close();
            }
            catch
            {
                //Error Message
            }
            finally { Connection.Close(); }

            return dtAllDetainedLicenses;
        }

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID) 
        {
            int NewDetainedLicenseID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Insert Into DetainedLicenses (LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased)
                            Values(@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,0)
                            Select Scope_Identity()";

            SqlCommand Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != DBNull.Value) 
                {
                    NewDetainedLicenseID = Convert.ToInt32(Result);
                }
            }
            catch 
            {
                NewDetainedLicenseID = -1;
            }
            finally { Connection.Close(); }
            return NewDetainedLicenseID;
        }

        public static bool UpdateDetainedLicense(int DetainID,int LicenseID, DateTime DetainDate,float FineFees, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE dbo.DetainedLicenses
                              SET LicenseID = @LicenseID, 
                              DetainDate = @DetainDate, 
                              FineFees = @FineFees,
                              CreatedByUserID = @CreatedByUserID,   
                              WHERE DetainID=@DetainID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainedLicenseID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static bool ReleaseDetainedLicense(int DetainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE dbo.DetainedLicenses
                              SET IsReleased = 1, 
                              ReleaseDate = @ReleaseDate, 
                              ReleaseApplicationID = @ReleaseApplicationID,
                              ReleasedByUserID = @ReleasedByUserID
                              WHERE DetainID=@DetainID;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

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

            return (rowsAffected > 0);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsDetained = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select IsDetained=1 
                            from detainedLicenses 
                            where 
                            LicenseID=@LicenseID 
                            and IsReleased=0;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsDetained = Convert.ToBoolean(result);
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }

            finally
            {
                connection.Close();
            }


            return IsDetained;
            ;

        }

    }

}

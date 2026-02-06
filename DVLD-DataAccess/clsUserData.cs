using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsUserData
    {
        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From Users Where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    isFound = true;
                    PersonID = (int)Reader["PersonID"];
                    UserName = Reader["UserName"].ToString();
                    Password = Reader["Password"].ToString();
                    IsActive = Convert.ToByte(Reader["IsActive"]) == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From Users Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    isFound = true;
                    UserID = (int)Reader["UserID"];
                    UserName = Reader["UserName"].ToString();
                    Password = Reader["Password"].ToString();
                    IsActive = Convert.ToByte(Reader["IsActive"]) == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password, ref int PersonID, ref int UserID, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From Users Where UserName = @UserName And Password=@Password";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    isFound = true;
                    PersonID = (int)Reader["PersonID"];
                    UserID = (int)Reader["UserID"];
                    IsActive = Convert.ToByte(Reader["IsActive"]) == 1 ? true : false;
                }
            }
            catch (Exception ex)
            {
               clsLogger.LogTheException(ex);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Insert Into Users Values(@PersonID,@UserName,@Password,@IsActive);
                             Select Scope_Identity();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            if (IsActive)
                Command.Parameters.AddWithValue("@IsActive", 1);
            else
                Command.Parameters.AddWithValue("@IsActive", 0);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                {
                    UserID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                UserID = -1;
            }
            finally
            {
                Connection.Close();
            }
            return UserID;
        }

        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Update Users Set PersonID=@PersonID,UserName=@UserName,Password=@Password,
                              IsActive=@IsActive where UserID=@UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@UserID", UserID);

            if (IsActive)
                Command.Parameters.AddWithValue("@IsActive", 1);
            else
                Command.Parameters.AddWithValue("@IsActive", 0);
            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                return false;
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dtAllUsers = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"

select U.UserID ,U.PersonID,
                            P.FirstName+' '+p.SecondName+' '+
							case 
							when p.ThirdName is null then ''
							else p.ThirdName+' '
							end
							+p.LastName As[FullName]
                            ,U.UserName , U.IsActive from Users U join People P on U.PersonID =P.PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                    dtAllUsers.Load(Reader);
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                dtAllUsers = null;
            }
            finally
            {
                Connection.Close();
            }
            return dtAllUsers;
        }

        public static bool DeleteUser(int UserID)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Delete From Users Where UserID = @UserID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                RowAffected = 0;
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }

        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select Found=1 From Users Where UserID=@UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select Found=1 From Users Where UserName=@UserName";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }

        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select Found = 1 From Users Where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex) 
            {
                clsLogger.LogTheException(ex);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
    }
}

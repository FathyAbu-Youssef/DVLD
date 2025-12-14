using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {
        public static bool GetPerosonInfoByID(
             int PersonID,
             ref string NationalNo,
             ref string FirstName,
             ref string SecondName,
             ref string ThirdName,
             ref string LastName,
             ref DateTime DateOfBirth,
             ref byte Gendor,
             ref string Address,
             ref string Phone,
             ref string Email,
             ref int NationalityCountryID,
             ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT*
                           FROM People
                           WHERE PersonID = @PersonID;";

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    NationalNo = reader["NationalNo"].ToString();
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();

                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gendor = Convert.ToByte(reader["Gendor"]);
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] == DBNull.Value) 
                    {
                        ImagePath = "";
                    }
                    else
                    ImagePath = reader["ImagePath"].ToString();

                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetPerosonInfoByNo(
                string NationalNo,
              ref int PersonID,
              ref string FirstName,
              ref string SecondName,
              ref string ThirdName,
              ref string LastName,
              ref DateTime DateOfBirth,
              ref byte Gendor,
              ref string Address,
              ref string Phone,
              ref string Email,
              ref int NationalityCountryID,
              ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT*
                           FROM People
                           WHERE NationalNo = @NationalNo;";

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    FirstName = reader["FirstName"].ToString();
                    SecondName = reader["SecondName"].ToString();
                    ThirdName = reader["ThirdName"].ToString();
                    LastName = reader["LastName"].ToString();

                    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    Gendor = Convert.ToByte(reader["Gendor"]);
                    Address = reader["Address"].ToString();
                    Phone = reader["Phone"].ToString();
                    Email = reader["Email"].ToString();

                    NationalityCountryID = Convert.ToInt32(reader["NationalityCountryID"]);

                    if (reader["ImagePath"] == DBNull.Value)    
                        ImagePath = "";
                    
                    else
                        ImagePath = reader["ImagePath"].ToString();

                    isFound = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewPerson(
              string NationalNo,
              string FirstName,
              string SecondName,
              string ThirdName,
              string LastName,
              DateTime DateOfBirth,
              byte Gendor,
              string Address,
              string Phone,
              string Email,
              int NationalityCountryID,
              string ImagePath)
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                            Gendor, Address, Phone, Email, NationalityCountryID, ImagePath)
                            VALUES
                           (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth,
                            @Gendor, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (string.IsNullOrEmpty(ThirdName)){Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);}
            else { Command.Parameters.AddWithValue("@ThirdName", ThirdName); }

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (string.IsNullOrEmpty(Email)) { Command.Parameters.AddWithValue("@Email", DBNull.Value); }
            else { Command.Parameters.AddWithValue("@Email", Email); }

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (string.IsNullOrEmpty(ImagePath)) { Command.Parameters.AddWithValue("@ImagePath", DBNull.Value); }
            else { Command.Parameters.AddWithValue("@ImagePath", ImagePath); }

            try
            {
                Connection.Open();
                PersonID = Convert.ToInt32(Command.ExecuteScalar());
            }
            catch(Exception ex) 
            {
                PersonID = -1;
            }
            finally
            {
                Connection.Close();
            }
            return PersonID;
        }

        public static bool UpdatePerson(
              int PersonID,
              string NationalNo,
              string FirstName,
              string SecondName,
              string ThirdName,
              string LastName,
              DateTime DateOfBirth,
              byte Gendor,
              string Address,
              string Phone,
              string Email,
              int NationalityCountryID,
              string ImagePath)
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE People
                             SET
                                 NationalNo = @NationalNo,
                                 FirstName = @FirstName,
                                 SecondName = @SecondName,
                                 ThirdName = @ThirdName,
                                 LastName = @LastName,
                                 DateOfBirth = @DateOfBirth,
                                 Gendor = @Gendor,
                                 Address = @Address,
                                 Phone = @Phone,
                                 Email = @Email,
                                 NationalityCountryID = @NationalityCountryID,
                                 ImagePath = @ImagePath
                             WHERE
                                 PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            Command.Parameters.AddWithValue("@ThirdName",
            string.IsNullOrWhiteSpace(ThirdName) ? (object)DBNull.Value : ThirdName);

            Command.Parameters.AddWithValue("@Email",
                 string.IsNullOrWhiteSpace(Email) ? (object)DBNull.Value : Email);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            Command.Parameters.AddWithValue("@ImagePath",
                string.IsNullOrWhiteSpace(ImagePath) ? (object)DBNull.Value : ImagePath);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                RowAffected = 0;
                throw;
            }
            finally 
            {
                Connection.Close(); 
            }

            return RowAffected != 0;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dtAllPeople = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT 
                           p. PersonID,
                           p. NationalNo,
                           p. FirstName,
                           p. SecondName,
                           p. ThirdName,
                           p. LastName,
                             CASE 
                                 WHEN P.Gendor = 0 THEN 'Male'
                                 ELSE 'Female'
                             END AS Gender,
                             Address,
                             Phone,
                             Email,
                             C.CountryName As [Nationality],
                             ImagePath
                         FROM People P 
						 join Countries  C on C.CountryID=P.NationalityCountryID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows) 
                {
                    dtAllPeople.Load(Reader);
                }
            }
            catch (Exception)
            {
                dtAllPeople = new DataTable();
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return dtAllPeople;
        }

        public static bool DeletePerson(int PersonID) 
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Delete From People Where PersonID=@PersonID";

            SqlCommand Command = new SqlCommand(@Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                RowAffected=Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                RowAffected = 0;
            }
            finally 
            {
                Connection.Close();
            }
            return RowAffected != 0;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT 1 FROM People
                     WHERE PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                object result = Command.ExecuteScalar();
                isExist = (result != null);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if person exists: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }

        public static bool IsPersonExist(string NationalNo)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT 1 FROM People
                     WHERE NationalNo = @NationalNo;";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                object result = Command.ExecuteScalar();
                isExist = (result != null);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking if person exists: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }
    }
}

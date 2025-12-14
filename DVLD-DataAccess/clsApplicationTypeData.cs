using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypeData
    {
        public static bool GetApplicationTypeByID(int ApplicationTypeID, ref string ApplicationTitle, ref float ApplicationFees)
        {
            bool isfound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From ApplicationTypes Where ApplicationTypeID=@ApplicationTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    isfound = true;
                    ApplicationTitle = reader["ApplicationTypeTitle"].ToString();
                    ApplicationFees = Convert.ToInt32(reader["ApplicationFees"]);
                    reader.Close();
                }

            }
            catch (Exception)
            {
                isfound = false;
                throw;
            }
            finally
            {
                Connection.Close();
            }

            return isfound;
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable Result = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From ApplicationTypes";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    Result.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Connection.Close();
            }
            return Result;
        }

        public static int AddNewApplicationType(string ApplicationTitle, float ApplicationFees)
        {
            int InsertedID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Insert Into ApplicationTypes Values (@ApplicationTitle , ApplicationFees)
                            Select Scope-Identity()";

            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("@ApplicationTitle", ApplicationTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    InsertedID = Convert.ToInt32(result);
                }
            }
            catch
            {
                InsertedID = -1;
            }
            finally { Connection.Close(); }

            return InsertedID;
        }

        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTitle, float ApplicationFees)
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Update ApplicationTypes Set ApplicationTypeTitle=@ApplicationTypeTitle,ApplicationFees=@ApplicationFees where ApplicationTypeID=@ApplicationTypeID";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationTypeID ", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationTypeTitle ", ApplicationTitle);
            Command.Parameters.AddWithValue("@ApplicationFees ", ApplicationFees);

            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Connection.Close();
            }
            return RowAffected > 0;
        }
    }
}

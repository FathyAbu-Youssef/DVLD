using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {
        public static bool GetTestTypeByID(int TestTypeID, ref string TestTypeTitle, ref string TestDescription, ref float TestFees) 
        {
            bool isTestTypeFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From TestTypes  Where TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try 
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                
                if (Reader.Read()) 
                {
                    isTestTypeFound = true;
                    TestTypeTitle = Reader["TestTypeTitle"].ToString();
                    TestDescription = Reader["TestTypeDescription"].ToString();
                    TestFees =Convert.ToSingle(Reader["TestTypeFees"]);
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                isTestTypeFound = false;        
            }
            finally 
            {
                Connection.Close();
            }

            return isTestTypeFound;
        }

        public static DataTable GetAllTestTypes() 
        {
            DataTable AllTestTypes = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select * From TestTypes";
            SqlCommand Command = new SqlCommand(Query,Connection);

            try 
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                AllTestTypes.Load(Reader);
            }
            catch (Exception ex) 
            {
                clsLogger.LogTheException(ex);
                AllTestTypes = new DataTable();
            }
            finally{ Connection.Close(); }

            return AllTestTypes;
        }

        public static int AddNewTestType(string TestTypeTitle, string TestDescription, float TestFees) 
        {
            int NewTestTypeID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Insert Into DataTypes
                             Values(@TestTypeTitle,@TestDescription,@TestFees);
                             Select Scope_Identity();";

            SqlCommand Command = new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("@TestDescription", TestDescription);
            Command.Parameters.AddWithValue("@TestFees", TestFees);

            try 
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                
                if (int.TryParse(Result.ToString(),out int NewlyInsertedID)) 
                {
                    NewTestTypeID = NewlyInsertedID;
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                NewTestTypeID = -1;
            }
            finally
            {
                Connection.Close(); 
            } 
            return NewTestTypeID;
        }

        public static bool UpdatTestType(int TestTypeID, string TestTypeTitle, string TestDescription, float TestFees)
        {
            bool isTestUpdated=false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Update TestTypes
                            Set TestTypeTitle=@TestTypeTitle,
                                TestTypeDescription=@TestTypeDescription,
                                TestTypeFees=@TestFees
                                Where TestTypeID=@TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            Command.Parameters.AddWithValue("@TestTypeDescription", TestDescription);
            Command.Parameters.AddWithValue("@TestFees", TestFees);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                Connection.Open();
                if (Command.ExecuteNonQuery() > 0) 
                {
                    isTestUpdated = true;
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogTheException(ex);
                isTestUpdated = false;
            }
            finally
            {
                Connection.Close();
            }
            
            return isTestUpdated;

        }
    }
}

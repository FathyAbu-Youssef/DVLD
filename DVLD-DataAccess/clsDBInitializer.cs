using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DVLD_DataAccess
{
    public class clsDBInitializer
    {
        private static string MasterConnectionString = "Server=.;Database=master;Integrated Security=True;";
        public static string AppConnectionString = "Server=.;Database=DVLD;Integrated Security=True;";
        private const string ResourceName = "DVLD_DataAccess.DVLD_Schema_Setup.sql";

        public static void InitializeDatabase()
        {
            if (DatabaseExists("DVLD"))
            {
                return; // Database is ready, do nothing.
            }
            ExecuteSchemaScript();
        }

        private static bool DatabaseExists(string databaseName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(AppConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                // Error 4060: Cannot open database requested by the login. (Database likely doesn't exist)
                // We assume if it fails to open, the database is missing.
                if (ex.Number == 4060 || ex.Number == 18456)
                {
                    return false;
                }
                // For any other exception (e.g., server not found), re-throw
                throw;
            }
        }

        private static void ExecuteSchemaScript()
        {
            string scriptContent = GetScriptContent();

            using (SqlConnection connection = new SqlConnection(MasterConnectionString))
            {
                connection.Open();
                string[] commandTexts = Regex.Split(scriptContent, @"^GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                foreach (string commandText in commandTexts)
                {
                    if (string.IsNullOrWhiteSpace(commandText)) continue;

                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
               
                        if (commandText.Trim().StartsWith("CREATE DATABASE", StringComparison.OrdinalIgnoreCase))
                        {
                            command.ExecuteNonQuery(); 
                        }
                        else
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private static string GetScriptContent()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(ResourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException($"Embedded resource '{ResourceName}' not found.");
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
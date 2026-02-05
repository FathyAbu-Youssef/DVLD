using DVLD_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace DVLD__Version_02_.Classes
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser { get; set; }

        internal static bool LoadUserNameAndPassword(ref string UserName, ref string Password)
        {
            /*
            Old Way To Load User Credentials From The File

            try
            {
                string FilePath = System.IO.Directory.GetCurrentDirectory() + "\\Data.txt";

                if (File.Exists(FilePath))
                {
                    using (StreamReader Reader = new StreamReader(FilePath))
                    {
                        string Line = Reader.ReadLine();
                        string[] strSplit = Line.Split(new string[] { "--" }, StringSplitOptions.None);
                        UserName = strSplit[0];
                        Password = strSplit[1];
                        return true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("An Error Occured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
            */

            //The New Way For Loading USER CREDENTIALS From The Registry

            string KeyPath = "HKEY_CURRENT_USER\\Software\\USER-CREDENTIALS";

            try 
            {
                UserName = Registry.GetValue(KeyPath, "UserName", null) as string;
                Password = Registry.GetValue(KeyPath, "Password", null) as string;
            }
            catch
            {
                return false;
            }
            return !(string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password));
        }

        internal static void RememberUserNameAndPassword(string UserName, string Password)
        {
            /*
             Old Way To Save User Credentials In A File
            string DirectoryPath = System.IO.Directory.GetCurrentDirectory();
            string FilePath = DirectoryPath + "\\Data.txt";

            if (UserName == "") 
            {
                File.Delete(FilePath);
                return;
            }

            using (StreamWriter Writer = new StreamWriter(FilePath)) 
            {
                string DataToSave = UserName + "--" + Password;
                Writer.WriteLine(DataToSave);
                return;
            }
            */

            //The New Way For Saving USER CREDENTIALS In The Registry
            
            string KeyPath = "HKEY_CURRENT_USER\\Software\\USER-CREDENTIALS";

            try 
            {
                Registry.SetValue(KeyPath, "UserName", UserName);
                Registry.SetValue(KeyPath, "Password", Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       
        }
    }
}

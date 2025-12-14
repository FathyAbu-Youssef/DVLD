using DVLD_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.Classes
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser { get; set; }

        internal static bool LoadUserNameAndPassword(ref string UserName, ref string Password)
        {
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
        }

        internal static void RememberUserNameAndPassword(string UserName, string Password)
        {
            //Either UserName And Password Are Empty Or Full 
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
        }
    }
}

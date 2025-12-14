using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.Classes
{
    public class clsUtil
    {
        private static bool CreateDirectoryIfNotExists(string DirectoryName)
        {
            if (!Directory.Exists(DirectoryName))
            {
                try
                {
                    Directory.CreateDirectory(DirectoryName);
                }
                catch
                {
                    return false; 
                }

            }

            return true;
        }

        private static string GenerateGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        private static string CreateFileName(string SourceFile)
        {
            FileInfo info = new FileInfo(SourceFile);
            return GenerateGuid()+ info.Extension;
        }

        internal static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string ProjectFolder = Directory.GetCurrentDirectory() + "\\Project_Images_Folder\\";

            if (!CreateDirectoryIfNotExists(ProjectFolder)) 
            {
                return false;
            }

            string DestinationImageFile = ProjectFolder +CreateFileName(SourceFile);

            try 
            {
                File.Copy(SourceFile, DestinationImageFile, true);
                SourceFile = DestinationImageFile;
            }
            catch 
            {
                return false;
            }
            return true;
        }
    }
}

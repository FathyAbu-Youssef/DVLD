using DVLD__Version_02_.Applications.Detain_License;
using DVLD__Version_02_.Applications.International_License;
using DVLD__Version_02_.Applications.LocalDrivingLicense;
using DVLD__Version_02_.Applications.Release_Detained_License;
using DVLD__Version_02_.Applications.RenewLocalLicense;
using DVLD__Version_02_.Applications.ReplaceLostOrDamagedLicense;
using DVLD__Version_02_.Drivers;
using DVLD__Version_02_.Licenses.InternationalLicense;
using DVLD__Version_02_.Licenses.Local_Licenses;
using DVLD__Version_02_.Login;
using DVLD__Version_02_.Tests;
using DVLD__Version_02_.Users;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //This will build the database of the poject if not exists 
            clsInitializer.InitializeDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}

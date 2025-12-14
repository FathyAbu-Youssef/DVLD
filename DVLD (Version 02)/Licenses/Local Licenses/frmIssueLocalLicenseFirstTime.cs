using DVLD__Version_02_.Classes;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.Licenses.Local_Licenses
{
    public partial class frmIssueLocalLicenseFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;

        public frmIssueLocalLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueLocalLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)  
            {
                MessageBox.Show("Invalid Local Driving License Application ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_LocalDrivingLicenseApplication.DoesPassAllTests()) 
            {
                MessageBox.Show("Not Passed All Tests , Please Pass All Tests First", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicenseApplication.GetActiveLicenseID();

            if (LicenseID != -1) 
            {
                MessageBox.Show($"This Application Completed With Active License ID:{LicenseID} ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlLocalDrivingLicenseInfo1.LoadApplicationInfoByLocalDrivingLicesneID(_LocalDrivingLicenseApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicenseApplication.IssueLicenseForTheFirstTime(txtNotes.Text, clsGlobal.CurrentUser.UserID);
            if (LicenseID == -1)
            {
                MessageBox.Show("License Didn't Issue Successfully", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else 
            {
                MessageBox.Show("License Issued Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

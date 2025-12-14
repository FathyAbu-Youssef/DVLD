using DVLD__Version_02_.Licenses.Local_Licenses;
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

namespace DVLD__Version_02_.Applications.LocalDrivingLicense
{
    public partial class ctrlLocalDrivingLicenseInfo : UserControl
    {
        private int __LocalDrivingLicenseApplicationID;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public int LocalDrivingLicenseApplicationID 
        {
            get { return __LocalDrivingLicenseApplicationID; }
        }

        public ctrlLocalDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfoByLocalDrivingLicesneID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.
                FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                ResetDefaultApplicationInfo();
                MessageBox.Show("Can't Find This Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FilLocalDrivingLicenseApplicationInfo();
        }

        private void _FilLocalDrivingLicenseApplicationInfo()
        {
            __LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            ctrlApplicationBasicInfo1.LoadApplicationData(_LocalDrivingLicenseApplication.ApplicationID);

            lbDLAID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount() + "/3";
            lbLicenceClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            llShowLicenseInfo.Enabled=_LocalDrivingLicenseApplication.GetActiveLicenseID() != -1;
        }

        private void ResetDefaultApplicationInfo()
        {
            ctrlApplicationBasicInfo1.RestApplicationInfo();
            lbDLAID.Text = "??";
            lbPassedTests.Text = "0/3";
            lbLicenceClass.Text = "??";
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}

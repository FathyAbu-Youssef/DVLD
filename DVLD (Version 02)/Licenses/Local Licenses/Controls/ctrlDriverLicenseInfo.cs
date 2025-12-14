using DVLD__Version_02_.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicense _License;

        public int LicenseID { get { return _LicenseID; } }
        public clsLicense License { get { return _License; } }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadData(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show($"Error : No License With This ID {_LicenseID}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                _ResetDefaultValues();
                return;
            }

            lbLicenseClass.Text = _License.LicenseClassInfo.ClassName;
            lbDriverName.Text = _License.DriverInfo.PersonInfo.FullName;
            lbLicenseID.Text = _License.LicenseID.ToString();
            lbNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lbGendor.Text = _License.DriverInfo.PersonInfo.GendorText;
            lbIssueDate.Text = _License.IssueDate.ToString("MM-yyyy");
            lbNotes.Text = string.IsNullOrEmpty(_License.Notes) ? "No Notes" : _License.Notes;
            lbIsActive.Text = _License.IsActive ? "Yes" : "No";
            lbDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToString("ddd-m-yyyy");
            lbDriverID.Text = _License.DriverID.ToString();
            lbExpiratiionDate.Text = _License.ExpirationDate.ToString("MM-yyyy");
            lbIsDetained.Text = clsDetainedLicense.IsLicenseDetained(_LicenseID) ? "Yes" : "No";
            lbIssueReason.Text = _License.GetIssueReason();

            _LoadPersonImage();
        }

        private void _ResetDefaultValues()
        {
            lbLicenseClass.Text = "??";
            lbDriverName.Text = "??";
            lbLicenseID.Text = "??";
            lbNationalNo.Text = "??";
            lbGendor.Text = "??";
            lbIssueDate.Text = "??";
            lbNotes.Text = "??";
            lbIsActive.Text = "??";
            lbDateOfBirth.Text = "??";
            lbDriverID.Text = "??";
            lbExpiratiionDate.Text = "??";
            lbIsDetained.Text = "??";
            lbIssueReason.Text = "??";
            PBPersonImage.Image = Resources.arab_man;
        }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                PBPersonImage.Image = Resources.arab_man;
            else
                PBPersonImage.Image = Resources.woman;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
            {
                PBPersonImage.Load(ImagePath);
            }
         
        }
    }
}

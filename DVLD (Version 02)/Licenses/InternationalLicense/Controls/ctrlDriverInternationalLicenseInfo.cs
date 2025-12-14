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

namespace DVLD__Version_02_.Licenses.InternationalLicense.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense = null;

        public int InterationalLicenseID { get { return InterationalLicenseID; } }
        public clsInternationalLicense InternationalLicense { get { return _InternationalLicense; } }
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            _InternationalLicenseID = InternationalLicenseID;

            if (_InternationalLicense == null)
            {
                MessageBox.Show($"Invalid International License With ID {InternationalLicenseID}", "Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _LoadLicenseInfo();
        }
        private void _LoadLicenseInfo()
        {
            lbDriverName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lbLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lbNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lbGendor.Text = _InternationalLicense.DriverInfo.PersonInfo.GendorText;
            lbDriverID.Text = _InternationalLicense.DriverID.ToString();
            lbIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lbDateOfBirth.Text = _InternationalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString("dd-MMM-yyyy");
            lbExpiratiionDate.Text = _InternationalLicense.ExpirationDate.ToString("dd-MMM-yyyy");
            lbApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lbIssueDate.Text = _InternationalLicense.IssueDate.ToString("dd-MMM-yyyy");

            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.Gendor == 0)
            {
                PBPersonImage.Image = Resources.arab_man;
            }
            else
            {
                PBPersonImage.Image = Resources.woman;
            }

            string PersonImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (!string.IsNullOrEmpty(PersonImagePath) && File.Exists(PersonImagePath))
            {
                PBPersonImage.Load(PersonImagePath);
            }
        }
    }
}

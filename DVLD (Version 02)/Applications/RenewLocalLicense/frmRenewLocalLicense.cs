using DVLD__Version_02_.Classes;
using DVLD__Version_02_.Licenses;
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

namespace DVLD__Version_02_.Applications.RenewLocalLicense
{
    public partial class frmRenewLocalLicense : Form
    {
        private int _NewLicenseID;

        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }

        private void frmRenewLocalLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            lbApplicationDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            lbIssueDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            lbApplicationFees.Tag = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lbApplicationFees.Text = lbApplicationFees.Tag + " $";
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void _ResetDefaultValues()
        {
            lbRenewApplicationID.Text = "??";
            lbApplicationFees.Text = "??";
            lbLicenseFees.Text = "??";
            txtNotes.Text = "";
            lbRenewApplicationID.Text = "??";
            lbLocalLicenseID.Text = "??";
            lbExpirationDate.Text = "??";
            lbCreatedBy.Text = "??";
            lbTotalFees.Text = "??";
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Renew This License", "Validate", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) ==
           DialogResult.Cancel) 
            {
                return;
            }
            clsLicense NewLicense =
                ctrlDriverLicenseInfoWithFilter1.SelectedLicense.RenewLicense(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (NewLicense != null)
            {
                MessageBox.Show("License Renewed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("License Didn't Renew Successfully", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lbRenewApplicationID.Text = NewLicense.ApplicationID.ToString();
            lbRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            llShowLicenseInfo.Enabled = true;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            btnRenew.Enabled = false;
        }
        private void ctrlDriverLicenseInfoWithFilter1_OnPersonSelected_1(int LicenseID)
        {
            lbLocalLicenseID.Text = LicenseID.ToString();
            llLicenseHistory.Enabled =llShowLicenseInfo.Enabled =(LicenseID != -1);
            if (LicenseID == -1)
            {
                _ResetDefaultValues();
                return;
            }
            _NewLicenseID = LicenseID; 
            lbLicenseFees.Tag = ctrlDriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.ClassFees.ToString();
            lbLicenseFees.Text = lbLicenseFees.Tag + " $";
            txtNotes.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicense.Notes.ToString();
            lbExpirationDate.Text = DateTime.Now.AddYears
                (ctrlDriverLicenseInfoWithFilter1.SelectedLicense.LicenseClassInfo.DefaultValidityLength)
                .ToString("dd-MMM-yyyy");
            lbTotalFees.Text = (Convert.ToSingle(lbApplicationFees.Tag) + Convert.ToSingle(lbLicenseFees.Tag)).ToString() + " $";

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicense.IsLicenseExpired())
            {
                MessageBox.Show($"This License Didn't Expire , It Will Expire At {ctrlDriverLicenseInfoWithFilter1.SelectedLicense.ExpirationDate}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("This License Is Not Active , Please Choose An Active One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnRenew.Enabled = true;
        }
        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}

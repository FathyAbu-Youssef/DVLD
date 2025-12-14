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

namespace DVLD__Version_02_.Applications.ReplaceLostOrDamagedLicense
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        private int _NewLicenseID = -1;

        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDamagedLicense.Checked) 
            {
                this.Text = "Replace Damaged License";
                lbApplicationFees.Text =
                   clsApplicationType.Find((int)clsLicense.enIssueReason.ReplacementForDamage).Fees.ToString() + " $";
            }
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLostLicense.Checked) 
            {
                this.Text = "Replace Lost License";
                lbApplicationFees.Text = 
                    clsApplicationType.Find((int)clsLicense.enIssueReason.ReplacementForLost).Fees.ToString() + " $";
            }
        }

        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
            lbApplicationDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            rbDamagedLicense.Checked = true;
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnPersonSelected(int SelectedLicense)
        {
            llLicenseHistory.Enabled = (SelectedLicense != -1);

            if (SelectedLicense == -1)
            {
                return;
            }
            lbOldLicenseID.Text = SelectedLicense.ToString();
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicense.IsActive)
            {
                MessageBox.Show("This License Not Active,You Need To Renew It", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnReplace.Enabled = true;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Replace This License?", "Validate", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                != DialogResult.OK)
            {
                return;
            }

            clsLicense NewLicense = ctrlDriverLicenseInfoWithFilter1.SelectedLicense.Replace
                (_GetIssueReason(), 1, txtNotes.Text.Trim());

            if (NewLicense == null)
            {
                MessageBox.Show("License Didn't Replace Successfully!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("License Replaced Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lbIR_ApplicationID.Text = NewLicense.ApplicationID.ToString();
            lbReplacementLicenseID.Text = NewLicense.LicenseID.ToString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            llLicenseInfo.Enabled=true;
            _NewLicenseID = NewLicense.LicenseID;
            btnReplace.Enabled = false;
            ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            gbReplaceForr.Enabled = false;
        }

        private clsLicense.enIssueReason _GetIssueReason()
        {
            return 
                  rbDamagedLicense.Checked ? 
                  clsLicense.enIssueReason.ReplacementForDamage:
                  clsLicense.enIssueReason.ReplacementForLost;
        }

        private void llLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void ctrlDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void llLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicense.DriverInfo.PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}

using DVLD__Version_02_.Applications.ApplicationTypes;
using DVLD__Version_02_.Applications.Detain_License;
using DVLD__Version_02_.Applications.International_License;
using DVLD__Version_02_.Applications.LocalDrivingLicense;
using DVLD__Version_02_.Applications.Release_Detained_License;
using DVLD__Version_02_.Applications.RenewLocalLicense;
using DVLD__Version_02_.Applications.ReplaceLostOrDamagedLicense;
using DVLD__Version_02_.Classes;
using DVLD__Version_02_.Drivers;
using DVLD__Version_02_.Login;
using DVLD__Version_02_.People;
using DVLD__Version_02_.Tests;
using DVLD__Version_02_.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_
{
    public partial class frmMainForm : Form
    {
        frmLogin _LoginForm;

        public frmMainForm(frmLogin LoginForm)
        {
            InitializeComponent(); 
            _LoginForm = LoginForm;
        }
 
        private void PeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void UsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void CurrentUserInfoItem_Click(object sender, EventArgs e)
        {
            frmUserInfocs frm = new frmUserInfocs(clsGlobal.CurrentUser.UserID);
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void ChangePasswordToolItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
  
        private void signOutTooItem_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _LoginForm.Show();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestType frm = new frmManageTestType();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainApplication frm = new frmDetainApplication();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void internationalDrivingLicenseApplicationsItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenseApplications frm = new frmListInternationalLicenseApplications();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void DriversToolStripMenueItem_Click(object sender, EventArgs e)
        {
            frmDriversList frmDriversList = new frmDriversList();
            frmDriversList.StartPosition=FormStartPosition.CenterParent;
            frmDriversList.ShowDialog();
        }
           
        private void ManageDetainedLicencesSubItem_Click(object sender, EventArgs e)
        {
            frmDetainedLicenseList frm = new frmDetainedLicenseList();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void RenewDrivingLicenseItem_Click_1(object sender, EventArgs e)
        {
            frmRenewLocalLicense frm = new frmRenewLocalLicense();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
 
        private void ReplacementForDamageOrLostItem_Click_1(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frm = new frmReplaceLostOrDamagedLicenseApplication();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void NewDrivingLicenseItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void InternationalLicenseSubItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}


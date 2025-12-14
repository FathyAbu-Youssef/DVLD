using DVLD__Version_02_.Licenses.InternationalLicense;
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

namespace DVLD__Version_02_.Licenses
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private int _DriverID;
        private clsDriver _Driver;
        private DataTable _dtLocalLicenses;
        private DataTable _dtInternationalLicenses;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenses()
        {
            _dtLocalLicenses = clsDriver.GetLocalLicenses(_DriverID);
            dgvLocalLicenses.DataSource = _dtLocalLicenses;
            lbLocaclLicensesCount.Text = "# " + dgvLocalLicenses.Rows.Count.ToString() + " Records";
            dgvLocalLicenses.AutoGenerateColumns = false;

            if (dgvLocalLicenses.Rows.Count > 0)
            {
                dgvLocalLicenses.Columns[0].HeaderText = "License ID";
                dgvLocalLicenses.Columns[0].Width = 110;

                dgvLocalLicenses.Columns[1].HeaderText = "Application ID";
                dgvLocalLicenses.Columns[1].Width = 130;

                dgvLocalLicenses.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenses.Columns[2].Width = 270;

                dgvLocalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenses.Columns[3].Width = 170;

                dgvLocalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenses.Columns[4].Width = 170;

                dgvLocalLicenses.Columns[5].HeaderText = "Is Active";
                dgvLocalLicenses.Columns[5].Width = 110;
            }
        }

        private void _LoadInternationalLicenses()
        {
            _dtInternationalLicenses = clsDriver.GetInternationalLicenses(_DriverID);
            dgvInternationalLicenses.DataSource = _dtInternationalLicenses;
            lbInternationalLicensesCount.Text = "# " + dgvInternationalLicenses.Rows.Count.ToString() + " Records";
            dgvInternationalLicenses.AutoGenerateColumns = false;

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "I.License ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 130;

                dgvInternationalLicenses.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[3].Width = 180;

                dgvInternationalLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[5].Width = 120;
            }

        }


        public void LoadData(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(DriverID);

            if (_Driver == null)  
            {
                MessageBox.Show($"Error : Can't Find Driver With ID {_DriverID}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        public void LoadDataByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show($"Person With ID: {PersonID} is Not Linked To Any Driver ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID = _Driver.DriverID;
            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        private void tpLocalLicenses_Click(object sender, EventArgs e)
        {

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicensesID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(LicensesID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LicensesID = (int)dgvLocalLicenses.CurrentRow.Cells[0].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicensesID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        public void Clear()
        {
            if (_dtInternationalLicenses != null && _dtLocalLicenses.Rows != null)
            {
                _dtInternationalLicenses.Rows.Clear();
                _dtLocalLicenses.Rows.Clear();

                lbLocaclLicensesCount.Text = "#Records";
                lbInternationalLicensesCount.Text = "#Records";
            }
        }
    }
}

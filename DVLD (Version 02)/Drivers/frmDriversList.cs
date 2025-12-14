using DVLD__Version_02_.Licenses;
using DVLD__Version_02_.Licenses.Local_Licenses;
using DVLD__Version_02_.People;
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

namespace DVLD__Version_02_.Drivers
{
    public partial class frmDriversList : Form
    {
        private DataTable _dtAllDrivers;

        public frmDriversList()
        {
            InitializeComponent();
        }

        private void frmDriversList_Load(object sender, EventArgs e)
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtAllDrivers;
            lbNumberOfDrivers.Text = "# " + dgvDrivers.Rows.Count.ToString() + " Records";
            cbFilterBy.SelectedIndex = 0;

            if (dgvDrivers.Rows.Count > 0) 
            {
                dgvDrivers.Columns[0].HeaderText = "Driver ID";
                dgvDrivers.Columns[0].Width = 120;

                dgvDrivers.Columns[1].HeaderText = "Person ID";
                dgvDrivers.Columns[1].Width = 120;

                dgvDrivers.Columns[2].HeaderText = "National No";
                dgvDrivers.Columns[2].Width = 140;

                dgvDrivers.Columns[3].HeaderText = "Full Name";
                dgvDrivers.Columns[3].Width = 320;

                dgvDrivers.Columns[4].HeaderText = "Date";
                dgvDrivers.Columns[4].Width = 170;

                dgvDrivers.Columns[5].HeaderText = "Active Licenses";
                dgvDrivers.Columns[5].Width = 150;
            }

        }

        private void dgvDrivers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFilterByvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                return;
            }

            if (cbFilterBy.Text == "National No")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar);
                return;
            }

            if (cbFilterBy.Text == "Full Name") 
            {
                e.Handled =  !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar);
                return;
            }
        }

        private void txtFilterByvalue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            if (FilterColumn == "None" || string.IsNullOrEmpty(txtFilterByvalue.Text))
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                lbNumberOfDrivers.Text = "# " + dgvDrivers.Rows.Count.ToString() + " Records";
                return;
            }

            if (FilterColumn == "NationalNo" || FilterColumn == "FullName")
            {
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterByvalue.Text.Trim());
            }

            else
            {
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, txtFilterByvalue.Text.Trim());
            }

            lbNumberOfDrivers.Text = "# " + dgvDrivers.Rows.Count.ToString() + " Records";
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                txtFilterByvalue.Visible = false;
                txtFilterByvalue.Text = "";
            }
            else
            {
                txtFilterByvalue.Visible = true;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmPersonInfo frm = new frmPersonInfo(PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDrivers.CurrentRow.Cells[1].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}

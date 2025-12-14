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

namespace DVLD__Version_02_.Users
{
    public partial class frmListUsers : Form
    {
        static DataTable _dtAllUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;
            lbNumberOfUsers.Text = "# " + dgvUsers.Rows.Count + " Records";

            dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 50;

            dgvUsers.Columns[1].HeaderText = "Person ID";
            dgvUsers.Columns[1].Width = 50;

            dgvUsers.Columns[2].HeaderText = "Full Name";
            dgvUsers.Columns[2].Width = 100;


            dgvUsers.Columns[3].HeaderText = "UserName";
            dgvUsers.Columns[3].Width = 30;


            dgvUsers.Columns[4].HeaderText = "Is Active";
            dgvUsers.Columns[4].Width = 150;
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfocs frm = new frmUserInfocs((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateUser frm = new frmAdd_UpdateUser();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog(this);

            //Refresh The List
            frmListUsers_Load(null, null);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateUser frm = new frmAdd_UpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //before all this validate first if the user attempt to delete the current user 
            DialogResult Result = MessageBox.Show("Are You Sure To Delete This Person?", "Validate", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (Result == DialogResult.OK)  
            {
                if (clsUser.Delete((int)dgvUsers.CurrentRow.Cells[0].Value))  
                {
                    MessageBox.Show("User Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListUsers_Load(null, null);
                }
                else
                {
                    MessageBox.Show("User Didn't Delete", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void lbAddNew_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateUser frm = new frmAdd_UpdateUser();
            frm.StartPosition=FormStartPosition.CenterParent;
            frm.ShowDialog();
            frmListUsers_Load(null, null);
        }

        private void cmbfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterByvalue.Visible = ((cmbfilter.Text != "None") && (cmbfilter.Text != "Is Active")); ;
            cmbIsActive.Visible = (cmbfilter.Text == "Is Active");
            _dtAllUsers.DefaultView.RowFilter = "";
            lbNumberOfUsers.Text = "# " + dgvUsers.Rows.Count + " Records";
        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = "";

            switch (cmbIsActive.Text)
            {
                case "All":
                    break;

                case "Yes":
                    FilterValue = "1";
                    break;

                case "No":
                    FilterValue = "0";
                    break;
            }

            if (cmbIsActive.Text == "All")
                _dtAllUsers.DefaultView.RowFilter = "";

            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, FilterValue);
      
            lbNumberOfUsers.Text = "# " + dgvUsers.Rows.Count + " Records";
        }

        private void txtFilterByvalue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cmbfilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName"; ;
                    break;

                case "UserName":
                    FilterColumn = "UserName";
                    break;
            }

            if (string.IsNullOrEmpty(txtFilterByvalue.Text.Trim()))
            {
                _dtAllUsers.DefaultView.RowFilter = "";
            }
            else if (FilterColumn == "PersonID" || FilterColumn == "UserID")
            {
                _dtAllUsers.DefaultView.RowFilter = $"{FilterColumn}={txtFilterByvalue.Text.Trim()}";
            }
            else
            {
                _dtAllUsers.DefaultView.RowFilter = $"{FilterColumn} LIke '{txtFilterByvalue.Text.Trim()}%'";
            }
            lbNumberOfUsers.Text = "# " + dgvUsers.Rows.Count + " Records";
        }

        private void txtFilterByvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbfilter.Text == "User ID" || cmbfilter.Text == "Person ID") 
            {
                e.Handled = !(char.IsDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)); 
            }
        }

        private void cmOptions_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}

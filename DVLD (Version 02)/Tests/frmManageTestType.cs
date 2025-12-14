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

namespace DVLD__Version_02_.Tests
{
    public partial class frmManageTestType : Form
    {
        private DataTable _AllTestTypes;
        public frmManageTestType()
        {
            InitializeComponent();
        }

        private void frmManageTestType_Load(object sender, EventArgs e)
        {
            _AllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _AllTestTypes;
            lbNumberOfTests.Text = "# " + dgvTestTypes.RowCount.ToString() + " Records";

            dgvTestTypes.Columns[0].HeaderText = "ID";
            dgvTestTypes.Columns[0].Width = 120;

            dgvTestTypes.Columns[1].HeaderText = "Title";
            dgvTestTypes.Columns[1].Width = 200;

            dgvTestTypes.Columns[2].HeaderText = "Description";
            dgvTestTypes.Columns[2].Width = 400;

            dgvTestTypes.Columns[3].HeaderText = "Fees";
            dgvTestTypes.Columns[3].Width = 100;


        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            frmManageTestType_Load(null, null);
        }
    }
}

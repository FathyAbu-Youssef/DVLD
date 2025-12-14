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

namespace DVLD__Version_02_.People.Cobtrols
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;

        public bool ShowAddPerson 
        {
            get { return btnAddNewPerson.Visible; }
            set { btnAddNewPerson.Visible = value; }
        }
      
        public bool FilterEanabled 
        {
            get { return gbFilter.Enabled; }
            set { gbFilter.Enabled = value; }
        }

        public int PersonID 
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        clsPerson SelectedPersonInfo 
        {
            get { return ctrlPersonCard1.SelectedPerson; }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            cmbFilter.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            FindNow();
        }

        private void FindNow() 
        {
            if (!string.IsNullOrEmpty(txtFilterValue.Text))
            {
                switch (cmbFilter.Text)
                {
                    case "Person ID":
                        ctrlPersonCard1.LoadPersonInfo(Convert.ToInt32(txtFilterValue.Text.Trim()));
                        break;

                    case "National No":
                        ctrlPersonCard1.LoadPersonInfo(txtFilterValue.Text.Trim());
                        break;
                }

            }

            if (OnPersonSelected != null && FilterEanabled)
            {
                OnPersonSelected.Invoke(PersonID);
            }
        }

        private void textFilterBy_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text)) 
            {
                errorProvider1.SetError(txtFilterValue, "This Value Required");
            }
            else 
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void textFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)13) 
            {
                btnFind.PerformClick();
            }

            if (cmbFilter.Text == "Person ID") 
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
            else 
            {
                e.Handled = (!Char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) 
            {
                MessageBox.Show("Please Enter All Required Fields", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FindNow();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdate frm = new frmAddUpdate();
            frm.DataBack += Frm_DataBack;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void Frm_DataBack(object Sender, int PersonID)
        {
            LoadPersonInfo(PersonID);
        }

        internal void FilterFocus()
        {
           txtFilterValue.Focus();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
        }
    }
}

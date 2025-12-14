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

namespace DVLD__Version_02_.Licenses.Local_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        private bool _FilterValue = true;

        public event Action<int> OnPersonSelected;
        public int LicensesID 
        {
            get
            {
                return ctrlDriverLicenseInfo1.LicenseID;
            }
        }
        public clsLicense SelectedLicense
        {
            get 
            {
                return ctrlDriverLicenseInfo1.License;
            }
        }
        public bool FilterEnabled 
        {
            get { return _FilterValue; }
            set
            {
                _FilterValue = value;
                gbFilter.Enabled = value;
            }
        }

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void txtLicenseIDFocus()
        {
            txtLicesneID.Focus();
        }

        public void LoadLicenseInfo(int LicenseID) 
        {
            txtLicesneID.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadData(LicenseID);
            if (OnPersonSelected != null && FilterEnabled)
            {
                OnPersonSelected.Invoke(ctrlDriverLicenseInfo1.LicenseID);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicesneID.Focus();
                return;
            }

            int LicenseID = int.Parse(txtLicesneID.Text);
            LoadLicenseInfo(LicenseID);
        }

        private void txtLicesneID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (e.KeyChar == (char)13)  
            {
                btnFind.PerformClick();
            }
        }

    }
}

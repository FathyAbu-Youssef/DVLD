using DVLD__Version_02_.Classes;
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

namespace DVLD__Version_02_.Applications.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private int _ApplicationTypeID;
        private clsApplicationType _ApplicationType;

        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType != null) 
            {
                lbApplicationTypeID.Text = _ApplicationTypeID.ToString();
                txtTitle.Text = _ApplicationType.Title;
                txtFees.Text = _ApplicationType.Fees.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds Are Invalid", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = Convert.ToSingle(txtFees.Text);

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Application Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmEditApplicationType_Load(null, null);
            }
            else 
            {
                MessageBox.Show("Application Type Didn't Update Successfully", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Tilte Can't Be Empty");
            }
            else 
            {
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.ValidateNumber(txtFees.Text) || string.IsNullOrEmpty(txtFees.Text)) 
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees,"Enter Valid Fees Value");
            }
            else 
            {
                errorProvider1.SetError(txtFees, "");
            }
        }
    }
}

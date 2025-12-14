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

namespace DVLD__Version_02_.Tests
{
    public partial class frmEditTestType : Form
    {
        private clsTestType.enTestType _TestTypeID;
        private clsTestType _TestType;

        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.FindTestType(_TestTypeID);

            if (_TestType != null)
            {
                lbTestTypeID.Text = ((int)_TestTypeID).ToString();
                txtTitle.Text = _TestType.TestTypeTitle;
                txtDescription.Text = _TestType.TestTypeDescription;
                txtFees.Text = _TestType.TestTypeFees.ToString();
            }
            else 
            {
                MessageBox.Show("Error, This Test Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) 
            {
                MessageBox.Show("Please Validate All Required Fields!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text);
            _TestType.TestTypeTitle = txtTitle.Text;
            _TestType.TestTypeDescription = txtDescription.Text;

            if (_TestType.Save())
            {
                MessageBox.Show("Test Updaed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Test Didn't Update Successfully!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim())) 
            {
                errorProvider1.SetError(txtTitle,"Title Can't Be Empty!");
                e.Cancel = true;
            }
            else 
            {
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                errorProvider1.SetError(txtDescription, "Description Can't Be Empty!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtDescription, "");
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                errorProvider1.SetError(txtFees, "Fees Can't Be Empty");
                e.Cancel = true;
                return;
            }

            if(!clsValidation.ValidateNumber(txtFees.Text.Trim())) 
            {
                errorProvider1.SetError(txtFees, "Fees Must Be Valid Number!");
                e.Cancel = true;
                return;

            }
            else
            {
                errorProvider1.SetError(txtFees, "");
                return;
            }
        }
    }
}

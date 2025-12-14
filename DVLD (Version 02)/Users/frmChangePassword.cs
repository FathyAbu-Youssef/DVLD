using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;

        public frmChangePassword(int UserID)
        {
            _UserID = UserID;
            InitializeComponent();
        }

        private void _ResetDefaultValues()
        {
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmNewPassword.Text = string.Empty;
            txtCurrentPassword.Focus();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            _User = clsUser.FindByUserID(_UserID);

            if (_User == null) 
            {
                MessageBox.Show("User not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if ((txtCurrentPassword.Text.Trim() != _User.Password.Trim()) 
                || string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtCurrentPassword, "Wrong Current Password");
                e.Cancel = true;
            }
            else 
            {
                errorProvider1.SetError(txtCurrentPassword, "");
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "Password Can't Be Empty!");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        private void txtConfirmNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if ((txtNewPassword.Text.Trim() !=txtConfirmNewPassword.Text.Trim())
         || string.IsNullOrEmpty(txtConfirmNewPassword.Text.Trim())) 
            {
                errorProvider1.SetError(txtConfirmNewPassword, "Wrong Confirmation!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmNewPassword, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show(
    "Please fill all required fields before saving.",
    "Warning",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning
);
                return;
            }

            _User.Password = txtNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show(
    "Person saved successfully ✅",
    "Success",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information
);
               _ResetDefaultValues();
            }

            else
            {
                MessageBox.Show(
    "Failed to save the person ❌",
    "Error",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error
);
            }
        }
    }
}

using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.Users
{
    public partial class frmAdd_UpdateUser : Form
    {
        enum enMode{AddNew=1,Update=2}

        private int _UserID;
        private clsUser _User;
        private enMode _Mode;

        public frmAdd_UpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAdd_UpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode=enMode.Update;
            _UserID=UserID;
        }

        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);
            ctrlPersonCardWithFilter1.FilterEanabled = false;
            if( _User == null ) 
            {
                MessageBox.Show("This Person Not Here", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbUserId.Text= _UserID.ToString();
            txtPassword.Text = _User.Password;
            txtUserName.Text = _User.UserName;
            txtConfirmPassword.Text = _User.Password;
            cbIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }

        private void _ResetDefaaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lbHeader.Text = "Add New User";
                this.Text = "Add New User";
                btnSave.Enabled = false;
                tpUserInfo.Enabled = false;
                _User = new clsUser();
            }
            else
            {
                lbHeader.Text = "Update User";
                this.Text = "Update User";
                btnSave.Enabled = true;
                tpUserInfo.Enabled=true;
            }
            cbIsActive.Checked = true;
        }

        private void frmAdd_UpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaaultValues();
            if (_Mode == enMode.Update)  
            {
                _LoadData();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update) 
            {
                tabcontrol1.SelectedTab = tabcontrol1.TabPages["tpUserInfo"];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)   
            {
                if (clsUser.isUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID)) 
                {
                    MessageBox.Show("This Person Is Already User", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    btnSave.Enabled = true;
                    tpUserInfo.Enabled = true;
                    tabcontrol1.SelectedTab = tabcontrol1.TabPages["tpUserInfo"];
                }

            }
            else
            {
                MessageBox.Show("You Must Choose The Person First", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)  
        {
            if (ctrlPersonCardWithFilter1.PersonID == -1)  
            {
                MessageBox.Show("You Must Choose The Person First", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew) 
            {
                if (clsUser.isUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("This Person Is Already User", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
     


            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please Enter All Required Fields", "Invalid", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            } 

            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = cbIsActive.Checked;
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            if (_User.Save())
            {
                _Mode = enMode.Update;
                ctrlPersonCardWithFilter1.FilterEanabled = false;
                lbHeader.Text = "Update User";
                this.Text = "Update User";
                MessageBox.Show("Person Saved Successfully", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed Saving Process", "Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "Please Enter UserName");
            }
            else
            {
                if (_Mode == enMode.AddNew)
                {
                    if (clsUser.isUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "This UserName Used By Another User");
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, "");
                    }
                }
                else
                {
                    if (txtUserName.Text.Trim() != _User.UserName)
                    {
                        if (clsUser.isUserExist(txtUserName.Text.Trim()))
                        {
                            e.Cancel = true;
                            errorProvider1.SetError(txtUserName, "This UserName Used By Another User");
                            return;
                        }
                        else
                        {
                            errorProvider1.SetError(txtUserName, "");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, "");
                    }

                }


            }
             
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password Can't Be Empty");
            }
            else 
            {
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Not Match");
            }
            else 
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }
    }
}

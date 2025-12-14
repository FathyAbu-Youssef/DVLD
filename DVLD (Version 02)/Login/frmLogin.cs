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

namespace DVLD__Version_02_.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (User != null) 
            {
                if (chkRememberme.Checked)
                {
                    clsGlobal.RememberUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else 
                {
                    clsGlobal.RememberUserNameAndPassword("", "");
                }

                if (!User.IsActive) 
                {
                    MessageBox.Show("You Are Not Active User\nContact Your Admin!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsGlobal.CurrentUser = User;
                frmMainForm ShowMainForm = new frmMainForm(this);
                ShowMainForm.StartPosition = FormStartPosition.CenterParent;
                this.Hide();
                ShowMainForm.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Wrong UserName OR Passowrd!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.LoadUserNameAndPassword(ref UserName, ref Password))
            {
                txtPassword.Text = Password;
                txtUserName.Text = UserName;
            }
        }
    }
}

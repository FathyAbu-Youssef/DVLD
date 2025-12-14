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

namespace DVLD__Version_02_.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private int _UserID;
        private clsUser _User;
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User == null ) 
            {
                _RestDefaultValues();
                MessageBox.Show("This User Is Not Found", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserName.Text = _User.UserName;
            lblUserID.Text = _User.UserID.ToString();
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }

        private void _RestDefaultValues()
        {
            ctrlPersonCard1.ResetDefaultValues();
            lblUserID.Text = "???";
            lblUserName.Text = "???";
            lblIsActive.Text = "???";
        }
    }
}

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
    public partial class frmUserInfocs : Form
    {
        int _UserID;
        public frmUserInfocs(int UserID)
        {
            _UserID = UserID;
            InitializeComponent();
        }

        private void ctrlUserCard1_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);
        }
    }
}

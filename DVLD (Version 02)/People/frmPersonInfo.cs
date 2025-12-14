using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.People
{
    public partial class frmPersonInfo : Form
    {
        public frmPersonInfo(int PersonID)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        public frmPersonInfo(string NationalNumber)
        {
            InitializeComponent();
            ctrlPersonCard1.LoadPersonInfo(NationalNumber);
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {

        }
    }
}

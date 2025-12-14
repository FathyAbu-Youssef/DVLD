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
    public partial class frmFindPerson : Form
    {
        public event Action<int> DataBack;

        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
           // DataBack?.Invoke(obj);
        }

        private void frmFindPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack?.Invoke(ctrlPersonCardWithFilter1.PersonID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -1;

        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
        }

        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            int SelectedPersonID = obj;

            if (SelectedPersonID == -1) 
            {
                ctrlDriverLicenses1.Clear();
                return;
            }

            ctrlDriverLicenses1.LoadDataByPersonID(SelectedPersonID);
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ctrlPersonCardWithFilter1.FilterEanabled = false;
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlDriverLicenses1.LoadDataByPersonID(_PersonID);
            }
        }
    }
}

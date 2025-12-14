using DVLD__Version_02_.People;
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

namespace DVLD__Version_02_.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private clsApplication _Application;
        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }

        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationData(int ApplicationID) 
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            if (_Application==null) 
            {
                MessageBox.Show("Can't Find This Application", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillApplicationInfo();
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;

            lbApplicationIID.Text = _Application.ApplicationID.ToString();
            lbStatus.Text = _Application.StatusText;
            lbFees.Text = _Application.PaidFees.ToString();
            lbType.Text = _Application.ApplicationTypeInfo.Title;
            lbApplicant.Text = _Application.ApplicantPersonInfo.FullName;
            lbDate.Text = _Application.ApplicationDate.ToString("dd-MM-yyyy");
            lbStatusDate.Text = _Application.LastStatusDate.ToString("dd-MM-yyyy");
            lbUserName.Text = _Application.CreatedUserInfo.UserName;
        }

        private void lbViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo ShowPersonInfo = new frmPersonInfo(_Application.ApplicantPersonID);
            ShowPersonInfo.StartPosition = FormStartPosition.CenterParent;
            ShowPersonInfo.ShowDialog();
        }

        public void RestApplicationInfo() 
        {
            _ApplicationID = -1;

            lbApplicationIID.Text = "??";
            lbStatus.Text = "??";
            lbFees.Text = "??";
            lbType.Text = "??";
            lbApplicant.Text = "??";
            lbDate.Text = "??";
            lbStatusDate.Text = "??";
            lbUserName.Text = "??";
        }
    }
}

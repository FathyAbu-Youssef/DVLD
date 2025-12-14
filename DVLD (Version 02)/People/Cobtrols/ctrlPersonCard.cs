using DVLD__Version_02_.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD__Version_02_.People.Cobtrols
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _Person;

        public int PersonID
        { get { return _PersonID;} }
        public clsPerson SelectedPerson 
        { get { return _Person; } }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID) 
        {
            _Person = clsPerson.FindPersonByID(PersonID);
            if (_Person == null) 
            {
                ResetDefaultValues();
                MessageBox.Show("No Person With This ID","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNumber)
        {
            _Person = clsPerson.FindPersonByNO(NationalNumber);
            if (_Person == null)
            {
                ResetDefaultValues();
                MessageBox.Show("No Person With This ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lbFullName.Text = _Person.FullName;
            lbPersonID.Text = _Person.PersonID.ToString();
            lbAddress.Text = _Person.Address;
            lbEmail.Text = _Person.Email;
            lbGendor.Text = _Person.GendorText;
            lbNationalNumber.Text = _Person.NationalNo;
            lbPhone.Text = _Person.Phone;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lbCounttry.Text = _Person.CountryInfo.CountryName;
            _LoadPersonImage();
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0) 
            {
                pbPersonimage.Image = Resources.arab_man;
            }
            else
            {
                pbPersonimage.Image = Resources.woman;
            }

            if (_Person.ImagePath != "") 
            {
                if (File.Exists(_Person.ImagePath)) 
                {
                    pbPersonimage.ImageLocation = _Person.ImagePath;
                }
            }
        }

        public void ResetDefaultValues()
        {
            llEditPersonInfo.Enabled = false;
            _PersonID = -1;
            lbFullName.Text = "??????";
            lbPersonID.Text = "??????";
            lbAddress.Text = "??????";
            lbEmail.Text = "??????";
            lbGendor.Text = "??????";
            lbNationalNumber.Text = "??????";
            lbPhone.Text = "??????";
            lbDateOfBirth.Text = "??????";
            lbCounttry.Text = "??????";

            pbPersonimage.Image = Resources.arab_man;
        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdate frm = new frmAddUpdate(_PersonID);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

            LoadPersonInfo(_PersonID);
        }
    }
}

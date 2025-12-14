using DVLD__Version_02_.Properties;
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

namespace DVLD__Version_02_.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private clsTestType.enTestType _TestTypeID;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
         
        private void _SetTitleAndImage()
        {
            switch ( _TestTypeID ) 
            {
                case clsTestType.enTestType.VisionTest:
                    lbHeader.Text = "Vision Test";
                    PBHeaderImage.Image = Resources.eye;
                    break;

                case clsTestType.enTestType.WrittenTest:
                    lbHeader.Text = "Written Test";
                    PBHeaderImage.Image = Resources.Written;
                    break;

                case clsTestType.enTestType.StreetTest:
                    lbHeader.Text = "Street Test";
                    PBHeaderImage.Image = Resources.Street;
                    break;
            }
        }
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _SetTitleAndImage();
            ctrlLocalDrivingLicenseInfo1.LoadApplicationInfoByLocalDrivingLicesneID(_LocalDrivingLicenseApplicationID);

            DataTable AllTestAppointmentsToTestType = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
            dgvAppointments.DataSource = AllTestAppointmentsToTestType;
            lbCountOfAppointments.Text = "# " + dgvAppointments.Rows.Count + " Records";
            if (dgvAppointments.Rows.Count > 0) 
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAppointments.Columns[0].Width = 150;

                dgvAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvAppointments.Columns[1].Width = 200;

                dgvAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvAppointments.Columns[2].Width = 150;

                dgvAppointments.Columns[3].HeaderText = "Is Locked";
                dgvAppointments.Columns[3].Width = 100;

            }

        }

        private void btnAddNewTestAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLA = clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseApplicationID);

            if (LDLA == null)  
            {
                MessageBox.Show($"Can't Find Application", "not valid", MessageBoxButtons.OK);
                return;
            }

            if (LDLA.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show($"This person already has an active test appointment to this test", "not valid", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

            if (LDLA.DoesPassTestType(_TestTypeID)) 
            {
                MessageBox.Show($"This person already pass this test", "not valid", MessageBoxButtons.OK
                       , MessageBoxIcon.Error);
                return;
            }
            /*
            We Can handle if he pass in the test of current test type or not 
                  clsTest LastTest = LDLA.GetLastTest(_TestTypeID);

            if (LastTest != null && LastTest.TestResult == true) 
            {
                MessageBox.Show($"This person already pass this test", "not valid", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
                return;
            }

           */

            frmScheduleTest ScheduleNewTest = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
            ScheduleNewTest.StartPosition = FormStartPosition.CenterParent;
            ScheduleNewTest.ShowDialog();

            frmListTestAppointments_Load(null, null);
        }

        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAppointments.Rows.Count > 0)
            {
                int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
                frmScheduleTest ScheduleNewTest = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, TestAppointmentID);
                ScheduleNewTest.StartPosition = FormStartPosition.CenterParent;
                ScheduleNewTest.ShowDialog();
                frmListTestAppointments_Load(null, null);
            }
            
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest TakeTheTest = new frmTakeTest(TestAppointmentID,_TestTypeID);
            TakeTheTest.StartPosition = FormStartPosition.CenterParent;
            TakeTheTest.ShowDialog();
            frmListTestAppointments_Load(null,null);
        }
    }
}

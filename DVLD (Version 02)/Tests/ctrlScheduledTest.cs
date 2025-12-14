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
    public partial class ctrlScheduledTest : UserControl
    {
        private clsTestType.enTestType _TestType;
        private int _TestAppointmentID=-1;
        private int _TestID=-1;
        

        public clsTestType.enTestType TestType 
        {
            get { return _TestType; }

            set
            {
                _TestType = value;
              
                switch (_TestType) 
                {
                    case clsTestType.enTestType.VisionTest:
                        GBTestTitle.Text = "Vision Test";
                        PBHeaderImage.Image = Resources.eye;
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        GBTestTitle.Text = "Written Test";
                        PBHeaderImage.Image = Resources.Written;
                        break;

                    case clsTestType.enTestType.StreetTest:
                        GBTestTitle.Text = "Street Test";
                        PBHeaderImage.Image = Resources.Street;
                        break;
                }
            }
        
        }
        public int TestID 
        {
            get { return _TestID; }
        }
        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public void LoadData(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            clsTestAppointment Appointment = clsTestAppointment.Find(TestAppointmentID);

            if (Appointment == null)  
            {
                MessageBox.Show($"Error : Not Appointment With This ID {TestAppointmentID}"
                    , "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingLicenseApplicationID(Appointment.LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + LocalDrivingLicenseApplication.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbLocalDrivingLicenseApplicationID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbApplicant.Text = LocalDrivingLicenseApplication.PersonFullFullName;
            lbLicenceClass.Text = clsLicenseClass.Find(LocalDrivingLicenseApplication.LicenseClassID).ClassName;
            lbTrials.Text = LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestType).ToString();
            lbFees.Text = Appointment.PaidFees.ToString();
            lbAppointmentDate.Text = Appointment.AppointmentDate.ToString("dd-MMM-yyyy");
            lbTestID.Text = Appointment.TestID == -1 ? "Not yet taken" : Appointment.TestID.ToString();
            _TestID = Appointment.TestID;
            _TestAppointmentID = Appointment.TestAppointmentID;
        }
        
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }
    }
}

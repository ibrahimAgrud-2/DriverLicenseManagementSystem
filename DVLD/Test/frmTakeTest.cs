using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class frmTakeTest : Form
    {


        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
        }

        private int _TestAppointmentID = -1;
        private TestAppointments _TestAppointment;

      
        public delegate void DataBackEventHandler(object sender, int testID);
        public event DataBackEventHandler DataBack;




        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            _TestAppointment = TestAppointments.Find(_TestAppointmentID);
            if(_TestAppointment==null)
            {
                MessageBox.Show($"There is no Test appointment with ID {_TestAppointmentID}");
                this.Close();
                return;
                
            }
            this.ctrlLDLAsTestAppointmentsInfo1.LoadAppInfo(_TestAppointment.localDrivingLicenseApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tests newTest = new Tests();

            newTest.testResult = (rbPass.Checked?1:0);
            newTest.testAppointmentID = _TestAppointmentID;
            newTest.notes = txtNotes.Text;
            newTest.createdByUserID = Global.currentUser.userID;

            _TestAppointment.isLocked = true;
            _TestAppointment.save();

            if (newTest.save())
            {
                MessageBox.Show("Saved Successfully");
                DataBack?.Invoke(this,newTest.testID);
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}

using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
     
        private void fillObjectDataToField()
        {
            _TestAppointment = TestAppointments.Find(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Test Appointment could not found");
                return;
            }
             

            this.ctrlTestAppointmentInfo1.LoadData(_TestAppointment.localDrivingLicenseApplicationID);
            button1.Enabled = true;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            fillObjectDataToField();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Tests test = new Tests();
            test.testAppointmentID = _TestAppointmentID;
            test.notes = textBox1.Text;
            test.createdByUserID = Global.currentUser.userID;
            test.testResult = (rbPass.Checked ? true : false);
            if (test.save()) 
            {
                MessageBox.Show("Yes");
            }
            else
            {
                MessageBox.Show("No");

            }
          
            
        }
    }
}

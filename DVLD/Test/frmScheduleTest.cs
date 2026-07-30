using DVLD.Test.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TestTypes;

namespace DVLD.Test
{
    public partial class frmScheduleTest : Form
    {

        int _LocalDrivingLicenseID=-1;
            TestTypes.enTestTypes _testType;
        int _testAppointmentID;
        public frmScheduleTest(int LocalDrivingLicenseID,TestTypes.enTestTypes testType,int testAppointmentID=-1)
        {
            InitializeComponent();

            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            _testAppointmentID = testAppointmentID;
            _testType = testType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crlScheduleTest1_Load(object sender, EventArgs e)
        {

        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            this.crlScheduleTest1.TestTypeID = _testType;
            crlScheduleTest1.LoadData(_LocalDrivingLicenseID, _testAppointmentID);
        }
    }
}

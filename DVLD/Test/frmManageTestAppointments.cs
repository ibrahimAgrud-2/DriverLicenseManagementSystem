using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;

using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class frmManageAppointments : Form
    {

        public frmManageAppointments(int LocalLicenseApplicationID,TestTypes.enTestTypes testType)
        {
            InitializeComponent();
            _LDLAID = LocalLicenseApplicationID;
            _TestType = testType;
        }
        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;
        private TestTypes.enTestTypes _TestType;

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);
            if(_LDLA==null)
            {
                MessageBox.Show("Valid Local Driving License Application not found");
                return;
            }
       
            _LoadData();
            _SetColumnNames();
        }


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "TestAppointmentID", "Appointment LocalDrivingLicenseApplicationID" },
              { "AppointmentDate", "Appointment Date" },
              { "PaidFees", "Paid Fees" },
              { "IsLocked", "Is Locked" }

            };
        private void _SetColumnNames()
        {
            if (dgvAppointmentList.Rows.Count <= 0)
                return;
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvAppointmentList.Columns[dict.Key].HeaderText = dict.Value;
            }
        }

        private void _RefreshAppointmentList()
        {
            DataTable dt = TestAppointments.GetApplicationTestAppointmentsPerTestType(_LDLAID, _TestType);
        

           
          //eğer hiç data yoksa header'ı görünmez yap. Varsa görünür yap. 
                dgvAppointmentList.ColumnHeadersVisible = (dt.Rows.Count != 0);
            
          //Data olsa da olmasada dgv'ye yükleme olmalı çünkü ilk load'da kolon isimleri belirlenecek.
            dgvAppointmentList.DataSource = dt;
            lblRecord.Text = dgvAppointmentList.RowCount.ToString();



        }

        private void _LoadData()
        {
            switch(_TestType)
            {
                case TestTypes.enTestTypes.Vision:
                    this.Text = "Vision Test Appointments";
                    break;
                case TestTypes.enTestTypes.Written:
                    this.Text = "Written Test Appointments";
                    break;
                case TestTypes.enTestTypes.Street:
                    this.Text = "Street Test Appointments";
                    break;
            }
            this.ctrlLocalDrivinglicenseApplicationInfo1.LoadAppInfo(_LDLAID);
            _RefreshAppointmentList();
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            //Burada sadece kişinin/başvurunun aynı aktif (sonucu belirlenmemiş) sınav türüne sahip mi onu kontrol ediyoruz.

            if(_LDLA.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

      

            Tests test = _LDLA.GetLastTestPerTestType(_TestType);

            if(test==null)
            {
                //schedule test

                frmScheduleTest frm1 = new frmScheduleTest(_LDLAID,_TestType);
                frm1.ShowDialog();
                _RefreshAppointmentList();
                return;
            }
            //if person already passed the test s/he cannot retak it.
            if (test.testResult == 1)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //schedule test

            frmScheduleTest frm = new frmScheduleTest(test.testAppointmentInfo.localDrivingLicenseApplicationID,_TestType);
            frm.ShowDialog();
            _RefreshAppointmentList();


        }



        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int testAppointmentID = Convert.ToInt32(dgvAppointmentList.SelectedRows[0].Cells[0].Value);
            frmTakeTest1 frm = new frmTakeTest1(testAppointmentID,_TestType);
            frm.ShowDialog();

            _RefreshAppointmentList();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int testAppointmentID = Convert.ToInt32(dgvAppointmentList.SelectedRows[0].Cells[0].Value);

  
            frmScheduleTest frm = new frmScheduleTest(_LDLAID,_TestType,testAppointmentID);
            frm.ShowDialog();

            _RefreshAppointmentList();
        }
    }
}

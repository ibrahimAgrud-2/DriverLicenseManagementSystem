using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class frmTestAppointments : Form
    {

        //id yanında testType'da göndermejk istedim çünkü fonksyin yazmaktan daha kolay.Ve güvenli.
        public frmTestAppointments(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            _LDLAID = LocalLicenseApplicationID;

        }
        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);
            /*
             Eğer passedTestCount 0 ise vision test olması gerekiyor demektir. Yani enum listesinde indexi bir olan vision olmalı. Enum listesinde 0'ın karşılığı yok bu yüzden +1 yapmamız gerekiyr. Ve bu her zaman doğrudur. Yani passedTest 2 ise bu demek oluyor ki 3.sıradaki writin test'i alması gerek 2+1=3.sıradaki enum ifadesi olur. 
             */
            if(_LDLA==null)
            {
                MessageBox.Show("Valid Local Driving License Application not found");
                return;
            }
            TestType = (TestTypes.enTestTypes)_LDLA.GetPassedTestCount()+1;
            _RefreshAppointmentList();
            _SetColumnNames();
            _LoadData();
        }

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;
        private TestTypes.enTestTypes TestType;

      





        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "TestAppointmentID", "Appointment ID" },
              { "AppointmentDate", "Appointment Date" },
              { "PaidFees", "Paid Fees" },
              { "IsLocked", "Is Locked" }

            };
        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvAppointmentList.Columns[dict.Key].HeaderText = dict.Value;
            }
      
        }

        private void _RefreshAppointmentList()
        {
            DataTable dt = TestAppointments.getTestAppointmentsRecords();
            dt.DefaultView.RowFilter = $"TestTypeID={(int)this.TestType} and LocalDrivingLicenseApplicationID={_LDLAID}";
        
            DataTable filteredTable= dt.DefaultView.ToTable("Appointments", false, "TestAppointmentID", "AppointmentDate", "PaidFees", "IsLocked");
           
            //eğer hiç data yoksa header'ı görünmez yap. Varsa görünür yap. 
                dgvAppointmentList.ColumnHeadersVisible = (filteredTable.Rows.Count != 0);
            
     //Data olsa da olmasada dgv'ye yükleme olmalı çünkü ilk load'da kolon isimleri belirlenecek.
            dgvAppointmentList.DataSource = filteredTable;
            lblRecord.Text = dgvAppointmentList.RowCount.ToString();



        }

        private void _LoadData()
        {
            switch(TestType)
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

            if(TestAppointments.HasActiveTestAppointment(_LDLAID, (int)this.TestType))
            {
                MessageBox.Show("The person Already has the same kind of test Appointment");
                return;
            }
           
            //Burada ise o sınav türünü geçmiş mi kontrol ediyoruz. Bu iki kontrol sayesinde kullanıcıya daha net bildirimler verebiliyoruz.
            if(_LDLA.GetPassedTestCount()==((int)this.TestType))
            {
                MessageBox.Show("Person Already passed the test.");
                return;
            }

            frmAddUpdateTestAppointment frm = new frmAddUpdateTestAppointment();
            frm.LDLAID = _LDLAID;
            frm.ShowDialog();
            _RefreshAppointmentList();
        }



        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.TryParse(dgvAppointmentList.SelectedRows[0].Cells[0].Value.ToString(),out int SelectedTestAppointmentID))
            {
               if(Convert.ToBoolean(dgvAppointmentList.SelectedRows[0].Cells[3].Value))
                {
                    MessageBox.Show("Cant take/edit this appoinment because its locked");
                    return;

                }
                frmTakeTest frm = new frmTakeTest(SelectedTestAppointmentID);
                frm.ShowDialog();
                _RefreshAppointmentList();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppointmentList.SelectedRows[0].Cells[0].Value.ToString(), out int SelectedTestAppointmentID))
            {
                frmAddUpdateTestAppointment frm = new frmAddUpdateTestAppointment(SelectedTestAppointmentID);
                frm.ShowDialog();
                _RefreshAppointmentList();
            }

        }
    }
}

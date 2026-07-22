using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class frmTestAppointments : Form
    {

        //id yanında testType'da göndermejk istedim çünkü fonksyin yazmaktan daha kolay.Ve güvenli.
        public frmTestAppointments(int LocalLicenseApplicationID, enTestType testType)
        {
            InitializeComponent();
            _LDLAID = LocalLicenseApplicationID;
            this.TestType = testType;
        }

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;


        public enum enTestType { Vision=0,Written=1,Street=2};
        public enTestType TestType;

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
            dt.DefaultView.RowFilter = $"TestTypeID={(int)this.TestType+1} and LocalDrivingLicenseApplicationID={_LDLAID}";
        
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
                case enTestType.Vision:
                    this.Text = "Vision Test Appointments";
                    break;
                case enTestType.Written:
                    this.Text = "Written Test Appointments";
                    break;
                case enTestType.Street:
                    this.Text = "Street Test Appointments";
                    break;
            }
            this.ctrlLocalDrivinglicenseApplicationInfo1.LoadAppInfo(_LDLAID);
            _RefreshAppointmentList();
        }

        private void frmTestAppointments_Load(object sender, EventArgs e)
        {
            _RefreshAppointmentList();
            _SetColumnNames();
            _LoadData();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            frmAddUpdateTestAppointment frm = new frmAddUpdateTestAppointment();
            frm.ShowDialog();
            _RefreshAppointmentList();
        }

    }
}

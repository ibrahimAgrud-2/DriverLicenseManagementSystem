using DVLD.Applications;
using DVLD.People.Controls;
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
using static System.Windows.Forms.DataGrid;

namespace DVLD.Test
{
    public partial class frmManageTestAppointments : Form
    {
        public frmManageTestAppointments(int LDLAID)
        {
            InitializeComponent();
            _LDLAID = LDLAID;
           
        }


        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;

        enum enTestType {Vision=0, Written= 1,Street=2 }
        enTestType TestType=enTestType.Vision;


        private void GetTestType()
        {

            TestType = (enTestType)LocalDrivingLicenseApp.GetTotalCompletedTests(_LDLA.ApplicationInfo.ApplicantPerson.nationalNo);
        }

    

        private void fillObjectDataToField()
        {
            if (_LDLA == null)
                return;

            this.ctrlLDLAInfo1.LoadData(_LDLA.ID);
        }

        private void _RefreshAppointmentList()
        {
            DataTable dt = TestAppointments.getTestAppointmentsRecords();
            dt.DefaultView.RowFilter = $"TestTypeID={(int)this.TestType} and LocalDrivingLicenseApplicationID={_LDLAID}";
            if (dgvAppointmentList.Rows.Count > 0)
                    dgvAppointmentList.DataSource = dt;


        }
        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);
            GetTestType();
            fillObjectDataToField();
            _RefreshAppointmentList();
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateTestAppointment frm = new frmAddUpdateTestAppointment(_LDLAID);
            frm.ShowDialog();

        }
    }
}

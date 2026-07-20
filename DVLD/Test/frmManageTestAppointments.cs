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
        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {
            _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);
            GetTestType();
            fillObjectDataToField();
          switch (TestType)
            {
                case enTestType.Vision:
                    this.Text = "Vision Test Appointment";
                    break;
                case enTestType.Written:
                    this.Text = "Written Test Appointment";
                    break;
                case enTestType.Street:
                    this.Text = "Street Test Appointment";
                    break;
            }


          
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
           
        }
    }
}

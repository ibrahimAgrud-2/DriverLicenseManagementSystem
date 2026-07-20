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
using static clsTestType;

namespace DVLD.Applications
{
    public partial class frmAddUpdateAppointment : Form
    {
        public frmAddUpdateAppointment(int LDLAID)
        {
            InitializeComponent();
            _LDLAID = LDLAID;
        }

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;
        enum enTestType { Vision = 0, Written = 1, Street = 2 }
        enTestType TestType = enTestType.Vision;

        private void GetTestType()
        {

            TestType = (enTestType)LocalDrivingLicenseApp.GetTotalCompletedTests(_LDLA.ApplicationInfo.ApplicantPerson.nationalNo);
        }



        private void fillObjectDataToField()
        {
            if (_LDLA == null)
                return;

  

           
        }
    }
}

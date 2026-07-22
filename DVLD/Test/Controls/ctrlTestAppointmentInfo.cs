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

namespace DVLD.Test.Controls
{
    public partial class ctrlTestAppointmentInfo : UserControl
    {
        public ctrlTestAppointmentInfo()
        {
            InitializeComponent();
        }

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;
        public enum enTestType { Vision = 1, Written = 2, Street = 3 }
       public enTestType TestType = enTestType.Vision;

       public int LDLAID { get { return _LDLAID; } }
        public LocalDrivingLicenseApp currentLDLDA { get { return _LDLA; } }
    
        public void LoadData(int LDLAID)
        {
            _LDLA = LocalDrivingLicenseApp.Find(LDLAID);
            if (_LDLA == null)
                return;

            _LDLAID = LDLAID;
            lblLDLAID.Text = _LDLA.ID.ToString();
            lblApplicationFee.Text = _LDLA.ApplicationInfo.PaidFees.ToString();
            lblPersonFullName.Text = _LDLA.ApplicationInfo.ApplicantPerson.fullName;
            lblTrail.Text = TestAppointments.GetTestAppointmentCount(_LDLA.ID, (int)TestType).ToString();
            lblClass.Text = _LDLA.LicenseClassInfo.className;
            dtpApplicationDate.Value = _LDLA.ApplicationInfo.ApplicationDate;
        }

    }
}

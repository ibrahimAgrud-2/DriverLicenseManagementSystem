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
    public partial class ctrlLDLAsTestAppointmentsInfo : UserControl
    {
        public ctrlLDLAsTestAppointmentsInfo()
        {
            InitializeComponent();
        }

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA = null;
        public int LocalLicenseAppID { get { return _LDLAID; } }
        public LocalDrivingLicenseApp SelectedLocalLicenseApp { get { return _LDLA; } }

        public DateTime getDate { get { return dtpApplicationDate.Value ; } }

        public bool DateTimePickerEnabled
        {
            get
            {
                return dtpApplicationDate.Enabled;
            }
            set
            {
                dtpApplicationDate.Enabled = value;
            }
        }
        private TestTypes.enTestTypes TestType;
        private void fillObjectDataToField(LocalDrivingLicenseApp LDLA)
        {
            lblLDLAID.Text = LDLA.LocalDrivingLicenseApplicationID.ToString();
            lblAppForClass.Text = LDLA.LicenseClassInfo.className;
            lblApplicantName.Text = LDLA.ApplicationInfo.ApplicantPerson.fullName;
            dtpApplicationDate.Value = LDLA.ApplicationInfo.ApplicationDate;
            lblFees.Text = LDLA.ApplicationInfo.PaidFees.ToString();
            TestType = (TestTypes.enTestTypes)_LDLA.GetPassedTestCount() + 1;

            TestAppointments _testAppointment = TestAppointments.FindByLocalDrivingLicenseID(_LDLAID);
            lblTrail.Text = LDLA.GetFailedTestCount((int)TestType).ToString();
        }

        private void _Load()
        {
            _LDLAID = _LDLA.LocalDrivingLicenseApplicationID;
            fillObjectDataToField(_LDLA);
        }
        public void LoadAppInfo(int LocalLicenseAppID)
        {
            _LDLA = LocalDrivingLicenseApp.Find(LocalLicenseAppID);
            if (_LDLA == null)
            {
                _LDLAID = -1;
                MessageBox.Show("No Person with PersonID = " + LocalLicenseAppID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Load();
        }

    }
}

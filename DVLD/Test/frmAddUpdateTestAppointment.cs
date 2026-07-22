using DVLD.People.Controls;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Test
{
    public partial class frmAddUpdateTestAppointment : Form
    {
        public frmAddUpdateTestAppointment()
        {
            InitializeComponent();
            this._Mode = enMode.enAddNew;
        }
        public frmAddUpdateTestAppointment(int LDLAID)
        {
            InitializeComponent();
            this._Mode = enMode.enUpdate;
            _LDLAID = LDLAID;
        }


        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode = enMode.enAddNew;

        public enum enTestType { Vision = 0, Written = 1, Street = 2 };
        public enTestType testType;

        private int _LDLAID = -1;
        private LocalDrivingLicenseApp _LDLA;

        private TestAppointments _TestAppointment;
        private void fillObjectDataToField()
        {
            if (_LDLA == null)
                return;
          
            this.ctrlLDLAsTestAppointmentsInfo1.LoadAppInfo(_LDLA.ID);
         
            //if(_LDLA.GetFailedTestCount()>0)
            //{
            //    groupBox1.Enabled = true;
            //}

        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private TestType.enTestTypes _GetTestType()
        {
            return (TestType.enTestTypes)(_LDLA.GetPassedTestCount()+1);
        }
        private bool _FillDataToObject()
        {
            _TestAppointment.createdByUserID = Global.currentUser.userID;
            _TestAppointment.appointmentDate = DateTime.Now;
            _TestAppointment.isLocked = false;
            _TestAppointment.paidFees = TestType.Find(_GetTestType()).TestTypeFees;
          //AddUpdate test appointment'teyim
                return false ;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {


            if (!_FillDataToObject())
            {
                MessageBox.Show("Fill requireds properly");
                return;
            }

            if (_LDLA.Save())
            {
                MessageBox.Show("Saved successfully");
                this._Mode = enMode.enUpdate;
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddUpdateTestAppointment_Load(object sender, EventArgs e)
        {
            if (this._Mode == enMode.enUpdate)
            {
                _LDLA = LocalDrivingLicenseApp.Find(_LDLAID);

                if (_LDLA == null)
                {
                    MessageBox.Show("No LDLA with ID = " + _LDLAID, "LDLA Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
                  fillObjectDataToField();

            }
            else
            {
                gbMain.Text = "Add New Test";
             
            }
        }
    }
}

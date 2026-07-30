using DVLD.Test.Controls;
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
    public partial class frmTakeTest1 : Form
    {
        public frmTakeTest1(int testAppointment,TestTypes.enTestTypes testType)
        {
            InitializeComponent();
            _TestAppointmentID = testAppointment;
            _TestType = testType;
        }
        private int _TestAppointmentID;
        private TestTypes.enTestTypes _TestType;

        private Tests _Test;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
                           )
            {
                return;
            }

            _Test.testAppointmentID = _TestAppointmentID;
            _Test.testResult = (rbPass.Checked?1:0);
            _Test.notes = txtNotes.Text.Trim();
            _Test.createdByUserID = Global.CurrentUser.UserID;

            if (_Test.save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmTakeTest1_Load(object sender, EventArgs e)
        {


            this.ctrlScheduledTest1.TestType = _TestType;
            this.ctrlScheduledTest1.LoadTest(_TestAppointmentID);

            if (this.ctrlScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;


            int _testID = this.ctrlScheduledTest1.TestID;

            if (_testID != -1)
            {
                _Test = Tests.Find(_testID);

                if (_Test.testResult == 1)
                {
                    rbPass.Checked = true;
                }
                else
                {
                    rbPass.Checked = true;
                }

                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
            else
            {

                _Test = new Tests();
            }
        }
    }
}

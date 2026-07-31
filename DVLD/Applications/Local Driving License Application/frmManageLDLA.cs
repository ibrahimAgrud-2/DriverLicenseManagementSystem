using DVLD.Applications.New_Local_Driving_License_Application;
using DVLD.Licenses;
using DVLD.Licenses.International_Licenses;
using DVLD.Test;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using clsApplication = DVLD_BusinessLayer.Applications;
using clsLicense = DVLD_BusinessLayer.Licenses;

namespace DVLD.Applications
{
    public partial class frmManageLDLA : Form
    {
        public frmManageLDLA()
        {
            InitializeComponent();
        }
        private DataTable _DtAppList;
        private void frmManageLDLA_Load(object sender, EventArgs e)
        {
            _RefreshLocalLicenseApplicationList();
            _SetColumnNames();
            cbFilterBy.SelectedIndex = 0;



        }

        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "LocalDrivingLicenseApplicationID", "LocalDrivingLicenseApplicationID" },
              { "ClassName", "Class Name" },
              { "NationalNo", "National No" },
              { "FullName", "Full Name" },
              { "ApplicationDate", "Application Date" },
              { "PassedTestCount", "Passed Test" },
              { "Status", "Status" }
            };
        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvAppList.Columns[dict.Key].HeaderText = dict.Value;
            }

        }

        private void _RefreshLocalLicenseApplicationList()
        {
            _DtAppList = LocalDrivingLicenseApp.getLocalDrivingLicenseAppRecords();
            dgvAppList.DataSource = _DtAppList;
            lblRecords.Text = dgvAppList.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApp frm = new frmAddUpdateLocalDrivingLicenseApp();
            frm.ShowDialog();
            _RefreshLocalLicenseApplicationList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {

                frmAddUpdateLocalDrivingLicenseApp frm = new frmAddUpdateLocalDrivingLicenseApp(selectedPersonID);
                frm.ShowDialog();
                _RefreshLocalLicenseApplicationList();
            }
        }




        private void DeleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int SelectedLDLAID))
            {
                LocalDrivingLicenseApp LDLA = LocalDrivingLicenseApp.Find(SelectedLDLAID);
                if (LDLA!=null)
                {
                    if (MessageBox.Show("Are you sure you want to delete App [" + SelectedLDLAID + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
             

                        if (LDLA.deleteLocalDrivingLicenseApp())
                        {
                            
                            MessageBox.Show("Application Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshLocalLicenseApplicationList();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while deleting process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    


                    }

                }
                else
                {
                    MessageBox.Show("Person Not Found");
                }

            }
        }


        //------filtering

        private void txtFilet_TextChanged(object sender, EventArgs e)
        {
            if (txtFilet.Text == "")
            {
                _DtAppList.DefaultView.RowFilter = null;
                dgvAppList.DataSource = _DtAppList;
                return;
            }
            string FilterColumn = "";





            switch (cbFilterBy.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;
            }

            if (cbFilterBy.Text == "L.D.L.AppID")
            {
                _DtAppList.DefaultView.RowFilter = $"{FilterColumn} = {txtFilet.Text} ";
            }
            else
            {
                _DtAppList.DefaultView.RowFilter = $"{FilterColumn} Like '{txtFilet.Text}%'";
            }

            lblRecords.Text = dgvAppList.RowCount.ToString();
        }

        private void txtFilet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1)
            {
                if (!int.TryParse(e.KeyChar.ToString(), out int test))
                {


                    e.Handled = !(char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
                }
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilet.Text = "";
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilet.Visible = false;
                _DtAppList.DefaultView.RowFilter = null;
            }
            else if (cbFilterBy.SelectedIndex == 4)
            {
                txtFilet.Visible = false;
                cbStatus.Visible = true;
            }
            else
            {
                txtFilet.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbStatus.SelectedIndex == 1)
            {
                _DtAppList.DefaultView.RowFilter = $"Status = 'New'";

            }
            else if (cbStatus.SelectedIndex == 2)
            {
                _DtAppList.DefaultView.RowFilter = $"Status = 'Completed'";

            }
            else if (cbStatus.SelectedIndex == 3)
            {
                _DtAppList.DefaultView.RowFilter = $"Status = 'Canceled'";

            }
            else
            {
                _DtAppList.DefaultView.RowFilter = null;
            }

            dgvAppList.DataSource = _DtAppList;
            lblRecords.Text = dgvAppList.RowCount.ToString();
        }

        //------filtering


        private void _HandleEnablingCsmOptions()
        {
            int LDLDAID = Convert.ToInt32(dgvAppList.SelectedRows[0].Cells[0].Value);
            LocalDrivingLicenseApp LDLA = LocalDrivingLicenseApp.Find(LDLDAID);

            bool IsLicenseIssued = LDLA.IsLicenseIssued();
            int TotalPassedTests = (int)dgvAppList.CurrentRow.Cells[5].Value;


            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = !IsLicenseIssued&& TotalPassedTests==3;


            showLicenseToolStripMenuItem.Enabled = IsLicenseIssued;
            editToolStripMenuItem.Enabled = LDLA.ApplicationStatus == clsApplication.enApplicationStatus.New;


            DeleteApplicationToolStripMenuItem.Enabled = LDLA.ApplicationStatus == clsApplication.enApplicationStatus.New&& !IsLicenseIssued;

            CancelApplicaitonToolStripMenuItem.Enabled = LDLA.ApplicationStatus == clsApplication.enApplicationStatus.New;




            bool isPassedVisionTest = LDLA.DoesPassTestType(TestTypes.enTestTypes.Vision);
            bool isPassedWrittenTest = LDLA.DoesPassTestType(TestTypes.enTestTypes.Written);
            bool isPassedStreetTest = LDLA.DoesPassTestType(TestTypes.enTestTypes.Street);

            ScheduleTestsMenue.Enabled = !(isPassedVisionTest && isPassedWrittenTest&& isPassedStreetTest);
            if (ScheduleTestsMenue.Enabled)
            {
                scheduleVisionTestToolStripMenuItem.Enabled = !isPassedVisionTest;
                scheduleWrittenTestToolStripMenuItem.Enabled = !isPassedWrittenTest&&isPassedVisionTest;
                scheduleStreetTestToolStripMenuItem.Enabled = isPassedVisionTest && isPassedWrittenTest && !isPassedStreetTest;

            }


        }


        private void cmsApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _HandleEnablingCsmOptions();
        }
        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedID))
            {

                frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime(selectedID);
                frm.ShowDialog();
                _RefreshLocalLicenseApplicationList();
                
            }
           
        }

        //show Licenese detail
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedID))
            {


                int licenseID = clsLicense.FindByApplicationID(LocalDrivingLicenseApp.Find(selectedID).ApplicationID).licenseID;

                frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(licenseID);
                frm.ShowDialog();
                _RefreshLocalLicenseApplicationList();
            }
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedID))
            {

                LocalDrivingLicenseApp LDLA = LocalDrivingLicenseApp.Find(selectedID);

                frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(LDLA.ApplicantPersonID);
                frm.ShowDialog();
            }
        }

        private void CancelApplicaitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedID))
            {

                if (MessageBox.Show("Are you sure you want to Cancel [" + selectedID + "]", "Confirm Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    LocalDrivingLicenseApp LDLA = LocalDrivingLicenseApp.Find(selectedID);
                    if (LDLA.Cancel())
                    {
                        MessageBox.Show("Cancelled successfully");
                        _RefreshLocalLicenseApplicationList();
                    }
                }

            }
        }

        //show LDLA detail
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedID))
            {
                frmShowLocalApplicationInfo frm = new frmShowLocalApplicationInfo(selectedID);
                frm.ShowDialog();
            }
        }

        private void _ScheduleTest(int LDLAID,TestTypes.enTestTypes testType)
        {
            frmManageAppointments frm = new frmManageAppointments(LDLAID, testType);
            frm.ShowDialog();
            _RefreshLocalLicenseApplicationList();
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(Convert.ToInt32(dgvAppList.SelectedRows[0].Cells[0].Value),TestTypes.enTestTypes.Vision);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(Convert.ToInt32(dgvAppList.SelectedRows[0].Cells[0].Value), TestTypes.enTestTypes.Written);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(Convert.ToInt32(dgvAppList.SelectedRows[0].Cells[0].Value), TestTypes.enTestTypes.Street);

        }
    }
}

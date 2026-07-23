using DVLD.Applications.New_Local_Driving_License_Application;
using DVLD.Test;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
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


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "LocalDrivingLicenseApplicationID", "ID" },
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


        private void frmManageLDLA_Load(object sender, EventArgs e)
        {
            _RefreshLocalLicenseApplicationList();
            _SetColumnNames();
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
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
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                if (LocalDrivingLicenseApp.IsLocalDriverLicenseExist(selectedPersonID))
                {
                    if (MessageBox.Show("Are you sure you want to delete Person [" + selectedPersonID + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (LocalDrivingLicenseApp.deleteLocalDrivingLicenseApp(selectedPersonID))
                        {
                            MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshLocalLicenseApplicationList();
                        }
                        else
                        {
                            MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("People Not Found");
                }

            }
        }

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
            else if(cbStatus.SelectedIndex == 3)
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
    
        private void _handleCSMScheduleTestOptions()
        {
            string status = dgvAppList.SelectedRows[0].Cells[6].Value.ToString();
            int completedTestCount = Convert.ToInt32(dgvAppList.SelectedRows[0].Cells[5].Value);


            if (status !="New"&& completedTestCount!=3)
            {
                ScheduleTestsMenue.Enabled = false;
                return;
            }
            else
            {
                ScheduleTestsMenue.Enabled = true;
                for (int i = 0; i < 3; i++)
                {

                    ScheduleTestsMenue.DropDownItems[i].Enabled = false;
                    if (i == completedTestCount)
                    {
                        ScheduleTestsMenue.DropDownItems[i].Enabled = true;
                    }
                }
            }
        }
        private void _HandleEnablingCsmOptions()
        {
            string status=dgvAppList.SelectedRows[0].Cells[6].Value.ToString();
            //enable all when new

            editToolStripMenuItem.Enabled= (status == "New");
            DeleteApplicationToolStripMenuItem.Enabled= (status == "New");
            CancelApplicaitonToolStripMenuItem.Enabled= (status == "New");
            _handleCSMScheduleTestOptions();
            //issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (status == "Completed");
            showLicenseToolStripMenuItem.Enabled = (status == "Completed");


        }

        private void dgvAppList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _HandleEnablingCsmOptions();
        }

        private void ScheduleTest_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedLDLAID))
            {

                int passedTestCount = (int)dgvAppList.SelectedRows[0].Cells[5].Value;

                

                frmTestAppointments frm = new frmTestAppointments(selectedLDLAID,(frmTestAppointments.enTestType)(passedTestCount));
                
                frm.ShowDialog();
                _RefreshLocalLicenseApplicationList();
            }


         
        }
    }
}

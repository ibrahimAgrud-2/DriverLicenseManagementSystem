using DVLD.Licenses;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using clsLicenses = DVLD_BusinessLayer.Licenses;
using System.Windows.Forms;
using DVLD.Licenses.International_Licenses;

namespace DVLD.Applications.International_License_Applications
{
    public partial class frmManageInternationalLicesnseApplications : Form
    {


        public frmManageInternationalLicesnseApplications()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private DataTable _DtInternationalLicenses;

        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "InternationalLicenseID", "International LicenseID" },
              { "ApplicationID", "App.LocalDrivingLicenseApplicationID" },
              { "IssuedUsingLocalLicenseID", "L.LicenseID" },
              { "IssueDate", "Issue Date" },
              { "ExpirationDate", "Expiration Date" },
              { "IsActive", "Is Active" }
            };
        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvInternationalLicensesList.Columns[dict.Key].HeaderText = dict.Value;
            }

        }

        private void _RefreshList()
        {
            _DtInternationalLicenses = InternationalLicense.getInternationalLicenseRecords();


            dgvInternationalLicensesList.DataSource = _DtInternationalLicenses.DefaultView.ToTable("InternationalLicenses", false, "InternationalLicenseID", "ApplicationID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");
            lblRecords.Text = dgvInternationalLicensesList.RowCount.ToString();

        }


        private void frmManageApplication_Load(object sender, EventArgs e)
        {
            _RefreshList();
            _SetColumnNames();
            cbFilterBy.SelectedIndex = 0;
        }

        private void showPersonDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvInternationalLicensesList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedID))
            {
                InternationalLicense L1 = InternationalLicense.Find(selectedID);
                frmPersonDetail frm = new frmPersonDetail(L1.ApplicantPersonID);
                frm.ShowDialog();
       }    }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvInternationalLicensesList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedLicenseID))
            {
                frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(selectedLicenseID);
                frm.ShowDialog();
            }

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvInternationalLicensesList.SelectedRows[0].Cells[2].Value.ToString(), out int selectedLicenseID))
            {
                int LicenseID = (int)dgvInternationalLicensesList.SelectedRows[0].Cells[2].Value;
                int personID = clsLicenses.Find(LicenseID).ApplicationInfo.ApplicantPersonID;
                frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personID);
                frm.ShowDialog();
            }
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilet.Text = "";


            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilet.Visible = false;
                _DtInternationalLicenses.DefaultView.RowFilter = null;
            }
            else
            {
                txtFilet.Visible = true;
            }

        }

        private void txtFilet_TextChanged(object sender, EventArgs e)
        {


            if (txtFilet.Text == "")
            {
                _DtInternationalLicenses.DefaultView.RowFilter = null;
                dgvInternationalLicensesList.DataSource = _DtInternationalLicenses;
                return;
            }
            string FilterColumn = "";

            /*
             
             International License LocalDrivingLicenseApplicationID
Application LocalDrivingLicenseApplicationID
Driver LocalDrivingLicenseApplicationID
Local License LocalDrivingLicenseApplicationID
Is Active
             
             */
            switch(cbFilterBy.Text)
            {
                case "International License LocalDrivingLicenseApplicationID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                case "Application LocalDrivingLicenseApplicationID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver LocalDrivingLicenseApplicationID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License LocalDrivingLicenseApplicationID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;
                default:
                    FilterColumn = "None";
                    return;
            }

            _DtInternationalLicenses.DefaultView.RowFilter = $"{FilterColumn} = {txtFilet.Text} ";

            lblRecords.Text = dgvInternationalLicensesList.RowCount.ToString();

        }

        //LocalDrivingLicenseApplicationID'de sadece numara girilmesi lazım.
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

        private void btnAddNewInternationaLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense frm = new frmAddNewInternationalLicense();
            frm.ShowDialog();
            _RefreshList();
        }
    }
}

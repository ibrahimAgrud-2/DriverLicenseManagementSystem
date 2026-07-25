using DVLD.Licenses;
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

namespace DVLD.Applications.International_License_Applications
{
    public partial class frmListInternationalLicesnseApplications : Form
    {


        public frmListInternationalLicesnseApplications()
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
              { "InternationalLicenseID", "Int.L.ID" },
              { "ApplicationID", "App.ID" },
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

        private void _RefreshPeopleList()
        {
            _DtInternationalLicenses = InternationalLicense.getInternationalLicenseRecords();

            dgvInternationalLicensesList.DataSource = _DtInternationalLicenses.DefaultView.ToTable("InternationalLicenses", false, "InternationalLicenseID", "ApplicationID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");
            lblRecords.Text = dgvInternationalLicensesList.RowCount.ToString();

        }


        private void frmManageApplication_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            _SetColumnNames();
            cbFilterBy.SelectedIndex = 0;
        }

        private void showPersonDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvInternationalLicensesList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                frmPersonDetail frm = new frmPersonDetail(selectedPersonID);
                frm.ShowDialog();
       }    }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvInternationalLicensesList.SelectedRows[0].Cells[3].Value.ToString(), out int selectedLicenseID))
            {
                frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(selectedLicenseID);
                frm.ShowDialog();
            }

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvInternationalLicensesList.SelectedRows[0].Cells[3].Value.ToString(), out int selectedLicenseID))
            {
                int driverID = (int)dgvInternationalLicensesList.SelectedRows[0].Cells[2].Value;
                int personID = Driver.Find(driverID).personID;
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
             
             International License ID
Application ID
Driver ID
Local License ID
Is Active
             
             */
            switch(cbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;
                default:
                    FilterColumn = "None";
                    return;
            }

            _DtInternationalLicenses.DefaultView.RowFilter = $"{FilterColumn} = {txtFilet.Text} ";

            lblRecords.Text = dgvInternationalLicensesList.RowCount.ToString();

        }

        //ID'de sadece numara girilmesi lazım.
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

    }
}

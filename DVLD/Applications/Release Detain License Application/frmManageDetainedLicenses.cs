using DVLD.Licenses;
using DVLD.Licenses.Detained_Licenses;
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

namespace DVLD.Applications.Release_Detain_License_Application
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        private DataTable _DtDetainedLicenses;


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
        {
                         { "DetainID", "Detain ID" },
                         { "LicenseID", "License ID" },
                         { "DetainDate", "Detain Date" },
                         { "IsReleased", "Is Released" },
                         { "FineFees", "Fine Fees" },
                         { "ReleaseDate", "Release Date" },
                         { "NationalNo", "National No" },
                         { "FullName", "Full Name" },
                         { "ReleaseApplicationID", "Release Application ID" }
        };
        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvDetainedLicenseList.Columns[dict.Key].HeaderText = dict.Value;
            }

        }

        private void _RefreshList()
        {
            _DtDetainedLicenses = DetainedLicense.getDetainedLicenseRecords();
            dgvDetainedLicenseList.DataSource = _DtDetainedLicenses;
            lblRecord.Text =dgvDetainedLicenseList.RowCount.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshList();
           _SetColumnNames();
            cbFilterBy.SelectedIndex = 0;
        }

        // ----------------- V Filtering V -----------------

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilter.Visible = false;
                _DtDetainedLicenses.DefaultView.RowFilter = null;
            }
            else if (cbFilterBy.SelectedIndex == 2)
            {
                txtFilter.Visible = false;
                cbActive.Visible = true;
            }
            else
            {
                txtFilter.Visible = true;
                cbActive.Visible = false;
            }
        }
        private void txtFilet_TextChanged(object sender, EventArgs e)
        {



            if (txtFilter.Text == "")
            {
                _DtDetainedLicenses.DefaultView.RowFilter = null;
                dgvDetainedLicenseList.DataSource = _DtDetainedLicenses;
                return;
            }
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (cbFilterBy.Text == "Detain ID")
            {
                _DtDetainedLicenses.DefaultView.RowFilter = $"{FilterColumn} = {txtFilter.Text} ";
            }
            else
            {
                _DtDetainedLicenses.DefaultView.RowFilter = $"{FilterColumn} Like '{txtFilter.Text}%'";
            }

            lblRecord.Text = dgvDetainedLicenseList.RowCount.ToString();

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
        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActive.SelectedIndex == 1)
            {
                _DtDetainedLicenses.DefaultView.RowFilter = $"IsReleased = 'true'";
                return;
            }
            else if (cbActive.SelectedIndex == 2)
            {
                _DtDetainedLicenses.DefaultView.RowFilter = $"IsReleased = 'false'";
                return;
            }
            _DtDetainedLicenses.DefaultView.RowFilter = null;
            dgvDetainedLicenseList.DataSource = _DtDetainedLicenses;
            lblRecord.Text = dgvDetainedLicenseList.RowCount.ToString();
        }

        // ----------------- Filtering ^^ -----------------


        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvDetainedLicenseList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {

                frmPersonDetail frm = new frmPersonDetail(selectedPersonID);
                frm.ShowDialog();
                _RefreshList();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvDetainedLicenseList.SelectedRows[0].Cells[1].Value.ToString(), out int selectedPersonID))
            {

                frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(selectedPersonID);
                frm.ShowDialog();
                _RefreshList();
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvDetainedLicenseList.SelectedRows[0].Cells[1].Value.ToString(), out int selectedPersonID))
            {

                frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(selectedPersonID);
                frm.ShowDialog();
                _RefreshList();
            }
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
          

                frmDetainLicense frm = new frmDetainLicense();
                frm.ShowDialog();
            _RefreshList();

            
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            _RefreshList();
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            if (Boolean.TryParse(dgvDetainedLicenseList.SelectedRows[0].Cells[3].Value.ToString(), out bool result))
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = !result;
            }
     

        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvDetainedLicenseList.SelectedRows[0].Cells[1].Value.ToString(), out int selectedPersonID))
            {

                frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
                frm.LoadData(selectedPersonID);
                frm.ShowDialog();
                _RefreshList();
            }
   
        }
    }
}

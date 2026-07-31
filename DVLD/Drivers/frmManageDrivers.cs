using DVLD.Licenses;
using DVLD.Licenses.International_Licenses;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Drivers
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }


        private DataTable _DtDrivers;


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "DriverID", "Driver LocalDrivingLicenseApplicationID" },
              { "PersonID", "Person LocalDrivingLicenseApplicationID" },
              { "nationalNo", "National No" },
              { "FullName", "Full Name" },
              { "CreatedDate", "Created Date" },
              { "NumberOfActiveLicenses", "Number Of Active Licenses" }
            };
        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvDrivers.Columns[dict.Key].HeaderText = dict.Value;
            }

        }

        private void _RefreshDriversList()
        {
            _DtDrivers = Driver.getDriverRecords();

            dgvDrivers.DataSource = _DtDrivers;
            lblRecords.Text = dgvDrivers.RowCount.ToString();

        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDriversList();
            _SetColumnNames();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilet.Text = "";


            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilet.Visible = false;
                _DtDrivers.DefaultView.RowFilter = null;
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
                _DtDrivers.DefaultView.RowFilter = null;
                dgvDrivers.DataSource = _DtDrivers;
                return;
            }
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Driver LocalDrivingLicenseApplicationID":
                    FilterColumn = "DriverID";
                    break;
                case "Person LocalDrivingLicenseApplicationID":
                    FilterColumn = "PersonID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

             
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    return;
            }

            if (cbFilterBy.Text == "Person LocalDrivingLicenseApplicationID")
            {
                _DtDrivers.DefaultView.RowFilter = $"{FilterColumn} = {txtFilet.Text} ";
            }
            else
            {
                _DtDrivers.DefaultView.RowFilter = $"{FilterColumn} Like '{txtFilet.Text}%'";
            }

            lblRecords.Text = dgvDrivers.RowCount.ToString();

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

        private void tsmEdit_Click(object sender, EventArgs e)
        {

        }

        private void showDetialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvDrivers.SelectedRows[0].Cells[1].Value;
            frmPersonDetail frm = new frmPersonDetail(personID);
            frm.ShowDialog();

        }

        private void ShowLicenseHistoryüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = (int)dgvDrivers.SelectedRows[0].Cells[1].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(personID);
            frm.ShowDialog();
                
                
       }
    }
}

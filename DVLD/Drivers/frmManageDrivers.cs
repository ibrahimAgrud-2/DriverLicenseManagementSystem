using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using clsDriver = DVLD_BusinessLayer.Driver;

namespace DVLD.Drivers
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }
        DataTable _DtDriversList;
        private DataTable _DtPeople;


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
        {
                { "DriverID", "Driver ID" },
                { "PersonID", "People ID" },
                { "NationalNo", "National No" },
                { "FullName", "Full Name" },
                { "CreatedDate", "Created Date" },
                  { "NumberOfActiveLicenses", "Active Licenses" }
        };
        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvDriverList.Columns[dict.Key].HeaderText = dict.Value;
            }

        }

        private void _RefreshPeopleList()
        {
            _DtPeople = clsDriver.GetDrivers();

            dgvDriverList.DataSource = _DtPeople;
            lblRecords.Text = dgvDriverList.RowCount.ToString();

        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            _SetColumnNames();
            cbFilterBy.SelectedIndex = 0;
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
                _DtPeople.DefaultView.RowFilter = null;
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
                _DtPeople.DefaultView.RowFilter = null;
                dgvDriverList.DataSource = _DtPeople;
                return;
            }
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (cbFilterBy.Text == "Person ID"|| cbFilterBy.Text == "Driver ID")
            {
                _DtPeople.DefaultView.RowFilter = $"{FilterColumn} = {txtFilet.Text} ";
            }
            else
            {
                _DtPeople.DefaultView.RowFilter = $"{FilterColumn} Like '{txtFilet.Text}%'";
            }

            lblRecords.Text = dgvDriverList.RowCount.ToString();

        }

        //ID'de sadece numara girilmesi lazım.
        private void txtFilet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1|| cbFilterBy.SelectedIndex==2)
            {
                if (!int.TryParse(e.KeyChar.ToString(), out int test))
                {


                    e.Handled = !(char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
                }
            }
        }

    }
}

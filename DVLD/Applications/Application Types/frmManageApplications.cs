using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD.Application.Application_Types
{
    public partial class frmManageApplications : Form
    {
        public frmManageApplications()
        {
            InitializeComponent();
        }

        DataTable _AppList;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "applicationTypeID", "Application Type ID" },
              { "applicationTypeTitle", "Application Type Title" },
              { "ApplicationFees", "Application Fees" }
            };
        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvAppList.Columns[dict.Key].HeaderText = dict.Value;
            }
        }

        private void _RefreshList()
        {
            _AppList = Applications.getApplicationsRecord();
            dgvAppList.DataSource = _AppList;
            lblRecords.Text = dgvAppList.RowCount.ToString();

        }
        private void frmManageApplications_Load(object sender, EventArgs e)
        {
            _RefreshList();
            _SetColumnNames();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }
    }
}

using DVLD.Applications.Application_Types;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace DVLD.Applications.Application_Types
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
        DataTable _AppList;


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
            _AppList = ApplicationTypes.getApplicationTypeRecords();
            dgvAppList.DataSource = _AppList;
            lblRecord.Text = dgvAppList.RowCount.ToString();

        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshList();
            _SetColumnNames();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvAppList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                frmEditApplicationType frm = new frmEditApplicationType();
                frm.ShowDialog();
                _RefreshList();
            }

        }
    }


}

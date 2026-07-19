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

namespace DVLD.Test.Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        DataTable _TestList;


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "TestTypeID", "Test Type ID" },
              { "TestTypeTitle", "Test Type Title" },
                 { "TestTypeFees", "Test Type Fees" },
              { "TestTypeDescription", "Description" }      
            
            };
        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvTestList.Columns[dict.Key].HeaderText = dict.Value;
            }
        }

        private void _RefreshList()
        {
            _TestList =clsTestType.getAllRecords();
            dgvTestList.DataSource = _TestList;
            lblRecord.Text = dgvTestList.RowCount.ToString();

        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshList();
            _SetColumnNames();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

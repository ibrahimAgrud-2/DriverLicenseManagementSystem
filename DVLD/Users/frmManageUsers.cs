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

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "UserID", "User ID" },     
            { "PersonID", "Person ID" },
              { "UserName", "User Name" },
              { "IsActive", "Is Active" },
            };

        private void _SetColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvUsersList.Columns[dict.Key].HeaderText = dict.Value;
            }
        }

        private DataTable _DtUsers;
        private void _RefreshPeopleList()
        {
            _DtUsers = User.getUserRecords();
            dgvUsersList.DataSource = _DtUsers;
          
            _SetColumnNames();

            lblRecords.Text = dgvUsersList.RowCount.ToString();
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }
    }
}

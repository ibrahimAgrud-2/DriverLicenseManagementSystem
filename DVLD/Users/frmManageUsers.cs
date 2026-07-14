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

        private DataTable _DtUsers;

        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "UserID", "User ID" },     
              { "PersonID", "PeopleBl ID" },
              { "UserName", "User Name" },
              { "IsActive", "Is Active" },
              { "FullName", "Full Name" },
            };


        private void _setDataResource()
        {
            DataTable dt = User.getUserRecords();
            dt.Columns.Add("FullName");
            foreach (DataRow dr in dt.Rows)
            {
                dr["FullName"] = $"{dr["firstName"]} {dr["secondName"]} {dr["thirdName"]} {dr["lastName"]}";
            }
            dt.Columns["FullName"].SetOrdinal(2);
            _DtUsers = dt;
         
        }
      

    
        private void _RefreshUserList()
        {
            
         

            _setDataResource();
            dgvUsersList.DataSource = _DtUsers;
            dgvUsersList.Columns["firstName"].Visible = false;
            dgvUsersList.Columns["secondName"].Visible = false;
            dgvUsersList.Columns["thirdName"].Visible = false;
            dgvUsersList.Columns["lastName"].Visible = false;
            dgvUsersList.Columns["password"].Visible = false;

            foreach (KeyValuePair<string, string> dict in _ColumnNames)
            {
                dgvUsersList.Columns[dict.Key].HeaderText = dict.Value;
            }


            lblRecords.Text = dgvUsersList.RowCount.ToString();
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            
            _RefreshUserList();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewUser frm = new frmAddUpdateNewUser(-1);
            frm.ShowDialog();
            _RefreshUserList();
            
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {

            if (int.TryParse(dgvUsersList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {

                frmAddUpdateNewUser frm = new frmAddUpdateNewUser(selectedPersonID);
                frm.ShowDialog();
                _RefreshUserList();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvUsersList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedUserID))
            {
                if (User.isUserExistByID(selectedUserID))
                {
                    if (User.deleteUser(selectedUserID))
                    {
                        MessageBox.Show("User Deleted");
                        _RefreshUserList();
                    }
                    else
                    {
                        MessageBox.Show("User has data link to it");
                    }
                }
                else
                {
                    MessageBox.Show("User Not Found");
                }

            }
        }
    }
}

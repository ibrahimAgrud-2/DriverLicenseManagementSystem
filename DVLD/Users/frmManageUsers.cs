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
              { "PersonID", "Person ID" },
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

        private void frmManageUsers_Load(object sender, EventArgs e)
        {

            _RefreshUserList();
        }

        //------------------------------------


        private void btnClose_Click(object sender, EventArgs e)
        {
          
            this.Close();
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

        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvUsersList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedUserID))
            {

                frmChangePassword frm = new frmChangePassword(selectedUserID);
                frm.ShowDialog();
              
            }
        }

        private void showDetialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.TryParse(dgvUsersList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                frmUserDetails frm = new frmUserDetails(selectedPersonID);
                frm.ShowDialog();
               
            }
        }


        //=========  V FİLTERİNG V ====================
     
        private enum _enFilters { none = 0, UserID = 1, UserName = 2, FullName = 3, isActive = 4 };

        private void txtFilet_TextChanged(object sender, EventArgs e)
        {


            if (txtFilet.Text == "")
            {
                _DtUsers.DefaultView.RowFilter = null;
                dgvUsersList.DataSource = _DtUsers;
                return;
            }

            switch ((_enFilters)cbFilterBy.SelectedIndex)
            {
            
                case _enFilters.UserID:
                    _DtUsers.DefaultView.RowFilter = $"UserID = '{txtFilet.Text}'";
                    break;
                case _enFilters.UserName:
                    _DtUsers.DefaultView.RowFilter = $"UserName = '{txtFilet.Text}'";
                    break;
                case _enFilters.FullName:
                    _DtUsers.DefaultView.RowFilter = $"FullName LIKE '%{txtFilet.Text}%'";
                    break;
                default:
                    MessageBox.Show("No Filter");
                    break;
            }
            dgvUsersList.DataSource = _DtUsers;

        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbActive.SelectedIndex == 1)
            {
                _DtUsers.DefaultView.RowFilter = $"isActive = 'true'";
                return;
            }
            else if(cbActive.SelectedIndex==2)
            {
                _DtUsers.DefaultView.RowFilter = $"isActive = 'false'";
                return;
            }
            _DtUsers.DefaultView.RowFilter = null;
            dgvUsersList.DataSource = _DtUsers;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                txtFilet.Visible = false;
                _DtUsers.DefaultView.RowFilter = null;
            }
            else if (cbFilterBy.SelectedIndex == 4)
            {
                txtFilet.Visible = false;
                cbActive.Visible = true;
            }
            else
            {
                txtFilet.Visible = true;
            }
        }
        //=========  ^^ FİLTERİNG ^^ ====================


    }
}

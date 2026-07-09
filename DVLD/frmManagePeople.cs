using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {

        //======================= V List People =============================
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private DataTable _DtPeople;


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "PersonID", "Person ID" },
              { "FirstName", "First Name" },
              { "LastName", "Last Name" },
              { "SecondName", "Second Name" },
              { "NationalNo", "National No" },
              { "ThirdName", "Third Name" },
              { "DateOfBirth", "Birth Date" },
              { "CountryName", "Country Name" },
            };
        private void _SetColumnNames()
        {
            foreach(KeyValuePair<string,string> dict in _ColumnNames) 
            {
                dgvPeopleList.Columns[dict.Key].HeaderText = dict.Value;
            }
            dgvPeopleList.Columns["Address"].Visible = false;
            dgvPeopleList.Columns["CountryID"].Visible = false;
            dgvPeopleList.Columns["ImagePath"].Visible = false;
        }

        private void _RefreshPeopleList()
        {
            _DtPeople = People.getAllPersonRecords();
            dgvPeopleList.DataSource = _DtPeople;
            _SetColumnNames();
             lblRecords.Text = dgvPeopleList.RowCount.ToString();
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _DtPeople = People.getAllPersonRecords();
            _RefreshPeopleList();
            cbFilterBy.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //====================^^^^List People^^^^==============================


        //==================== VV Delete, call, Email ==============================

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvPeopleList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                if(People.isPersonExistByID(selectedPersonID))
                {
                    if(People.delete(selectedPersonID))
                    {
                        MessageBox.Show("Person Deleted");
                        _RefreshPeopleList();
                    }
                    else
                    {
                        MessageBox.Show("Person has data link to it");
                    }
                }
                else
                {
                    MessageBox.Show("Person Not Found");
                }

            }



        }

        private void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet");
        }
        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet");

        }
        //====================================================================





        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);

            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {


            if(int.TryParse(dgvPeopleList.SelectedRows[0].Cells[0].Value.ToString(),out int selectedPersonID))
            {

                frmAddUpdatePerson frm = new frmAddUpdatePerson(selectedPersonID);
                frm.ShowDialog();
                _RefreshPeopleList();
            }

        }


        private void showDetaiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.TryParse(dgvPeopleList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                frmPersonDetail frm = new frmPersonDetail(selectedPersonID);
                frm.ShowDialog();
            }
          
        }


        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(cbFilterBy.SelectedIndex==0)
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
                dgvPeopleList.DataSource = _DtPeople;
                return;
            }

        
                
            switch(cbFilterBy.Text)
            {
                case "Person ID":
                    _DtPeople.DefaultView.RowFilter = string.Format("PersonID = '{0}'", txtFilet.Text);
                    break;

                case "First Name":
                    _DtPeople.DefaultView.RowFilter = $"FirstName LIKE '%{txtFilet.Text}%'"; ;
                    break;
                case "National No":
                    _DtPeople.DefaultView.RowFilter = string.Format("NationalNo = '{0}'", txtFilet.Text);
                    break;


            }
            dgvPeopleList.DataSource = _DtPeople;
            
        }


        //========Bu ID için sadece  numara girilme sıkıntısı için test amaçla eklendi.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!int.TryParse(e.KeyChar.ToString(), out int test))
            {

                MessageBox.Show("no");
                e.Handled = true;

            }

        }
    }
}

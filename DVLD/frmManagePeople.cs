using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

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
              { "gender1", "Gender" }
            };
        private void _SetColumnNames()
        {
  

            foreach(KeyValuePair<string,string> dict in _ColumnNames) 
            {
                dgvPeopleList.Columns[dict.Key].HeaderText = dict.Value;
            }
            dgvPeopleList.Columns["imagePath"].Visible = false;
            dgvPeopleList.Columns["NationalityCountryID"].Visible = false;
            dgvPeopleList.Columns["CountryID"].Visible = false;
           dgvPeopleList.Columns["Gender"].Visible = false;

            dgvPeopleList.Columns["gender1"].DisplayIndex = 6;
            dgvPeopleList.Columns["CountryName"].DisplayIndex = 9;

        }

        private void _RefreshPeopleList()
        {
            DataTable table = People.getAllPersonRecords();

        
            dgvPeopleList.DataSource = table;

            _SetColumnNames();

             lblRecords.Text = dgvPeopleList.RowCount.ToString();
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {

            _RefreshPeopleList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvPeopleList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {

                if(People.isPersonExistByID(selectedPersonID))
               {
                    People.delete(selectedPersonID);
                    _RefreshPeopleList();
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

        private void showDetialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.TryParse(dgvPeopleList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                frmPersonDetail frm = new frmPersonDetail(selectedPersonID);
                frm.ShowDialog();
            }
          
        }
    }
}

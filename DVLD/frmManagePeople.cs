using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }


        private void _RefreshPeopleList()
        {
            DataTable table = People.getAllPersonRecords();


            table.Columns.Remove("Gender");
            table.Columns.Remove("NationalityCountryID");
            table.Columns.Remove("CountryID");
           table.Columns.Remove("ImagePath");

            table.Columns["gender1"].SetOrdinal(6);
            table.Columns["gender1"].ColumnName = "Gender";

            table.Columns["CountryName"].SetOrdinal(8);



            dgvPeopleList.DataSource = table;

          

            //Bu burada olmamaması gerekebilir
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
    }
}

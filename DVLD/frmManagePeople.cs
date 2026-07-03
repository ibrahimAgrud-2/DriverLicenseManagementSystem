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

        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

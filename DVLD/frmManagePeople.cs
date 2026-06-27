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
            dgvPeopleList.DataSource = People.getAllPersonRecords();

        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dVLDDataSet.People' table. You can move, or remove it, as needed.
            this.peopleTableAdapter.Fill(this.dVLDDataSet.People);
            _RefreshPeopleList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

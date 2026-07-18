using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void ctrlPersonCardWithFilter1_OnPersonLoaded(int obj)
        {
            MessageBox.Show(obj.ToString());
           }

        private void button1_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void btn(object sender, EventArgs e)
        {
            MessageBox.Show(this.ctrlPersonCardWithFilter1.personID.ToString());

        }
    }
}

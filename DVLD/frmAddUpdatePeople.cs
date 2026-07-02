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
    public partial class frmAddUpdatePeople : Form
    {

        public frmAddUpdatePeople(int PersonID)
        {
            InitializeComponent(PersonID);
        }

     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdatePeople_Load(object sender, EventArgs e)
        {

        }
    }
}

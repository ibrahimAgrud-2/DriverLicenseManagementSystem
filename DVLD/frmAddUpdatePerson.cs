using DVLD_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdatePerson : Form
    {

        private int _PersonID;
        public frmAddUpdatePerson(int personID)
        {
            InitializeComponent();

            _PersonID = personID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {

            this.ctrlAddUpdatePerson1.start(-1);
        }

        private void ctrlAddUpdatePerson1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlAddUpdatePerson1_SaveCompleted(int obj)
        {
            label3.Text = obj.ToString();
        }
    }
}

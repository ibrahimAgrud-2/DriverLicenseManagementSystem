using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdatePerson : Form
    {


        public delegate void sendColorBack(object sender,int personID);
        public event sendColorBack sendIDBack;

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
            if(_PersonID!=-1)
            {
                label3.Text = _PersonID.ToString();
            }
            this.ctrlAddUpdatePerson1.start(_PersonID);
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

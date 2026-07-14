using DVLD_BusinessLayer;
using System;
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
            if(_PersonID > 0)
            {
                lblPersonId.Text = _PersonID.ToString();
                lblMode.Text = "Update PeopleBl";
            }
            this.ctrlAddUpdatePerson1.personID = _PersonID;


        }

        private void ctrlAddUpdatePerson1_OnSaveComplete(int obj)
        {
            lblPersonId.Text = obj.ToString();
            lblMode.Text = "Update PeopleBl";
        }
    }
}

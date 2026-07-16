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
    public partial class frmPersonDetail : Form
    {
        private int _PersonID;
        public frmPersonDetail(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void frmPersonDetail_Load(object sender, EventArgs e)
        {
            
            this.ctrlPersonInformation1.LoadPersonInfo(_PersonID);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

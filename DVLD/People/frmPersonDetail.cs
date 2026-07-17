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

        private string _NationalNo;

        public frmPersonDetail(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
            this.ctrlPersonInformation1.LoadPersonInfo(_PersonID);
        }
        public frmPersonDetail(string  nationalNo)
        {
            InitializeComponent();
            _NationalNo = nationalNo;
            this.ctrlPersonInformation1.LoadPersonInfo(_NationalNo);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

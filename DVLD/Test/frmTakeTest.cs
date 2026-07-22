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

namespace DVLD.Test
{
    public partial class frmTakeTest : Form
    {
        public frmTakeTest(int testID)
        {
            InitializeComponent();
            _TestID = testID;
        }

        private int _TestID = -1;
        private Tests _Test;

        private void frmTakeTest_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

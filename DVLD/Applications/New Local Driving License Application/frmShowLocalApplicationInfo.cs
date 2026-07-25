using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmShowLocalApplicationInfo : Form
    {
        public frmShowLocalApplicationInfo(int LDLAID)
        {
            InitializeComponent();
            _LDLAID = LDLAID;
        }

        private int _LDLAID = -1;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowApplicationInfo_Load(object sender, EventArgs e)
        {
            this.ctrlLocalDrivinglicenseApplicationInfo1.LoadAppInfo(_LDLAID);

        }
    }
}

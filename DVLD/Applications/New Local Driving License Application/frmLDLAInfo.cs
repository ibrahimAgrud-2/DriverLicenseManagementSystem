using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.New_Local_Driving_License_Application
{
    public partial class frmLDLAInfo : Form
    {
        public frmLDLAInfo(int LDLAID)
        {
            InitializeComponent();
            _LDLAID = LDLAID;
        }
        private int _LDLAID=-1;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLDLAInfo_Load(object sender, EventArgs e)
        {
            this.ctrlLDLAInfo1.LoadData(_LDLAID);
        }

  
    }
}

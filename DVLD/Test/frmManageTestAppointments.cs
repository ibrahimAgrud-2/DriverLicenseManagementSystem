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
    public partial class frmManageTestAppointments : Form
    {
        public frmManageTestAppointments(int LDLAID)
        {
            InitializeComponent();
        }


        private int _LDLAInfo = -1;
        private LocalDrivingLicenseApp _LDLA;

        enum enTestType {Vision=1, Written= 2,Street=3 }
        enTestType TestType=enTestType.Vision;

        private void frmManageTestAppointments_Load(object sender, EventArgs e)
        {

        }
    }
}

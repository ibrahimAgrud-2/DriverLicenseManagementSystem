using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        public frmShowPersonLicenseHistory(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }
        private int _personID=-1;

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            this.ctrlPersonCardWithFilter1.LoadData(_personID);
            this.ctrlPersonCardWithFilter1.FilterEnabled = false;

            this.ctrlListLicenses1.LoadLicenses();
        }
    }
}

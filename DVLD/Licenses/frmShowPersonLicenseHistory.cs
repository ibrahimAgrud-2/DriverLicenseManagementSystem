using DVLD.Licenses.International_Licenses;
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
        
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
          
        }
        public frmShowPersonLicenseHistory(int personID)
        {
            InitializeComponent();
            _personID = personID;
        }
        private int _personID=-1;

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_personID != -1)
            {
                this.ctrlPersonCardWithFilter1.FilterEnabled = false;
                this.ctrlPersonCardWithFilter1.LoadData(_personID);
                this.ctrlListLicenses1.LoadLicenses(_personID);
            }
            else
            {
                this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            }

          
        }

     

        private void ctrlPersonCardWithFilter1_OnPersonLoaded(int obj)
        {
            _personID = obj;

            if(obj==-1)
            {
                ctrlListLicenses1.Clear();
                return;
            }
                
            ctrlListLicenses1.LoadLicenses(_personID);
        }
    }
}

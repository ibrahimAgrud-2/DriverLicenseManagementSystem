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
using clsLicenses = DVLD_BusinessLayer.Licenses;


namespace DVLD.Licenses.Controls
{
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public event Action<int> OnLicenseLoaded;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseLoaded(int PersonID)
        {
            Action<int> handler = OnLicenseLoaded;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

     
        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbMain.Enabled = _FilterEnabled;
            }
        }

        public int LicenseID
        {
            get { return this.ctrlShowLicenseInfo1.LicenseID; }
        }
        public clsLicenses selectedLicense
        {
            get { return this.ctrlShowLicenseInfo1.SelectedLicense; }
        }



        public void ResetForm()
        {
            this.ctrlShowLicenseInfo1.ResetForm();
           
        }

        public void LoadLicenseIndo(int licenseID)
        {
            txtFilter.Text = licenseID.ToString();
            this.ctrlShowLicenseInfo1.LoadLicenseInfo(licenseID);
            _FindLicense();
        }
        private void _FindLicense()
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
            {
                MessageBox.Show("Enter a valid filter value");
                return;
            }
            if (clsLicenses.isLicenseExist(Convert.ToInt32(txtFilter.Text)))
            {
                this.ctrlShowLicenseInfo1.LoadLicenseInfo(Convert.ToInt32(txtFilter.Text));
                if (OnLicenseLoaded != null && FilterEnabled)
                {
                    OnLicenseLoaded(Convert.ToInt32(txtFilter.Text));


                }
            }
            else
            {
                ResetForm();
                MessageBox.Show($"Could Not find License with ID {txtFilter.Text}");
                txtFilter.Text = "";
                txtFilter.Focus();


            }
            

        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            if (!int.TryParse(e.KeyChar.ToString(), out int test))
            {

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindLicense();

        }
    }
}

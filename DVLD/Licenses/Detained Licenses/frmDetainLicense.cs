using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using clslicense = DVLD_BusinessLayer.Licenses;
using clsApplication = DVLD_BusinessLayer.Applications;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD.Licenses.Detained_Licenses
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }


           private int _DetainLicenseID = -1;
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainedDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lblCreatedByUser.Text = Global.CurrentUser.UserName;
        }



        private void ctrlLicenseInfoWithFilter1_OnLicenseLoaded(int obj)
        {
            int selectedID = obj;

            llShowLicenseHistory.Enabled = (selectedID!=-1);
            if(selectedID==-1)
            {
                return;
            }


            if(!this.ctrlLicenseInfoWithFilter1.selectedLicense.isActive)
            {
                MessageBox.Show("The license is not active");
                return;
            }
            if(this.ctrlLicenseInfoWithFilter1.selectedLicense.isLicenseDetained)
            {
                MessageBox.Show("The license is Already detained");
                return;
            }
            lblLicenseID.Text = selectedID.ToString();

            btnDetain.Enabled = true;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Fill required fields");
                return;
            }
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            DetainedLicense detainedLicense = this.ctrlLicenseInfoWithFilter1.selectedLicense.Detain(Convert.ToDouble(txtFineFee.Text),Global.CurrentUser.userID);

            if(detainedLicense==null)
            {
                MessageBox.Show("failed to Detain the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DetainLicenseID = detainedLicense.detainID;
            MessageBox.Show("Licensed Detained Successfully with ID=" + _DetainLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblDetainID.Text = detainedLicense.detainID.ToString();


            btnDetain.Enabled = false;
            this.ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(this.ctrlLicenseInfoWithFilter1.selectedLicense.ApplicationInfo.ApplicantPersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicenseInfo frm = new frmShowDrivingLicenseInfo(_DetainLicenseID);
            frm.ShowDialog();
        }

        private void txtFineFee_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFineFee.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFee,"Enter a valid Fine fee");
            }
        }

        private void txtFineFee_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!double.TryParse(e.KeyChar.ToString(), out double test))
                {

                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


                }
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

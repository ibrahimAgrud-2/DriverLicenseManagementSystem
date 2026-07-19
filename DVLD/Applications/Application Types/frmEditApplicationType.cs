using DVLD.Global_Classes;
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

namespace DVLD.Applications.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        private int _AppTypeID = -1;
        ApplicationTypes _Apt;


        public frmEditApplicationType(int appTypeID)
        {
            InitializeComponent();
            _AppTypeID = appTypeID;
        }


        private void _loadData(int appTypeID)
        {
            _Apt = ApplicationTypes.Find(appTypeID);
            if(_Apt == null)
            {
                MessageBox.Show("Application Type could not found",
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblID.Text = _Apt.applicationTypeID.ToString();
            txtAppTypeName.Text = _Apt.applicantTypeTitle;
            txtAppFees.Text = _Apt.applicationFee.ToString();

        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
           
            _loadData(_AppTypeID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                _Apt.applicantTypeTitle = txtAppTypeName.Text;
                _Apt.applicationFee = Convert.ToDouble(txtAppFees.Text);
                if (_Apt.UpdateApplicationType())
                {
                    MessageBox.Show("Saved successfully");
                }
                else
                {
                    MessageBox.Show("Application Type could not saved",
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                MessageBox.Show("Fill required fields",
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  
        
        
        
        
        
        //---------- Validating ----------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtAppFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAppFees, "Enter Application Type fees");
            }
            else if(!Validation.isNumber(txtAppFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAppFees, "Fee is not properly formated");

            }
            else
            {       
                errorProvider1.SetError(txtAppFees, null);
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!int.TryParse(e.KeyChar.ToString(), out int test))
            {

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            }
        }

        private void txtAppTypeName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAppTypeName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAppTypeName, "Enter Application Type fees");
            }
            else if(ApplicationTypes.isApplicationTypeExist(txtAppTypeName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAppTypeName, "Application Type title already exists");
            }
            else
            {
                errorProvider1.SetError(txtAppTypeName, null);
            }
        }
    }
}

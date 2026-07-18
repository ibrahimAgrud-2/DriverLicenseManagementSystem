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
            textBox1.Text = _Apt.applicantTypeTitle;
            textBox2.Text = _Apt.applicationFee.ToString();

        }
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
           
            _loadData(_AppTypeID);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                _Apt.applicantTypeTitle = textBox1.Text;
                _Apt.applicationFee = Convert.ToDouble(textBox2.Text);
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
            if(string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Enter Application Type fees");
            }
            else if(!double.TryParse(textBox2.Text, out double fees))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Fee is not properly formated");

            }
            else
            {
                errorProvider1.SetError(textBox2, null);
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
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Enter Application Type fees");
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }
        }
    }
}

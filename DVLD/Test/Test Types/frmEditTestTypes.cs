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

namespace DVLD.Test.Test_Types
{
    public partial class frmEditTestTypes : Form
    {
        public frmEditTestTypes(clsTestType.enTestTypes testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;
        }

        private clsTestType.enTestTypes _TestTypeID;
        clsTestType _TestType;

        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);
            if (_TestType == null)
            {
                MessageBox.Show("Test Type could not found",
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblID.Text = _TestType.ID.ToString();
            txtTestTypeName.Text = _TestType.TestTypeTitle;
            txtTypeFee.Text = _TestType.TestTypeFees.ToString();
            txtDescription.Text = _TestType.TestTypeDescription.ToString();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                _TestType.TestTypeTitle = txtTestTypeName.Text;
                _TestType.TestTypeFees = Convert.ToDouble(txtTypeFee.Text);
                _TestType.TestTypeDescription = txtDescription.Text;
                if (_TestType.UpdateTestTypes())
                {
                    MessageBox.Show("Saved successfully");
                }
                else
                {
                    MessageBox.Show("Test Type could not saved",
                                 "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                MessageBox.Show("Fill required fields",
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void txtTypeFee_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTypeFee.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTypeFee, "Enter Test Type fees");
            }
            else if (!Validation.isNumber(txtTypeFee.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTypeFee, "Fee is not properly formated");

            }
            else
            {
                errorProvider1.SetError(txtTypeFee, null);
            }
        }

        private void txtTypeFee_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!int.TryParse(e.KeyChar.ToString(), out int test))
            {

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


            }
        }

        private void txtTestTypeName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeName.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeName, "Enter Test Type Title");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeName, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Enter Test Type Description");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }





        //---------- Validating ----------------------

    }
}

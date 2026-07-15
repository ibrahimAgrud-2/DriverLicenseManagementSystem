using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Person = DVLD_BusinessLayer.People;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {

        //======================= V List People =============================
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private DataTable _DtPeople;


        private Dictionary<string, string> _ColumnNames = new Dictionary<string, string>
            {
              { "PersonID", "People ID" },
              { "FirstName", "First Name" },
              { "LastName", "Last Name" },
              { "SecondName", "Second Name" },
              { "NationalNo", "National No" },
              { "ThirdName", "Third Name" },
              { "DateOfBirth", "Birth Date" },
              { "CountryName", "Country Name" },
            };
        private void _SetColumnNames()
        {
            foreach(KeyValuePair<string,string> dict in _ColumnNames) 
            {
                dgvPeopleList.Columns[dict.Key].HeaderText = dict.Value;
            }

        }

        private void _RefreshPeopleList()
        {
            _DtPeople = Person.getAllPersonRecords();

            dgvPeopleList.DataSource = _DtPeople.DefaultView.ToTable("People", false, "PersonID", "NationalNo", "FirstName", "secondName", "thirdName", "LastName", "Gender", "DateOfBirth", "CountryName", "Address", "Email", "Phone");
            lblRecords.Text = dgvPeopleList.RowCount.ToString();
    
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            _SetColumnNames();
            cbFilterBy.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //====================^^^^List People^^^^==============================


        //==================== VV Delete, call, Email ==============================

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (int.TryParse(dgvPeopleList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                if(Person.isPersonExistByID(selectedPersonID))
                {
                    if(MessageBox.Show("Are you sure you want to delete Person [" + dgvPeopleList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (Person.delete(selectedPersonID))
                        {
                            MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefreshPeopleList();
                        }
                        else
                        {
                            MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                else
                {
                    MessageBox.Show("People Not Found");
                }

            }



        }

        private void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet");
        }
        private void callToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implemented yet");

        }
        //====================================================================





        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();

            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {


            if(int.TryParse(dgvPeopleList.SelectedRows[0].Cells[0].Value.ToString(),out int selectedPersonID))
            {

                frmAddUpdatePerson frm = new frmAddUpdatePerson(selectedPersonID);
                frm.ShowDialog();
                _RefreshPeopleList();
            }

        }

        private void showDetaiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (int.TryParse(dgvPeopleList.SelectedRows[0].Cells[0].Value.ToString(), out int selectedPersonID))
            {
                frmPersonDetail frm = new frmPersonDetail(selectedPersonID);
                frm.ShowDialog();
                _RefreshPeopleList();
            }
          
        }


        //------------ V  filtering V -------------------------
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilet.Text = "";


            if(cbFilterBy.SelectedIndex==0)
            {
                txtFilet.Visible = false;
                _DtPeople.DefaultView.RowFilter = null;
            }
            else
            {
                txtFilet.Visible = true;
            }
        
        }

        private void txtFilet_TextChanged(object sender, EventArgs e)
        {

            if (txtFilet.Text == "")
            {
                _DtPeople.DefaultView.RowFilter = null;
                dgvPeopleList.DataSource = _DtPeople;
                return;
            }
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "Gender";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if(cbFilterBy.Text == "Person ID")
            {
               _DtPeople.DefaultView.RowFilter = $"{FilterColumn} = {txtFilet.Text} ";
            }
            else
            {
                _DtPeople.DefaultView.RowFilter = $"{FilterColumn} Like '{txtFilet.Text}%'";
            }

            

        }

        //ID'de sadece numara girilmesi lazım.
        private void txtFilet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex==1)
            {
                if (!int.TryParse(e.KeyChar.ToString(), out int test))
                {

                    if (e.KeyChar == '\b')
                        return;
                    e.Handled = true;

                }
            }
        }



      
    }
}

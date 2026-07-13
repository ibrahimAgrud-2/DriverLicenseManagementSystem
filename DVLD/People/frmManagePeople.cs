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
              { "PersonID", "PeopleBl ID" },
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
            dgvPeopleList.Columns["Address"].Visible = false;
            dgvPeopleList.Columns["CountryID"].Visible = false;
            dgvPeopleList.Columns["ImagePath"].Visible = false;

        }

        private void _RefreshPeopleList()
        {
            _DtPeople = Person.getAllPersonRecords();

            
            //toTable kullan visile yerinee
            dgvPeopleList.DataSource = _DtPeople;
            _SetColumnNames();
             lblRecords.Text = dgvPeopleList.RowCount.ToString();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {

    
            _DtPeople = Person.getAllPersonRecords();
            _RefreshPeopleList();
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
                    if(Person.delete(selectedPersonID))
                    {
                        MessageBox.Show("PeopleBl Deleted");
                        _RefreshPeopleList();
                    }
                    else
                    {
                        MessageBox.Show("PeopleBl has data link to it");
                    }
                }
                else
                {
                    MessageBox.Show("PeopleBl Not Found");
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
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);

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


       private  enum _enFilters { none=0,ID=1,NationalNo=2,firstName=3,secondName=4,thirdName=5,lastName=6, Nationality = 7,Gender=8,phone=9,Email=10}
        private void txtFilet_TextChanged(object sender, EventArgs e)
        {

            if (txtFilet.Text == "")
            {
                _DtPeople.DefaultView.RowFilter = null;
                dgvPeopleList.DataSource = _DtPeople;
                return;
            }


            switch ((_enFilters)cbFilterBy.SelectedIndex)
            {
                case _enFilters.ID:
                    _DtPeople.DefaultView.RowFilter = $"PersonID = '{txtFilet.Text}'";
                    break;
                case _enFilters.firstName:
                    _DtPeople.DefaultView.RowFilter = $"FirstName LIKE '%{txtFilet.Text}%'";
                    break;
                case _enFilters.NationalNo:
                    _DtPeople.DefaultView.RowFilter = $"NationalNo = '{txtFilet.Text}'";
                    break;
                case _enFilters.Nationality:
                    _DtPeople.DefaultView.RowFilter = $"CountryName LIKE '%{txtFilet.Text}%'";
                    break;
                case _enFilters.phone:
                    _DtPeople.DefaultView.RowFilter = $"Phone LIKE '%{txtFilet.Text}%'";
                    break;
                case _enFilters.Email:
                    _DtPeople.DefaultView.RowFilter = $"Email LIKE '%{txtFilet.Text}%'";
                    break;
                case _enFilters.Gender:
                    _DtPeople.DefaultView.RowFilter = $"Gender = '{txtFilet.Text}'";
                    break;
                case _enFilters.secondName:
                    _DtPeople.DefaultView.RowFilter = $"SecondName LIKE '%{txtFilet.Text}%'";
                    break;
                case _enFilters.thirdName:
                    _DtPeople.DefaultView.RowFilter = $"thirdName LIKE '%{txtFilet.Text}%'";
                    break;
                case _enFilters.lastName:
                    _DtPeople.DefaultView.RowFilter = $"lastName LIKE '%{txtFilet.Text}%'";
                    break;
                default:
                    MessageBox.Show("No Filter");
                    break;
            }
            dgvPeopleList.DataSource = _DtPeople;



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

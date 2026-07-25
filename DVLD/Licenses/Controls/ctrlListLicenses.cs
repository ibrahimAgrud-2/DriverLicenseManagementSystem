using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using clsLicenses = DVLD_BusinessLayer.Licenses;
using System.Windows.Forms;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlListLicenses : UserControl
    {
        public ctrlListLicenses()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> _LocalListColumnNames = new Dictionary<string, string>
            {
              { "LicenseID", "L.ID" },
              { "ApplicationID", "App.ID" },
              { "ClassName", "Class" },
              { "IssueDate", "Issue Date" },
              { "ExpirationDate", "Expiration Date" },
              { "IsActive", "Is Active" }
            };
        private Dictionary<string, string> _InternationalListColumnNames = new Dictionary<string, string>
            {
              { "InternationalLicenseID", "_InternationalLicense.L.ID" },
              { "ApplicationID", "App.ID" },
              { "IssuedUsingLocalLicenseID", "L.LicenseID" },
              { "IssueDate", "Issue Date" },
              { "ExpirationDate", "Expiration Date" },
              { "IsActive", "Is Active" }
            };
        private void _SetLocalLicensesColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _LocalListColumnNames)
            {
                dgvLocalLicenseList.Columns[dict.Key].HeaderText = dict.Value;
            }
        }
        private void _SetInternationalLicensesColumnNames()
        {
            foreach (KeyValuePair<string, string> dict in _InternationalListColumnNames)
            {
                dgvInternationalLicenseList.Columns[dict.Key].HeaderText = dict.Value;
            }
        }

        DataTable _DtLocalLicenses;
        DataTable _DtInternationalLicenses;
        private void _RefreshLists(int personID)
        {
            _DtLocalLicenses = clsLicenses.getAllLocalLicenseByPersonID(personID);
            _DtInternationalLicenses = InternationalLicense.getAllInternationalLicenseByPersonID(personID);


      

            if (_DtLocalLicenses.Rows.Count > 0)
            {
                dgvLocalLicenseList.DataSource = _DtLocalLicenses.DefaultView.ToTable("LocalLicenses", false, "LicenseID", "ApplicationID", "ClassName", "IssueDate", "ExpirationDate", "IsActive");
                _SetLocalLicensesColumnNames();
            }

            if (_DtInternationalLicenses.Rows.Count > 0)
            {
 

                dgvInternationalLicenseList.DataSource = _DtInternationalLicenses.DefaultView.ToTable("InternationalLicenses", false, "InternationalLicenseID", "ApplicationID", "IssuedUsingLocalLicenseID", "IssueDate", "ExpirationDate", "IsActive");
                _SetInternationalLicensesColumnNames();
            }
          

        }


        public void LoadLicenses(int personID)
        {
            _RefreshLists(personID);

        }



        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tbMain.SelectedIndex==0)
            {
                lblRecord.Text = dgvLocalLicenseList.Rows.Count.ToString();
            }
            else
            {
                lblRecord.Text = dgvInternationalLicenseList.Rows.Count.ToString();

            }
        }
    }
}

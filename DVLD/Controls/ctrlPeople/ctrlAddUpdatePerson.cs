using DVLD_BusinessLayer;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Controls.ctrlPeople
{
    public partial class ctrlAddUpdatePerson : UserControl
    {

        public ctrlAddUpdatePerson()
        {
            InitializeComponent();
        }

        private void ctrlAddUpdatePerson_Load(object sender, EventArgs e)
        {

        }

        private void _FillCountriesToComboBox()
        {
            DataTable dt= Country.getCountryRecord();

            foreach(DataRow data in dt.Rows)
            {
                cbCountries.Items.Add(data["CountryName"]);
            }
        }

        private void _Load()
        {
            dtpBirthDate.Value = DateTime.Now.AddYears(-18);
            _FillCountriesToComboBox();


        }
    }
}

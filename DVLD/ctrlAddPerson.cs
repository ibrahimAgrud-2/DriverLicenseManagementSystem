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

namespace DVLD
{
    public partial class ctrlAddPerson : UserControl
    {
        public ctrlAddPerson()
        {
            InitializeComponent();
        }

        private void _FillCountriesToComboBox()
        {
            DataTable dt = Country.getCountryRecord();

            foreach (DataRow dr in dt.Rows)
            {
                cbCountries.Items.Add(dr["CountryName"]);
            }
        }

        private void _Load()
        {
            _FillCountriesToComboBox();
            cbCountries.SelectedIndex = 8;
        }
        private void ctrlAddPerson_Load(object sender, EventArgs e)
        {
            _Load();
        }

        private void mskFirstName_Leave(object sender, EventArgs e)
        {
            MaskedTextBox msTxt = (MaskedTextBox)sender;

            if (!msTxt.MaskCompleted)
            {
                errorProvider1.SetError(msTxt,"Input is not valid");
            }
    }   }
}

using DVLD_BusinessLayer;
using System;
using PeopleBL = DVLD_BusinessLayer.People;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlFindUser_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

       
       //Bazı durumlarda örneğin update'te filter aktif olmamalı. Onun için dışardan enable'ı değiştirebilmek için var. 
        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {

            }
        }

        private PeopleBL _findPerson()
        {

            PeopleBL person = new PeopleBL();
            switch (cbFilterBy.Text)
            {
                case "National No":
                    this.ctrlPersonInformation1.LoadPersonInfo(txtFilter.Text);
                    break;
                case "Person ID":
                    this.ctrlPersonInformation1.LoadPersonInfo(Convert.ToInt32(txtFilter.Text));
                    break;
            }
   
            return person;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _findPerson();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            //basılan tuş enter ise btnFind'a basılmış yap.
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            if (cbFilterBy.SelectedIndex == 0)
            {
                if (!int.TryParse(e.KeyChar.ToString(), out int test))
                {

                    if (e.KeyChar == '\b')
                        return;
                    e.Handled = true;

                }
            }
        }
            
        private void AddCompleted(object sender,int personID)
        {
            //Ekleme yapıldıktan sonra ID'i txtFilter'e ekle ve cbFilter'i ID yap. Daha iyi durur.
            cbFilterBy.SelectedIndex = 0;
            txtFilter.Text = personID.ToString();
            this.ctrlPersonInformation1.LoadPersonInfo(personID);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += AddCompleted;
            frm.ShowDialog();
        }

    }
}

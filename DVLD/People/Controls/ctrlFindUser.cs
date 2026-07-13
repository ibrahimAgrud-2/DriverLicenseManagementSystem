    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using  PeopleBL=  DVLD_BusinessLayer.People;
    using System.Windows.Forms;

    namespace DVLD.People.Controls
    {
        public partial class ctrlFindUser : UserControl
        {
            public ctrlFindUser()
            {
                InitializeComponent();
            }

            private void ctrlFindUser_Load(object sender, EventArgs e)
            {
                
            }
        //______________ ^^^ Event ^^^ ______________________
        public event Action<int> OnFilteringComplete;
        protected virtual void FilterCompleted(int result)
        {
            Action<int> test = OnFilteringComplete;
            if (test != null)
            {
                test(result);
            }

        }
        //______________ ^^^ Event ^^^ ______________________
     
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();
        }

        private int _findPerson()
        {
            int personID = -1;
           switch(cbFilterBy.Text)
            {
                case "National No":
                    personID = PeopleBL.findPersonByNationalNo(txtFilter.Text).personID;
                    break;
                case "Person ID":
                    personID = PeopleBL.findPersonByID(Convert.ToInt32(txtFilter.Text)).personID;
                    break;
            }
                    return personID;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int personID = _findPerson();
            if (personID!=-1)
            {
                OnFilteringComplete(personID);
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "PeopleBl ID")
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

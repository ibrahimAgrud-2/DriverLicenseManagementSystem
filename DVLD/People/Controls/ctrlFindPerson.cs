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
        public partial class ctrlFindPerson : UserControl
        {
            public ctrlFindPerson()
            {
                InitializeComponent();
            }

            private void ctrlFindUser_Load(object sender, EventArgs e)
            {
            cbFilterBy.SelectedIndex = 0;
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
        public event Action<int> OnAddComplete;
        protected virtual void AddCompleted(object sender, int result)
        {
            Action<int> test = OnAddComplete;
            if (test != null)
            {
                test(result);
            }

        }
        //______________ ^^^ Event ^^^ ______________________

   
     
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += AddCompleted;
            frm.ShowDialog();
        }

        private int _findPerson()
        {
      
            PeopleBL person = new PeopleBL();
           switch(cbFilterBy.Text)
            {
                case "National No":
                    person = PeopleBL.find(txtFilter.Text);
                    break;
                case "Person ID":
                    person = PeopleBL.find(Convert.ToInt32(txtFilter.Text));
                    break;
            }
            if(person!=null)
                  return person.personID;
            return -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int personID = _findPerson();
         
                OnFilteringComplete(personID);
            
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
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

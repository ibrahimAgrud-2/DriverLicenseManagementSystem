using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PeopleBL = DVLD_BusinessLayer.People;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        //search işlemi bittikten sonra eğer person varsa ID'sini buraya koysun. Person'un olup olmadığını bunla anlicaz
        private int _PeronID = -1;
        private void ctrlFindUser1_OnFilteringComplete(int obj)
        {
            _PeronID = obj;
            this.ctrlPersonInformation1.PersonID = obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
   
                tbMain.SelectedIndex = 1;
            
        }

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (User.findUserByUserID(_PeronID) != null)
            {
                MessageBox.Show("User Exist");
                tbMain.SelectedIndex = 0;
                return;
            }
            if(_PeronID==-1)
            {
          
                tbMain.SelectedIndex = 0;
      
            }


        }
    }
}

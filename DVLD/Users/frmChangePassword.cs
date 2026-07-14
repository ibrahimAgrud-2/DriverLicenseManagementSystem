using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {

        private int _UserID = -1;
        
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            User usr = User.findUserByUserID(_UserID);
            if(usr!=null)
                this.ctrlPersonInformation1.PersonID = usr.personID;


        }
    }
}

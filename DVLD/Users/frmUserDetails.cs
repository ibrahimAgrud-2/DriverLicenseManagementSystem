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
    public partial class frmUserDetails : Form
    {

        private int _UserID=-1;
       
        public frmUserDetails(int userID)
        {
            InitializeComponent();
            _UserID = userID;

        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            User usr = User.findUserByUserID(_UserID);
            if(usr!=null)
            {
                this.ctrlUserInfo1.LoadDataToUserControls(usr.userID,usr.personID);
            }
        }
    }
}

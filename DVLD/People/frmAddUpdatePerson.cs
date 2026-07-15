using DVLD_BusinessLayer;
using System;
using System.Globalization;
using System.Windows.Forms;
using PeopleBL = DVLD_BusinessLayer.People;

namespace DVLD
{
    public partial class frmAddUpdatePerson : Form
    {


        private RegionInfo _Region = RegionInfo.CurrentRegion;


        private PeopleBL _Person;
        private int _personID;
        enum enMode { enAddNew = 1, enUpdate = 2 };
        private enMode _Mode;

        public frmAddUpdatePerson()
        {
            InitializeComponent();


        }

        public frmAddUpdatePerson(int personID)
        {
           
            InitializeComponent();

           
        }


        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
    
        }

    }
}

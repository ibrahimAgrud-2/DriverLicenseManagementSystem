using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using clsApplications = DVLD_BusinessLayer.Applications;

namespace DVLD.Applications.Controls
{
    public partial class frmApplicationInfo : UserControl
    {
        public frmApplicationInfo()
        {
            InitializeComponent();
        }

        private int _ApplicationID = -1;
        private clsApplications _App=null;

        public int ApplicationID { get { return _ApplicationID; } }

        public clsApplications SelectedApp { get { return _App; } }

        private void fillObjectDataToField(clsApplications App)
        {

            lblAppDate.Text = App.ApplicationDate.ToString() ;
            lblFees.Text = App.PaidFees.ToString();
            lblAppLastStatusDate.Text = App.LastStatusDate.ToString();
            lblCreatedByUserID.Text = App.CreatedByUserID.ToString();
            lblApplicantPersonFullName.Text = App.ApplicantPerson.fullName;
            lblAppType.Text = App.ApplicationTypeInfo.applicantTypeTitle;
            lbID.Text = App.ID.ToString();
            lblAppStatus.Text = App.ApplicationStatus.ToString();

        }


        private void _Load()
        {
            _ApplicationID = _App.ID;
            fillObjectDataToField(_App);
            lnklblEditPersonInfo.Enabled = true;

        }
        public void LoadAppInfo(int AppID)
        {
            _App = clsApplications.Find(AppID);
            if (_App == null)
            {
                _ApplicationID = -1;
                ResetForm();
                MessageBox.Show("No Person with PersonID = " + AppID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Load();
        }
        public void ResetForm()
        {
            //Yükleme başarılı olup olmadığını ID ile biliyoruz. Bu yüzden yükleme başarısız olduğunda 
            //formu temizlerken ID'i de -1 yapıyoruz.
            _ApplicationID = -1;
            lblAppDate.Text = "????";
            lblFees.Text = "????";
            lblAppLastStatusDate.Text = "????";
            lblCreatedByUserID.Text = "????";
            lblApplicantPersonFullName.Text = "????";
            lblAppType.Text = "????";
            lbID.Text = "????";
            lblAppStatus.Text = "????";

        }

        private void lnklblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_App.ApplicantPersonID);
            frm.ShowDialog();
            LoadAppInfo(ApplicationID);
        }
    }
}

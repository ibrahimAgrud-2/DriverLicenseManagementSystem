using DVLD.Properties;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using clsApplications = DVLD_BusinessLayer.Applications;
using System.Windows.Forms;

namespace DVLD.Applications.Control
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private clsApplications _App;
        private int _AppID = -1;
        public int AppID { get { return _AppID; } }

        public clsApplications selecetedApp { get { return _App; } }


        private void fillObjectDataToField()
        {
            lblApplicationID.Text = _App.ID.ToString() ;
            lblCreatedByUser.Text = _App.CreatedByUserID.ToString();
            lblApplicant.Text = _App.ApplicantPerson.fullName;
            lblDate.Text=_App.ApplicationDate.ToString();
            lblFees.Text=_App.PaidFees.ToString();
             lblStatus.Text = _App.ApplicationStatus.ToString();
            lblType.Text = _App.ApplicationTypeInfo.applicantTypeTitle;
            lblStatusDate.Text = _App.LastStatusDate.ToString();
        }
        public void ResetForm()
        {
            //Yükleme başarılı olup olmadığını ID ile biliyoruz. Bu yüzden yükleme başarısız olduğunda 
            //formu temizlerken ID'i de -1 yapıyoruz.
            lblApplicationID.Text = "[????]";
            lblCreatedByUser.Text = "[????]";
            lblApplicant.Text = "[????]";
            lblDate.Text = "[????/??/??]";
            lblFees.Text = "[????]";
            lblStatus.Text = "[????/??/??]";
            lblType.Text = "[????]";
            lblStatusDate.Text = "[????]";
        }

        private void _Load()
        {
            _AppID = _App.ID;
            fillObjectDataToField();
            llViewPersonInfo.Enabled = true;

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_App.ApplicantPersonID);
            frm.ShowDialog();
            LoadAppInfo(_AppID);
        }
        public void LoadAppInfo(int AppID)
        {
            _App = clsApplications.FindApplication(AppID);
            if (_App == null)
            {
                _AppID = -1;
                ResetForm();
                MessageBox.Show("No Person with PersonID = " + AppID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Load();
        }
      
    }
}

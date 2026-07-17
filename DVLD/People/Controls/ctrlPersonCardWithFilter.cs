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


        public event Action<int> OnPersonLoaded;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonLoaded(int PersonID)
        {
            Action<int> handler = OnPersonLoaded;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
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
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }


        //Bazı durumlarda add butonunu göstermemek isteyebiliriz.
        private bool _ShowAddPersonButton = true;
        public bool ShowAddPersonButton
        {
            get
            {
                return _ShowAddPersonButton;
            }
            set
            {
                _ShowAddPersonButton = value;
                btnAddNewPerson.Visible = _ShowAddPersonButton;
            }
        }


        public int personID
        {
            get { return this.ctrlPersonInformation1.PersonID; }
        }
        public PeopleBL selectedPerson
        {
            get { return this.ctrlPersonInformation1.SelectedPerson; }
        }


        //bazı durumlarda textbox'ta girmek yerine kod'dan veriyti yüklemek için kullanabiliriz.
        public void LoadData(int personID)
        {
            txtFilter.Text = personID.ToString();
            cbFilterBy.SelectedIndex = 0;
            _findPerson();
        }


        private void _findPerson()
        {

         
            switch (cbFilterBy.Text)
            {
                case "National No":
                    this.ctrlPersonInformation1.LoadPersonInfo(txtFilter.Text);
                    break;
                case "Person ID":
                    this.ctrlPersonInformation1.LoadPersonInfo(Convert.ToInt32(txtFilter.Text));
                    break;
            }

            //OnPersonLoaded ile Bu evente abone olan biri var mı kontrol ediypruz. YOksa çöker. 2.kontrol ise eğer filtreleme kontrol edilmişmi onu kontrol ediyoruz. 3.Konrol de ise yükleme başarılımı onu kontrol ediyoruz
            if (OnPersonLoaded!=null&&FilterEnabled)
            {
                OnPersonLoaded(this.ctrlPersonInformation1.PersonID);
            }
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

                    e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);


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

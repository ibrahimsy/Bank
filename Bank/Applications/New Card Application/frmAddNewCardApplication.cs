using Bank.Accounts.Controls;
using Bank.Global_Classes;
using BankBussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Applications.New_Card_Application
{
    public partial class frmAddNewCardApplication : Form
    {
        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        int _AccountID = -1;
        int _NewCardApplicationID = -1;
        clsAccount _AccountInfo;
        clsNewCardApplication _NewCardApplicationInfo;
        public frmAddNewCardApplication()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }

        public frmAddNewCardApplication(int NewCardApplicationID)
        {
            InitializeComponent();
            _NewCardApplicationID = NewCardApplicationID;
            _Mode = enMode.enUpdate;
        }

        void _FillCardTypesComboBox()
        {
            DataTable dtCardTypes = clsCardType.GetCardTypesList();
            foreach (DataRow row in dtCardTypes.Rows)
            {
                cbCardTypes.Items.Add(row["CardName"]);
            }
            cbCardTypes.SelectedIndex = 0;
        }

        void _ResetDefaultData()
        {
            _FillCardTypesComboBox();
            if (_Mode == enMode.enAddNew)
            {
                _NewCardApplicationInfo = new clsNewCardApplication();

                lblApplicationDate.Text = clsFormat.GetDateFormat(DateTime.Now);
                lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
                lblApplicationFee.Text = clsApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.IssueNewCard).Fees.ToString();
                lblTitle.Text = "Add New Card Request";
                this.Text = lblTitle.Text;
                tpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                lblTitle.Text = "Update New Card Request";
                this.Text = lblTitle.Text;
                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            
        }
        
        void LoadInfo()
        {
            _NewCardApplicationInfo = clsNewCardApplication.FindNewCardApplicationByID(_NewCardApplicationID);
            if (_NewCardApplicationInfo == null) 
            {
                MessageBox.Show($"No Application Found With ID [{_NewCardApplicationID}]",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ctrlAccountCardWithFilter1.FilterEnabled = false;
            ctrlAccountCardWithFilter1.LoadInfoByAccountNumber(_NewCardApplicationInfo.AccountInfo.AccountNumber);

            lblApplicationID.Text = _NewCardApplicationInfo.ApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.GetDateFormat(_NewCardApplicationInfo.ApplicationDate);
            lblApplicationFee.Text = _NewCardApplicationInfo.PaidFees.ToString();
            lblCreatedBy.Text = _NewCardApplicationInfo.UserInfo.UserName;
            cbCardTypes.SelectedIndex = cbCardTypes.FindString(_NewCardApplicationInfo.CardTypeInfo.CardName);

        }
        
        private void frmAddNewCardApplication_Load(object sender, EventArgs e)
        {
           // ctrlClientCardWithFilter1.FilterByAccountNumber = false;
            if (_Mode == enMode.enAddNew)
            {
                _ResetDefaultData();
            }
            else
                LoadInfo();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlAccountCardWithFilter1.AccountID == -1)
            {
                MessageBox.Show("Select An Account First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedTab = tpApplicationInfo;
            tpApplicationInfo.Enabled = true;
            btnSave.Enabled = true;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            
            //Check If There Is An Active Application For Same Card Type
            
            _NewCardApplicationInfo.ApplicantAccountID = ctrlAccountCardWithFilter1.AccountID;
            _NewCardApplicationInfo.ApplicationDate = DateTime.Now;
            _NewCardApplicationInfo.Status = clsApplication.enApplicationStatus.New;
            _NewCardApplicationInfo.ApplicationTypeID = (int)clsApplication.enApplicationTypes.IssueNewCard;
            _NewCardApplicationInfo.CardTypeID = clsCardType.FindCardTypeByName(cbCardTypes.Text).CardTypeID;
            _NewCardApplicationInfo.PaidFees = Convert.ToDecimal(lblApplicationFee.Text);
            _NewCardApplicationInfo.CreatedBy = clsGlobalSettings.CurrentUser.UserID;

            if (_NewCardApplicationInfo.Save())
            {
                lblApplicationID.Text = _NewCardApplicationInfo.NewCardApplicationID.ToString();
                _Mode = enMode.enUpdate;

                lblTitle.Text = "Update New Card Request";
                this.Text = lblTitle.Text;
                MessageBox.Show("New Card Application Created Successfuly","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Error: Data Is Not Saved Successfuly", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

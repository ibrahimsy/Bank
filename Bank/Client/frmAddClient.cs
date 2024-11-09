using Bank.Global_Classes;
using Bank.Util;
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
using static BankBussiness.clsAccount;

namespace Bank.Client
{
    public partial class frmAddClient : Form
    {
        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        int _ClientID = -1;
        clsClient _ClientInfo;
        clsAccount _PrimaryAccountInfo;
        public frmAddClient()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }
        public frmAddClient(int ClientID)
        {
            InitializeComponent();
            _Mode = enMode.enUpdate;
            _ClientID = ClientID;
        }

        void _FillBranchesComboBox()
        {
            DataTable dtBranches = clsBranch.GetBranchsList();
            foreach (DataRow row in dtBranches.Rows)
            {
                cbBranches.Items.Add(row["BranchName"]);
            }
            cbBranches.SelectedIndex = 0;   
        }
        void _FillAccountTypesComboBox()
        {
            DataTable dtAccountTypes = clsAccountType.GetAccountTypesList();
            foreach (DataRow row in dtAccountTypes.Rows)
            {
                cbAccountType.Items.Add(row["AccountTypeName"]);
            }
            cbAccountType.SelectedIndex = 0;
        }
        void _FillAccountStatusComboBox()
        {
            //Active = 1,InActive = 2,Closed = 3,Pending = 4,Frozen = 5,Blocked = 6
            cbAccountStatus.Items.Add(clsAccount.enAccountStatus.Active);
            cbAccountStatus.Items.Add(clsAccount.enAccountStatus.InActive);
            cbAccountStatus.Items.Add(clsAccount.enAccountStatus.Closed);
            cbAccountStatus.Items.Add(clsAccount.enAccountStatus.Pending);
            cbAccountStatus.Items.Add(clsAccount.enAccountStatus.Frozen);
            cbAccountStatus.Items.Add(clsAccount.enAccountStatus.Blocked);

            cbAccountStatus.SelectedIndex = 0;
        }

        //public frmAddClient(int ClientID)
        //{
        //    InitializeComponent();
        //    _ClientID = ClientID;
        //    _Mode = enMode.enUpdate;
        //}

        void _ResetDefaultValue()
        {
            if (_Mode == enMode.enAddNew)
            {
                _ClientInfo = new clsClient();
                this.Text = "Add Client";
                lblTitle.Text = this.Text;

                tpPrimaryAccount.Enabled = false;
                btnSave.Enabled = false;
                ctrlPersonInfoWithFilter1.TextValueFocus();
            }
            else
            {
                this.Text = "Update Client";
                lblTitle.Text = this.Text;

                tpPrimaryAccount.Enabled = true;
                btnSave.Enabled = Enabled;
            }
            _FillBranchesComboBox();
            _FillAccountTypesComboBox();
            _FillAccountStatusComboBox();

        }

        void _LoadClientInfo()
        {
            _ClientInfo = clsClient.FindClientByID(_ClientID);
            if (_ClientInfo == null)
            {
                MessageBox.Show($"Client Not Found With ID = [{_ClientID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlPersonInfoWithFilter1.FilterEnabled = false;
            ctrlPersonInfoWithFilter1.LoadPersonInfo(_ClientInfo.PersonID);
            chkIsActive.Checked = _ClientInfo.AccountStatus;
            txtClientNotes.Text = _ClientInfo.Notes;

            tabControl1.TabPages.Remove(tpPrimaryAccount);    
            btnNext.Visible = false;
            btnSave.Enabled = true;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonInfoWithFilter1.PersonID != -1)
            {
                if (clsClient.IsExistByPersonID(ctrlPersonInfoWithFilter1.PersonID) && _Mode == enMode.enAddNew)
                {
                    MessageBox.Show("Selected Person Allready Is Client In System,\nchoose another person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tabControl1.SelectedTab = tpPrimaryAccount;
                    tpPrimaryAccount.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Choose A Person First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmAddEditClient_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.TextValueFocus();
        }

        private bool _HandlePrimaryAccount()
        {
            _PrimaryAccountInfo = new clsAccount();

            _PrimaryAccountInfo.ClientID = _ClientInfo.ClientID;
            _PrimaryAccountInfo.AccountNumber = clsUtility.GenerateAccountNumber(8);
            _PrimaryAccountInfo.IsPrimary = true;
            _PrimaryAccountInfo.AccountTypeID = clsAccountType.FindAccountTypeByName(cbAccountType.Text).AccountTypeID;
            _PrimaryAccountInfo.Balance = Convert.ToDecimal(txtBalance.Text);
            _PrimaryAccountInfo.AccountStatus = (byte)((clsAccount.enAccountStatus)cbAccountStatus.SelectedItem);
            _PrimaryAccountInfo.DateOpened = DateTime.Now;
            _PrimaryAccountInfo.BranchID = _ClientInfo.BranchID;
            _PrimaryAccountInfo.Notes = txtNotes.Text;
            _PrimaryAccountInfo.CreatedBy = _ClientInfo.CreatedBy;

            if (!_PrimaryAccountInfo.Save())
            {
                MessageBox.Show($"An Error Occurred During Create the Account",
                  "Faild",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Error);

                clsClient.DeleteClient(_ClientInfo.ClientID);

                return false;
            }
            return true;
        }
       
        private bool _HandleClient()
        {
            _ClientInfo.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            _ClientInfo.AccountStatus = chkIsActive.Checked;
            _ClientInfo.BranchID = clsBranch.FindBranchByBranchName(cbBranches.Text).BranchID;
            _ClientInfo.CreatedBy = clsGlobalSettings.CurrentUser.UserID;
            _ClientInfo.CreatedDate = DateTime.Now;
            _ClientInfo.Notes = txtClientNotes.Text;

            if (!_ClientInfo.Save())
            {
                MessageBox.Show($"An Error Occoured During Create The Client.",
                 "Error",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enUpdate)
            {
                _ClientInfo.Notes = txtClientNotes.Text.Trim();
                _ClientInfo.AccountStatus = chkIsActive.Checked;

                if (_ClientInfo.Save())
                {
                    MessageBox.Show($"Client Updated Successfuly",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"An Error Occurred.Client Haven't Updated",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                return;
            }

            // Here In AddNew Mode Client We Need To Create Primary Account For First Time
            if (!this.ValidateChildren())
            {
                MessageBox.Show($"Some Feild Are Invalid,Put Mouse On Red Icon",
                    "Faild",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!_HandleClient())
                return;

            if (!_HandlePrimaryAccount())
                return;

              MessageBox.Show($"Client Created Successfully",
              "Success",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);

                lblClientID.Text = _ClientInfo.ClientID.ToString();
                lblAccountID.Text = _PrimaryAccountInfo.AccountID.ToString();
                lblAccountNumber.Text = _PrimaryAccountInfo.AccountNumber;

                _Mode = enMode.enUpdate;
                lblTitle.Text = "UPDATE Client";
                this.Text = lblTitle.Text;
                ctrlPersonInfoWithFilter1.FilterEnabled = false;
        }
       
        private void frmAddEditClient_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.enUpdate)
            {
                _LoadClientInfo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtBalance_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBalance.Text.Trim()))
            {
                errorProvider1.SetError(txtBalance,"This Field Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBalance, null);
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

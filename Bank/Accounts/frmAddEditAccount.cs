using Bank.Global_Classes;
using Bank.People.Controls;
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

namespace Bank.Accounts
{
    public partial class frmAddEditAccount : Form
    {
        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        int _AccountID = -1;
        clsAccount _AccountInfo;
        public frmAddEditAccount()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }
        public frmAddEditAccount(int AccountID)
        {
            InitializeComponent();
            _AccountID = AccountID;
            _Mode = enMode.enUpdate;
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
        void _ResetDefaultValue()
        {
            if (_Mode == enMode.enAddNew)
            {
                _AccountInfo = new clsAccount();
                this.Text =  "Add Acount".ToUpper();
                lblTitle.Text = this.Text;

                tpAccountInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrlClientCardWithFilter1.TextValueFocus();
            }
            else
            {
                this.Text = "Update Account".ToUpper();
                lblTitle.Text = this.Text;

                tpAccountInfo.Enabled = true;
                btnSave.Enabled = Enabled;
            }

            _FillBranchesComboBox();
            _FillAccountTypesComboBox();
            _FillAccountStatusComboBox();

        }

        void _LoadData()
        {
            _AccountInfo = clsAccount.FindAccountByID(_AccountID);
            if (_AccountInfo == null)
            {
                MessageBox.Show("Account is not found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lblAccountID.Text = _AccountInfo.AccountID.ToString();
            lblAccountNumber.Text = _AccountInfo.AccountNumber.ToString();
            cbAccountType.SelectedIndex = cbAccountType.FindString(_AccountInfo.AccountTypeInfo.AccountTypeName);
            cbAccountStatus.SelectedIndex = cbAccountStatus.FindString(((clsAccount.enAccountStatus)_AccountInfo.AccountStatus).ToString());
            cbBranches.SelectedIndex = cbBranches.FindString(_AccountInfo.BranchInfo.BranchName);
            txtBalance.Text = _AccountInfo.Balance.ToString();
            txtNotes.Text = _AccountInfo.Notes.ToString();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(ctrlClientCardWithFilter1.ClientID == -1)
            {
                MessageBox.Show("Select A Client First","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedTab = tpAccountInfo;
            tpAccountInfo.Enabled = true;
            btnSave.Enabled = true;    
        }

        private void frmAddEditAccount_Activated(object sender, EventArgs e)
        {
            ctrlClientCardWithFilter1.TextValueFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool _RequestCardUponCreateAccount()
        {
            clsNewCardApplication _NewCardApplicationInfo = new clsNewCardApplication();
            _NewCardApplicationInfo.ApplicantAccountID = _AccountInfo.AccountID;
            _NewCardApplicationInfo.ApplicationDate = DateTime.Now;
            _NewCardApplicationInfo.Status = clsApplication.enApplicationStatus.Pending;
            _NewCardApplicationInfo.ApplicationTypeID = (int)clsApplication.enApplicationTypes.IssueNewCard;
            _NewCardApplicationInfo.CardTypeID = (int)clsCardType.enCardType.DebitCard;
            _NewCardApplicationInfo.PaidFees = clsApplicationType.FindApplicationTypeByID(_NewCardApplicationInfo.ApplicationTypeID).Fees;
            _NewCardApplicationInfo.CreatedBy = clsGlobalSettings.CurrentUser.UserID;

            return (_NewCardApplicationInfo.Save());
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show($"Some Feild Are Invalid,Put Mouse On Red Icon",
                    "Faild",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _AccountInfo.ClientID = ctrlClientCardWithFilter1.ClientID;
            _AccountInfo.AccountTypeID = clsAccountType.FindAccountTypeByName(cbAccountType.Text).AccountTypeID;
            _AccountInfo.Balance = Convert.ToDecimal(txtBalance.Text);
            _AccountInfo.AccountStatus = (byte)((clsAccount.enAccountStatus)cbAccountStatus.SelectedItem);
            _AccountInfo.DateOpened = DateTime.Now;
            _AccountInfo.BranchID = clsBranch.FindBranchByBranchName(cbBranches.Text).BranchID;
            _AccountInfo.Notes = txtNotes.Text;
            _AccountInfo.CreatedBy = clsGlobalSettings.CurrentUser.UserID;

            if (_AccountInfo.Save())
            {
                MessageBox.Show($"Account Saved Successfuly",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                lblTitle.Text = "Edit Account";
                this.Text = lblTitle.Text;
                _Mode = enMode.enUpdate;

                lblAccountID.Text = _AccountInfo.AccountID.ToString();
                lblAccountNumber.Text = _AccountInfo.AccountNumber.ToString();  
                ctrlClientCardWithFilter1.FilterEnabled = false;

                if(chkRequestForCard.Checked)
                {
                    if (_RequestCardUponCreateAccount())
                        MessageBox.Show("Requested For Card Was Created","Card Request",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Requested For Card Was Failde,Contact Your Admin", "Card Request Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"An Error Occurred.",
                    "Faild",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void frmAddEditAccount_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.enUpdate)
            {
                _LoadData();
            }
        }

        private void txtBalance_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBalance.Text.Trim()))
            {
                errorProvider1.SetError(txtBalance, "This Field Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBalance, null);
            }
            double Balance = Convert.ToDouble(txtBalance.Text.Trim());
            if (clsAccountType.FindAccountTypeByName(cbAccountType.Text).MinimumBalance > Balance)
            {
                errorProvider1.SetError(txtBalance, "Insufficient Balance,\n Balance Is Less Than Minimum Amount To Open This Account");
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

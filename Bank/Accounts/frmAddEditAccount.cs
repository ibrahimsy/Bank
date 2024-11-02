using Bank.People.Controls;
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(ctrlClientCardWithFilter1.ClientID == -1)
            {
                MessageBox.Show("Select A Client First","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedTab = tpAccountInfo;


        }

        private void frmAddEditAccount_Activated(object sender, EventArgs e)
        {
            ctrlClientCardWithFilter1.TextValueFocus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}

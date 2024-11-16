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

namespace Bank.Accounts.Controls
{
    public partial class ctrlAccountCard : UserControl
    {
        int _AccountID = -1;
        string _AccountNumber = "";
        clsAccount _AccountInfo;
        
        public int AccountID
        {
            get
            {
                return _AccountID;
            }
        }
        
        public string AccountNumber
        {
            get
            {
                return _AccountNumber;
            }
        }
        
        public ctrlAccountCard()
        {
            InitializeComponent();
        }

        public void LoadAccountInfo(int AccountID)
        {
            _AccountID = AccountID;
            _AccountInfo = clsAccount.FindAccountByID(_AccountID);

            if (_AccountInfo == null)
            {
                MessageBox.Show($"There Is No Account Exist With ID[{_AccountID}]",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            lblAccountID.Text = _AccountID.ToString();
            lblAccountHolder.Text = _AccountInfo.ClientInfo.PersonInfo.FullName;
            lblAccountNumber.Text = _AccountInfo.AccountNumber;
            lblIsPrimary.Text = _AccountInfo.IsPrimary ? "Yes" : "No";
            lblBranchName.Text = _AccountInfo.BranchInfo.BranchName;
            lblBalance.Text = _AccountInfo.Balance.ToString();
            lblAccountStatus.Text = ((clsAccount.enAccountStatus)_AccountInfo.AccountStatus).ToString();
            lblAccountType.Text = _AccountInfo.AccountTypeInfo.AccountTypeName;
            lblDateOpened.Text = clsFormat.GetDateFormat(_AccountInfo.DateOpened);
            lblDateClosed.Text = (_AccountInfo.DateClosed == DateTime.MaxValue)?"":clsFormat.GetDateFormat(_AccountInfo.DateClosed);
            lblAccountNotes.Text = _AccountInfo.Notes;
        }

        public void LoadAccountInfo(string AccountNumber)
        {
            _AccountNumber = AccountNumber;
            _AccountInfo = clsAccount.FindAccountByAccountNumber(AccountNumber);

            if (_AccountInfo == null)
            {
                MessageBox.Show($"There Is No Account Exist With ID[{_AccountID}]",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            _AccountID = _AccountInfo.AccountID;
            lblAccountID.Text = _AccountID.ToString();
            lblAccountHolder.Text = _AccountInfo.ClientInfo.PersonInfo.FullName;
            lblAccountNumber.Text = _AccountInfo.AccountNumber;
            lblIsPrimary.Text = _AccountInfo.IsPrimary ? "Yes" : "No";
            lblBranchName.Text = _AccountInfo.BranchInfo.BranchName;
            lblBalance.Text = _AccountInfo.Balance.ToString();
            lblAccountStatus.Text = ((clsAccount.enAccountStatus)_AccountInfo.AccountStatus).ToString();
            lblAccountType.Text = _AccountInfo.AccountTypeInfo.AccountTypeName;
            lblDateOpened.Text = _AccountInfo.DateOpened.ToString();
            lblDateClosed.Text = (_AccountInfo.DateClosed == DateTime.MaxValue) ? "" : clsFormat.GetDateFormat(_AccountInfo.DateClosed);
            lblAccountNotes.Text = _AccountInfo.Notes.ToString();
        }

    }
}

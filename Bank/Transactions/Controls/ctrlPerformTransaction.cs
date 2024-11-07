using Bank.Properties;
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
using static BankBussiness.clsTransaction;

namespace Bank.Transactions.Controls
{
    public partial class ctrlPerformTransaction : UserControl
    {

        clsAccount _AccountInfo;

        private clsTransaction.enTransactionType _enTransactionType = clsTransaction.enTransactionType.Deposit;
        
        public clsTransaction.enTransactionType TransactionType
        {
            get
            {
                return _enTransactionType;
            }
            set
            {
                _enTransactionType = value;
                switch (_enTransactionType)
                {
                    case clsTransaction.enTransactionType.Deposit:
                        gbTransactionTitle.Text = "Deposit";
                        pbTransactionImage.Image = Resources.deposit;
                        lblTransactionTitle.Text = gbTransactionTitle.Text;
                        lblTransType.Text = gbTransactionTitle.Text;
                        break;
                    case clsTransaction.enTransactionType.Withdraw:
                        gbTransactionTitle.Text = "Withdraw";
                        pbTransactionImage.Image = Resources.cash_withdrawal;
                        lblTransactionTitle.Text = gbTransactionTitle.Text;
                        lblTransType.Text = gbTransactionTitle.Text;
                        break;
                }
            }
        }

        public string AccountNumber
        {
            get
            {
                return cbMyAccounts.Text.Trim();
            }
        }
        public clsAccount AccountInfo
        {
            get
            {
                return _AccountInfo;
            }
        }
       
        public Decimal Amount
        {
            get
            {
                return Convert.ToDecimal(txtAmount.Text.Trim());
            }
        }     
        public string Description
        {
            get
            {
                return txtDescription.Text;
            }
        }
        public ctrlPerformTransaction()
        {
            InitializeComponent();
        }

        void _FillAccountsNumberInComboBox(int ClientID)
        {
            DataTable dtAccounts = clsAccount.GetAccountsListByClientID(ClientID);
            foreach (DataRow row in dtAccounts.Rows)
            {
                cbMyAccounts.Items.Add(row["AccountNumber"]);
            }
            cbMyAccounts.SelectedIndex = 0;
        }

        public void LoadInfo(int ClientID)
        {
            _FillAccountsNumberInComboBox(ClientID);
            txtAmount.Focus();
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
            {
                errorProvider1.SetError(txtAmount, "Required Field");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtAmount, null);
            }

            _AccountInfo = clsAccount.FindAccountByAccountNumber(cbMyAccounts.Text.Trim());
            if (_AccountInfo == null)
            {
                errorProvider1.SetError(txtAmount,"An Error With This Account,Choose Another Account.");
                e.Cancel= true;
            }
            else
            {
                errorProvider1.SetError(txtAmount,null);
            }

            if(_enTransactionType == enTransactionType.Withdraw && (Convert.ToDecimal(txtAmount.Text.Trim()) > _AccountInfo.Balance))
            {
                errorProvider1.SetError(txtAmount, "Insufficient Amount In Account.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtAmount, null);
            }

        }
    }
}

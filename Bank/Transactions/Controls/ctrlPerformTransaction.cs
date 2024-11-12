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
                return txtAccountNumber.Text.Trim();
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

        public void LoadInfo(string AccountNumber)
        {
            txtAccountNumber.Text = AccountNumber;
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
        }
    }
}

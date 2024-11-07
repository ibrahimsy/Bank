using Bank.Global_Classes;
using Bank.Transactions.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bank.Transactions
{
    public partial class frmTransaction : Form
    {
        private clsTransaction.enTransactionType _enTransactionType = clsTransaction.enTransactionType.Deposit;
        int _ClientID = -1;
        clsAccount _AccountInfo;
        public frmTransaction(int clientID, clsTransaction.enTransactionType type)
        {
            InitializeComponent();
            _ClientID = clientID;
            _enTransactionType = type;
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            ctrlPerformTransaction1.TransactionType = _enTransactionType;
            ctrlPerformTransaction1.LoadInfo(_ClientID);
        }
        bool _HandleTransactionProcess()
        {
            _AccountInfo = clsAccount.FindAccountByAccountNumber(ctrlPerformTransaction1.AccountNumber);
            if (_AccountInfo == null)
            {
                MessageBox.Show("An Error With This Account,Choose Another Account.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
           
            if (_enTransactionType == enTransactionType.Withdraw && (Convert.ToDecimal(ctrlPerformTransaction1.Amount) > _AccountInfo.Balance))
            {
                MessageBox.Show("Insufficient Balance In Your Account.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (_enTransactionType == clsTransaction.enTransactionType.Deposit)
            {
                if (!_AccountInfo.Deposit(ctrlPerformTransaction1.Amount))
                {
                    MessageBox.Show("Transaction(Deposit) Faild,An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (!_AccountInfo.Withdraw(ctrlPerformTransaction1.Amount))
            {
                MessageBox.Show("Transaction(Withdraw) Faild,An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ctrlPerformTransaction1.ValidateChildren())
            {
                return;
            }

            if (!_HandleTransactionProcess())
            {
                return;
            }

            clsTransaction TransactionInfo = new clsTransaction();

            TransactionInfo.AccountID = _AccountInfo.AccountID;
            TransactionInfo.TransactionDate = DateTime.Now;
            TransactionInfo.TransactionType = (byte)_enTransactionType;
            TransactionInfo.Amount = ctrlPerformTransaction1.Amount;
            TransactionInfo.BalanceAfterTransaction = _AccountInfo.Balance;
            TransactionInfo.CurrencyID = 1;
            TransactionInfo.Description = ctrlPerformTransaction1.Description;
            TransactionInfo.Status = (byte)clsTransaction.enTransactionStatus.Completed;
            TransactionInfo.CreatedBy = clsGlobalSettings.CurrentUser.UserID;
            TransactionInfo.CreatedDate = DateTime.Now;

            if (TransactionInfo.Save())
            {
                MessageBox.Show($"Transaction Successfull,Balance Is {TransactionInfo.BalanceAfterTransaction}",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Transaction Faild,An Error Occurred",
                                "Faild",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

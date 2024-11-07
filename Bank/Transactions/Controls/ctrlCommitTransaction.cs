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

namespace Bank.Transactions.Controls
{
    public partial class ctrlCommitTransaction : UserControl
    {
        int _ClientID = -1;
        
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
        public ctrlCommitTransaction()
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
            _ClientID = ClientID;
            _FillAccountsNumberInComboBox(ClientID);

        }
    }
}

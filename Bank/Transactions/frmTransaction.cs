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

namespace Bank.Transactions
{
    public partial class frmTransaction : Form
    {
        private clsTransaction.enTransactionType _enTransactionType = clsTransaction.enTransactionType.Deposit;
        int _ClientID = -1;
        public frmTransaction(int clientID, clsTransaction.enTransactionType type)
        {
            InitializeComponent();
            _ClientID = clientID;
            _enTransactionType = type;
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {

        }
    }
}

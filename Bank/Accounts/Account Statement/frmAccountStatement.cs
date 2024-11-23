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

namespace Bank.Accounts.Account_Statement
{
    public partial class frmAccountStatement : Form
    {
        DataTable _dtAccountStatment; 
        public frmAccountStatement()
        {
            InitializeComponent();
        }
        
        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            _dtAccountStatment = clsTransaction.GetAccountStatment(txtAccountNumber.Text.Trim(),dtpFromDate.Value,dtpToDate.Value);
            dgvAccountStatments.DataSource = _dtAccountStatment;
            lblRecordsCount.Text = _dtAccountStatment.Rows.Count.ToString();

            if (_dtAccountStatment.Rows.Count > 0)
            {
                dgvAccountStatments.Columns[0].HeaderText = "Transaction ID";
                //dgvTransactions.Columns[0].Width = 100;

                dgvAccountStatments.Columns[1].HeaderText = "Account Number";
                //dgvTransactions.Columns[1].Width = 110;

                dgvAccountStatments.Columns[2].HeaderText = "Transaction Date";
                //dgvTransactions.Columns[2].Width = 300;

                dgvAccountStatments.Columns[3].HeaderText = "Transaction Type";
                //dgvTransactions.Columns[3].Width = 150;

                dgvAccountStatments.Columns[4].HeaderText = "Amount";
                //dgvTransactions.Columns[4].Width = 180;

                dgvAccountStatments.Columns[5].HeaderText = "Balance After Transaction";
                //dgvTransactions.Columns[5].Width = 100;

                dgvAccountStatments.Columns[6].HeaderText = "Currency Code";
                //dgvTransactions.Columns[6].Width = 100;

                dgvAccountStatments.Columns[7].HeaderText = "Description";
                //dgvTransactions.Columns[7].Width = 100;

                dgvAccountStatments.Columns[8].HeaderText = "Status";
                //dgvTransactions.Columns[8].Width = 100;

                dgvAccountStatments.Columns[9].HeaderText = "Reference Number";
                //dgvTransactions.Columns[9].Width = 100;

                dgvAccountStatments.Columns[10].HeaderText = "Source Account";
                //dgvTransactions.Columns[10].Width = 100;

                dgvAccountStatments.Columns[11].HeaderText = "Recipient Account";
                //dgvTransactions.Columns[11].Width = 100;
            }

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                dtpToDate.Value = dtpFromDate.Value;
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                dtpToDate.Value = dtpFromDate.Value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using Bank.Transactions;
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
    public partial class frmManageAccounts : Form
    {
        DataTable _dtAccountsList;
        public frmManageAccounts()
        {
            InitializeComponent();
        }
        void _RefreshAccountsList()
        {
            _dtAccountsList = clsAccount.GetAccountsList();
            dgvAccounts.DataSource = _dtAccountsList;
            lblRecordsCount.Text = _dtAccountsList.Rows.Count.ToString();

            if (dgvAccounts.Rows.Count > 0)
            {
                dgvAccounts.Columns[0].HeaderText = "Account ID";
                dgvAccounts.Columns[0].Width = 90;

                dgvAccounts.Columns[1].HeaderText = "Client ID";
                dgvAccounts.Columns[1].Width = 90;

                dgvAccounts.Columns[2].HeaderText = "Account Number";
                dgvAccounts.Columns[2].Width = 100;

                dgvAccounts.Columns[3].HeaderText = "Is Primary";
                dgvAccounts.Columns[3].Width = 80;

                dgvAccounts.Columns[4].HeaderText = "Type";
                dgvAccounts.Columns[4].Width = 80;

                dgvAccounts.Columns[5].HeaderText = "Balance";
                dgvAccounts.Columns[5].Width = 100;

                dgvAccounts.Columns[6].HeaderText = "Status";
                dgvAccounts.Columns[6].Width = 80;

                dgvAccounts.Columns[7].HeaderText = "Date Opened";
                dgvAccounts.Columns[7].Width = 100;

                dgvAccounts.Columns[8].HeaderText = "Date Closed";
                dgvAccounts.Columns[8].Width = 100;

                dgvAccounts.Columns[9].HeaderText = "Branch";
                dgvAccounts.Columns[9].Width = 100;

                dgvAccounts.Columns[10].HeaderText = "Last Transaction Date";
                dgvAccounts.Columns[10].Width = 100;

                dgvAccounts.Columns[11].HeaderText = "Notes";
                dgvAccounts.Columns[11].Width = 100;
            }


            
        }

        private void frmManageAccounts_Load(object sender, EventArgs e)
        {
            _RefreshAccountsList();
            cbFilterBy.SelectedIndex = 0;
        }
        string _ColumnText(string ColumnName)
        {
            /*
             None
            Account ID
            Client ID
            Account Number
            Account Type
            Account Status
            Date Opened
            Date Closed
            Branch Name
             */
            switch (ColumnName)
            {
                case "Account ID":
                    return "AccountID";
                case "Client ID":
                    return "ClientID";
                case "Account Number":
                    return "AccountNumber";
                case "Account Type":
                    return "AccountType";
                case "Account Status":
                    return "AccountStatus";
                case "Branch Name":
                    return "BranchName";
                default:
                    return "";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                _dtAccountsList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAccountsList.Rows.Count.ToString();

                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text == "")
            {
                _dtAccountsList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtAccountsList.Rows.Count.ToString();
                return;
            }
            string FilterColumn = _ColumnText(cbFilterBy.Text);

            string FilterValue = txtFilterValue.Text;



            if (FilterColumn == "AccountID" || FilterColumn == "ClientID" )
            {
                _dtAccountsList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                _dtAccountsList.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, FilterValue);
            }
            lblRecordsCount.Text = _dtAccountsList.DefaultView.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "AccountID" || cbFilterBy.Text == "ClientID")
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void showAccountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowAccountInfo frm = new frmShowAccountInfo((int)dgvAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            frmAddEditAccount frm = new frmAddEditAccount();
            frm.ShowDialog();

            _RefreshAccountsList();
        }
        private void _StartTransaction(clsTransaction.enTransactionType Type)
        {
            string AccountNumber = (string)dgvAccounts.CurrentRow.Cells[2].Value;
            frmTransaction frm = new frmTransaction(AccountNumber, Type);
            frm.ShowDialog();
        }
        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _StartTransaction(clsTransaction.enTransactionType.Deposit);
            _RefreshAccountsList();
        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _StartTransaction(clsTransaction.enTransactionType.Withdraw);
            _RefreshAccountsList();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransfer frm = new frmTransfer((int)dgvAccounts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshAccountsList();
        }
    }
}

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
    public partial class frmTransactionsList : Form
    {
        public frmTransactionsList()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        DataTable _dtTransactionList;     
        void _RefreshTransactionsList()
        {
            _dtTransactionList = clsTransaction.GetTransactionsList();
            dgvTransactions.DataSource = _dtTransactionList;

            if (dgvTransactions.Rows.Count > 0)
            {

                dgvTransactions.Columns[0].HeaderText = "Transaction ID";
                dgvTransactions.Columns[0].Width = 100;

                dgvTransactions.Columns[1].HeaderText = "Account Number";
                dgvTransactions.Columns[1].Width = 110;

                dgvTransactions.Columns[2].HeaderText = "Transaction Date";
                dgvTransactions.Columns[2].Width = 300;

                dgvTransactions.Columns[3].HeaderText = "Transaction Type";
                dgvTransactions.Columns[3].Width = 150;

                dgvTransactions.Columns[4].HeaderText = "Amount";
                dgvTransactions.Columns[4].Width = 180;

                dgvTransactions.Columns[5].HeaderText = "Balance After Transaction";
                dgvTransactions.Columns[5].Width = 100;

                dgvTransactions.Columns[6].HeaderText = "Currency Code";
                dgvTransactions.Columns[6].Width = 100;

                dgvTransactions.Columns[7].HeaderText = "Description";
                dgvTransactions.Columns[7].Width = 100;

                dgvTransactions.Columns[8].HeaderText = "Status";
                dgvTransactions.Columns[8].Width = 100;

                dgvTransactions.Columns[9].HeaderText = "Reference Number";
                dgvTransactions.Columns[9].Width = 100;

                dgvTransactions.Columns[10].HeaderText = "Source Account";
                dgvTransactions.Columns[10].Width = 100;

                dgvTransactions.Columns[11].HeaderText = "Recipient Account";
                dgvTransactions.Columns[11].Width = 100;


            }


            lblRecordsCount.Text = _dtTransactionList.Rows.Count.ToString();
        }

        string _ColumnText(string ColumnName)
        {
            switch (ColumnName)
            {
                case "Transaction ID":
                    return "TransactionID";
                case "Account ID":
                    return "AccountID";
                case "Account Number":
                    return "AccountNumber";
                case "Transaction Type":
                    return "TransactionType";
                case "Status":
                    return "Status";
                case "Destination Account":
                    return "DestinationAccount";
                default:
                    return "";
            }
        }

        private void deleteTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TransactionID = (int)dgvTransactions.CurrentRow.Cells[0].Value;

            DialogResult result = MessageBox.Show($"Are You Sure You Want To Delete Transaction With ID[{TransactionID}]",
                                                   "Confirm",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (clsTransaction.DeleteTransaction(TransactionID))
                {
                    MessageBox.Show($"Transaction Deleted Successfuly",
                                                   "Success",
                                                   MessageBoxButtons.OK,
                                                   MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"An Error Occurred",
                                                   "Faild",
                                                   MessageBoxButtons.OK,
                                                   MessageBoxIcon.Error);
                }
            }
            _RefreshTransactionsList();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Account ID" || cbFilterBy.Text == "TransactionID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void txtFilterValue_TextChanged_1(object sender, EventArgs e)
        {
            if (txtFilterValue.Text == "")
            {
                _dtTransactionList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtTransactionList.Rows.Count.ToString();
                return;
            }
            string FilterColumn = _ColumnText(cbFilterBy.Text);

            string FilterValue = txtFilterValue.Text;

            if (FilterColumn == "TransactionID" || FilterColumn == "AccountID")
            {
                _dtTransactionList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                _dtTransactionList.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = _dtTransactionList.DefaultView.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                _dtTransactionList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtTransactionList.Rows.Count.ToString();

                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
            }
        }

        private void frmTransactionsList_Load(object sender, EventArgs e)
        {
            _RefreshTransactionsList();
            cbFilterBy.SelectedIndex = 0;
        }
    }
}

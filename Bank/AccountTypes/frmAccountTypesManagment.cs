using Bank.AccountTypes;
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

namespace Bank.AccountTypes
{
    public partial class frmAccountTypesManagment : Form
    {
        DataTable _dtAccountTypes;
        public frmAccountTypesManagment()
        {
            InitializeComponent();
        }
        /*
         int    AccountTypeID
         string AccountTypeName
         float  InterestRate
         double WithdrawalLimit
         double MinimumBalance
         string Description
         */
        void _RefreshAccountTypesList()
        {
            _dtAccountTypes = clsAccountType.GetAccountTypesList();
            dgvAccountTypes.DataSource = _dtAccountTypes;
            lblRecordsCount.Text = _dtAccountTypes.Rows.Count.ToString();

            if (dgvAccountTypes.Rows.Count > 0)
            {
                dgvAccountTypes.Columns[0].HeaderText = "Account Type ID";
                dgvAccountTypes.Columns[0].Width = 100;

                dgvAccountTypes.Columns[1].HeaderText = "Account Type Name";
                dgvAccountTypes.Columns[1].Width = 150;

                dgvAccountTypes.Columns[2].HeaderText = "Interest Rate";
                dgvAccountTypes.Columns[2].Width = 200;

                dgvAccountTypes.Columns[3].HeaderText = "Withdrawal Limit";
                dgvAccountTypes.Columns[3].Width = 150;

                dgvAccountTypes.Columns[4].HeaderText = "Minimum Balance";
                dgvAccountTypes.Columns[4].Width = 180;

                dgvAccountTypes.Columns[5].HeaderText = "Description";
                dgvAccountTypes.Columns[5].Width = 150;
            }

        }

        private void frmAccountTypesManagment_Load(object sender, EventArgs e)
        {
            _RefreshAccountTypesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editAccountTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditAccountType frm = new frmEditAccountType((int)dgvAccountTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshAccountTypesList();
        }
    }
}

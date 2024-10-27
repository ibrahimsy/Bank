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
    public partial class frmWithDrawDeposit : Form
    {
        int _ClientID;
        clsClient _ClientInfo;

        clsClient.enTransactionMode _enTransactionMode;

        public frmWithDrawDeposit(int ClientID, clsClient.enTransactionMode TransactionMode)
        {
            InitializeComponent();
            _ClientID = ClientID;
            _enTransactionMode = TransactionMode;
        }

        private void txtWithdrawAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        void _ResetDefaultValues()
        {
            lblBeneficiaryAccount.Enabled = false;
            txtBeneficiaryAccount.Enabled = false ;

            switch (_enTransactionMode)
            {
                case clsClient.enTransactionMode.enWithdraw:
                    lblTitle.Text = "Withdraw";
                    this.Text = lblTitle.Text;
                    lblTransationAmount.Text = "Withdraw Amount";
                    break;
                case clsClient.enTransactionMode.enDeposit:
                    lblTitle.Text = "Deposit";
                    this.Text = lblTitle.Text;
                    lblTransationAmount.Text = "Deposit Amount";
                    break;
                case clsClient.enTransactionMode.enTransfer:
                    lblTitle.Text = "Transfer";
                    this.Text = lblTitle.Text;
                    lblTransationAmount.Text = "Transfer Amount";
                    lblBeneficiaryAccount.Enabled = true;
                    txtBeneficiaryAccount.Enabled = true;
                    break;
            }
        }
        
        private void frmWithDraw_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            ctrlClientCard1.LoadClientInfo(_ClientID);

            _ClientInfo = ctrlClientCard1.ClientInfo;

            

        }

        void _ValidateEmptyTextBox(TextBox textBox,CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                errorProvider1.SetError(textBox, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox, null);
            }
        }
        private void txtWithdrawAmount_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyTextBox(txtTransactionAmount, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool PerformTransactionProcess()
        {
            double TransactionAmount = Convert.ToDouble(txtTransactionAmount.Text.Trim());
            switch (_enTransactionMode)
            {

                case clsClient.enTransactionMode.enWithdraw:
                    return _ClientInfo.WithDraw(TransactionAmount);
                    
                case clsClient.enTransactionMode.enDeposit:
                    return _ClientInfo.Deposit(TransactionAmount);
                    
                case clsClient.enTransactionMode.enTransfer:
                    return _ClientInfo.Transfer(txtBeneficiaryAccount.Text, TransactionAmount);
                default:
                    return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (PerformTransactionProcess())
            {
                MessageBox.Show("Transaction Done Successfuly","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Transaction Faild,An Error Occurred", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBeneficiaryAccount_Validating(object sender, CancelEventArgs e)
        {
            if (_enTransactionMode != clsClient.enTransactionMode.enTransfer)
                return;
            _ValidateEmptyTextBox(txtBeneficiaryAccount, e);


            if (!clsClient.IsExistByClientAccountNo(txtBeneficiaryAccount.Text.Trim()))
               {
                    errorProvider1.SetError(txtBeneficiaryAccount, "Account Number Is Not Exist");
                    e.Cancel = true;
             }
             else
             {
                  errorProvider1.SetError(txtBeneficiaryAccount, null);
             }

            if (clsClient.IsClientActive(txtBeneficiaryAccount.Text))
            {
                errorProvider1.SetError(txtBeneficiaryAccount, "Account Number Is Not Active");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBeneficiaryAccount, null);
            }

            if (_ClientInfo.AccountNumber == txtBeneficiaryAccount.Text.Trim())
            {
                errorProvider1.SetError(txtBeneficiaryAccount, "You Cant Add Your Account Number As a Beneficiary");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBeneficiaryAccount, null);
            }


        }
    }
}

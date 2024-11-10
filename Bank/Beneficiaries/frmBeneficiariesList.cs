using Bank.Beneficiaries.Controls;
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

namespace Bank.Beneficiaries
{
    public partial class frmBeneficiariesList : Form
    {

        int _SourceAccountID = -1;
        clsAccount _SourceAccountInfo;
        DataTable _dtBeneficiaries;
        
        ctrlBeneficiariesCard ctrlBCard;
        public frmBeneficiariesList(int SourceAccountID)
        {
            InitializeComponent();
            _SourceAccountID = SourceAccountID;
        }

        void _ResetDefaultValue()
        {
            _SourceAccountInfo = clsAccount.FindAccountByID(_SourceAccountID);
            if (_SourceAccountInfo == null)
            {
                MessageBox.Show($"No Account Found By ID [{_SourceAccountID}]","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            gbTransferDetails.Enabled = false;
            
            btnConfirm.Enabled = false;

            lblMyAccountType.Text = _SourceAccountInfo.AccountTypeInfo.AccountTypeName +".";
            lblAccountNumber.Text = _SourceAccountInfo.AccountNumber;
            lblCurrency.Text = "USD";// To be Continues
            lblMyBalance.Text = _SourceAccountInfo.Balance.ToString();
        }
        void _GenerateBeneficiariesList()
        {
            foreach (DataRow row in _dtBeneficiaries.Rows)
            {
                ctrlBCard = new ctrlBeneficiariesCard();
                ctrlBCard.LoadInfo((int)row["BeneficiaryID"], (string)row["FullName"], (string)row["AccountNumber"]);
                ctrlBCard.Click += _OnCardSelected;
                flpBeneficiaryList.Controls.Add(ctrlBCard);            
            }
        }
        private void frmBeneficiariesList_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            _dtBeneficiaries = clsClient.FindClientByAccountID(_SourceAccountID).GetClientBeneficiaries();
            _GenerateBeneficiariesList();
            
        }

        void _OnCardSelected(object sender, EventArgs e) 
        {
            var SelectedCard = (ctrlBeneficiariesCard)sender;
            if (SelectedCard != null)
            {
                gbTransferDetails.Enabled = true;
                clsBeneficiary beneficiary = clsBeneficiary.FindBeneficiarieByID(SelectedCard.BeneficiaryID);
                lblBeneficiaryNickname.Text = beneficiary.Nickname + ".";
                lblBeneAccountNumber.Text = beneficiary.AccountInfo.AccountNumber;
            }   
        }

        private void txtTransferAmount_TextChanged(object sender, EventArgs e)
        {
            btnConfirm.Enabled = txtTransferAmount.Text.Trim() != ""; 
        }

        private void txtTransferAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTransferAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTransferAmount.Text.Trim()))
            {
                errorProvider1.SetError(txtTransferAmount, "Required Feild");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTransferAmount, null);
            }
            if(txtTransferAmount.Text.Trim() == "")
                return;
            if (_SourceAccountInfo.Balance < Convert.ToDecimal(txtTransferAmount.Text.Trim()))
            {
                errorProvider1.SetError(txtTransferAmount, "Insufficient Funds");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtTransferAmount, null);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            _SourceAccountInfo.Transfer(lblBeneAccountNumber.Text, Convert.ToDecimal(txtTransferAmount.Text.Trim()));
        }
    }
}

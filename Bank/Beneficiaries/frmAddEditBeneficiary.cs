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
    public partial class frmAddEditBeneficiary : Form
    {
        enum enMode { enAddNew = 1,enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        int _SenderClientID = -1;
        clsClient _SenderClientInfo;
        public frmAddEditBeneficiary(int SenderClientID)
        {
            InitializeComponent();
            _SenderClientID = SenderClientID;
        }

        void _ResetDefaultValue()
        {
            cbFilterBy.SelectedIndex = 0;
            btnSave.Enabled = false;
            gbBeneficiary.Visible = false;

            _SenderClientInfo = clsClient.FindClientByID(_SenderClientID);
            if (_SenderClientInfo == null)
            {
                MessageBox.Show($"An Error Occurred,Sender Client Issue",
                                   "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }    
        }
        private void frmAddEditBeneficiary_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();

        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                errorProvider1.SetError(txtFilterValue,"Required Field");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtFilterValue,null);
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private clsClient _PerformSearch(string Input,string SearchType)
        {    
            switch (SearchType) 
            {
                case "Account":
                    if(!_SenderClientInfo.IsClientOwnAccount(Input))
                        return clsClient.FindClientByAccountNumber(Input);  
                    else
                        {
                        MessageBox.Show("You cannot save your own Account as a beneficiary.Please Try a different Account Number",
                                       "Sorry",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                        }
                    break;
                case "Phone":
                    if(_SenderClientInfo.PersonInfo.Phone != Input)
                        return clsClient.FindClientByPhoneNumber(Input);
                    else
                        MessageBox.Show("You cannot save your own Phone as a beneficiary.Please Try a different Phone Number",
                                       "Sorry",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                    break;
                case "Card":
                    // To add later By card Number
                    break;
            }
            return null;
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            int TargetLength = 0;
            string SearchType = "";
            switch (cbFilterBy.Text.Trim())
            {
                case "Account Number":
                    TargetLength = 8;
                    SearchType = "Account";
                    break;
                case "Mobile Number":
                    TargetLength = 10;
                    SearchType = "Phone";
                    break;
                case "Card Number":
                    TargetLength = 16;
                    SearchType = "Card";
                    break;
            }

            txtFilterValue.MaxLength = TargetLength;

            if (txtFilterValue.Text.Length == TargetLength)
            {
                clsClient  _clientInfo = _PerformSearch(txtFilterValue.Text.Trim(),SearchType);
                if (_clientInfo == null)
                {
                    MessageBox.Show($"We are unable to process your request,no valid account was found against this {SearchType} Number",
                                       "Sorry",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                    return;
                }

                btnSave.Enabled = true;
                gbBeneficiary.Visible = true;
                lblBeneficiaryName.Text = _clientInfo.PersonInfo.FullName;
                lblBenefAccountNumber.Text = SearchType == "Account"
                                           ? txtFilterValue.Text.Trim()
                                           : clsAccount.FindPrimaryAccountByClientID(_clientInfo.ClientID).AccountNumber;
            }

            gbBeneficiary.Visible = false;

        }

        private void txtNickname_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                errorProvider1.SetError(txtFilterValue, "Required Field");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

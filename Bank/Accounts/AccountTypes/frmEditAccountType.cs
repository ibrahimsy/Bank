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
using static BankBussiness.clsAccountType;

namespace Bank.AccountTypes
{
    public partial class frmEditAccountType : Form
    {
       
        int _AccountTypeID = -1;
        clsAccountType _AccountTypeInfo;
        public frmEditAccountType(int AccountTypeID)
        {
            InitializeComponent();
            _AccountTypeID = AccountTypeID;
        }

        void _LoadAccountTypeInfo()
        {
            _AccountTypeInfo = clsAccountType.FindAccountTypeByID(_AccountTypeID);
            if (_AccountTypeInfo == null)
            {
                MessageBox.Show($"AccountType With ID [{_AccountTypeID}] Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblAccountTypeID.Text =   _AccountTypeInfo.AccountTypeID.ToString();
            txtAccountTypeName.Text = _AccountTypeInfo.AccountTypeName.ToString();
            txtInterestRate.Text =    _AccountTypeInfo.InterestRate.ToString();
            txtWithdrawalLimit.Text = _AccountTypeInfo.WithdrawalLimit.ToString();
            txtMinimumBalance.Text =  _AccountTypeInfo.MinimumBalance.ToString();
            txtDescription.Text =     _AccountTypeInfo.Description.ToString();  
            
        }

      

       
        void _ValidateEmptyTextBox(TextBox textItem,CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textItem.Text.Trim()))
            {
                errorProvider1.SetError(textItem,"This Field Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textItem,null);
            }
        }

        private void TextBoxes_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyTextBox((TextBox)sender,e);
        }

        private void frmEditAccountType_Load(object sender, EventArgs e)
        {
            _LoadAccountTypeInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            _AccountTypeInfo.AccountTypeName = txtAccountTypeName.Text.Trim();
            _AccountTypeInfo.InterestRate = Convert.ToSingle(txtInterestRate.Text.Trim());
            _AccountTypeInfo.WithdrawalLimit = Convert.ToDouble(txtWithdrawalLimit.Text.Trim());
            _AccountTypeInfo.MinimumBalance = Convert.ToDouble(txtMinimumBalance.Text.Trim());
            _AccountTypeInfo.Description = txtDescription.Text.Trim();


            if (_AccountTypeInfo.Save())
            {
                MessageBox.Show($"AccountType Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

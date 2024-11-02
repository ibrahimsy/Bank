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

namespace Bank.Client
{
    public partial class frmChangePinCode : Form
    {
        int _ClientID;
        clsClient _ClientInfo;
        public frmChangePinCode(int ClientID)
        {
            InitializeComponent();
            _ClientID = ClientID;
        }

        void _ValidateEmptyInput(MaskedTextBox input, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(input.Text.Trim()))
            {
                errorProvider1.SetError(input, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(input, null);
            }
        }

        private void frmChangePinCode_Load(object sender, EventArgs e)
        {
          
            txtCurrentPinCode.Focus();
            _ClientInfo = ctrlClientCard1.ClientInfo;
        }

        private void txtCurrentPinCode_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyInput(txtCurrentPinCode, e);

            
        }

        private void txtNewPinCode_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyInput(txtNewPinCode, e);
        }

        private void txtConfirmPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPinCode.Text.Trim() != txtNewPinCode.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPinCode, "Password Must Be Matched");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPinCode, null);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Feild Is Invalid,put Mouse On Red Icon", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            if (_ClientInfo.Save())
            {
                MessageBox.Show("PinCode Changed Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using Bank.Global_Classes;
using BankBussiness;
using DevExpress.Utils.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        clsApplication.enApplicationTypes _ApplicationTypeID = clsApplication.enApplicationTypes.IssueNewCard;
        clsApplicationType _ApplicationTypeInfo;
        public frmEditApplicationType(clsApplication.enApplicationTypes ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        void _LoadApplicationTypeInfo()
        {
            _ApplicationTypeInfo = clsApplicationType.FindApplicationTypeByID((int)_ApplicationTypeID);
            if (_ApplicationTypeInfo == null)
            {
                MessageBox.Show($"Application Type With ID [{_ApplicationTypeID}] Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationTypeID.Text = ((int)_ApplicationTypeID).ToString();
            txtApplicationTypeName.Text = _ApplicationTypeInfo.TypeTitle;
            txtApplicationFee.Text = _ApplicationTypeInfo.Fees.ToString();
        }

        void _ValidateEmptyTextBox(TextBox textItem, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textItem.Text.Trim()))
            {
                errorProvider1.SetError(textItem, "This Field Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textItem, null);
            }

            if(textItem == txtApplicationFee && !clsValidations.IsNumber(textItem.Text))
            {
                errorProvider1.SetError(textItem, "This Field Is Have Numbers Only");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textItem, null);
            }
        }

        private void TextBoxes_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyTextBox((TextBox)sender,e);
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypeInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Feild is incorrect ,put mouse on red icon",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            _ApplicationTypeInfo.TypeTitle = txtApplicationTypeName.Text.Trim();
            _ApplicationTypeInfo.Fees = Convert.ToDecimal(txtApplicationFee.Text.Trim());

            if (_ApplicationTypeInfo.Save())
            {
                MessageBox.Show($"Application Type Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtApplicationFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}

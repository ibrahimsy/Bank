using Bank.Global_Classes;
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
    public partial class frmAddEditClient : Form
    {
        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        int _ClientID = -1;
        clsClient _ClientInfo;
        public frmAddEditClient()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }

        public frmAddEditClient(int ClientID)
        {
            InitializeComponent();
            _ClientID = ClientID;
            _Mode = enMode.enUpdate;
        }

        void _ResetDefaultValue()
        {
            if (_Mode == enMode.enAddNew)
            {
                _ClientInfo = new clsClient();
                this.Text = "Add Client";
                lblTitle.Text = this.Text;

                tpClientInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrlPersonInfoWithFilter1.TextValueFocus();
            }
            else
            {
                this.Text = "Update Client";
                lblTitle.Text = this.Text;

                tpClientInfo.Enabled = true;
                btnSave.Enabled = Enabled;
            }
        }

        void _LoadUserInfo()
        {
            _ClientInfo = clsClient.FindClientByID(_ClientID);
            if (_ClientInfo == null)
            {
                MessageBox.Show($"User Not Found With ID = [{_ClientID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlPersonInfoWithFilter1.FilterEnabled = false;
            ctrlPersonInfoWithFilter1.LoadPersonInfo(_ClientInfo.PersonID);

            lblClientID.Text = _ClientInfo.ClientID.ToString();
            txtAccountNo.Text = _ClientInfo.AccountNumber.ToString();
            txtPinCode.Text = _ClientInfo.PinCode.ToString();
            chkIsActive.Checked = _ClientInfo.IsActive;

            btnSave.Enabled = true;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonInfoWithFilter1.PersonID != -1)
            {
                if (clsClient.IsExistByPersonID(ctrlPersonInfoWithFilter1.PersonID) && _Mode == enMode.enAddNew)
                {
                    MessageBox.Show("Selected Person Allready Is Client In System,\nchoose another person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tabControl1.SelectedTab = tpClientInfo;
                    tpClientInfo.Enabled = true;
                    btnSave.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Choose A Person First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmAddEditClient_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.TextValueFocus();
        }

        private void txtAccountNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccountNo.Text.Trim()))
            {
                errorProvider1.SetError(txtAccountNo, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtAccountNo, null);
            }

            if (clsClient.IsExistByClientAccountNo(txtAccountNo.Text.Trim()) && _Mode == enMode.enAddNew)
            {
                errorProvider1.SetError(txtAccountNo, "Account.No Is Exist");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtAccountNo, null);
            }
        }

        private void txtPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPinCode.Text.Trim()))
            {
                errorProvider1.SetError(txtPinCode, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPinCode, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show($"Some Feild Are Invalid,Put Mouse On Red Icon",
                    "Faild",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            _ClientInfo.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            _ClientInfo.AccountNumber = txtAccountNo.Text;
            _ClientInfo.PinCode = Convert.ToInt16(txtPinCode.Text.Trim());
            _ClientInfo.IsActive = chkIsActive.Checked;
            _ClientInfo.CreatedByID = clsGlobalSettings.CurrentUser.UserID;

            if (_ClientInfo.Save())
            {
                MessageBox.Show($"Client Created Successfuly With ID = [{_ClientInfo.ClientID}]",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _Mode = enMode.enUpdate;
                lblTitle.Text = "UPDATE Client";
                this.Text = lblTitle.Text;
                ctrlPersonInfoWithFilter1.FilterEnabled = false;
                lblClientID.Text = _ClientInfo.ClientID.ToString();

            }
            else
            {
                MessageBox.Show($"An Error Occurred",
                    "Faild",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtPinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void frmAddEditClient_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.enUpdate)
            {
                _LoadUserInfo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

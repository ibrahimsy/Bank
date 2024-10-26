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

namespace Bank.Users
{
    public partial class frmChangePassword : Form
    {
        int _UserID;
        clsUser _UserInfo;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);

            _UserInfo = ctrlUserCard1.UserInfo;
        }

        void _ValidateEmptyInput(TextBox input, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(input.Text.Trim()))
            {
                errorProvider1.SetError(input,"This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(input, null);
            }
        }
        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Feild Is Invalid,put Mouse On Red Icon","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _UserInfo.Password = txtNewPassword.Text.Trim();
            if (_UserInfo.Save())
            {
                MessageBox.Show("Password Changed Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyInput(txtCurrentPassword,e);

            if (!clsUser.IsExistByUserNameAndPassword(ctrlUserCard1.UserInfo.UserName,txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtCurrentPassword, "InCorrect Password");
                e.Cancel= true;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            _ValidateEmptyInput(txtNewPassword, e);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Must Be Matched");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }
    }
}

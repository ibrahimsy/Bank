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
    public partial class frmAddEditUser : Form
    {
        enum enMode { enAddNew = 1,enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        int _UserID = -1;
        clsUser _UserInfo;
        public frmAddEditUser()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.enUpdate;
        }

        void _ResetDefaultValue()
        {
            if(_Mode == enMode.enAddNew)
            {
                _UserInfo = new clsUser();
                this.Text = "Add User";
                lblTitle.Text = this.Text;

                tpLoginInfo.Enabled = false;
                btnSave.Enabled = false;
                ctrlPersonInfoWithFilter1.TextValueFocus();
            }
            else
            {
                this.Text = "Update User";
                lblTitle.Text = this.Text;

                tpLoginInfo.Enabled = true;
                btnSave.Enabled = Enabled; 
            }
        }

        void _LoadUserInfo()
        {
            _UserInfo = clsUser.FindUserByID(_UserID);
            if (_UserInfo == null)
            {
                MessageBox.Show($"User Not Found With ID = [{_UserID}]","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            ctrlPersonInfoWithFilter1.FilterEnabled = false;
            ctrlPersonInfoWithFilter1.LoadPersonInfo();

            lblUserID.Text = _UserInfo.UserID.ToString();
            txtUserName.Text = _UserInfo.UserName.ToString();
            txtPassword.Text = _UserInfo.Password.ToString();
            txtConfirmPassword.Text = _UserInfo.Password.ToString();
            chkIsActive.Checked = _UserInfo.IsActive;

            btnSave.Enabled = true;

        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.enUpdate)
            {
                _LoadUserInfo();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            if (ctrlPersonInfoWithFilter1.PersonID != -1)
            {
                if (clsPerson.IsPersonLinkedWithUSer(ctrlPersonInfoWithFilter1.PersonID) && _Mode == enMode.enAddNew)
                {
                    MessageBox.Show("Selected Person Linked With User","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    tabControl1.SelectedTab = tpLoginInfo;
                    tpLoginInfo.Enabled = true;
                    btnSave.Enabled=true;
                }
            }
            else
            {
                MessageBox.Show("Choose A Person First","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonInfoWithFilter1.TextValueFocus();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtUserName, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            if (clsUser.IsExistByUserName(txtUserName.Text.Trim()) && _Mode == enMode.enAddNew)
            {
                errorProvider1.SetError(txtUserName, "UserName Is Exist");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
         }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtUserName, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password Must Be Match");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null); 
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

            _UserInfo.PersonID = ctrlPersonInfoWithFilter1.PersonID;
            _UserInfo.UserName = txtUserName.Text;
            _UserInfo.Password = txtPassword.Text;
            _UserInfo.IsActive = chkIsActive.Checked;

            if (_UserInfo.Save())
            {
                MessageBox.Show($"User Created Successfuly With ID = [{_UserInfo.UserID}]",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                _Mode = enMode.enUpdate;
                lblTitle.Text = "UPDATE USER";
                this.Text = lblTitle.Text;
                ctrlPersonInfoWithFilter1.FilterEnabled = false;
                lblUserID.Text = _UserInfo.UserID.ToString();
                
            }
            else
            {
                MessageBox.Show($"An Error Occurred",
                    "Faild",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}

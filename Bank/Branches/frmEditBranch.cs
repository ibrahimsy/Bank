using BankBussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Branches
{
    public partial class frmEditBranch : Form
    {
        int _BranchID = -1;
        clsBranch _BranchInfo;
        public frmEditBranch(int branchID)
        {
            InitializeComponent();
            _BranchID = branchID;
        }

        void _LoadBranchInfo()
        {
            _BranchInfo = clsBranch.FindBranchByID(_BranchID);
            if (_BranchInfo == null)
            {
                MessageBox.Show($"Branch With ID [{_BranchID}] Is Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            lblBranchID.Text = _BranchInfo.BranchID.ToString();
            txtBranchName.Text = _BranchInfo.BranchName.ToString();
            txtAddress.Text = _BranchInfo.Address.ToString();
            txtEmail.Text = _BranchInfo.Email.ToString();
            txtPhoneNumber.Text = _BranchInfo.PhoneNumber.ToString();
            txtOpeningHours.Text  = _BranchInfo.OpeningHours.ToString();

            cbBranchStatus.SelectedIndex = 0;
        }

        private void frmEditBranch_Load(object sender, EventArgs e)
        {
            _LoadBranchInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _BranchInfo.BranchName = txtBranchName.Text.Trim();
            _BranchInfo.Email = txtEmail.Text.Trim();
            _BranchInfo.PhoneNumber = txtPhoneNumber.Text.Trim();
            _BranchInfo.Address = txtAddress.Text.Trim();
            _BranchInfo.OpeningHours = txtOpeningHours.Text.Trim();
            _BranchInfo.Status = clsBranch.FindBranchByBranchName(txtBranchName.Text).Status;

            if (_BranchInfo.Save())
            {
                MessageBox.Show($"Branch Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"An Error Occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

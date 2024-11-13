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
    public partial class frmManageUsers : Form
    {
        DataTable _dtUserList;
        public frmManageUsers()
        {
            InitializeComponent();
        }

        void _RefreshUsersList()
        {
            _dtUserList = clsUser.GetUsersList();
            dgvUsers.DataSource = _dtUserList;

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 150;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 150;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 250;

                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 150;

                dgvUsers.Columns[4].HeaderText = "Password";
                dgvUsers.Columns[4].Width = 150;

                dgvUsers.Columns[5].HeaderText = "Is Active";
                dgvUsers.Columns[5].Width = 150;

                dgvUsers.Columns[6].HeaderText = "Permission";
                dgvUsers.Columns[6].Width = 150;
            }


            lblRecordsCount.Text = _dtUserList.Rows.Count.ToString();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            cbFilterBy.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string _ColumnText(string ColumnName)
        {
            switch (ColumnName)
            {
                case "User ID":
                    return "UserID";
                case "Person ID":
                    return "PersonID";
                case "Full Name":
                    return "FullName";
                case "UserName":
                    return "UserName";
                case "Password":
                    return "Password";
                case "Is Active":
                    return "IsActive";
                default:
                    return "";
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                _dtUserList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();

                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text == "")
            {
                _dtUserList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }
            string FilterColumn = _ColumnText(cbFilterBy.Text);

            string FilterValue = txtFilterValue.Text;

            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
            {
                _dtUserList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                _dtUserList.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();

            _RefreshUsersList();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void showUserDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshUsersList();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            DialogResult result = MessageBox.Show($"Are You Sure You Want To Delete User With ID[{UserID}]",
                                                   "Confirm",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes) 
            {
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show($"User Deleted Successfuly",
                                                   "Success",
                                                   MessageBoxButtons.OK,
                                                   MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"An Error Occurred",
                                                   "Faild",
                                                   MessageBoxButtons.OK,
                                                   MessageBoxIcon.Error);
                }
            }
            _RefreshUsersList();
        }
    }
}

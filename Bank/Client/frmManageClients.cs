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
    public partial class frmManageClients : PermissionForm
    {
        DataTable _dtClientList;
        public frmManageClients()
        {
            InitializeComponent();
        }
        void _RefreshClientsList()
        {
            _dtClientList = clsClient.GetClientsList();
            dgvClients.DataSource = _dtClientList;

            if (dgvClients.Rows.Count > 0)
            {

                dgvClients.Columns[0].HeaderText = "Client ID";
                dgvClients.Columns[0].Width = 100;

                dgvClients.Columns[1].HeaderText = "Person ID";
                dgvClients.Columns[1].Width = 110;

                dgvClients.Columns[2].HeaderText = "Full Name";
                dgvClients.Columns[2].Width = 300;

                dgvClients.Columns[3].HeaderText = "Account Status";
                dgvClients.Columns[3].Width = 150;

                dgvClients.Columns[4].HeaderText = "Created Date";
                dgvClients.Columns[4].Width = 180;

                dgvClients.Columns[5].HeaderText = "Branch Name";
                dgvClients.Columns[5].Width = 100;

                dgvClients.Columns[5].HeaderText = "Notes";
                dgvClients.Columns[5].Width = 100;

            }


            lblRecordsCount.Text = _dtClientList.Rows.Count.ToString();
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageClients_Load(object sender, EventArgs e)
        {
            _RefreshClientsList();
            cbFilterBy.SelectedIndex = 0;
        }

        string _ColumnText(string ColumnName)
        {
            switch (ColumnName)
            {
                case "Person ID":
                    return "PersonID";
                case "Client ID":
                    return "ClientID";
                case "Full Name":
                    return "FullName";
                default:
                    return "";
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                _dtClientList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtClientList.Rows.Count.ToString();

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
                _dtClientList.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtClientList.Rows.Count.ToString();
                return;
            }
            string FilterColumn = _ColumnText(cbFilterBy.Text);

            string FilterValue = txtFilterValue.Text;

            if (FilterColumn == "PersonID" || FilterColumn == "ClientID")
            {
                _dtClientList.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                _dtClientList.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = _dtClientList.DefaultView.Count.ToString();
        }

        private void showClientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientInfo frm = new frmClientInfo((int)dgvClients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddClient frm = new frmAddClient();
            frm.ShowDialog();

            _RefreshClientsList();
        }

        private void editClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddClient frm = new frmAddClient((int)dgvClients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshClientsList();
        }

        private void deleteClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ClientID = (int)dgvClients.CurrentRow.Cells[0].Value;

            DialogResult result = MessageBox.Show($"Are You Sure You Want To Delete Client With ID[{ClientID}]",
                                                   "Confirm",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (clsClient.DeleteClient(ClientID))
                {
                    MessageBox.Show($"Client Deleted Successfuly",
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
            _RefreshClientsList();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!DoesUserHavePermission(clsUser.enPermission.AddClient))
                return;

            frmAddClient frm = new frmAddClient();
            frm.ShowDialog();

            _RefreshClientsList();
        }

        private void ChangePinCode_toolStripe(object sender, EventArgs e)
        {
            frmChangePinCode frm = new frmChangePinCode((int)dgvClients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshClientsList();
        }

        private void dgvClients_DoubleClick(object sender, EventArgs e)
        {
            frmClientInfo frm = new frmClientInfo((int)dgvClients.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshClientsList();
        }

       

        private void withDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            _RefreshClientsList();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _RefreshClientsList();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            _RefreshClientsList();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(!CheckPermission(clsUser.enPermission.Transaction))
                TransactiontoolStripMenuItem.Enabled = false;

            if (!CheckPermission(clsUser.enPermission.AddClient))
                addClientToolStripMenuItem.Enabled = false;
        }
    }
}

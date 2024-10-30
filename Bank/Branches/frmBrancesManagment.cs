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

namespace Bank.Branches
{
    public partial class frmBrancesManagment : Form
    {
        DataTable _dtBranches;
        public frmBrancesManagment()
        {
            InitializeComponent();
        }

        void _RefreshBranchesList()
        {
            _dtBranches = clsBranch.GetBranchsList();
            dgvBranches.DataSource = _dtBranches;
            lblRecordsCount.Text = _dtBranches.Rows.Count.ToString();

            if (dgvBranches.Rows.Count > 0)
            {
                dgvBranches.Columns[0].HeaderText = "Branch ID";
                dgvBranches.Columns[0].Width = 100;

                dgvBranches.Columns[1].HeaderText = "Branch Name";
                dgvBranches.Columns[1].Width = 150;

                dgvBranches.Columns[2].HeaderText = "Address";
                dgvBranches.Columns[2].Width = 200;

                dgvBranches.Columns[3].HeaderText = "Phone Number";
                dgvBranches.Columns[3].Width = 150;

                dgvBranches.Columns[4].HeaderText = "Email";
                dgvBranches.Columns[4].Width = 180;

                dgvBranches.Columns[5].HeaderText = "Opening Hours";
                dgvBranches.Columns[5].Width = 150;

                dgvBranches.Columns[6].HeaderText = "Branch Status";
                dgvBranches.Columns[6].Width = 150;
            }
            
        }
        private void frmBrancesManagment_Load(object sender, EventArgs e)
        {
            _RefreshBranchesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editBranchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditBranch frm = new frmEditBranch((int)dgvBranches.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshBranchesList();
        }
    }
}

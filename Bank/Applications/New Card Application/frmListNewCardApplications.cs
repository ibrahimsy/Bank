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

namespace Bank.Applications.New_Card_Application
{
    public partial class frmListNewCardApplications : Form
    {
        public frmListNewCardApplications()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewCardApplication_Click(object sender, EventArgs e)
        {
            frmAddNewCardApplication frm = new frmAddNewCardApplication();
            frm.ShowDialog();
            frmListNewCardApplications_Load(null,null);
        }

        private void frmListNewCardApplications_Load(object sender, EventArgs e)
        {
            DataTable _dtNewCardApplications = clsNewCardApplication.GetNewCardApplicationsList();
            dgvNewCardApplications.DataSource = _dtNewCardApplications;
            lblRecordsCount.Text = _dtNewCardApplications.Rows.Count.ToString();

            if (_dtNewCardApplications.Rows.Count > 0)
            {
                dgvNewCardApplications.Columns[0].HeaderText = "N.C.App ID";
                //dgvNewCardApplications.Columns[0].Width = 10;

                dgvNewCardApplications.Columns[1].HeaderText = "Base App ID";

                dgvNewCardApplications.Columns[2].HeaderText = "Card Type";

                dgvNewCardApplications.Columns[3].HeaderText = "Account Number";

                dgvNewCardApplications.Columns[4].HeaderText = "Full Name";

                dgvNewCardApplications.Columns[5].HeaderText = "Application Date";

                dgvNewCardApplications.Columns[6].HeaderText = "Status";
            }

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowNewCardApplicationInfo frm = new frmShowNewCardApplicationInfo((int)dgvNewCardApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}

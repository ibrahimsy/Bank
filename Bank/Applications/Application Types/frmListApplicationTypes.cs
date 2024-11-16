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

namespace Bank.Application_Types
{
    public partial class frmListApplicationTypes : Form
    {
        DataTable _dtApplicationTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }
        
        void _RefreshApplicationTypesList()
        {
            _dtApplicationTypes = clsApplicationType.GetApplicationTypesList();
            dgvApplicationTypes.DataSource = _dtApplicationTypes;
            lblRecordsCount.Text = _dtApplicationTypes.Rows.Count.ToString();

            if (dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "Type ID";
                dgvApplicationTypes.Columns[0].Width = 100;

                dgvApplicationTypes.Columns[1].HeaderText = "Type Name";
                dgvApplicationTypes.Columns[1].Width = 150;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 200;
            }

        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
        }

        private void editApplicationTypeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((clsApplication.enApplicationTypes)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshApplicationTypesList();
        }
    }
}

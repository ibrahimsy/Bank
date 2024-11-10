using Bank.Beneficiaries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Transactions
{
    public partial class frmTransfer : Form
    {
        int _SourceAccountID = -1;
        public frmTransfer(int SourceAccountID)
        {
            InitializeComponent();
            _SourceAccountID = SourceAccountID;
        }

        private void pbMyBeneficiary_Click(object sender, EventArgs e)
        {
            frmBeneficiariesList frm = new frmBeneficiariesList(_SourceAccountID);
            frm.ShowDialog();
        }

        private void pbAddNewBeneficiary_Click(object sender, EventArgs e)
        {
            frmAddEditBeneficiary frm = new frmAddEditBeneficiary(_SourceAccountID);
            frm.ShowDialog();
        }
    }
}

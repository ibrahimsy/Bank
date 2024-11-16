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

namespace Bank.Cards.CardTypes
{
    public partial class frmListCardTypes : Form
    {
        public frmListCardTypes()
        {
            InitializeComponent();
        }

        DataTable _dtCardTypes;
        

        void _RefreshCardTypesList()
        {
            _dtCardTypes = clsCardType.GetCardTypesList();
            dgvCardTypes.DataSource = _dtCardTypes;
            lblRecordsCount.Text = _dtCardTypes.Rows.Count.ToString();

            if (dgvCardTypes.Rows.Count > 0)
            {
                dgvCardTypes.Columns[0].HeaderText = "Type ID";
                dgvCardTypes.Columns[0].Width = 100;

                dgvCardTypes.Columns[1].HeaderText = "Type Name";
                dgvCardTypes.Columns[1].Width = 150;

                dgvCardTypes.Columns[2].HeaderText = "Description";
                dgvCardTypes.Columns[2].Width = 200;
            }

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void editCardTypeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        
            _RefreshCardTypesList();
        }

        private void frmListCardTypes_Load(object sender, EventArgs e)
        {
            _RefreshCardTypesList();
        }
    }
}

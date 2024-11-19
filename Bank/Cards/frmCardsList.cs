using Bank.Applications.New_Card_Application;
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
using static BankBussiness.clsCard;

namespace Bank.Cards
{
    public partial class frmCardsList : Form
    {
        public frmCardsList()
        {
            InitializeComponent();
        }

        DataTable _dtCards;
 
        string _ColumnText(string ColumnName)
        {
            switch (ColumnName)
            {
                case "Card ID":
                    return "CardID";
                case "Account Number":
                    return "AccountNumber";
                case "Card Number":
                    return "CardNumber";
                case "Card Type":
                    return "CardType";
                case "Card Holder":
                    return "CardHolder";
                case "Status":
                    return "Status";

                default:
                    return "";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCardsList_Load(object sender, EventArgs e)
        {
            _dtCards = clsCard.GetCardsList();
            dgvCards.DataSource = _dtCards;
            lblRecordsCount.Text = _dtCards.Rows.Count.ToString();


            if (_dtCards.Rows.Count > 0)
            {
                dgvCards.Columns[0].HeaderText = "Card ID";

                dgvCards.Columns[1].HeaderText = "Account Number";

                dgvCards.Columns[2].HeaderText = "Card Number";

                dgvCards.Columns[3].HeaderText = "PIN Code";

                dgvCards.Columns[4].HeaderText = "CVV";

                dgvCards.Columns[5].HeaderText = "Expiration Date";

                dgvCards.Columns[6].HeaderText = "Card Type";

                dgvCards.Columns[7].HeaderText = "Card Holder";

                dgvCards.Columns[8].HeaderText = "Status";

            }

            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                _dtCards.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtCards.Rows.Count.ToString();

                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged_1(object sender, EventArgs e)
        {
            if (txtFilterValue.Text == "")
            {
                _dtCards.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtCards.Rows.Count.ToString();
                return;
            }
            string FilterColumn = _ColumnText(cbFilterBy.Text);

            string FilterValue = txtFilterValue.Text;

            if (FilterColumn == "CardID")
            {
                _dtCards.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                _dtCards.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = _dtCards.DefaultView.Count.ToString();
        }

        private void txtFilterValue_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "CardID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}

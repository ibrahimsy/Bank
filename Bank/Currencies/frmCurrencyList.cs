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

namespace Bank.Currencies
{
    public partial class frmCurrencyList : Form
    {
        DataTable _dtCurrencies;
        public frmCurrencyList()
        {
            InitializeComponent();
        }

        void _RefreshCurrencyList()
        {
            _dtCurrencies = clsCurrency.GetCurrenciesList();
            dgvCurrencies.DataSource = _dtCurrencies;

            if (dgvCurrencies.Rows.Count > 0)
            {

                dgvCurrencies.Columns[0].HeaderText = "Currency ID";
                dgvCurrencies.Columns[0].Width = 100;

                dgvCurrencies.Columns[1].HeaderText = "Country Name";
                dgvCurrencies.Columns[1].Width = 110;

                dgvCurrencies.Columns[2].HeaderText = "Currency Code";
                dgvCurrencies.Columns[2].Width = 300;

                dgvCurrencies.Columns[3].HeaderText = "Currency Name";
                dgvCurrencies.Columns[3].Width = 150;
                
                dgvCurrencies.Columns[4].HeaderText = "Rate";
                dgvCurrencies.Columns[4].Width = 180;
            }


            lblRecordsCount.Text = _dtCurrencies.Rows.Count.ToString();
        }
       
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCurrencyList_Load(object sender, EventArgs e)
        {
            _RefreshCurrencyList();
            cbFilterBy.SelectedIndex = 0;
        }

        string _ColumnText(string ColumnName)
        {
            switch (ColumnName)
            {
                case "Currency ID":
                    return "CurrencyID";
                case "Country Name":
                    return "CountryName";
                case "Currency Code":
                    return "CurrencyCode";
                case "Currency Name":
                    return "CurrencyName";
                default:
                    return "";
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                _dtCurrencies.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtCurrencies.Rows.Count.ToString();

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
                _dtCurrencies.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtCurrencies.Rows.Count.ToString();
                return;
            }
            string FilterColumn = _ColumnText(cbFilterBy.Text);

            string FilterValue = txtFilterValue.Text;

            if (FilterColumn == "CurrencyID")
            {
                _dtCurrencies.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                _dtCurrencies.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = _dtCurrencies.DefaultView.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Currency ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}

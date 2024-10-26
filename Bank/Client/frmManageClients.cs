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
    public partial class frmManageClients : Form
    {
        DataTable _dtClientList;
        public frmManageClients()
        {
            InitializeComponent();
        }
        void _RefreshPeopleList()
        {
            _dtClientList = clsClient.GetClientsList();
            dgvClients.DataSource = _dtClientList;

            if (dgvClients.Rows.Count > 0)
            {

                dgvClients.Columns[0].HeaderText = "Client ID";
                dgvClients.Columns[0].Width = 100;

                dgvClients.Columns[1].HeaderText = "Person ID";
                dgvClients.Columns[1].Width = 100;

                dgvClients.Columns[2].HeaderText = "Full Name";
                dgvClients.Columns[2].Width = 250;

                dgvClients.Columns[3].HeaderText = "Account Number";
                dgvClients.Columns[3].Width = 150;

                dgvClients.Columns[4].HeaderText = "Pin Code";
                dgvClients.Columns[4].Width = 100;

                dgvClients.Columns[5].HeaderText = "Balance";
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
            _RefreshPeopleList();
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
                case "Account Number":
                    return "AccountNumber";
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

            lblRecordsCount.Text = _dtClientList.Rows.Count.ToString();
        }
    
    
    }
}

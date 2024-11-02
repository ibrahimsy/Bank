using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Client.Controls
{
    public partial class ctrlClientCardWithFilter : UserControl
    {
        int _ClientID = -1;
        public int ClientID
        {
            get
            {
                _ClientID = ctrlClientCard1.ClientID;
                return _ClientID;
            }
            set
            {
                _ClientID = value;
            }
        }

        bool _FilterEnable = true;
        public bool FilterEnabled
        {
            set
            {
                _FilterEnable = value;
                gbClientFilter.Enabled = _FilterEnable;
            }
            get
            {
                return _FilterEnable;
            }
        }
        public ctrlClientCardWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlClientCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            TextValueFocus();
        }

        void _FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Client ID":
                    ctrlClientCard1.LoadClientInfoByID(int.Parse(txtFilterValue.Text.Trim()));
                    break;
                case "National No":
                    ctrlClientCard1.LoadClientInfoByNationalNo(txtFilterValue.Text.Trim());
                    break;
                case "Primary Account Number":
                    ctrlClientCard1.LoadClientInfoByAccountNumber(txtFilterValue.Text.Trim());
                    break;
            }
        }
        public void TextValueFocus()
        {
            txtFilterValue.Focus();
        }

        private void btnFindClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
                return;
            _FindNow();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Client ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

            if (e.KeyChar == (char)13)
            {
                _FindNow();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Clear();
            TextValueFocus();
        }
    }
}

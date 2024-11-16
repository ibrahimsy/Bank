using Bank.Client.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Accounts.Controls
{
    public partial class ctrlAccountCardWithFilter : UserControl
    {
        int _AccountID = -1;
        public int AccountID
        {
            get
            {
                _AccountID = ctrlAccountCard1.AccountID;
                return _AccountID;
            }
            set
            {
                _AccountID = value;
            }
        }

        bool _FilterEnable = true;
        public bool FilterEnabled
        {
            set
            {
                _FilterEnable = value;
                gbAccountFilter.Enabled = _FilterEnable;
            }
            get
            {
                return _FilterEnable;
            }
        }

        public ctrlAccountCardWithFilter()
        {
            InitializeComponent();
            cbFilterBy.SelectedIndex = 0;
        }
        void _FindNow()
        {
              ctrlAccountCard1.LoadAccountInfo(txtFilterValue.Text.Trim());
        }
        public void TextValueFocus()
        {
            txtFilterValue.Focus();
        }
        public void LoadInfoByAccountNumber(string AccountNumber)
        {
            cbFilterBy.Text = AccountNumber;
            txtFilterValue.Text = AccountNumber;

            _FindNow();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                _FindNow();
            }
        }

        private void btnFindAccount_Click(object sender, EventArgs e)
        {
            _FindNow();
        }
    }
}

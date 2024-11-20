﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Cards.Controls
{
    public partial class ctrlCardInfoWihFilter : UserControl
    {
        public event Action<int> OnCardSelected;

        protected virtual void CardSelected(int CardID)
        {
            Action<int> handler = OnCardSelected;
            if (handler != null)
            {
                handler(CardID);
            }
        }
        public ctrlCardInfoWihFilter()
        {
            InitializeComponent();
        }

        private void btnCardSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;
            _FindNow();
        }

        void _FindNow()
        {
            string CardNumber = txtCardNumber.Text.Trim();
            ctrlCardInfo1.LoadCardInfoByCardNumber(CardNumber);
            if (OnCardSelected != null)
            {
                OnCardSelected(ctrlCardInfo1.CardID);
            }
        }

        private void txtCardNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCardNumber.Text))
            {
                errorProvider1.SetError(txtCardNumber,"Required Feild");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCardNumber, null);
            }
        }

        public void TextFocus()
        {
            txtCardNumber.Focus();
        }
        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if(e.KeyChar == (char)13)
            {
                _FindNow() ;
            }
        }
    }
}
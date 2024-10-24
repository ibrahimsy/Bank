using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.People.Controls
{
    public partial class ctrlPersonInfoWithFilter : UserControl
    {
        public int PersonID
        {
            get
            {
                return ctrlPersonInfo1.PersonID;
            }
        }
        
        bool _FilterEnable = true;
        public bool FilterEnabled
        {
            set
            {
                _FilterEnable = value;
                gpFilter.Enabled = _FilterEnable;
            }
            get
            {
                return _FilterEnable;
            }
        }
        
        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

        }

        public void LoadPersonInfo()
        {
            txtFilterValue.Text = PersonID.ToString();
            cbFilterBy.Text = "Person ID";

            _FindNow();
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
                return;
            _FindNow();
        }

        void _FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonInfo1.LoadPersonInfo(int.Parse(txtFilterValue.Text.Trim()));
                    break;
                case "National No":
                    ctrlPersonInfo1.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
                return; 

           
            if (cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

            if(e.KeyChar == (char)13)
            {
                _FindNow();
            }
        }

        public void TextValueFocus()
        {
            txtFilterValue.Focus();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextValueFocus();
        }
    }
}

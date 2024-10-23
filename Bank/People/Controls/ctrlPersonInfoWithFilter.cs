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
        
        bool _FilterEnable = false;
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
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
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
            if (cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}

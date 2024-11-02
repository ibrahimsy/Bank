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
                    ctrlClientCard1.LoadClientInfo(int.Parse(txtFilterValue.Text.Trim()));
                    break;
                case "National No":
                    ctrlPersonInfo1.LoadPersonInfo(txtFilterValue.Text.Trim());
                    break;
            }
        }
        public void TextValueFocus()
        {
            txtFilterValue.Focus();
        }
    }
}

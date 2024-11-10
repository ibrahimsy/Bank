using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Beneficiaries
{
    public partial class ctrlBeneficiaryCard : UserControl
    {
        public ctrlBeneficiaryCard()
        {
            InitializeComponent();
        }

        public void LoadInfo(string BeneficiaryName,string AccountNumber)
        {
            lblBeneficiaryName.Text = BeneficiaryName;
            lblBenefAccountNumber.Text = AccountNumber;
        }
    }
}

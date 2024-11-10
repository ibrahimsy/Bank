using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Beneficiaries.Controls
{
    public partial class ctrlBeneficiariesCard : UserControl
    {
       

        int _BeneficiaryID = -1;
        public int BeneficiaryID
        {
            get
            {
                return _BeneficiaryID;
            }
        }
        public ctrlBeneficiariesCard()
        {
            InitializeComponent();
        }

        public void LoadInfo(int BeneficiaryID,string Name,string AccountNumber)
        {
            lblBeneficiaryName.Text = Name;
            lblBenefAccountNumber.Text = AccountNumber;
            _BeneficiaryID = BeneficiaryID;
        }

        private void ctrlBeneficiariesCard_Click(object sender, EventArgs e)
        {
           
        }

        private void ctrlBeneficiariesCard_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.CadetBlue;
        }

        private void ctrlBeneficiariesCard_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkSlateGray;
        }
    }
}

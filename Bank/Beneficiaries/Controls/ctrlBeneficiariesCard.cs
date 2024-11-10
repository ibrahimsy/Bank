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
        public event Action<int>  OnBeneficiaryCardSelected;

        protected virtual void BeneficiaryCardSelected(int BeneficiaryID)
        {
            Action<int> handler = OnBeneficiaryCardSelected;
            if (handler != null) 
            {
                handler(BeneficiaryID);
            }
        }

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
            //if (OnBeneficiaryCardSelected != null)
            //{
            //    OnBeneficiaryCardSelected(BeneficiaryID);
            //}
           
        }

        private void ctrlBeneficiariesCard_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }

        private void ctrlBeneficiariesCard_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.PowderBlue;
        }
    }
}

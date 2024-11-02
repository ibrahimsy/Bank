using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Accounts
{
    public partial class frmShowAccountInfo : Form
    {
        int _AccountID = -1;
        string _AccountNumber = "";
        public frmShowAccountInfo(int AccountID)
        {
            InitializeComponent();
            _AccountID = AccountID;
        }
        public frmShowAccountInfo(string AccountName)
        {
            InitializeComponent();
            _AccountNumber = AccountName;
        }

        private void frmShowAccountInfo_Load(object sender, EventArgs e)
        {
            ctrlAccountCard1.LoadAccountInfo(_AccountID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Cards
{
    public partial class frmShowCardInfo : Form
    {
        int _CardID = -1;
        public frmShowCardInfo(int CardID)
        {
            InitializeComponent();
            _CardID = CardID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowCardInfo_Load(object sender, EventArgs e)
        {
            ctrlCardInfo1.LoadCardInfoByCardID(_CardID);
        }
    }
}

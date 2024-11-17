using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Applications.New_Card_Application
{
    public partial class frmShowNewCardApplicationInfo : Form
    {
        int _NewCardApplicationID = -1;
        public frmShowNewCardApplicationInfo(int NewCardApplicationID)
        {
            InitializeComponent();
            _NewCardApplicationID = NewCardApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowNewCardApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlNewCardApplicationInfo1.LoadInfo(_NewCardApplicationID);
        }
    }
}

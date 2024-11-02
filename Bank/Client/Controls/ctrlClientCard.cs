using BankBussiness;
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
    public partial class ctrlClientCard : UserControl
    {
        int _ClientID;
        clsClient _ClientInfo;
        public int ClientID
        {
            get
            {
                return _ClientID;
            }
        }

        public clsClient ClientInfo
        {
            get
            {
                return _ClientInfo;
            }
        }
        public ctrlClientCard()
        {
            InitializeComponent();
        }

        public void LoadClientInfo(int ClientID)
        {
            _ClientInfo = clsClient.FindClientByID(ClientID);
            if (_ClientInfo == null)
            {
                MessageBox.Show($"User With ID [{ClientID}] Is Not Found",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            _ClientID = ClientID;
        
            ctrlPersonCard1.LoadPersonInfo(_ClientInfo.PersonID);
            lblClientID.Text = ClientID.ToString();
            lblPrimaryAccountNo.Text = clsAccount.FindPrimaryAccountByClientID(_ClientID).AccountNumber;
            lblIsActive.Text = _ClientInfo.AccountStatus ? "Yes" : "No";
        }
    }
}

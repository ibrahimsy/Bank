using Bank.Client;
using Bank.Global_Classes;
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

namespace Bank.Applications.New_Card_Application.Controls
{
    public partial class ctrlNewCardApplicationInfo : UserControl
    {
        int _NewCardApplicationID = -1;

        clsNewCardApplication _NewCardApplicationInfo;
        public ctrlNewCardApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int NewCardApplicationID)
        {
             _NewCardApplicationInfo = clsNewCardApplication.FindNewCardApplicationByID(NewCardApplicationID);
            if (_NewCardApplicationInfo == null)
            {
                MessageBox.Show($"Error: No Card Application Found With ID[{_NewCardApplicationInfo}]",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _NewCardApplicationID = NewCardApplicationID;

            int CardID = _NewCardApplicationInfo.GetActiveCard();
            llbViewCardInfo.Enabled = (CardID != -1);

            lblNewCardApplicationID.Text = NewCardApplicationID.ToString();
            lblCardType.Text = clsCardType.FindCardTypeByID(_NewCardApplicationInfo.CardTypeID).CardName;
            ctrlApplicationInfo1.LoadApplicationBasicInfo(_NewCardApplicationInfo.ApplicationID);
            
        }

        private void llbViewCardInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Show Card Info
        }
    }
}

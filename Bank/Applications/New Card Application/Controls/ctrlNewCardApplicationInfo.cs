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

            lblNewCardApplicationID.Text = NewCardApplicationID.ToString();
            lblCardType.Text = clsCardType.FindCardTypeByID(_NewCardApplicationInfo.CardTypeID).CardName;
            lblApplicationID.Text = _NewCardApplicationInfo.ApplicationID.ToString();
            lblApplicationType.Text = clsApplicationType.FindApplicationTypeByID(_NewCardApplicationInfo.ApplicationTypeID).TypeTitle;
            lblApplicationDate.Text = clsFormat.GetDateFormat(_NewCardApplicationInfo.ApplicationDate);
            lblApplicantFullName.Text = _NewCardApplicationInfo.PersonFullName;
            lblStatus.Text = _NewCardApplicationInfo.StatusText;
            lblAccountNumber.Text = _NewCardApplicationInfo.AccountNumber;
            lblPaidFees.Text = _NewCardApplicationInfo.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindUserByID( _NewCardApplicationInfo.CreatedBy).UserName;
        }

        private void llbViewClientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsAccount AccountInfo = clsAccount.FindAccountByAccountNumber(lblAccountNumber.Text);
            frmClientInfo frm = new frmClientInfo(AccountInfo.ClientInfo.ClientID);
            frm.ShowDialog();
        }

        private void llbViewCardInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int CardID = clsCard.IsCardExistForAccountID(clsAccount.FindAccountByAccountNumber(lblAccountNumber.Text).AccountID,
                                                        clsCardType.FindCardTypeByName(lblCardType.Text).CardTypeID);
            if(CardID == -1)
            {
                MessageBox.Show("No Active Card Exists","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            

        }
    }
}

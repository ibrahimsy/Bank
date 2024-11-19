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

namespace Bank.Cards
{
    public partial class ctrlCardInfo : UserControl
    {
        int _CardID = -1;
        public int CardID
        {
            get
            {
                return _CardID;
            }
        }
        public ctrlCardInfo()
        {
            InitializeComponent();
        }

        public void LoadCardInfoByCardID(int CardID)
        {
            clsCard CardInfo = clsCard.FindCardByID(CardID);
            if (CardInfo == null) 
            {
                MessageBox.Show($"No Client Was Found With ID [{CardID}]","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _CardID = CardID;
            lblCardID.Text = CardID.ToString();
            lblCardNumber.Text = CardInfo.CardNumber;
            lblHolderFullName.Text = CardInfo.AccountInfo.FullName;
            lblPinCode.Text = CardInfo.PinCode;
            lblCVV.Text = CardInfo.CVV;
            lblIssueReason.Text = CardInfo.IssueReasonText;
            lblApplicationID.Text = CardInfo.ApplicationID.ToString();
            lblIssueDate.Text = clsFormat.GetDateFormat( CardInfo.IssueDate);
            lblExpirationDate.Text = clsFormat.GetDateFormat(CardInfo.ExpirationDate);
            lblLinkedAccountNumber.Text = CardInfo.AccountInfo.AccountNumber;
            lblStatus.Text = CardInfo.StatusText;
            lblCardType.Text = CardInfo.CardTypeInfo.CardName;
            lblCreatedBy.Text = CardInfo.UserInfo.UserName;
        }

        public void LoadCardInfoByCardNumber(string CardNumber)
        {
            clsCard CardInfo = clsCard.FindCardByCardNumber(CardNumber);
            if (CardInfo == null)
            {
                MessageBox.Show($"No Client Was Found With ID [{CardID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _CardID = CardID;
            lblCardID.Text = CardID.ToString();
            lblCardNumber.Text = CardInfo.CardNumber;
            lblHolderFullName.Text = CardInfo.AccountInfo.FullName;
            lblPinCode.Text = CardInfo.PinCode;
            lblCVV.Text = CardInfo.CVV;
            lblIssueReason.Text = CardInfo.IssueReasonText;
            lblApplicationID.Text = CardInfo.ApplicationID.ToString();
            lblIssueDate.Text = clsFormat.GetDateFormat(CardInfo.IssueDate);
            lblExpirationDate.Text = clsFormat.GetDateFormat(CardInfo.ExpirationDate);
            lblLinkedAccountNumber.Text = CardInfo.AccountInfo.AccountNumber;
            lblStatus.Text = CardInfo.StatusText;
            lblCardType.Text = CardInfo.CardTypeInfo.CardName;
            lblCreatedBy.Text = CardInfo.UserInfo.UserName;
        }

    }
}

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
        clsCard _CardInfo;
        public clsCard SelectedCardInfo
        {
            get
            {
                return _CardInfo;
            }
        }
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
            _CardInfo = clsCard.FindCardByID(CardID);
            if (_CardInfo == null)
            {
                MessageBox.Show($"No Client Was Found With ID [{CardID}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _CardID = CardID;
            lblCardID.Text = CardID.ToString();
            lblCardNumber.Text = _CardInfo.CardNumber;
            lblHolderFullName.Text = _CardInfo.AccountInfo.FullName;
            lblPinCode.Text = _CardInfo.PinCode;
            lblCVV.Text = _CardInfo.CVV;
            lblIssueReason.Text = _CardInfo.IssueReasonText;
            lblApplicationID.Text = _CardInfo.ApplicationID.ToString();
            lblIssueDate.Text = clsFormat.GetDateFormat(_CardInfo.IssueDate);
            lblExpirationDate.Text = clsFormat.GetDateFormat(_CardInfo.ExpirationDate);
            lblLinkedAccountNumber.Text = _CardInfo.AccountInfo.AccountNumber;
            lblStatus.Text = _CardInfo.StatusText;
            lblCardType.Text = _CardInfo.CardTypeInfo.CardName;
            lblCreatedBy.Text = _CardInfo.UserInfo.UserName;
        }

        public void LoadCardInfoByCardNumber(string CardNumber)
        {
            _CardInfo = clsCard.FindCardByCardNumber(CardNumber);
            if (_CardInfo == null)
            {
                _CardID = -1;
                MessageBox.Show($"No Card Was Found With Card Number [{CardNumber}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _CardID = _CardInfo.CardID;
            lblCardID.Text = _CardID.ToString();
            lblCardNumber.Text = _CardInfo.CardNumber;
            lblHolderFullName.Text = _CardInfo.AccountInfo.FullName;
            lblPinCode.Text = new string('*', _CardInfo.PinCode.Length);
            lblCVV.Text = new string('*', _CardInfo.CVV.Length);
            lblIssueReason.Text = _CardInfo.IssueReasonText;
            lblApplicationID.Text = _CardInfo.ApplicationID.ToString();
            lblIssueDate.Text = clsFormat.GetDateFormat(_CardInfo.IssueDate);
            lblExpirationDate.Text = clsFormat.GetDateFormat(_CardInfo.ExpirationDate);
            lblLinkedAccountNumber.Text = _CardInfo.AccountInfo.AccountNumber;
            lblStatus.Text = _CardInfo.StatusText;
            lblCardType.Text = _CardInfo.CardTypeInfo.CardName;
            lblCreatedBy.Text = _CardInfo.UserInfo.UserName;
        }

        public void ResetDefaultValue()
        {
            lblCardID.Text = "[ ? ]";
            lblCardNumber.Text = "[ ? ]";
            lblHolderFullName.Text = "[ ? ]";
            lblPinCode.Text = "[ ? ]";
            lblCVV.Text = "[ ? ]";
            lblIssueReason.Text = "[ ? ]";
            lblApplicationID.Text = "[ ? ]";
            lblIssueDate.Text = "[ ? ]";
            lblExpirationDate.Text = "[ ? ]";
            lblLinkedAccountNumber.Text = "[ ? ]";
            lblStatus.Text = "[ ? ]";
            lblCardType.Text = "[ ? ]";
            lblCreatedBy.Text = "[ ? ]";
        }
    }
}

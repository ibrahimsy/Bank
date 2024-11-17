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

        public ctrlNewCardApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int NewCardApplicationID)
        {
            clsNewCardApplication _NewCardApplicationInfo = clsNewCardApplication.FindNewCardApplicationByID(NewCardApplicationID);
            if (_NewCardApplicationInfo == null)
            {
                MessageBox.Show($"Error: No Card Application Found With ID[{_NewCardApplicationInfo}]",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblNewCardApplicationID.Text = _NewCardApplicationID.ToString();
            lblCardType.Text = clsCardType.FindCardTypeByID(_NewCardApplicationInfo.CardTypeID).CardName;
            lblApplicationID.Text = _NewCardApplicationInfo.ApplicationID.ToString();
            lblApplicationType.Text = clsApplicationType.FindApplicationTypeByID(_NewCardApplicationInfo.ApplicationTypeID).TypeTitle;
            lblApplicationDate.Text = clsFormat.GetDateFormat(_NewCardApplicationInfo.ApplicationDate);
            lblApplicantFullName.Text = _NewCardApplicationInfo.PersonFullName;
            lblStatus.Text = _NewCardApplicationInfo.StatusText;
            lblAccountNumber.Text = _NewCardApplicationInfo.AccountNumber;
            lblPaidFees.Text = _NewCardApplicationInfo.PaidFees.ToString();
            lblCreatedBy.Text = _NewCardApplicationInfo.UserInfo.UserName;
        }
    }
}

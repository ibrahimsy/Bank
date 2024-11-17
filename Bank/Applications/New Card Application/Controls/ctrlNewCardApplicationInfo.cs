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

        public ctrlNewCardApplicationInfo(int NewCardApplicationID)
        {
            InitializeComponent();
            _NewCardApplicationID = NewCardApplicationID;
        }

        public void LoadInfo()
        {
            clsNewCardApplication _NewCardApplicationInfo = clsNewCardApplication.FindNewCardApplicationByID(_NewCardApplicationID);
            if (_NewCardApplicationInfo == null)
            {
                MessageBox.Show($"Error: No Card Application Found With ID[{_NewCardApplicationInfo}]",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //lblNewCardApplicationID.Text = _NewCardApplicationID.ToString();
            //lblCardType.Text = clsCardType.FindCardTypeByID(_NewCardApplicationInfo.CardTypeID).CardName;
            //lblBasicApplicationID.Text = _NewCardApplicationInfo.ApplicationID.ToString();
            //lblApplicationType.Text = clsApplicationType.FindApplicationTypeByID(_NewCardApplicationInfo.ApplicationTypeID).TypeTitle;
            //lblApplicationDate.Text = clsFormat.GetDateFormat(_NewCardApplicationInfo.ApplicationDate);
            //lblApplicantFullName.Text = _NewCardApplicationInfo.AccountInfo.ClientInfo.PersonInfo.FullName;
            //lblApplicationStatus.Text = _NewCardApplicationInfo.StatusText;
            //lblAccountNumber.Text = _NewCardApplicationInfo.AccountInfo.AccountNumber;
            //lblPaidFees.Text = _NewCardApplicationInfo.PaidFees.ToString();
            //lblCreatedBy.Text = _NewCardApplicationInfo.UserInfo.UserName;
        }
    }
}

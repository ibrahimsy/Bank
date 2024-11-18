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

namespace Bank.Applications.Controls
{
    public partial class ctrlApplicationInfo : UserControl
    {
        clsApplication _ApplicationInfo;
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        public void LoadApplicationBasicInfo(int ApplicationID)
        {
            _ApplicationInfo = clsApplication.FindApplicationByID(ApplicationID);
            if (_ApplicationInfo == null)
            {
                MessageBox.Show($"Error : No Application Found With ID [{ApplicationID}]",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = ApplicationID.ToString();
            lblApplicationType.Text = clsApplicationType.FindApplicationTypeByID(_ApplicationInfo.ApplicationTypeID).TypeTitle;
            lblApplicationDate.Text = clsFormat.GetDateFormat(_ApplicationInfo.ApplicationDate);
            lblApplicantFullName.Text = _ApplicationInfo.ApplicantFullName;
            lblStatus.Text = _ApplicationInfo.StatusText;
            lblAccountNumber.Text = _ApplicationInfo.AccountInfo.AccountNumber;
            lblPaidFees.Text = _ApplicationInfo.PaidFees.ToString();
            lblCreatedBy.Text = _ApplicationInfo.UserInfo.UserName;
        }

        private void llbViewClientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmClientInfo frm = new frmClientInfo(_ApplicationInfo.AccountInfo.ClientID);
            frm.ShowDialog();
        }
    }
}

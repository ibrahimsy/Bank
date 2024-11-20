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

namespace Bank.Applications.Replace_Lost_Or_Damage_Card
{
    public partial class frmReplaceForLostOrDamageCard : Form
    {
        clsApplication.enApplicationTypes _IssueReson;
        public frmReplaceForLostOrDamageCard(clsApplication.enApplicationTypes IssueReson)
        {
            InitializeComponent();
            _IssueReson = IssueReson;
        }

        void _ResetDefaultValue()
        {
            if(_IssueReson == clsApplication.enApplicationTypes.ReplacementLostCard)
            {
                lblTitle.Text = "Replace For Lost";
                this.Text = lblTitle.Text;
            }
            else
            {
                lblTitle.Text = "Replace For Damage";
                this.Text = lblTitle.Text;
            }

            lblApplicationDate.Text = clsFormat.GetDateFormat( DateTime.Now);
            lblApplicationFees.Text = clsApplicationType.FindApplicationTypeByID((int)_IssueReson).Fees.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
        }

        private void frmReplaceForLostOrDamageCard_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
        }
    }
}

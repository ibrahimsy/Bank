using Bank.Cards;
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
using static BankBussiness.clsApplication;
using static BankBussiness.clsCard;

namespace Bank.Applications.Replace_Lost_Or_Damage_Card
{
    public partial class frmReplaceForLostOrDamageCard : Form
    {
        clsApplication.enApplicationTypes _ApplicationType;
        int _SelectedCardID = -1;
        int _NewCardID = -1;
        public frmReplaceForLostOrDamageCard(clsApplication.enApplicationTypes ApplicationType)
        {
            InitializeComponent();
            _ApplicationType = ApplicationType;
        }

        void _ResetDefaultValue()
        {
            if(_ApplicationType == clsApplication.enApplicationTypes.ReplacementLostCard)
            {
                lblTitle.Text = "Replace For Lost";
                this.Text = lblTitle.Text;
            }
            else
            {
                lblTitle.Text = "Replace For Damage";
                this.Text = lblTitle.Text;
            }
            btnIssue.Enabled = false;
            llbShowCardHistory.Enabled = false;
            llbShowNewCardInfo.Enabled = false;

            lblApplicationDate.Text = clsFormat.GetDateFormat( DateTime.Now);
            lblApplicationFees.Text = clsApplicationType.FindApplicationTypeByID((int)_ApplicationType).Fees.ToString();
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
        }

        private void frmReplaceForLostOrDamageCard_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
        }
        
        private void ctrlCardInfoWihFilter1_OnCardSelected(int obj)
        {
            _SelectedCardID = obj;
            lblOldCardID.Text = obj.ToString();
            llbShowCardHistory.Enabled = (_SelectedCardID != -1);
            btnIssue.Enabled = (_SelectedCardID != -1);
            
            if (_SelectedCardID == -1)
            {
                ctrlCardInfoWihFilter1.ResetCardInfo();
                return;
            }

            if (!ctrlCardInfoWihFilter1.CardInfo.IsActive)
            {
                MessageBox.Show("Selected License Is Not Active ,Choose Another One",
                    "Not Allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            } 
           
        }

        clsCard.enIssueReason _GetIssueReason()
        {
            if (_ApplicationType == clsApplication.enApplicationTypes.ReplacementDamageCard)
                return clsCard.enIssueReason.ReplacmentForDamage;
            else
                return clsCard.enIssueReason.ReplacmentForLost;
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Replacment The New Card ?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsCard NewCard = ctrlCardInfoWihFilter1.CardInfo.Replace(_GetIssueReason(),clsGlobalSettings.CurrentUser.UserID);
            if (NewCard == null)
            {
                MessageBox.Show("Faild To Issue A Replacment For This Card.",
                                 "Faild",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                return;
            }

            _NewCardID = NewCard.CardID;
            lblReplaceCardID.Text = NewCard.CardID.ToString();
            lblRApplicationID.Text = NewCard.ApplicationID.ToString();

            MessageBox.Show($"Card Replaced Successfuly With ID [{_NewCardID}]","",MessageBoxButtons.OK,MessageBoxIcon.Information);

            btnIssue.Enabled = false;
            ctrlCardInfoWihFilter1.FilterEnabled = false;
            llbShowNewCardInfo.Enabled = true;
            llbShowNewCardInfo.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbShowNewCardInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowCardInfo frm = new frmShowCardInfo(_NewCardID);
            frm.ShowDialog();
        }
    }
}

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
        clsApplication.enApplicationTypes _IssueReason;
        int _SelectedCardID = -1;
        public frmReplaceForLostOrDamageCard(clsApplication.enApplicationTypes IssueaReson)
        {
            InitializeComponent();
            _IssueReason = IssueaReson;
        }

        void _ResetDefaultValue()
        {
            if(_IssueReason == clsApplication.enApplicationTypes.ReplacementLostCard)
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
            lblApplicationFees.Text = clsApplicationType.FindApplicationTypeByID((int)_IssueReason).Fees.ToString();
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
                return;   
           
        }

        bool _HandleReplaceCardApplication(ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicantAccountID = ctrlCardInfoWihFilter1.CardInfo.AccountID;
            Application.ApplicationTypeID = (int)_IssueReason;
            Application.ApplicationDate = DateTime.Now;
            Application.Status = enApplicationStatus.Completed;
            Application.PaidFees = clsApplicationType.FindApplicationTypeByID((int)_IssueReason).Fees;
            Application.CreatedBy = clsGlobalSettings.CurrentUser.UserID;


            if (Application.Save())
            {
                ApplicationID = Application.ApplicationID;
                return true;
            }else
                return false;
        }


        private void btnIssue_Click(object sender, EventArgs e)
        {
            int ReplaceApplicationID = -1;
            if (!_HandleReplaceCardApplication(ref ReplaceApplicationID))
            {
                MessageBox.Show("An Error Occurred","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            clsCard ReplacementCard = new clsCard();

            ReplacementCard.AccountID = ctrlCardInfoWihFilter1.CardInfo.AccountID;
            ReplacementCard.CardNumber = ctrlCardInfoWihFilter1.CardInfo.CardNumber;
            ReplacementCard.PinCode = ctrlCardInfoWihFilter1.CardInfo.PinCode;
            ReplacementCard.CVV = ctrlCardInfoWihFilter1.CardInfo.CVV;
            ReplacementCard.IssueDate = DateTime.Now;
            ReplacementCard.ExpirationDate = DateTime.Now.AddYears(clsCardType.FindCardTypeByID(ctrlCardInfoWihFilter1.CardInfo.CardTypeID).DefaultValidationLength);
            ReplacementCard.Status = enCardStatus.Active;
            ReplacementCard.CardTypeID = ctrlCardInfoWihFilter1.CardInfo.CardTypeID;
            ReplacementCard.ApplicationID = ReplaceApplicationID;
            ReplacementCard.IssueReason = (clsCard.enIssueReason)_IssueReason;
            ReplacementCard.CreatedBy = clsGlobalSettings.CurrentUser.UserID;





            llbShowNewCardInfo.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

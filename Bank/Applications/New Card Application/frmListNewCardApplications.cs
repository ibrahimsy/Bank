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
using static BankBussiness.clsCard;

namespace Bank.Applications.New_Card_Application
{
    public partial class frmListNewCardApplications : PermissionForm
    {
        DataTable _dtNewCardApplications;
        public frmListNewCardApplications()
        {
            InitializeComponent();
        }
        /*
        None
        N.C.App ID
        App ID
        Account Number
        Card Type
        Status
         */
        string _ColumnText(string ColumnName)
        {
            switch (ColumnName)
            {
                case "N.C.App ID":
                    return "NewCardApplicationID";
                case "App ID":
                    return "ApplicationID";
                case "Account Number":
                    return "AccountNumber";
                case "Card Type":
                    return "CardName";
                case "Full Name":
                    return "FullName";
                case "Status":
                    return "Status";

                default:
                    return "";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewCardApplication_Click(object sender, EventArgs e)
        {
            frmAddNewCardApplication frm = new frmAddNewCardApplication();
            frm.ShowDialog();
            frmListNewCardApplications_Load(null, null);
        }

        private void frmListNewCardApplications_Load(object sender, EventArgs e)
        {
            _dtNewCardApplications = clsNewCardApplication.GetNewCardApplicationsList();
            dgvNewCardApplications.DataSource = _dtNewCardApplications;
            lblRecordsCount.Text = _dtNewCardApplications.Rows.Count.ToString();


            if (_dtNewCardApplications.Rows.Count > 0)
            {
                dgvNewCardApplications.Columns[0].HeaderText = "N.C.App ID";

                dgvNewCardApplications.Columns[1].HeaderText = "Base App ID";

                dgvNewCardApplications.Columns[2].HeaderText = "Card Type";

                dgvNewCardApplications.Columns[3].HeaderText = "Account Number";

                dgvNewCardApplications.Columns[4].HeaderText = "Full Name";

                dgvNewCardApplications.Columns[5].HeaderText = "Application Date";

                dgvNewCardApplications.Columns[6].HeaderText = "Status";
            }

            cbFilterBy.SelectedIndex = 0;
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowNewCardApplicationInfo frm = new frmShowNewCardApplicationInfo((int)dgvNewCardApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                _dtNewCardApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtNewCardApplications.Rows.Count.ToString();

                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text == "")
            {
                _dtNewCardApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _dtNewCardApplications.Rows.Count.ToString();
                return;
            }
            string FilterColumn = _ColumnText(cbFilterBy.Text);

            string FilterValue = txtFilterValue.Text;

            if (FilterColumn == "ApplicationID" || FilterColumn == "NewCardApplicationID")
            {
                _dtNewCardApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }
            else
            {
                _dtNewCardApplications.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = _dtNewCardApplications.DefaultView.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "N.C.App ID" || cbFilterBy.Text == "App ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void editNewCardApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewCardApplication frm = new frmAddNewCardApplication((int)dgvNewCardApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListNewCardApplications_Load(null, null);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int NewCardApplicationID = (int)dgvNewCardApplications.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Are You Sure You Want To Delete Application With ID[{NewCardApplicationID}]",
                                                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                return;

            clsNewCardApplication NewCardApplicatonInfo = clsNewCardApplication.FindNewCardApplicationByID(NewCardApplicationID);

            if (NewCardApplicatonInfo.Delete())
            {
                MessageBox.Show($"Application With ID[{NewCardApplicationID}] Deleted Successfully",
                                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListNewCardApplications_Load(null, null);
            }
            else
            {
                MessageBox.Show($"Error :An Error Occured",
                                 "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int NewCardApplicationID = (int)dgvNewCardApplications.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Are You Sure You Want To Cancel Application With ID[{NewCardApplicationID}]",
                                                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                return;

            clsNewCardApplication NewCardApplicationInfo = clsNewCardApplication.FindNewCardApplicationByID(NewCardApplicationID);
            if (NewCardApplicationInfo != null)
            {
                if (NewCardApplicationInfo.Cancel())
                {
                    MessageBox.Show($"Application With ID[{NewCardApplicationID}] Canceled",
                                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmListNewCardApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show($"Error :Couldn't Cancel Application",
                                     "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            int NewCardApplicationID = (int)dgvNewCardApplications.CurrentRow.Cells[0].Value;
            clsNewCardApplication NewCardApplicationInfo = clsNewCardApplication.FindNewCardApplicationByID(NewCardApplicationID);
            if (NewCardApplicationInfo != null)
            {
                if (NewCardApplicationInfo.SetCompleted())
                {
                    MessageBox.Show("Application Approved By Admin","Approved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frmListNewCardApplications_Load(null,null);
                }
                else
                {
                    MessageBox.Show("Error: Application Approve Faild", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int NewCardApplicationID = (int)dgvNewCardApplications.CurrentRow.Cells[0].Value;

            clsNewCardApplication NewCardApplicationInfo = clsNewCardApplication.FindNewCardApplicationByID(NewCardApplicationID);
            if (NewCardApplicationInfo == null) 
            {
                return;
            }

            bool IsCardIssued = (NewCardApplicationInfo.GetActiveCard() != -1);

            editNewCardApplicationToolStripMenuItem.Enabled = !IsCardIssued && (NewCardApplicationInfo.Status == clsApplication.enApplicationStatus.Pending);

            deleteApplicationToolStripMenuItem.Enabled = (NewCardApplicationInfo.Status == clsApplication.enApplicationStatus.Pending);

            cancelApplicationToolStripMenuItem.Enabled = !IsCardIssued && (NewCardApplicationInfo.Status != clsApplication.enApplicationStatus.Canceled);

            ApproveActivationtoolStripMenuItem.Enabled = (NewCardApplicationInfo.Status == clsApplication.enApplicationStatus.Pending) && CheckPermission(clsUser.enPermission.ApplicationCardApprove);

            issueCardToolStripMenuItem.Enabled = (NewCardApplicationInfo.Status == clsApplication.enApplicationStatus.Approved) && !IsCardIssued;

            showCardInfoToolStripMenuItem.Enabled = IsCardIssued;

        }

        private void issueCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int NewCardApplicationID = (int)dgvNewCardApplications.CurrentRow.Cells[0].Value;

            clsNewCardApplication NewCardApplicationInfo = clsNewCardApplication.FindNewCardApplicationByID(NewCardApplicationID);
            if (NewCardApplicationInfo == null)
            {
                return;
            }

            clsCard Card = new clsCard();
            Card.AccountID = NewCardApplicationInfo.ApplicantAccountID;
            Card.ExpirationDate = DateTime.Now.AddYears(clsCardType.FindCardTypeByID(NewCardApplicationInfo.CardTypeID).DefaultValidationLength);
            Card.Status = enCardStatus.Active;
            Card.CardTypeID = NewCardApplicationInfo.CardTypeID;
            Card.IssueDate = DateTime.Now;
            Card.ApplicationID = NewCardApplicationInfo.ApplicationID;
            Card.IssueReason = enIssueReason.FirstTime;
            Card.CreatedBy = clsGlobalSettings.CurrentUser.UserID;

            if (Card.Save())
            {
                MessageBox.Show("Card Issued Successfuly","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error : An Error Occured ,Card Issue Faild", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

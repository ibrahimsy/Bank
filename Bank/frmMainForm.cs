using Bank.Accounts;
using Bank.AccountTypes;
using Bank.Application_Types;
using Bank.Applications.New_Card_Application;
using Bank.Applications.Replace_Lost_Or_Damage_Card;
using Bank.Branches;
using Bank.Cards;
using Bank.Cards.CardTypes;
using Bank.Client;
using Bank.Currencies;
using Bank.Global_Classes;
using Bank.People;
using Bank.Transactions;
using Bank.Users;
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

namespace Bank
{
    public partial class frmMainForm : PermissionForm
    {
        Form _LoginForm;
        frmManagePeople _PeopleForm ;
        frmManageUsers _UserForm;
        frmManageAccounts _ManageAccountsForm;
        public frmMainForm(Form LoginForm)
        {
            InitializeComponent();
            _LoginForm = LoginForm;
            this.WindowState = FormWindowState.Maximized;
        }


        void _OpenChildForm(Form ChildForm)
        {   
            ChildForm.WindowState = FormWindowState.Maximized;
            ChildForm.Show();   
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
                _PeopleForm = new frmManagePeople();
                _OpenChildForm(_PeopleForm);
            
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DoesUserHavePermission(clsUser.enPermission.UserManagment))
                return;

                _UserForm = new frmManageUsers();
                _OpenChildForm(_UserForm);

        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           if(MessageBox.Show("Are You Sure You Want To Close Program",
                            "Confirm",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _LoginForm.Show();
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void showCurrentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobalSettings.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void addClientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddClient frm = new frmAddClient();
            frm.ShowDialog();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageClients frm = new frmManageClients();
            frm.ShowDialog();
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (!CheckPermission(clsUser.enPermission.AddPerson))
                addPersontToolStripMenuItem.Enabled = false;
            if (!CheckPermission(clsUser.enPermission.AddClient))
                addClientToolStripMenuItem1.Enabled = false;

        }

        private void toolStripMenuItem4_Click_1(object sender, EventArgs e)
        {
            frmBrancesManagment frm = new frmBrancesManagment();
            frm.ShowDialog();
        }

        private void accountTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountTypesManagment frm = new frmAccountTypesManagment();
            frm.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            frmCurrencyList frm = new frmCurrencyList();
            frm.ShowDialog();
        }

        private void _RefereshMainFormWindows()
        {
            lblClientsCount.Text = clsClient.GetClientsCount().ToString();
            lblTotalUsers.Text = clsUser.GetUsersCount().ToString();
            lblTotalAccounts.Text = clsAccount.GetAccountsCount().ToString();
            lblTotalBalances.Text = clsAccount.GetTotalBalances().ToString() + " $";
        }
        
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            _RefereshMainFormWindows();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
           frmTransactionsList frm = new frmTransactionsList();
            frm.ShowDialog();
        }

        private void requestBlockUnBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RefereshMainInfo_Click(object sender, EventArgs e)
        {
            _RefereshMainFormWindows();
        }

        private void accountTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmManageAccounts frm = new frmManageAccounts();
            frm.ShowDialog();
        }

        private void manageTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountTypesManagment frm = new frmAccountTypesManagment();
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void manageCardTpesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListCardTypes frm = new frmListCardTypes();
            frm.ShowDialog();
        }

        private void requestDebitCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewCardApplication frm = new frmAddNewCardApplication();
            frm.ShowDialog();
        }

        private void manageNewCardApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListNewCardApplications frm = new frmListNewCardApplications();
            frm.ShowDialog();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            frmCardsList frm = new frmCardsList();  
            frm.ShowDialog();
        }

        private void lostCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceForLostOrDamageCard frm = new frmReplaceForLostOrDamageCard(clsApplication.enApplicationTypes.ReplacementLostCard);
            frm.ShowDialog();
        }

        private void destroyedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceForLostOrDamageCard frm = new frmReplaceForLostOrDamageCard(clsApplication.enApplicationTypes.ReplacementDamageCard);
            frm.ShowDialog();
        }
    }
}

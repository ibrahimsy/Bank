﻿using Bank.Accounts;
using Bank.AccountTypes;
using Bank.Branches;
using Bank.Client;
using Bank.Currencies;
using Bank.Global_Classes;
using Bank.People;
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

        void _CheckForOpenedForm()
        {  
            if(this.MdiChildren.Length == 1)
            {
              
                _RefereshMainFormWindows();
            }
    
        } 

        void _OpenChildForm(Form ChildForm)
        {
          

            ChildForm.MdiParent = this;
            ChildForm.WindowState = FormWindowState.Maximized;
            ChildForm.FormClosed+= (s,args) => _CheckForOpenedForm();
            ChildForm.Show();
            
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_PeopleForm == null || _PeopleForm.IsDisposed)
            {
                _PeopleForm = new frmManagePeople();
                _OpenChildForm(_PeopleForm);
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DoesUserHavePermission(clsUser.enPermission.UserManagment))
                return;

            if (_UserForm == null || _UserForm.IsDisposed)
            {
                _UserForm = new frmManageUsers();
                _OpenChildForm(_UserForm);
                
            }
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
            if (_ManageAccountsForm == null || _ManageAccountsForm.IsDisposed)
            {
                 _ManageAccountsForm = new frmManageAccounts();
                _OpenChildForm(_ManageAccountsForm);
            }
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
    }
}

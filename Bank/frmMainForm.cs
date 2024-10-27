using Bank.Client;
using Bank.Global_Classes;
using Bank.People;
using Bank.Users;
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
    public partial class frmMainForm : Form
    {
        Form _LoginForm;
        public frmMainForm(Form LoginForm)
        {
            InitializeComponent();
            _LoginForm = LoginForm;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog(); 
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
            frmAddEditClient frm = new frmAddEditClient();
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

    }
}

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

namespace Bank.Login
{
    public partial class frmLogin : Form
    {
        string _UserName = "";
        string _Password = "";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _UserName = txtUsername.Text;
            _Password = txtPassword.Text;

            if (!clsUser.IsExistByUserNameAndPassword(_UserName,_Password))
            {
                MessageBox.Show("Invalid Username/Password ,try Again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            clsGlobalSettings.CurrentUser = clsUser.FindUserByUserName(_UserName);
            
            if (!clsGlobalSettings.CurrentUser.IsActive)
            {
                MessageBox.Show("Your Account Is not Active ,Contact Your Admin.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (chkRememberMe.Checked)
                clsGlobalSettings.RememberUserNameAndPassword(_UserName, _Password);
            else
                clsGlobalSettings.RememberUserNameAndPassword("", "");


            this.Hide();

            frmMainForm frm = new frmMainForm(this);
            frm.ShowDialog();

            //this.Close();


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "";
            string Password = "";

            if(clsGlobalSettings.GetRestoredUserNameAndPassword(ref Username,ref Password))
            {
                txtUsername.Text = Username;
                txtPassword.Text = Password;

                chkRememberMe.Checked = true;
            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Text = "";

                chkRememberMe.Checked = false;
            }
        }
    }
}

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

            if (clsUser.IsExistByUserNameAndPassword(_UserName,_Password))
            {

            }
        }
    }
}

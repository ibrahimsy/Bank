using Bank.Accounts;
using Bank.Beneficiaries;
using Bank.Client;
using Bank.Login;
using Bank.People;
using Bank.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new frmTest());
        }
    }
}

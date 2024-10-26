using Bank.People.Controls;
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

namespace Bank.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        int _UserID;
        clsUser _UserInfo;
        public int UserID
        {
            get
            {
                return _UserID;
            }
        }
       
        public clsUser UserInfo
        {
            get
            {
                return _UserInfo;
            }
        }

        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
             _UserInfo = clsUser.FindUserByID(UserID);
            if (_UserInfo == null)
            {
                MessageBox.Show($"User With ID [{UserID}] Is Not Found",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            _UserID = UserID;
            ctrlPersonInfo1.LoadPersonInfo(_UserInfo.PersonID);
            lblUserID.Text = UserID.ToString();
            lblUserName.Text = _UserInfo.UserName.ToString();
            lblIsActive.Text = _UserInfo.IsActive ?"Yes":"No";
        }
    }
}

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

namespace Bank.Applications.New_Card_Application
{
    public partial class frmAddNewCardApplication : Form
    {
        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        int _AccountID = -1;
        clsAccount _AccountInfo;
        public frmAddNewCardApplication()
        {
            InitializeComponent();
        }

        void _FillCardTypesComboBox()
        {
            DataTable dtCardTypes = clsCardType.GetCardTypesList();
            foreach (DataRow row in dtCardTypes.Rows)
            {
                cbCardTypes.Items.Add(row["CardName"]);
            }
            cbCardTypes.SelectedIndex = 0;
        }

        void _ResetDefaultData()
        {
            _FillCardTypesComboBox();
            lblApplicationDate.Text = clsFormat.GetDateFormat(DateTime.Now);
            lblApplicationStatus.Text = "New";
            lblCreatedBy.Text = clsGlobalSettings.CurrentUser.UserName;
            lblApplicationFee.Text = clsApplicationType.FindApplicationTypeByID((int)clsApplication.enApplicationTypes.IssueNewCard).Fees.ToString();

            tpApplicationInfo.Enabled = false;
            btnSave.Enabled = false;
            ctrlClientCardWithFilter1.TextValueFocus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void frmAddNewCardApplication_Load(object sender, EventArgs e)
        {
            ctrlClientCardWithFilter1.FilterByAccountNumber = false;
            _ResetDefaultData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlClientCardWithFilter1.ClientID == -1)
            {
                MessageBox.Show("Select An Account First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedTab = tpApplicationInfo;
            tpApplicationInfo.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}

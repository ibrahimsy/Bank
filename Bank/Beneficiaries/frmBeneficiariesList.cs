using Bank.Beneficiaries.Controls;
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

namespace Bank.Beneficiaries
{
    public partial class frmBeneficiariesList : Form
    {

        int _ClientID = -1;
        DataTable _dtBeneficiaries;
        
        ctrlBeneficiariesCard ctrlBCard;
        public frmBeneficiariesList(int ClientID)
        {
            InitializeComponent();
            _ClientID = ClientID;
        }
        void _GenerateBeneficiariesList()
        {

            foreach (DataRow row in _dtBeneficiaries.Rows)
            {
                ctrlBCard = new ctrlBeneficiariesCard();
                ctrlBCard.LoadInfo((int)row["BeneficiaryID"], (string)row["FullName"], (string)row["AccountNumber"]);
               
                flpPhoneList.Controls.Add(ctrlBCard);
                ctrlBCard.Click += _OnCardSelected;
            }
        }
        private void frmBeneficiariesList_Load(object sender, EventArgs e)
        {
            _dtBeneficiaries = clsClient.FindClientByID(_ClientID).GetClientBeneficiaries();
            _GenerateBeneficiariesList();
        }

        void _OnCardSelected(object sender, EventArgs e) 
        {
             MessageBox.Show($"Selected Beneficiary ID : {ctrlBCard.BeneficiaryID}");
        }

    }
}

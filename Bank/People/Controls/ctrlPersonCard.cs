using Bank.Properties;
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

namespace Bank.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        int _PersonID = -1;
        clsPerson _PersonInfo;

        public int PersonID
        {
            get
            {
                return _PersonID;
            }
            set
            {
                _PersonID = value;
            }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
            llEditPersonInfo.Enabled = false;
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonInfo = clsPerson.FindPersonByID(PersonID);
            if (_PersonInfo == null)
            {
                MessageBox.Show($"Person Not Found With ID [{_PersonID}]",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            _PersonID = PersonID;

            lblPersonID.Text = _PersonID.ToString();
            lblNationalNo.Text = _PersonInfo.NationalNo;
            lblFullName.Text = _PersonInfo.FullName;
            lblGendor.Text = _PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblEmail.Text = _PersonInfo.Email;  
            lblPhone.Text = _PersonInfo.Phone;
            lblAddress.Text = _PersonInfo.Address;
            lblCountry.Text = clsCountry.FindByID(_PersonInfo.NationalityCountryID).CountryName;
            llEditPersonInfo.Enabled = true;

            if (_PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            if (_PersonInfo.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _PersonInfo.ImagePath;
            }

        }

        public void LoadPersonInfo(string NationalNo)
        {
            _PersonInfo = clsPerson.FindPersonByNationalNo(NationalNo);
            if (_PersonInfo == null)
            {
                MessageBox.Show($"Person Not Found With National No : [{NationalNo}]",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            _PersonID = _PersonInfo.PersonID;

            lblPersonID.Text = _PersonInfo.PersonID.ToString();
            lblNationalNo.Text = NationalNo;
            lblFullName.Text = _PersonInfo.FullName;
            lblGendor.Text = _PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblEmail.Text = _PersonInfo.Email;
            lblPhone.Text = _PersonInfo.Phone;
            lblAddress.Text = _PersonInfo.Address;
            lblCountry.Text = clsCountry.FindByID(_PersonInfo.NationalityCountryID).CountryName;
            llEditPersonInfo.Enabled = true;

            if (_PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            if (_PersonInfo.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _PersonInfo.ImagePath;
            }

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.ShowDialog();

            LoadPersonInfo(PersonID);
        }
    }
}

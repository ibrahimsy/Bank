using Bank.Properties;
using Bank.Util;
using BankBussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bank.People
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void DataBackEventHandler(int PersonID);

        public event DataBackEventHandler DataBack;

        enum enMode { enAddNew = 1, enUpdate = 2 }
        enMode _Mode = enMode.enAddNew;

        clsPerson _PersonInfo;
        int _PersonID = -1;
        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.enUpdate;
        }

        void _FillComboBoxWithCountries()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }
            cbCountries.SelectedIndex = cbCountries.FindString("Syria");
        }

        void _ResetDefaultValue()
        {
            _FillComboBoxWithCountries();

            if (_Mode == enMode.enAddNew)
            {
                _PersonInfo = new clsPerson();

                this.Text = "ADD PERSON";
                lblTitle.Text = this.Text;
                rbMale.Checked = true;
                llRemoveImage.Visible = false;

                dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
                dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

                pbPersonImage.Image = Resources.Male_512;
            }
            else
            {
                this.Text = "UPDATE PERSON";
                lblTitle.Text = this.Text;
            }

        }
        
        void _LoadPersonInfo()
        {
            _PersonInfo = clsPerson.FindPersonByID(_PersonID);
            if (_PersonInfo == null)
            {
                MessageBox.Show($"No Person Found With ID = [{_PersonID}]","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lblPersonID.Text = _PersonInfo.PersonID.ToString();

            txtNationalNo.Text = _PersonInfo.NationalNo.ToString();
            txtFirstName.Text = _PersonInfo.FirstName.ToString();
            txtSecondName.Text = _PersonInfo.SecondName.ToString();
            txtThirdName.Text = _PersonInfo.ThirdName.ToString();
            txtLastName.Text = _PersonInfo.LastName.ToString();
            txtPhone.Text = _PersonInfo.Phone.ToString();
            txtEmail.Text = _PersonInfo.Email.ToString();
            txtAddress.Text = _PersonInfo.Address.ToString();

            dtpDateOfBirth.Value = _PersonInfo.DateOfBirth;
            cbCountries.SelectedIndex = cbCountries.FindString(_PersonInfo.CountryInfo.CountryName);
            if(_PersonInfo.Gendor == 0)
            {
                pbPersonImage.Image = Resources.Male_512;
                rbMale.Checked = true;
            }
            else
            {
                pbPersonImage.Image = Resources.Female_512;
                rbFemale.Checked = true;
            }
        
            string ImagePath = _PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbPersonImage.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Person Image Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            llRemoveImage.Visible = pbPersonImage.ImageLocation != null;
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.enUpdate)
            {
                _LoadPersonInfo();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Title = this.Text;
            openFileDialog1 .FileName = "Person Image";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.gif;*.bmp;*.png|All Files|*.*";
            openFileDialog1.FilterIndex = 1;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.ImageLocation = openFileDialog1.FileName;
                llRemoveImage.Visible = true;
            }
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if(rbMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;
            llRemoveImage.Visible = false;
        }

        private void txtInputs_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                errorProvider1.SetError(textBox,"This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBox,null);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                errorProvider1.SetError(txtNationalNo, "This Feild Is Required");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

            if (clsPerson.IsExistByNationalNo(txtNationalNo.Text.Trim()) && _Mode == enMode.enAddNew)
            {
                errorProvider1.SetError(txtNationalNo, "National Number Allready Exists");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                return;
            }

            if (!clsUtility.IsValidEmail(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, "Invalid Email");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        
        }

        bool _HandlePersonImage()
        {
            if (_PersonInfo.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_PersonInfo.ImagePath != "")
                {
                    if (File.Exists(_PersonInfo.ImagePath))
                    {
                        try
                        {
                            File.Delete(_PersonInfo.ImagePath);
                        }catch(Exception ex) 
                        {
                            return false;
                        }
                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceFile = pbPersonImage.ImageLocation;
                    if (clsUtility.CopyImageToProjectImagesFolder(ref SourceFile))
                    {
                        pbPersonImage.ImageLocation = SourceFile;
                        return true;
                    }
                    else
                        return false;
                }
            }
           return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Feild Is Not Valid,Put The Mouse On Red Icon.",
                                "Faild",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            _PersonInfo.FirstName = txtFirstName.Text.Trim();
            _PersonInfo.SecondName = txtSecondName.Text.Trim();
            _PersonInfo.ThirdName = txtThirdName.Text.Trim();
            _PersonInfo.LastName = txtLastName.Text.Trim();

            _PersonInfo.Phone = txtPhone.Text.Trim();
            _PersonInfo.Email = txtEmail.Text.Trim();
            _PersonInfo.Address = txtAddress.Text.Trim();

            _PersonInfo.NationalNo = txtNationalNo.Text.Trim();
            _PersonInfo.NationalityCountryID = clsCountry.FindByName(cbCountries.Text).CountryID;

            if (rbMale.Checked)
                _PersonInfo.Gendor = 0;
            else
                _PersonInfo.Gendor = 1;

            if (pbPersonImage.ImageLocation == null)
                _PersonInfo.ImagePath = "";
            else 
                _PersonInfo.ImagePath = pbPersonImage.ImageLocation;

            if (_PersonInfo.Save())
            {
                MessageBox.Show("Person Saved Successfuly","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                _Mode = enMode.enUpdate;
                this.Text = "UPDATE PERSON";

                lblTitle.Text = this.Text;
                lblPersonID.Text = _PersonInfo.PersonID.ToString();

                //Send Data Back
                DataBack?.Invoke(_PersonInfo.PersonID);
               
            }
            else
            {
                MessageBox.Show("An Error Occurred", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

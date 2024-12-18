﻿using Bank.Global_Classes;
using Bank.Util;
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

namespace Bank.People
{
    public partial class frmManagePeople :PermissionForm
    {
        DataTable _dtPeopleList;
        DataTable _dtPeople;
        public frmManagePeople()
        {
            InitializeComponent();
        }

        void _RefreshPeopleList()
        {
            _dtPeopleList = clsPerson.GetPeopleList();
            _dtPeople = _dtPeopleList.DefaultView.ToTable(true, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName",
                                                    "Gendor", "CountryName", "DateOfBirth", "Phone", "Email");
            dgvPeople.DataSource = _dtPeople;

            if (dgvPeople.Rows.Count > 0)
            {
                
                dgvPeople.Columns[0].HeaderText = "Person ID";
                //dgvPeople.Columns[0].Width = 100;

                dgvPeople.Columns[1].HeaderText = "National No";
                ///dgvPeople.Columns[1].Width = 100;

                dgvPeople.Columns[2].HeaderText = "First Name";
                //dgvPeople.Columns[2].Width = 100;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                //dgvPeople.Columns[3].Width = 100;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                //dgvPeople.Columns[4].Width = 100;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                //dgvPeople.Columns[5].Width = 100;

                dgvPeople.Columns[6].HeaderText = "Gendor";
                //dgvPeople.Columns[6].Width = 100;

                dgvPeople.Columns[7].HeaderText = "Country Name";
                //dgvPeople.Columns[7].Width = 100;

                dgvPeople.Columns[8].HeaderText = "Date Of Birth";
                //dgvPeople.Columns[8].Width = 100;

                dgvPeople.Columns[9].HeaderText = "Phone";
                //dgvPeople.Columns[9].Width = 100;

                dgvPeople.Columns[10].HeaderText = "Email";
                //dgvPeople.Columns[10].Width = 100;
            }


            lblRecordsCount.Text = _dtPeople.Rows.Count.ToString();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cbFilterBy.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string _ColumnText(string ColumnName)
        {
            switch (ColumnName)
            {
                case "Person ID":
                    return "PersonID";
                case "National No":
                    return "NationalNo";
                case "First Name":
                    return "FirstName";
                case "Second Name":
                    return "SecondName";
                case "Third Name":
                    return "ThirdName";
                case "Last Name":
                    return "LastName";
                case "Gendor":
                    return "Gendor";
                case "Nationality":
                    return "Nationality";
                case "Date Of Birth":
                    return "DateOfBirth";
                default:
                    return "";
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();

                txtFilterValue.Visible = false;
            }
            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text == "")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
                return;
            }
            string FilterColumn = _ColumnText(cbFilterBy.Text);

            string FilterValue = txtFilterValue.Text;

            if (FilterColumn == "PersonID" || FilterColumn == "DateOfBirth")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn,FilterValue);
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {

            if (!DoesUserHavePermission(clsUser.enPermission.AddPerson))
                return;

            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void editPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DoesUserHavePermission(clsUser.enPermission.EditPerson))
                return;

            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DoesUserHavePermission(clsUser.enPermission.AddPerson))
                return;

            frmAddEditPerson frm = new frmAddEditPerson();
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DoesUserHavePermission(clsUser.enPermission.EditPerson))
                return;

            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if (MessageBox.Show($"Are You Sure You Want To Delete Person With ID [{PersonID}]",
                                    "Confirm",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person Deleted Successfuly",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("You can't Delete This Person Because There Are Data Connected with.",
                                    "Faild",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DoesUserHavePermission(clsUser.enPermission.ShowPersonInfo))
                return;

            frmPersonInfo frm = new frmPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            if (!DoesUserHavePermission(clsUser.enPermission.ShowPersonInfo))
                return;

            frmPersonInfo frm = new frmPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }


    }
}

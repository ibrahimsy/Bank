namespace Bank.Beneficiaries
{
    partial class frmAddEditBeneficiary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSearchByTitle = new System.Windows.Forms.Label();
            this.pBeneficiaryCard = new System.Windows.Forms.Panel();
            this.lblBenefAccountNumber = new System.Windows.Forms.Label();
            this.lblBeneficiaryName = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbBeneficiary = new System.Windows.Forms.GroupBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbAccounts = new System.Windows.Forms.ComboBox();
            this.pBeneficiaryCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbBeneficiary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Account Number",
            "Card Number",
            "Mobile Number"});
            this.cbFilterBy.Location = new System.Drawing.Point(116, 64);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(247, 28);
            this.cbFilterBy.TabIndex = 1;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search By";
            // 
            // lblSearchByTitle
            // 
            this.lblSearchByTitle.AutoSize = true;
            this.lblSearchByTitle.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchByTitle.Location = new System.Drawing.Point(6, 112);
            this.lblSearchByTitle.Name = "lblSearchByTitle";
            this.lblSearchByTitle.Size = new System.Drawing.Size(91, 24);
            this.lblSearchByTitle.TabIndex = 3;
            this.lblSearchByTitle.Text = "Search Title";
            // 
            // pBeneficiaryCard
            // 
            this.pBeneficiaryCard.BackColor = System.Drawing.Color.PowderBlue;
            this.pBeneficiaryCard.Controls.Add(this.cbAccounts);
            this.pBeneficiaryCard.Controls.Add(this.lblBenefAccountNumber);
            this.pBeneficiaryCard.Controls.Add(this.lblBeneficiaryName);
            this.pBeneficiaryCard.Location = new System.Drawing.Point(10, 22);
            this.pBeneficiaryCard.Name = "pBeneficiaryCard";
            this.pBeneficiaryCard.Size = new System.Drawing.Size(347, 108);
            this.pBeneficiaryCard.TabIndex = 5;
            // 
            // lblBenefAccountNumber
            // 
            this.lblBenefAccountNumber.AutoSize = true;
            this.lblBenefAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenefAccountNumber.Location = new System.Drawing.Point(13, 35);
            this.lblBenefAccountNumber.Name = "lblBenefAccountNumber";
            this.lblBenefAccountNumber.Size = new System.Drawing.Size(224, 16);
            this.lblBenefAccountNumber.TabIndex = 6;
            this.lblBenefAccountNumber.Text = "Beneficiary Account (s) Number";
            // 
            // lblBeneficiaryName
            // 
            this.lblBeneficiaryName.AutoSize = true;
            this.lblBeneficiaryName.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaryName.Location = new System.Drawing.Point(11, 6);
            this.lblBeneficiaryName.Name = "lblBeneficiaryName";
            this.lblBeneficiaryName.Size = new System.Drawing.Size(160, 29);
            this.lblBeneficiaryName.TabIndex = 6;
            this.lblBeneficiaryName.Text = "Beneficiary Name";
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNickname.Location = new System.Drawing.Point(9, 139);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(160, 24);
            this.lblNickname.TabIndex = 6;
            this.lblNickname.Text = "Beneficiary Nickname";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank.Properties.Resources.AddBeneficiary;
            this.pictureBox1.Location = new System.Drawing.Point(403, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbBeneficiary);
            this.groupBox1.Controls.Add(this.txtFilterValue);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.cbFilterBy);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblSearchByTitle);
            this.groupBox1.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 328);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Beneficiary";
            // 
            // gbBeneficiary
            // 
            this.gbBeneficiary.Controls.Add(this.pBeneficiaryCard);
            this.gbBeneficiary.Controls.Add(this.txtNickname);
            this.gbBeneficiary.Controls.Add(this.lblNickname);
            this.gbBeneficiary.Location = new System.Drawing.Point(6, 139);
            this.gbBeneficiary.Name = "gbBeneficiary";
            this.gbBeneficiary.Size = new System.Drawing.Size(391, 181);
            this.gbBeneficiary.TabIndex = 11;
            this.gbBeneficiary.TabStop = false;
            // 
            // txtNickname
            // 
            this.txtNickname.Font = new System.Drawing.Font("Titillium Web", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNickname.Location = new System.Drawing.Point(174, 136);
            this.txtNickname.MaxLength = 20;
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(183, 30);
            this.txtNickname.TabIndex = 10;
            this.txtNickname.Validating += new System.ComponentModel.CancelEventHandler(this.txtNickname_Validating);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Titillium Web", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(116, 100);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(247, 30);
            this.txtFilterValue.TabIndex = 9;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Bank.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(431, 346);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Bank.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(527, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 36);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbAccounts
            // 
            this.cbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccounts.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccounts.FormattingEnabled = true;
            this.cbAccounts.Location = new System.Drawing.Point(16, 54);
            this.cbAccounts.Name = "cbAccounts";
            this.cbAccounts.Size = new System.Drawing.Size(199, 32);
            this.cbAccounts.TabIndex = 7;
            // 
            // frmAddEditBeneficiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 395);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddEditBeneficiary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditBeneficiary";
            this.Load += new System.EventHandler(this.frmAddEditBeneficiary_Load);
            this.pBeneficiaryCard.ResumeLayout(false);
            this.pBeneficiaryCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbBeneficiary.ResumeLayout(false);
            this.gbBeneficiary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSearchByTitle;
        private System.Windows.Forms.Panel pBeneficiaryCard;
        private System.Windows.Forms.Label lblBenefAccountNumber;
        private System.Windows.Forms.Label lblBeneficiaryName;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.GroupBox gbBeneficiary;
        private System.Windows.Forms.ComboBox cbAccounts;
    }
}
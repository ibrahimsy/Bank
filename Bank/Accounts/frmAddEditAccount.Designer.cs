namespace Bank.Accounts
{
    partial class frmAddEditAccount
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpClientInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlClientCardWithFilter1 = new Bank.Client.Controls.ctrlClientCardWithFilter();
            this.tpAccountInfo = new System.Windows.Forms.TabPage();
            this.cbAccountStatus = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cbBranches = new System.Windows.Forms.ComboBox();
            this.cbAccountType = new System.Windows.Forms.ComboBox();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkRequestForCard = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tpClientInfo.SuspendLayout();
            this.tpAccountInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Titillium Web", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1007, 36);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "ADD ACCOUNT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpClientInfo);
            this.tabControl1.Controls.Add(this.tpAccountInfo);
            this.tabControl1.Location = new System.Drawing.Point(33, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(990, 502);
            this.tabControl1.TabIndex = 31;
            // 
            // tpClientInfo
            // 
            this.tpClientInfo.Controls.Add(this.btnNext);
            this.tpClientInfo.Controls.Add(this.ctrlClientCardWithFilter1);
            this.tpClientInfo.Location = new System.Drawing.Point(4, 22);
            this.tpClientInfo.Name = "tpClientInfo";
            this.tpClientInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpClientInfo.Size = new System.Drawing.Size(982, 476);
            this.tpClientInfo.TabIndex = 0;
            this.tpClientInfo.Text = "Client Info";
            this.tpClientInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Bank.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(874, 431);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(92, 36);
            this.btnNext.TabIndex = 31;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlClientCardWithFilter1
            // 
            this.ctrlClientCardWithFilter1.ClientID = -1;
            this.ctrlClientCardWithFilter1.FilterEnabled = true;
            this.ctrlClientCardWithFilter1.Location = new System.Drawing.Point(21, 6);
            this.ctrlClientCardWithFilter1.Name = "ctrlClientCardWithFilter1";
            this.ctrlClientCardWithFilter1.Size = new System.Drawing.Size(945, 419);
            this.ctrlClientCardWithFilter1.TabIndex = 30;
            // 
            // tpAccountInfo
            // 
            this.tpAccountInfo.Controls.Add(this.chkRequestForCard);
            this.tpAccountInfo.Controls.Add(this.cbAccountStatus);
            this.tpAccountInfo.Controls.Add(this.txtNotes);
            this.tpAccountInfo.Controls.Add(this.cbBranches);
            this.tpAccountInfo.Controls.Add(this.cbAccountType);
            this.tpAccountInfo.Controls.Add(this.lblAccountNumber);
            this.tpAccountInfo.Controls.Add(this.lblAccountID);
            this.tpAccountInfo.Controls.Add(this.label12);
            this.tpAccountInfo.Controls.Add(this.label11);
            this.tpAccountInfo.Controls.Add(this.label9);
            this.tpAccountInfo.Controls.Add(this.label8);
            this.tpAccountInfo.Controls.Add(this.label6);
            this.tpAccountInfo.Controls.Add(this.label5);
            this.tpAccountInfo.Controls.Add(this.label2);
            this.tpAccountInfo.Controls.Add(this.txtBalance);
            this.tpAccountInfo.Controls.Add(this.pictureBox1);
            this.tpAccountInfo.Location = new System.Drawing.Point(4, 22);
            this.tpAccountInfo.Name = "tpAccountInfo";
            this.tpAccountInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpAccountInfo.Size = new System.Drawing.Size(982, 476);
            this.tpAccountInfo.TabIndex = 1;
            this.tpAccountInfo.Text = "Account Information";
            this.tpAccountInfo.UseVisualStyleBackColor = true;
            // 
            // cbAccountStatus
            // 
            this.cbAccountStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountStatus.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountStatus.FormattingEnabled = true;
            this.cbAccountStatus.Location = new System.Drawing.Point(210, 204);
            this.cbAccountStatus.Name = "cbAccountStatus";
            this.cbAccountStatus.Size = new System.Drawing.Size(176, 28);
            this.cbAccountStatus.TabIndex = 43;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(199, 273);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(492, 106);
            this.txtNotes.TabIndex = 42;
            // 
            // cbBranches
            // 
            this.cbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBranches.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBranches.FormattingEnabled = true;
            this.cbBranches.Location = new System.Drawing.Point(524, 159);
            this.cbBranches.Name = "cbBranches";
            this.cbBranches.Size = new System.Drawing.Size(167, 28);
            this.cbBranches.TabIndex = 41;
            // 
            // cbAccountType
            // 
            this.cbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountType.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountType.FormattingEnabled = true;
            this.cbAccountType.Location = new System.Drawing.Point(210, 157);
            this.cbAccountType.Name = "cbAccountType";
            this.cbAccountType.Size = new System.Drawing.Size(176, 28);
            this.cbAccountType.TabIndex = 40;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.Location = new System.Drawing.Point(208, 99);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(47, 32);
            this.lblAccountNumber.TabIndex = 39;
            this.lblAccountNumber.Text = "[ ? ]";
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.Location = new System.Drawing.Point(155, 53);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(47, 32);
            this.lblAccountID.TabIndex = 38;
            this.lblAccountID.Text = "[ ? ]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(116, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 32);
            this.label12.TabIndex = 37;
            this.label12.Text = "Notes :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(432, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 32);
            this.label11.TabIndex = 36;
            this.label11.Text = "Branch :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(41, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 32);
            this.label9.TabIndex = 35;
            this.label9.Text = "Account Status :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(423, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 32);
            this.label8.TabIndex = 34;
            this.label8.Text = "Balance :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 32);
            this.label6.TabIndex = 33;
            this.label6.Text = "Account Type :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 32);
            this.label5.TabIndex = 32;
            this.label5.Text = "Account Number :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 32);
            this.label2.TabIndex = 31;
            this.label2.Text = "Account ID :";
            // 
            // txtBalance
            // 
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(524, 203);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(167, 29);
            this.txtBalance.TabIndex = 29;
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            this.txtBalance.Validating += new System.ComponentModel.CancelEventHandler(this.txtBalance_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank.Properties.Resources.Revenue_bro;
            this.pictureBox1.Location = new System.Drawing.Point(737, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Bank.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(833, 556);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Bank.Properties.Resources.Save_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(931, 556);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 36);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chkRequestForCard
            // 
            this.chkRequestForCard.AutoSize = true;
            this.chkRequestForCard.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRequestForCard.Location = new System.Drawing.Point(199, 402);
            this.chkRequestForCard.Name = "chkRequestForCard";
            this.chkRequestForCard.Size = new System.Drawing.Size(314, 28);
            this.chkRequestForCard.TabIndex = 44;
            this.chkRequestForCard.Text = "Request For Card (Debit Card By Default)";
            this.chkRequestForCard.UseVisualStyleBackColor = true;
            // 
            // frmAddEditAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 611);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmAddEditAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditAccount";
            this.Activated += new System.EventHandler(this.frmAddEditAccount_Activated);
            this.Load += new System.EventHandler(this.frmAddEditAccount_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpClientInfo.ResumeLayout(false);
            this.tpAccountInfo.ResumeLayout(false);
            this.tpAccountInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Client.Controls.ctrlClientCardWithFilter ctrlClientCardWithFilter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpClientInfo;
        private System.Windows.Forms.TabPage tpAccountInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbAccountStatus;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cbBranches;
        private System.Windows.Forms.ComboBox cbAccountType;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chkRequestForCard;
    }
}
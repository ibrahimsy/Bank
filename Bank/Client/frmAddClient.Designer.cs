namespace Bank.Client
{
    partial class frmAddClient
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
            this.txtClientNotes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlPersonInfoWithFilter1 = new Bank.People.Controls.ctrlPersonInfoWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpPrimaryAccount = new System.Windows.Forms.TabPage();
            this.cbAccountStatus = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cbBranches = new System.Windows.Forms.ComboBox();
            this.cbAccountType = new System.Windows.Forms.ComboBox();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.lblClientID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tpClientInfo.SuspendLayout();
            this.tpPrimaryAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Titillium Web", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1229, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Client";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpClientInfo);
            this.tabControl1.Controls.Add(this.tpPrimaryAccount);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(274, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 567);
            this.tabControl1.TabIndex = 19;
            // 
            // tpClientInfo
            // 
            this.tpClientInfo.Controls.Add(this.chkIsActive);
            this.tpClientInfo.Controls.Add(this.txtClientNotes);
            this.tpClientInfo.Controls.Add(this.label3);
            this.tpClientInfo.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.tpClientInfo.Controls.Add(this.btnNext);
            this.tpClientInfo.Location = new System.Drawing.Point(4, 22);
            this.tpClientInfo.Name = "tpClientInfo";
            this.tpClientInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpClientInfo.Size = new System.Drawing.Size(959, 541);
            this.tpClientInfo.TabIndex = 0;
            this.tpClientInfo.Text = "Client Info";
            this.tpClientInfo.UseVisualStyleBackColor = true;
            // 
            // txtClientNotes
            // 
            this.txtClientNotes.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientNotes.Location = new System.Drawing.Point(104, 378);
            this.txtClientNotes.Multiline = true;
            this.txtClientNotes.Name = "txtClientNotes";
            this.txtClientNotes.Size = new System.Drawing.Size(541, 106);
            this.txtClientNotes.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 32);
            this.label3.TabIndex = 28;
            this.label3.Text = "Notes :";
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.FilterEnabled = true;
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(6, 6);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.PersonID = -1;
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(942, 359);
            this.ctrlPersonInfoWithFilter1.TabIndex = 16;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Bank.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(861, 448);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(92, 36);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpPrimaryAccount
            // 
            this.tpPrimaryAccount.Controls.Add(this.cbAccountStatus);
            this.tpPrimaryAccount.Controls.Add(this.txtNotes);
            this.tpPrimaryAccount.Controls.Add(this.cbBranches);
            this.tpPrimaryAccount.Controls.Add(this.cbAccountType);
            this.tpPrimaryAccount.Controls.Add(this.lblAccountNumber);
            this.tpPrimaryAccount.Controls.Add(this.lblAccountID);
            this.tpPrimaryAccount.Controls.Add(this.lblClientID);
            this.tpPrimaryAccount.Controls.Add(this.label2);
            this.tpPrimaryAccount.Controls.Add(this.label12);
            this.tpPrimaryAccount.Controls.Add(this.label11);
            this.tpPrimaryAccount.Controls.Add(this.label9);
            this.tpPrimaryAccount.Controls.Add(this.label8);
            this.tpPrimaryAccount.Controls.Add(this.label6);
            this.tpPrimaryAccount.Controls.Add(this.label5);
            this.tpPrimaryAccount.Controls.Add(this.label1);
            this.tpPrimaryAccount.Controls.Add(this.txtBalance);
            this.tpPrimaryAccount.Controls.Add(this.pictureBox1);
            this.tpPrimaryAccount.Location = new System.Drawing.Point(4, 22);
            this.tpPrimaryAccount.Name = "tpPrimaryAccount";
            this.tpPrimaryAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrimaryAccount.Size = new System.Drawing.Size(959, 516);
            this.tpPrimaryAccount.TabIndex = 1;
            this.tpPrimaryAccount.Text = "Primary Account Info";
            this.tpPrimaryAccount.UseVisualStyleBackColor = true;
            // 
            // cbAccountStatus
            // 
            this.cbAccountStatus.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountStatus.FormattingEnabled = true;
            this.cbAccountStatus.Location = new System.Drawing.Point(223, 270);
            this.cbAccountStatus.Name = "cbAccountStatus";
            this.cbAccountStatus.Size = new System.Drawing.Size(176, 28);
            this.cbAccountStatus.TabIndex = 28;
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(212, 339);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(492, 106);
            this.txtNotes.TabIndex = 27;
            // 
            // cbBranches
            // 
            this.cbBranches.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBranches.FormattingEnabled = true;
            this.cbBranches.Location = new System.Drawing.Point(537, 225);
            this.cbBranches.Name = "cbBranches";
            this.cbBranches.Size = new System.Drawing.Size(167, 28);
            this.cbBranches.TabIndex = 25;
            // 
            // cbAccountType
            // 
            this.cbAccountType.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccountType.FormattingEnabled = true;
            this.cbAccountType.Location = new System.Drawing.Point(223, 223);
            this.cbAccountType.Name = "cbAccountType";
            this.cbAccountType.Size = new System.Drawing.Size(176, 28);
            this.cbAccountType.TabIndex = 24;
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.Location = new System.Drawing.Point(208, 121);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(47, 32);
            this.lblAccountNumber.TabIndex = 23;
            this.lblAccountNumber.Text = "[ ? ]";
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.Location = new System.Drawing.Point(155, 75);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(47, 32);
            this.lblAccountID.TabIndex = 22;
            this.lblAccountID.Text = "[ ? ]";
            // 
            // lblClientID
            // 
            this.lblClientID.AutoSize = true;
            this.lblClientID.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientID.Location = new System.Drawing.Point(155, 32);
            this.lblClientID.Name = "lblClientID";
            this.lblClientID.Size = new System.Drawing.Size(47, 32);
            this.lblClientID.TabIndex = 21;
            this.lblClientID.Text = "[ ? ]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 32);
            this.label2.TabIndex = 20;
            this.label2.Text = "Client ID :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(129, 329);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 32);
            this.label12.TabIndex = 19;
            this.label12.Text = "Notes :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(445, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 32);
            this.label11.TabIndex = 18;
            this.label11.Text = "Branch :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(54, 264);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 32);
            this.label9.TabIndex = 16;
            this.label9.Text = "Account Status :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(436, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 32);
            this.label8.TabIndex = 15;
            this.label8.Text = "Balance :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 32);
            this.label6.TabIndex = 14;
            this.label6.Text = "Account Type :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 32);
            this.label5.TabIndex = 13;
            this.label5.Text = "Account Number :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Account ID :";
            // 
            // txtBalance
            // 
            this.txtBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(537, 269);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(167, 29);
            this.txtBalance.TabIndex = 4;
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            this.txtBalance.Validating += new System.ComponentModel.CancelEventHandler(this.txtBalance_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank.Properties.Resources.Revenue_bro;
            this.pictureBox1.Location = new System.Drawing.Point(737, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Bank.Properties.Resources.Refund_bro__1_;
            this.pictureBox2.Location = new System.Drawing.Point(18, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 246);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Bank.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1051, 641);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 22;
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
            this.btnSave.Location = new System.Drawing.Point(1149, 641);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 36);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(104, 490);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(110, 36);
            this.chkIsActive.TabIndex = 31;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // frmAddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1253, 689);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmAddClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditClient";
            this.Activated += new System.EventHandler(this.frmAddEditClient_Activated);
            this.Load += new System.EventHandler(this.frmAddEditClient_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpClientInfo.ResumeLayout(false);
            this.tpClientInfo.PerformLayout();
            this.tpPrimaryAccount.ResumeLayout(false);
            this.tpPrimaryAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpClientInfo;
        private People.Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpPrimaryAccount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox cbBranches;
        private System.Windows.Forms.ComboBox cbAccountType;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.ComboBox cbAccountStatus;
        private System.Windows.Forms.TextBox txtClientNotes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsActive;
    }
}
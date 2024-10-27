namespace Bank.Transactions
{
    partial class frmWithDrawDeposit
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
            this.lblTransationAmount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTransactionAmount = new System.Windows.Forms.TextBox();
            this.ctrlClientCard1 = new Bank.Client.Controls.ctrlClientCard();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblBeneficiaryAccount = new System.Windows.Forms.Label();
            this.txtBeneficiaryAccount = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Size = new System.Drawing.Size(935, 47);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "TransactionTitle";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTransationAmount
            // 
            this.lblTransationAmount.AutoSize = true;
            this.lblTransationAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTransationAmount.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransationAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTransationAmount.Location = new System.Drawing.Point(29, 422);
            this.lblTransationAmount.Name = "lblTransationAmount";
            this.lblTransationAmount.Size = new System.Drawing.Size(202, 32);
            this.lblTransationAmount.TabIndex = 13;
            this.lblTransationAmount.Text = "Transaction Amount :";
            this.lblTransationAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Bank.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(763, 507);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Bank.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(861, 507);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 36);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtTransactionAmount
            // 
            this.txtTransactionAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransactionAmount.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionAmount.Location = new System.Drawing.Point(237, 425);
            this.txtTransactionAmount.Name = "txtTransactionAmount";
            this.txtTransactionAmount.Size = new System.Drawing.Size(147, 32);
            this.txtTransactionAmount.TabIndex = 16;
            this.txtTransactionAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWithdrawAmount_KeyPress);
            this.txtTransactionAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtWithdrawAmount_Validating);
            // 
            // ctrlClientCard1
            // 
            this.ctrlClientCard1.Location = new System.Drawing.Point(12, 59);
            this.ctrlClientCard1.Name = "ctrlClientCard1";
            this.ctrlClientCard1.Size = new System.Drawing.Size(935, 360);
            this.ctrlClientCard1.TabIndex = 12;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblBeneficiaryAccount
            // 
            this.lblBeneficiaryAccount.AutoSize = true;
            this.lblBeneficiaryAccount.BackColor = System.Drawing.Color.Transparent;
            this.lblBeneficiaryAccount.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaryAccount.ForeColor = System.Drawing.Color.Black;
            this.lblBeneficiaryAccount.Location = new System.Drawing.Point(29, 468);
            this.lblBeneficiaryAccount.Name = "lblBeneficiaryAccount";
            this.lblBeneficiaryAccount.Size = new System.Drawing.Size(198, 32);
            this.lblBeneficiaryAccount.TabIndex = 17;
            this.lblBeneficiaryAccount.Text = "Beneficiary account :";
            this.lblBeneficiaryAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBeneficiaryAccount
            // 
            this.txtBeneficiaryAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBeneficiaryAccount.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeneficiaryAccount.Location = new System.Drawing.Point(237, 468);
            this.txtBeneficiaryAccount.Name = "txtBeneficiaryAccount";
            this.txtBeneficiaryAccount.Size = new System.Drawing.Size(147, 32);
            this.txtBeneficiaryAccount.TabIndex = 18;
            this.txtBeneficiaryAccount.Validating += new System.ComponentModel.CancelEventHandler(this.txtBeneficiaryAccount_Validating);
            // 
            // frmWithDrawDeposit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 555);
            this.Controls.Add(this.txtBeneficiaryAccount);
            this.Controls.Add(this.lblBeneficiaryAccount);
            this.Controls.Add(this.txtTransactionAmount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTransationAmount);
            this.Controls.Add(this.ctrlClientCard1);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmWithDrawDeposit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction";
            this.Load += new System.EventHandler(this.frmWithDraw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Client.Controls.ctrlClientCard ctrlClientCard1;
        private System.Windows.Forms.Label lblTransationAmount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtTransactionAmount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblBeneficiaryAccount;
        private System.Windows.Forms.TextBox txtBeneficiaryAccount;
    }
}
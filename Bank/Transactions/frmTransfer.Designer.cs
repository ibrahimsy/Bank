namespace Bank.Transactions
{
    partial class frmTransfer
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
            this.lblTransactionTitle = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            this.gpTransferTo = new System.Windows.Forms.GroupBox();
            this.pbAddNewBeneficiary = new System.Windows.Forms.PictureBox();
            this.pbOwnAccounts = new System.Windows.Forms.PictureBox();
            this.pbMyBeneficiary = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.gpTransferTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewBeneficiary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOwnAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyBeneficiary)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTransactionTitle
            // 
            this.lblTransactionTitle.Font = new System.Drawing.Font("Titillium Web", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionTitle.Location = new System.Drawing.Point(6, 9);
            this.lblTransactionTitle.Name = "lblTransactionTitle";
            this.lblTransactionTitle.Size = new System.Drawing.Size(604, 41);
            this.lblTransactionTitle.TabIndex = 7;
            this.lblTransactionTitle.Text = "Transfer";
            this.lblTransactionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb
            // 
            this.pb.Image = global::Bank.Properties.Resources.Money_Transfer;
            this.pb.Location = new System.Drawing.Point(243, 53);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(131, 102);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 8;
            this.pb.TabStop = false;
            // 
            // gpTransferTo
            // 
            this.gpTransferTo.Controls.Add(this.pbAddNewBeneficiary);
            this.gpTransferTo.Controls.Add(this.pbOwnAccounts);
            this.gpTransferTo.Controls.Add(this.pbMyBeneficiary);
            this.gpTransferTo.Controls.Add(this.label6);
            this.gpTransferTo.Controls.Add(this.label5);
            this.gpTransferTo.Controls.Add(this.label4);
            this.gpTransferTo.Location = new System.Drawing.Point(12, 164);
            this.gpTransferTo.Name = "gpTransferTo";
            this.gpTransferTo.Size = new System.Drawing.Size(598, 168);
            this.gpTransferTo.TabIndex = 9;
            this.gpTransferTo.TabStop = false;
            this.gpTransferTo.Text = "Transfer To";
            // 
            // pbAddNewBeneficiary
            // 
            this.pbAddNewBeneficiary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAddNewBeneficiary.Image = global::Bank.Properties.Resources.add_beneficiary;
            this.pbAddNewBeneficiary.Location = new System.Drawing.Point(422, 68);
            this.pbAddNewBeneficiary.Name = "pbAddNewBeneficiary";
            this.pbAddNewBeneficiary.Size = new System.Drawing.Size(68, 62);
            this.pbAddNewBeneficiary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAddNewBeneficiary.TabIndex = 10;
            this.pbAddNewBeneficiary.TabStop = false;
            this.pbAddNewBeneficiary.Click += new System.EventHandler(this.pbAddNewBeneficiary_Click);
            // 
            // pbOwnAccounts
            // 
            this.pbOwnAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbOwnAccounts.Image = global::Bank.Properties.Resources.own_account;
            this.pbOwnAccounts.Location = new System.Drawing.Point(225, 68);
            this.pbOwnAccounts.Name = "pbOwnAccounts";
            this.pbOwnAccounts.Size = new System.Drawing.Size(68, 62);
            this.pbOwnAccounts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOwnAccounts.TabIndex = 9;
            this.pbOwnAccounts.TabStop = false;
            // 
            // pbMyBeneficiary
            // 
            this.pbMyBeneficiary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMyBeneficiary.Image = global::Bank.Properties.Resources.beneficiary;
            this.pbMyBeneficiary.Location = new System.Drawing.Point(55, 68);
            this.pbMyBeneficiary.Name = "pbMyBeneficiary";
            this.pbMyBeneficiary.Size = new System.Drawing.Size(68, 62);
            this.pbMyBeneficiary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMyBeneficiary.TabIndex = 8;
            this.pbMyBeneficiary.TabStop = false;
            this.pbMyBeneficiary.Click += new System.EventHandler(this.pbMyBeneficiary_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(356, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 32);
            this.label6.TabIndex = 7;
            this.label6.Text = "Add New Beneficiary";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(194, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 32);
            this.label5.TabIndex = 6;
            this.label5.Text = "Own Account";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "My Beneficiary";
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 345);
            this.Controls.Add(this.gpTransferTo);
            this.Controls.Add(this.lblTransactionTitle);
            this.Controls.Add(this.pb);
            this.Name = "frmTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.gpTransferTo.ResumeLayout(false);
            this.gpTransferTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewBeneficiary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOwnAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMyBeneficiary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTransactionTitle;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.GroupBox gpTransferTo;
        private System.Windows.Forms.PictureBox pbAddNewBeneficiary;
        private System.Windows.Forms.PictureBox pbOwnAccounts;
        private System.Windows.Forms.PictureBox pbMyBeneficiary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
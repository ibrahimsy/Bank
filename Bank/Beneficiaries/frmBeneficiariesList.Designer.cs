namespace Bank.Beneficiaries
{
    partial class frmBeneficiariesList
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
            this.flpBeneficiaryList = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTransferDetails = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBeneficiaryCard = new System.Windows.Forms.Panel();
            this.txtTransferAmount = new System.Windows.Forms.TextBox();
            this.lblMyBalance = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMyAccountType = new System.Windows.Forms.Label();
            this.lblAccountNumber = new System.Windows.Forms.Label();
            this.lblBeneficiaryName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBeneficiaryNickname = new System.Windows.Forms.Label();
            this.lblBeneAccountNumber = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gbTransferDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pBeneficiaryCard.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // flpBeneficiaryList
            // 
            this.flpBeneficiaryList.AutoScroll = true;
            this.flpBeneficiaryList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBeneficiaryList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBeneficiaryList.Location = new System.Drawing.Point(18, 257);
            this.flpBeneficiaryList.Name = "flpBeneficiaryList";
            this.flpBeneficiaryList.Padding = new System.Windows.Forms.Padding(10);
            this.flpBeneficiaryList.Size = new System.Drawing.Size(346, 236);
            this.flpBeneficiaryList.TabIndex = 0;
            this.flpBeneficiaryList.WrapContents = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(811, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "My Existing Beneficiary ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbTransferDetails
            // 
            this.gbTransferDetails.Controls.Add(this.textBox2);
            this.gbTransferDetails.Controls.Add(this.label8);
            this.gbTransferDetails.Controls.Add(this.label7);
            this.gbTransferDetails.Controls.Add(this.pictureBox1);
            this.gbTransferDetails.Controls.Add(this.pBeneficiaryCard);
            this.gbTransferDetails.Controls.Add(this.panel2);
            this.gbTransferDetails.Location = new System.Drawing.Point(392, 67);
            this.gbTransferDetails.Name = "gbTransferDetails";
            this.gbTransferDetails.Size = new System.Drawing.Size(431, 426);
            this.gbTransferDetails.TabIndex = 2;
            this.gbTransferDetails.TabStop = false;
            this.gbTransferDetails.Text = "Transfer Details";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Titillium Web", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(32, 339);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(371, 48);
            this.textBox2.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "(Optional)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(259, 29);
            this.label7.TabIndex = 17;
            this.label7.Text = "Additional Remittance Details";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank.Properties.Resources.Transfer_To_Arrow;
            this.pictureBox1.Location = new System.Drawing.Point(196, 167);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pBeneficiaryCard
            // 
            this.pBeneficiaryCard.BackColor = System.Drawing.Color.PowderBlue;
            this.pBeneficiaryCard.Controls.Add(this.txtTransferAmount);
            this.pBeneficiaryCard.Controls.Add(this.lblMyBalance);
            this.pBeneficiaryCard.Controls.Add(this.lblCurrency);
            this.pBeneficiaryCard.Controls.Add(this.label4);
            this.pBeneficiaryCard.Controls.Add(this.label2);
            this.pBeneficiaryCard.Controls.Add(this.panel1);
            this.pBeneficiaryCard.Controls.Add(this.lblMyAccountType);
            this.pBeneficiaryCard.Controls.Add(this.lblAccountNumber);
            this.pBeneficiaryCard.Controls.Add(this.lblBeneficiaryName);
            this.pBeneficiaryCard.Location = new System.Drawing.Point(25, 29);
            this.pBeneficiaryCard.Name = "pBeneficiaryCard";
            this.pBeneficiaryCard.Size = new System.Drawing.Size(389, 147);
            this.pBeneficiaryCard.TabIndex = 6;
            // 
            // txtTransferAmount
            // 
            this.txtTransferAmount.Font = new System.Drawing.Font("Titillium Web", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransferAmount.Location = new System.Drawing.Point(154, 96);
            this.txtTransferAmount.Name = "txtTransferAmount";
            this.txtTransferAmount.Size = new System.Drawing.Size(173, 30);
            this.txtTransferAmount.TabIndex = 15;
            this.txtTransferAmount.TextChanged += new System.EventHandler(this.txtTransferAmount_TextChanged);
            this.txtTransferAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTransferAmount_KeyPress);
            this.txtTransferAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtTransferAmount_Validating);
            // 
            // lblMyBalance
            // 
            this.lblMyBalance.AutoSize = true;
            this.lblMyBalance.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyBalance.Location = new System.Drawing.Point(149, 37);
            this.lblMyBalance.Name = "lblMyBalance";
            this.lblMyBalance.Size = new System.Drawing.Size(112, 29);
            this.lblMyBalance.TabIndex = 14;
            this.lblMyBalance.Text = "My Balance ";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Titillium Web", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.Location = new System.Drawing.Point(96, 35);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(52, 32);
            this.lblCurrency.TabIndex = 13;
            this.lblCurrency.Text = "USD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Balance : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "I Want To Send :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(0, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 10);
            this.panel1.TabIndex = 9;
            // 
            // lblMyAccountType
            // 
            this.lblMyAccountType.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyAccountType.Location = new System.Drawing.Point(77, 6);
            this.lblMyAccountType.Name = "lblMyAccountType";
            this.lblMyAccountType.Size = new System.Drawing.Size(131, 29);
            this.lblMyAccountType.TabIndex = 8;
            this.lblMyAccountType.Text = "Account Type";
            // 
            // lblAccountNumber
            // 
            this.lblAccountNumber.AutoSize = true;
            this.lblAccountNumber.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNumber.Location = new System.Drawing.Point(203, 6);
            this.lblAccountNumber.Name = "lblAccountNumber";
            this.lblAccountNumber.Size = new System.Drawing.Size(183, 29);
            this.lblAccountNumber.TabIndex = 6;
            this.lblAccountNumber.Text = "My Account  Number";
            // 
            // lblBeneficiaryName
            // 
            this.lblBeneficiaryName.AutoSize = true;
            this.lblBeneficiaryName.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaryName.Location = new System.Drawing.Point(11, 6);
            this.lblBeneficiaryName.Name = "lblBeneficiaryName";
            this.lblBeneficiaryName.Size = new System.Drawing.Size(69, 29);
            this.lblBeneficiaryName.TabIndex = 6;
            this.lblBeneficiaryName.Text = "From : ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PowderBlue;
            this.panel2.Controls.Add(this.lblBeneficiaryNickname);
            this.panel2.Controls.Add(this.lblBeneAccountNumber);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(25, 194);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 71);
            this.panel2.TabIndex = 16;
            // 
            // lblBeneficiaryNickname
            // 
            this.lblBeneficiaryNickname.AutoSize = true;
            this.lblBeneficiaryNickname.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaryNickname.Location = new System.Drawing.Point(50, 15);
            this.lblBeneficiaryNickname.Name = "lblBeneficiaryNickname";
            this.lblBeneficiaryNickname.Size = new System.Drawing.Size(98, 29);
            this.lblBeneficiaryNickname.TabIndex = 8;
            this.lblBeneficiaryNickname.Text = "NickName";
            // 
            // lblBeneAccountNumber
            // 
            this.lblBeneAccountNumber.AutoSize = true;
            this.lblBeneAccountNumber.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneAccountNumber.Location = new System.Drawing.Point(179, 15);
            this.lblBeneAccountNumber.Name = "lblBeneAccountNumber";
            this.lblBeneAccountNumber.Size = new System.Drawing.Size(183, 29);
            this.lblBeneAccountNumber.TabIndex = 6;
            this.lblBeneAccountNumber.Text = "My Account  Number";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 29);
            this.label14.TabIndex = 6;
            this.label14.Text = "To : ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Bank.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(635, 499);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Image = global::Bank.Properties.Resources.confirm_16;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(733, 499);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 36);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Bank.Properties.Resources.Beneficiary5;
            this.pictureBox2.Location = new System.Drawing.Point(95, 67);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 184);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // frmBeneficiariesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 552);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.gbTransferDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpBeneficiaryList);
            this.Name = "frmBeneficiariesList";
            this.Text = "Transfer";
            this.Load += new System.EventHandler(this.frmBeneficiariesList_Load);
            this.gbTransferDetails.ResumeLayout(false);
            this.gbTransferDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pBeneficiaryCard.ResumeLayout(false);
            this.pBeneficiaryCard.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBeneficiaryList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTransferDetails;
        private System.Windows.Forms.Panel pBeneficiaryCard;
        private System.Windows.Forms.Label lblMyAccountType;
        private System.Windows.Forms.Label lblAccountNumber;
        private System.Windows.Forms.Label lblBeneficiaryName;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTransferAmount;
        private System.Windows.Forms.Label lblMyBalance;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBeneficiaryNickname;
        private System.Windows.Forms.Label lblBeneAccountNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
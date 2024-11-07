namespace Bank.Transactions.Controls
{
    partial class ctrlPerformTransaction
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbTransactionTitle = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMyAccounts = new System.Windows.Forms.ComboBox();
            this.lblTransactionTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pbTransactionImage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblTransType = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbTransactionTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransactionImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTransactionTitle
            // 
            this.gbTransactionTitle.Controls.Add(this.label1);
            this.gbTransactionTitle.Controls.Add(this.cbMyAccounts);
            this.gbTransactionTitle.Controls.Add(this.lblTransactionTitle);
            this.gbTransactionTitle.Controls.Add(this.txtDescription);
            this.gbTransactionTitle.Controls.Add(this.pbTransactionImage);
            this.gbTransactionTitle.Controls.Add(this.label3);
            this.gbTransactionTitle.Controls.Add(this.label2);
            this.gbTransactionTitle.Controls.Add(this.txtAmount);
            this.gbTransactionTitle.Controls.Add(this.lblTransType);
            this.gbTransactionTitle.Location = new System.Drawing.Point(3, 3);
            this.gbTransactionTitle.Name = "gbTransactionTitle";
            this.gbTransactionTitle.Size = new System.Drawing.Size(500, 468);
            this.gbTransactionTitle.TabIndex = 8;
            this.gbTransactionTitle.TabStop = false;
            this.gbTransactionTitle.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "My Own Accounts";
            // 
            // cbMyAccounts
            // 
            this.cbMyAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyAccounts.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMyAccounts.FormattingEnabled = true;
            this.cbMyAccounts.Location = new System.Drawing.Point(23, 293);
            this.cbMyAccounts.Name = "cbMyAccounts";
            this.cbMyAccounts.Size = new System.Drawing.Size(176, 32);
            this.cbMyAccounts.TabIndex = 2;
            // 
            // lblTransactionTitle
            // 
            this.lblTransactionTitle.Font = new System.Drawing.Font("Titillium Web", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionTitle.Location = new System.Drawing.Point(6, 16);
            this.lblTransactionTitle.Name = "lblTransactionTitle";
            this.lblTransactionTitle.Size = new System.Drawing.Size(488, 41);
            this.lblTransactionTitle.TabIndex = 0;
            this.lblTransactionTitle.Text = "Transaction Title";
            this.lblTransactionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(23, 377);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(370, 85);
            this.txtDescription.TabIndex = 3;
            // 
            // pbTransactionImage
            // 
            this.pbTransactionImage.Image = global::Bank.Properties.Resources.deposit;
            this.pbTransactionImage.Location = new System.Drawing.Point(175, 60);
            this.pbTransactionImage.Name = "pbTransactionImage";
            this.pbTransactionImage.Size = new System.Drawing.Size(150, 115);
            this.pbTransactionImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTransactionImage.TabIndex = 6;
            this.pbTransactionImage.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount To ";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(23, 219);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(370, 32);
            this.txtAmount.TabIndex = 1;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmount_Validating);
            // 
            // lblTransType
            // 
            this.lblTransType.Location = new System.Drawing.Point(0, 0);
            this.lblTransType.Name = "lblTransType";
            this.lblTransType.Size = new System.Drawing.Size(100, 23);
            this.lblTransType.TabIndex = 9;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlPerformTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTransactionTitle);
            this.Name = "ctrlPerformTransaction";
            this.Size = new System.Drawing.Size(510, 478);
            this.gbTransactionTitle.ResumeLayout(false);
            this.gbTransactionTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransactionImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTransactionTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMyAccounts;
        private System.Windows.Forms.Label lblTransactionTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.PictureBox pbTransactionImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblTransType;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

namespace Bank.Accounts.Controls
{
    partial class ctrlAccountCardWithFilter
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
            this.gbAccountFilter = new System.Windows.Forms.GroupBox();
            this.btnAddNewAccount = new System.Windows.Forms.Button();
            this.btnFindAccount = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.ctrlAccountCard1 = new Bank.Accounts.Controls.ctrlAccountCard();
            this.gbAccountFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAccountFilter
            // 
            this.gbAccountFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(25)))), ((int)(((byte)(82)))));
            this.gbAccountFilter.Controls.Add(this.btnAddNewAccount);
            this.gbAccountFilter.Controls.Add(this.btnFindAccount);
            this.gbAccountFilter.Controls.Add(this.txtFilterValue);
            this.gbAccountFilter.Controls.Add(this.cbFilterBy);
            this.gbAccountFilter.Location = new System.Drawing.Point(3, 3);
            this.gbAccountFilter.Name = "gbAccountFilter";
            this.gbAccountFilter.Size = new System.Drawing.Size(1027, 63);
            this.gbAccountFilter.TabIndex = 2;
            this.gbAccountFilter.TabStop = false;
            // 
            // btnAddNewAccount
            // 
            this.btnAddNewAccount.Image = global::Bank.Properties.Resources.AddPerson_32;
            this.btnAddNewAccount.Location = new System.Drawing.Point(433, 15);
            this.btnAddNewAccount.Name = "btnAddNewAccount";
            this.btnAddNewAccount.Size = new System.Drawing.Size(50, 40);
            this.btnAddNewAccount.TabIndex = 7;
            this.btnAddNewAccount.UseVisualStyleBackColor = true;
            // 
            // btnFindAccount
            // 
            this.btnFindAccount.Image = global::Bank.Properties.Resources.SearchPerson;
            this.btnFindAccount.Location = new System.Drawing.Point(377, 15);
            this.btnFindAccount.Name = "btnFindAccount";
            this.btnFindAccount.Size = new System.Drawing.Size(50, 40);
            this.btnFindAccount.TabIndex = 6;
            this.btnFindAccount.UseVisualStyleBackColor = true;
            this.btnFindAccount.Click += new System.EventHandler(this.btnFindAccount_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(250, 19);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(121, 29);
            this.txtFilterValue.TabIndex = 5;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Account Number"});
            this.cbFilterBy.Location = new System.Drawing.Point(12, 18);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(232, 32);
            this.cbFilterBy.TabIndex = 4;
            // 
            // ctrlAccountCard1
            // 
            this.ctrlAccountCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ctrlAccountCard1.Location = new System.Drawing.Point(3, 64);
            this.ctrlAccountCard1.Name = "ctrlAccountCard1";
            this.ctrlAccountCard1.Size = new System.Drawing.Size(1027, 352);
            this.ctrlAccountCard1.TabIndex = 3;
            // 
            // ctrlAccountCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlAccountCard1);
            this.Controls.Add(this.gbAccountFilter);
            this.Name = "ctrlAccountCardWithFilter";
            this.Size = new System.Drawing.Size(1033, 425);
            this.gbAccountFilter.ResumeLayout(false);
            this.gbAccountFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAccountFilter;
        private System.Windows.Forms.Button btnAddNewAccount;
        private System.Windows.Forms.Button btnFindAccount;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private ctrlAccountCard ctrlAccountCard1;
    }
}

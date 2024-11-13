namespace Bank.Client.Controls
{
    partial class ctrlClientCardWithFilter
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
            this.gbClientFilter = new System.Windows.Forms.GroupBox();
            this.btnAddNewClient = new System.Windows.Forms.Button();
            this.btnFindClient = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.ctrlClientCard1 = new Bank.Client.Controls.ctrlClientCard();
            this.gbClientFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbClientFilter
            // 
            this.gbClientFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(25)))), ((int)(((byte)(82)))));
            this.gbClientFilter.Controls.Add(this.btnAddNewClient);
            this.gbClientFilter.Controls.Add(this.btnFindClient);
            this.gbClientFilter.Controls.Add(this.txtFilterValue);
            this.gbClientFilter.Controls.Add(this.cbFilterBy);
            this.gbClientFilter.Location = new System.Drawing.Point(3, 3);
            this.gbClientFilter.Name = "gbClientFilter";
            this.gbClientFilter.Size = new System.Drawing.Size(939, 63);
            this.gbClientFilter.TabIndex = 1;
            this.gbClientFilter.TabStop = false;
            // 
            // btnAddNewClient
            // 
            this.btnAddNewClient.Image = global::Bank.Properties.Resources.AddPerson_32;
            this.btnAddNewClient.Location = new System.Drawing.Point(433, 15);
            this.btnAddNewClient.Name = "btnAddNewClient";
            this.btnAddNewClient.Size = new System.Drawing.Size(50, 40);
            this.btnAddNewClient.TabIndex = 7;
            this.btnAddNewClient.UseVisualStyleBackColor = true;
            // 
            // btnFindClient
            // 
            this.btnFindClient.Image = global::Bank.Properties.Resources.SearchPerson;
            this.btnFindClient.Location = new System.Drawing.Point(377, 15);
            this.btnFindClient.Name = "btnFindClient";
            this.btnFindClient.Size = new System.Drawing.Size(50, 40);
            this.btnFindClient.TabIndex = 6;
            this.btnFindClient.UseVisualStyleBackColor = true;
            this.btnFindClient.Click += new System.EventHandler(this.btnFindClient_Click);
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
            "Client ID",
            "National No",
            "Primary Account Number"});
            this.cbFilterBy.Location = new System.Drawing.Point(12, 18);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(232, 32);
            this.cbFilterBy.TabIndex = 4;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // ctrlClientCard1
            // 
            this.ctrlClientCard1.Location = new System.Drawing.Point(3, 64);
            this.ctrlClientCard1.Name = "ctrlClientCard1";
            this.ctrlClientCard1.Size = new System.Drawing.Size(942, 349);
            this.ctrlClientCard1.TabIndex = 0;
            // 
            // ctrlClientCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbClientFilter);
            this.Controls.Add(this.ctrlClientCard1);
            this.Name = "ctrlClientCardWithFilter";
            this.Size = new System.Drawing.Size(945, 416);
            this.Load += new System.EventHandler(this.ctrlClientCardWithFilter_Load);
            this.gbClientFilter.ResumeLayout(false);
            this.gbClientFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlClientCard ctrlClientCard1;
        private System.Windows.Forms.GroupBox gbClientFilter;
        private System.Windows.Forms.Button btnAddNewClient;
        private System.Windows.Forms.Button btnFindClient;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
    }
}

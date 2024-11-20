namespace Bank.Cards.Controls
{
    partial class ctrlCardInfoWihFilter
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
            this.ctrlCardInfo1 = new Bank.Cards.ctrlCardInfo();
            this.plSearchCard = new System.Windows.Forms.Panel();
            this.btnCardSearch = new System.Windows.Forms.Button();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.plSearchCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlCardInfo1
            // 
            this.ctrlCardInfo1.Location = new System.Drawing.Point(3, 87);
            this.ctrlCardInfo1.Name = "ctrlCardInfo1";
            this.ctrlCardInfo1.Size = new System.Drawing.Size(866, 359);
            this.ctrlCardInfo1.TabIndex = 0;
            // 
            // plSearchCard
            // 
            this.plSearchCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(25)))), ((int)(((byte)(82)))));
            this.plSearchCard.Controls.Add(this.label1);
            this.plSearchCard.Controls.Add(this.btnCardSearch);
            this.plSearchCard.Controls.Add(this.txtCardNumber);
            this.plSearchCard.Location = new System.Drawing.Point(3, 3);
            this.plSearchCard.Name = "plSearchCard";
            this.plSearchCard.Size = new System.Drawing.Size(866, 78);
            this.plSearchCard.TabIndex = 1;
            // 
            // btnCardSearch
            // 
            this.btnCardSearch.Image = global::Bank.Properties.Resources.card_search;
            this.btnCardSearch.Location = new System.Drawing.Point(375, 14);
            this.btnCardSearch.Name = "btnCardSearch";
            this.btnCardSearch.Size = new System.Drawing.Size(66, 51);
            this.btnCardSearch.TabIndex = 1;
            this.btnCardSearch.UseVisualStyleBackColor = true;
            this.btnCardSearch.Click += new System.EventHandler(this.btnCardSearch_Click);
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.Location = new System.Drawing.Point(149, 21);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(210, 36);
            this.txtCardNumber.TabIndex = 0;
            this.txtCardNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCardNumber_KeyPress);
            this.txtCardNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtCardNumber_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Card Number";
            // 
            // ctrlCardInfoWihFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plSearchCard);
            this.Controls.Add(this.ctrlCardInfo1);
            this.Name = "ctrlCardInfoWihFilter";
            this.Size = new System.Drawing.Size(872, 449);
            this.plSearchCard.ResumeLayout(false);
            this.plSearchCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlCardInfo ctrlCardInfo1;
        private System.Windows.Forms.Panel plSearchCard;
        private System.Windows.Forms.Button btnCardSearch;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
    }
}

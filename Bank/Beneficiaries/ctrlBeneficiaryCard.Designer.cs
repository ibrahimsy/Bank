﻿namespace Bank.Beneficiaries
{
    partial class ctrlBeneficiaryCard
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
            this.lblBenefAccountNumber = new System.Windows.Forms.Label();
            this.lblBeneficiaryName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBenefAccountNumber
            // 
            this.lblBenefAccountNumber.AutoSize = true;
            this.lblBenefAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBenefAccountNumber.Location = new System.Drawing.Point(5, 43);
            this.lblBenefAccountNumber.Name = "lblBenefAccountNumber";
            this.lblBenefAccountNumber.Size = new System.Drawing.Size(202, 16);
            this.lblBenefAccountNumber.TabIndex = 7;
            this.lblBenefAccountNumber.Text = "Beneficiary Account Number";
            // 
            // lblBeneficiaryName
            // 
            this.lblBeneficiaryName.AutoSize = true;
            this.lblBeneficiaryName.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaryName.Location = new System.Drawing.Point(3, 10);
            this.lblBeneficiaryName.Name = "lblBeneficiaryName";
            this.lblBeneficiaryName.Size = new System.Drawing.Size(160, 29);
            this.lblBeneficiaryName.TabIndex = 8;
            this.lblBeneficiaryName.Text = "Beneficiary Name";
            // 
            // ctrlBeneficiaryCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.Controls.Add(this.lblBenefAccountNumber);
            this.Controls.Add(this.lblBeneficiaryName);
            this.Name = "ctrlBeneficiaryCard";
            this.Size = new System.Drawing.Size(279, 82);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBenefAccountNumber;
        private System.Windows.Forms.Label lblBeneficiaryName;
    }
}

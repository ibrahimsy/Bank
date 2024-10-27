namespace Bank.Client
{
    partial class frmChangePinCode
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
            this.ctrlClientCard1 = new Bank.Client.Controls.ctrlClientCard();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurrentPinCode = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPinCode = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConfirmPinCode = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlClientCard1
            // 
            this.ctrlClientCard1.Location = new System.Drawing.Point(6, 68);
            this.ctrlClientCard1.Name = "ctrlClientCard1";
            this.ctrlClientCard1.Size = new System.Drawing.Size(935, 360);
            this.ctrlClientCard1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Titillium Web", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(347, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Change Pin Code";
            // 
            // txtCurrentPinCode
            // 
            this.txtCurrentPinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentPinCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPinCode.Location = new System.Drawing.Point(206, 432);
            this.txtCurrentPinCode.Mask = "0000";
            this.txtCurrentPinCode.Name = "txtCurrentPinCode";
            this.txtCurrentPinCode.Size = new System.Drawing.Size(86, 31);
            this.txtCurrentPinCode.TabIndex = 13;
            this.txtCurrentPinCode.ValidatingType = typeof(int);
            this.txtCurrentPinCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtCurrentPinCode_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Current Pin Code :";
            // 
            // txtNewPinCode
            // 
            this.txtNewPinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPinCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPinCode.Location = new System.Drawing.Point(206, 469);
            this.txtNewPinCode.Mask = "0000";
            this.txtNewPinCode.Name = "txtNewPinCode";
            this.txtNewPinCode.Size = new System.Drawing.Size(86, 31);
            this.txtNewPinCode.TabIndex = 15;
            this.txtNewPinCode.ValidatingType = typeof(int);
            this.txtNewPinCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtNewPinCode_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "New Pin Code :";
            // 
            // txtConfirmPinCode
            // 
            this.txtConfirmPinCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPinCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPinCode.Location = new System.Drawing.Point(206, 508);
            this.txtConfirmPinCode.Mask = "0000";
            this.txtConfirmPinCode.Name = "txtConfirmPinCode";
            this.txtConfirmPinCode.Size = new System.Drawing.Size(86, 31);
            this.txtConfirmPinCode.TabIndex = 17;
            this.txtConfirmPinCode.ValidatingType = typeof(int);
            this.txtConfirmPinCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPinCode_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 509);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 29);
            this.label4.TabIndex = 16;
            this.label4.Text = "Confirm Pin Code :";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Bank.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(751, 560);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Bank.Properties.Resources.Save_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(849, 560);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 36);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmChangePinCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 611);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtConfirmPinCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewPinCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrentPinCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlClientCard1);
            this.Name = "frmChangePinCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change PinCode";
            this.Load += new System.EventHandler(this.frmChangePinCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlClientCard ctrlClientCard1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtCurrentPinCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtNewPinCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtConfirmPinCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
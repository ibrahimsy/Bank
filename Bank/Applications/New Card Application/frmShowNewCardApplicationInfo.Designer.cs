namespace Bank.Applications.New_Card_Application
{
    partial class frmShowNewCardApplicationInfo
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
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlNewCardApplicationInfo1 = new Bank.Applications.New_Card_Application.Controls.ctrlNewCardApplicationInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Bank.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(762, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlNewCardApplicationInfo1
            // 
            this.ctrlNewCardApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.ctrlNewCardApplicationInfo1.Name = "ctrlNewCardApplicationInfo1";
            this.ctrlNewCardApplicationInfo1.Size = new System.Drawing.Size(842, 385);
            this.ctrlNewCardApplicationInfo1.TabIndex = 0;
            // 
            // frmShowNewCardApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 451);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlNewCardApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowNewCardApplicationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Info";
            this.Load += new System.EventHandler(this.frmShowNewCardApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlNewCardApplicationInfo ctrlNewCardApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}
namespace Bank.Applications.New_Card_Application.Controls
{
    partial class ctrlNewCardApplicationInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.llbViewCardInfo = new System.Windows.Forms.LinkLabel();
            this.lblCardType = new System.Windows.Forms.Label();
            this.lblNewCardApplicationID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlApplicationInfo1 = new Bank.Applications.Controls.ctrlApplicationInfo();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.llbViewCardInfo);
            this.groupBox1.Controls.Add(this.lblCardType);
            this.groupBox1.Controls.Add(this.lblNewCardApplicationID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Titillium Web", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Card Application Info";
            // 
            // llbViewCardInfo
            // 
            this.llbViewCardInfo.AutoSize = true;
            this.llbViewCardInfo.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbViewCardInfo.Location = new System.Drawing.Point(698, 85);
            this.llbViewCardInfo.Name = "llbViewCardInfo";
            this.llbViewCardInfo.Size = new System.Drawing.Size(132, 29);
            this.llbViewCardInfo.TabIndex = 12;
            this.llbViewCardInfo.TabStop = true;
            this.llbViewCardInfo.Text = "View Card Info";
            this.llbViewCardInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbViewCardInfo_LinkClicked);
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardType.Location = new System.Drawing.Point(663, 43);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(43, 29);
            this.lblCardType.TabIndex = 11;
            this.lblCardType.Text = "[ ? ]";
            // 
            // lblNewCardApplicationID
            // 
            this.lblNewCardApplicationID.AutoSize = true;
            this.lblNewCardApplicationID.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCardApplicationID.Location = new System.Drawing.Point(245, 43);
            this.lblNewCardApplicationID.Name = "lblNewCardApplicationID";
            this.lblNewCardApplicationID.Size = new System.Drawing.Size(43, 29);
            this.lblNewCardApplicationID.TabIndex = 10;
            this.lblNewCardApplicationID.Text = "[ ? ]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Applied For Card Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Titillium Web", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Card Application ID :";
            // 
            // ctrlApplicationInfo1
            // 
            this.ctrlApplicationInfo1.Location = new System.Drawing.Point(5, 123);
            this.ctrlApplicationInfo1.Name = "ctrlApplicationInfo1";
            this.ctrlApplicationInfo1.Size = new System.Drawing.Size(834, 265);
            this.ctrlApplicationInfo1.TabIndex = 1;
            // 
            // ctrlNewCardApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlApplicationInfo1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlNewCardApplicationInfo";
            this.Size = new System.Drawing.Size(842, 393);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNewCardApplicationID;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.LinkLabel llbViewCardInfo;
        private Applications.Controls.ctrlApplicationInfo ctrlApplicationInfo1;
    }
}

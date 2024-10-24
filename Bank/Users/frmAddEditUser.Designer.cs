namespace Bank.Users
{
    partial class frmAddEditUser
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPersonInfoWithFilter1 = new Bank.People.Controls.ctrlPersonInfoWithFilter();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tbPersonInfo.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPersonInfo);
            this.tabControl1.Controls.Add(this.tpLoginInfo);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 68);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(977, 481);
            this.tabControl1.TabIndex = 0;
            // 
            // tbPersonInfo
            // 
            this.tbPersonInfo.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.tbPersonInfo.Controls.Add(this.btnNext);
            this.tbPersonInfo.Location = new System.Drawing.Point(4, 22);
            this.tbPersonInfo.Name = "tbPersonInfo";
            this.tbPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonInfo.Size = new System.Drawing.Size(969, 455);
            this.tbPersonInfo.TabIndex = 0;
            this.tbPersonInfo.Text = "Person Info";
            this.tbPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Bank.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(861, 405);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(92, 36);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.Controls.Add(this.pictureBox1);
            this.tpLoginInfo.Controls.Add(this.lblUserID);
            this.tpLoginInfo.Controls.Add(this.chkIsActive);
            this.tpLoginInfo.Controls.Add(this.label5);
            this.tpLoginInfo.Controls.Add(this.txtConfirmPassword);
            this.tpLoginInfo.Controls.Add(this.txtPassword);
            this.tpLoginInfo.Controls.Add(this.txtUserName);
            this.tpLoginInfo.Controls.Add(this.label3);
            this.tpLoginInfo.Controls.Add(this.label2);
            this.tpLoginInfo.Controls.Add(this.label1);
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(969, 455);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Login Info";
            this.tpLoginInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank.Properties.Resources.add_user;
            this.pictureBox1.Location = new System.Drawing.Point(641, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 257);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(208, 85);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(44, 20);
            this.lblUserID.TabIndex = 9;
            this.lblUserID.Text = "[ ? ] ";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(212, 275);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(97, 24);
            this.chkIsActive.TabIndex = 8;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Confirm Password :";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(212, 220);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(189, 29);
            this.txtConfirmPassword.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(212, 179);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(189, 29);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(212, 133);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(189, 29);
            this.txtUserName.TabIndex = 4;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(110, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::Bank.Properties.Resources.Save_321;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(897, 555);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 36);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(16, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(969, 35);
            this.lblTitle.TabIndex = 17;
            this.lblTitle.Text = "ADD TITLE";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Roboto", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Bank.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(799, 555);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.FilterEnabled = true;
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(6, 18);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(952, 381);
            this.ctrlPersonInfoWithFilter1.TabIndex = 16;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 622);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditUser";
            this.Activated += new System.EventHandler(this.frmAddEditUser_Activated);
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tbPersonInfo.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPersonInfo;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private People.Controls.ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
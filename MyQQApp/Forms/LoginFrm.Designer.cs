namespace MyQQApp.Forms
{
    partial class LoginFrm
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
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.ucBackPanel = new MyQQApp.FormControl.ucBackPanel();
            this.lbRegister = new System.Windows.Forms.Label();
            this.ucSelfHead = new MyQQApp.FormControl.ucSelfHead();
            this.checkBoxRememberPwd = new System.Windows.Forms.CheckBox();
            this.linkLabelForgetPwd = new System.Windows.Forms.LinkLabel();
            this.txtUserId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Location = new System.Drawing.Point(255, 176);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(247, 31);
            this.txtPwd.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(255, 243);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(247, 38);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMinBtn = true;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(571, 336);
            this.ucBackPanel.TabIndex = 0;
            // 
            // lbRegister
            // 
            this.lbRegister.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbRegister.Location = new System.Drawing.Point(7, 292);
            this.lbRegister.Name = "lbRegister";
            this.lbRegister.Size = new System.Drawing.Size(57, 39);
            this.lbRegister.TabIndex = 5;
            this.lbRegister.Text = "注册";
            this.lbRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbRegister.Click += new System.EventHandler(this.lbRegister_Click);
            // 
            // ucSelfHead
            // 
            this.ucSelfHead.BackColor = System.Drawing.Color.Transparent;
            this.ucSelfHead.Location = new System.Drawing.Point(74, 131);
            this.ucSelfHead.Name = "ucSelfHead";
            this.ucSelfHead.SelfHeadImage = null;
            this.ucSelfHead.SelfStatusImage = global::MyQQApp.Properties.Resources.OnLine;
            this.ucSelfHead.Size = new System.Drawing.Size(150, 150);
            this.ucSelfHead.TabIndex = 6;
            // 
            // checkBoxRememberPwd
            // 
            this.checkBoxRememberPwd.AutoSize = true;
            this.checkBoxRememberPwd.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxRememberPwd.Location = new System.Drawing.Point(255, 214);
            this.checkBoxRememberPwd.Name = "checkBoxRememberPwd";
            this.checkBoxRememberPwd.Size = new System.Drawing.Size(95, 24);
            this.checkBoxRememberPwd.TabIndex = 7;
            this.checkBoxRememberPwd.Text = "记住密码";
            this.checkBoxRememberPwd.UseVisualStyleBackColor = true;
            this.checkBoxRememberPwd.CheckStateChanged += new System.EventHandler(this.checkBoxRememberPwd_CheckStateChanged);
            // 
            // linkLabelForgetPwd
            // 
            this.linkLabelForgetPwd.AutoSize = true;
            this.linkLabelForgetPwd.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelForgetPwd.Location = new System.Drawing.Point(389, 216);
            this.linkLabelForgetPwd.Name = "linkLabelForgetPwd";
            this.linkLabelForgetPwd.Size = new System.Drawing.Size(69, 20);
            this.linkLabelForgetPwd.TabIndex = 8;
            this.linkLabelForgetPwd.TabStop = true;
            this.linkLabelForgetPwd.Text = "忘记密码";
            // 
            // txtUserId
            // 
            this.txtUserId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserId.FormattingEnabled = true;
            this.txtUserId.Location = new System.Drawing.Point(255, 131);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(247, 32);
            this.txtUserId.TabIndex = 9;
            this.txtUserId.Text = "admin";
            this.txtUserId.TextChanged += new System.EventHandler(this.txtUserId_TextChanged);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(571, 336);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.linkLabelForgetPwd);
            this.Controls.Add(this.checkBoxRememberPwd);
            this.Controls.Add(this.ucSelfHead);
            this.Controls.Add(this.lbRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.ucBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginFrm";
            this.Text = "LoginFrm";
            this.Load += new System.EventHandler(this.LoginFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControl.ucBackPanel ucBackPanel;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lbRegister;
        private FormControl.ucSelfHead ucSelfHead;
        private System.Windows.Forms.CheckBox checkBoxRememberPwd;
        private System.Windows.Forms.LinkLabel linkLabelForgetPwd;
        private System.Windows.Forms.ComboBox txtUserId;
    }
}
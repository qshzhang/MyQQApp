namespace MyQQApp.Forms
{
    partial class FriendInfoFrm
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
            this.picHead = new System.Windows.Forms.PictureBox();
            this.lbID = new System.Windows.Forms.Label();
            this.txtIP = new MyQQApp.FormControl.ucDesEdit();
            this.txtGroup = new MyQQApp.FormControl.ucDesEdit();
            this.txtRemark = new MyQQApp.FormControl.ucDesEdit();
            this.txtAge = new MyQQApp.FormControl.ucDesEdit();
            this.txtSignature = new MyQQApp.FormControl.ucDesEdit();
            this.txtNickname = new MyQQApp.FormControl.ucDesEdit();
            this.ucBackPanel = new MyQQApp.FormControl.ucBackPanel();
            this.combSex = new MyQQApp.FormControl.ucDesComb();
            this.combDegree = new MyQQApp.FormControl.ucDesComb();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.SuspendLayout();
            // 
            // picHead
            // 
            this.picHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHead.Location = new System.Drawing.Point(189, 45);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(178, 152);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHead.TabIndex = 3;
            this.picHead.TabStop = false;
            // 
            // lbID
            // 
            this.lbID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbID.ForeColor = System.Drawing.Color.Red;
            this.lbID.Location = new System.Drawing.Point(189, 204);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(178, 29);
            this.lbID.TabIndex = 13;
            this.lbID.Text = "ID: 100005";
            this.lbID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.Transparent;
            this.txtIP.ContentStr = "";
            this.txtIP.DescribeStr = "IP";
            this.txtIP.Location = new System.Drawing.Point(80, 597);
            this.txtIP.Name = "txtIP";
            this.txtIP.PasswordChr = '\0';
            this.txtIP.Size = new System.Drawing.Size(397, 48);
            this.txtIP.TabIndex = 23;
            // 
            // txtGroup
            // 
            this.txtGroup.BackColor = System.Drawing.Color.Transparent;
            this.txtGroup.ContentStr = "";
            this.txtGroup.DescribeStr = "Group";
            this.txtGroup.Location = new System.Drawing.Point(80, 546);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.PasswordChr = '\0';
            this.txtGroup.Size = new System.Drawing.Size(397, 48);
            this.txtGroup.TabIndex = 20;
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.Transparent;
            this.txtRemark.ContentStr = "";
            this.txtRemark.DescribeStr = "Remark";
            this.txtRemark.Location = new System.Drawing.Point(80, 497);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PasswordChr = '\0';
            this.txtRemark.Size = new System.Drawing.Size(397, 48);
            this.txtRemark.TabIndex = 19;
            // 
            // txtAge
            // 
            this.txtAge.BackColor = System.Drawing.Color.Transparent;
            this.txtAge.ContentStr = "";
            this.txtAge.DescribeStr = "Age";
            this.txtAge.Location = new System.Drawing.Point(80, 345);
            this.txtAge.Name = "txtAge";
            this.txtAge.PasswordChr = '\0';
            this.txtAge.Size = new System.Drawing.Size(397, 48);
            this.txtAge.TabIndex = 17;
            // 
            // txtSignature
            // 
            this.txtSignature.BackColor = System.Drawing.Color.Transparent;
            this.txtSignature.ContentStr = "";
            this.txtSignature.DescribeStr = "Signature";
            this.txtSignature.Location = new System.Drawing.Point(80, 298);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.PasswordChr = '\0';
            this.txtSignature.Size = new System.Drawing.Size(397, 48);
            this.txtSignature.TabIndex = 15;
            // 
            // txtNickname
            // 
            this.txtNickname.BackColor = System.Drawing.Color.Transparent;
            this.txtNickname.ContentStr = "";
            this.txtNickname.DescribeStr = "Nickname";
            this.txtNickname.Location = new System.Drawing.Point(80, 251);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.PasswordChr = '\0';
            this.txtNickname.Size = new System.Drawing.Size(397, 48);
            this.txtNickname.TabIndex = 14;
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMinBtn = true;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(577, 657);
            this.ucBackPanel.TabIndex = 0;
            this.ucBackPanel.Load += new System.EventHandler(this.UserInfoFrm_Load);
            // 
            // combSex
            // 
            this.combSex.BackColor = System.Drawing.Color.Transparent;
            this.combSex.DescribeStr = "Sex";
            this.combSex.Enabled = false;
            this.combSex.Location = new System.Drawing.Point(80, 393);
            this.combSex.Name = "combSex";
            this.combSex.Size = new System.Drawing.Size(397, 48);
            this.combSex.TabIndex = 24;
            // 
            // combDegree
            // 
            this.combDegree.BackColor = System.Drawing.Color.Transparent;
            this.combDegree.DescribeStr = "Degree";
            this.combDegree.Enabled = false;
            this.combDegree.Location = new System.Drawing.Point(80, 445);
            this.combDegree.Name = "combDegree";
            this.combDegree.Size = new System.Drawing.Size(397, 48);
            this.combDegree.TabIndex = 25;
            // 
            // FriendInfoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 657);
            this.Controls.Add(this.combDegree);
            this.Controls.Add(this.combSex);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.txtGroup);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtSignature);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.picHead);
            this.Controls.Add(this.ucBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FriendInfoFrm";
            this.Text = "RegisterFrm";
            this.Load += new System.EventHandler(this.UserInfoFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FormControl.ucBackPanel ucBackPanel;
        private System.Windows.Forms.PictureBox picHead;
        private System.Windows.Forms.Label lbID;
        private FormControl.ucDesEdit txtNickname;
        private FormControl.ucDesEdit txtSignature;
        private FormControl.ucDesEdit txtAge;
        private FormControl.ucDesEdit txtRemark;
        private FormControl.ucDesEdit txtGroup;
        private FormControl.ucDesEdit txtIP;
        private FormControl.ucDesComb combSex;
        private FormControl.ucDesComb combDegree;
    }
}
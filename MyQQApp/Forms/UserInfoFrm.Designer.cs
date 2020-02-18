namespace MyQQApp.Forms
{
    partial class UserInfoFrm
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
            this.ucBackPanel = new MyQQApp.FormControl.ucBackPanel();
            this.picHead = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.ucDEId = new MyQQApp.FormControl.ucDesEdit();
            this.ucDENickName = new MyQQApp.FormControl.ucDesEdit();
            this.ucDEMix1 = new MyQQApp.FormControl.ucDesEdit();
            this.ucDEMix2 = new MyQQApp.FormControl.ucDesEdit();
            this.ucDEMix3 = new MyQQApp.FormControl.ucDesEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.SuspendLayout();
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMinBtn = false;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(493, 576);
            this.ucBackPanel.TabIndex = 0;
            // 
            // picHead
            // 
            this.picHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHead.Location = new System.Drawing.Point(163, 37);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(178, 152);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHead.TabIndex = 3;
            this.picHead.TabStop = false;
            this.picHead.Click += new System.EventHandler(this.picHead_Click);
            this.picHead.MouseEnter += new System.EventHandler(this.picHead_MouseEnter);
            this.picHead.MouseLeave += new System.EventHandler(this.picHead_MouseLeave);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(175, 515);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(128, 40);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "OK";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ucDEId
            // 
            this.ucDEId.ContentStr = "";
            this.ucDEId.DescribeStr = "Id";
            this.ucDEId.Location = new System.Drawing.Point(52, 226);
            this.ucDEId.Name = "ucDEId";
            this.ucDEId.Size = new System.Drawing.Size(397, 48);
            this.ucDEId.TabIndex = 8;
            // 
            // ucDENickName
            // 
            this.ucDENickName.ContentStr = "";
            this.ucDENickName.DescribeStr = "NickName";
            this.ucDENickName.Location = new System.Drawing.Point(52, 281);
            this.ucDENickName.Name = "ucDENickName";
            this.ucDENickName.Size = new System.Drawing.Size(397, 48);
            this.ucDENickName.TabIndex = 9;
            // 
            // ucDEMix1
            // 
            this.ucDEMix1.ContentStr = "";
            this.ucDEMix1.DescribeStr = "Remark";
            this.ucDEMix1.Location = new System.Drawing.Point(52, 336);
            this.ucDEMix1.Name = "ucDEMix1";
            this.ucDEMix1.Size = new System.Drawing.Size(397, 48);
            this.ucDEMix1.TabIndex = 10;
            // 
            // ucDEMix2
            // 
            this.ucDEMix2.ContentStr = "";
            this.ucDEMix2.DescribeStr = "IP";
            this.ucDEMix2.Location = new System.Drawing.Point(52, 391);
            this.ucDEMix2.Name = "ucDEMix2";
            this.ucDEMix2.Size = new System.Drawing.Size(397, 48);
            this.ucDEMix2.TabIndex = 11;
            // 
            // ucDEMix3
            // 
            this.ucDEMix3.ContentStr = "";
            this.ucDEMix3.DescribeStr = "Signature";
            this.ucDEMix3.Location = new System.Drawing.Point(52, 446);
            this.ucDEMix3.Name = "ucDEMix3";
            this.ucDEMix3.Size = new System.Drawing.Size(397, 48);
            this.ucDEMix3.TabIndex = 12;
            // 
            // UserInfoFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 576);
            this.Controls.Add(this.ucDEMix3);
            this.Controls.Add(this.ucDEMix2);
            this.Controls.Add(this.ucDEMix1);
            this.Controls.Add(this.ucDENickName);
            this.Controls.Add(this.ucDEId);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.picHead);
            this.Controls.Add(this.ucBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserInfoFrm";
            this.Text = "UserInfoFrm";
            this.Load += new System.EventHandler(this.UserInfoFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FormControl.ucBackPanel ucBackPanel;
        private System.Windows.Forms.PictureBox picHead;
        private System.Windows.Forms.Button btnUpdate;
        private FormControl.ucDesEdit ucDEId;
        private FormControl.ucDesEdit ucDENickName;
        private FormControl.ucDesEdit ucDEMix1;
        private FormControl.ucDesEdit ucDEMix2;
        private FormControl.ucDesEdit ucDEMix3;
    }
}
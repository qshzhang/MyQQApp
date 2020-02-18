namespace MyQQApp.Forms
{
    partial class FrmRecvFile
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
            this.BtnReject = new System.Windows.Forms.Button();
            this.BtnRecv = new System.Windows.Forms.Button();
            this.ucBackPanel = new MyQQApp.FormControl.ucBackPanel();
            this.pbBase = new System.Windows.Forms.PictureBox();
            this.pbProgress = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnReject
            // 
            this.BtnReject.Location = new System.Drawing.Point(291, 110);
            this.BtnReject.Name = "BtnReject";
            this.BtnReject.Size = new System.Drawing.Size(106, 44);
            this.BtnReject.TabIndex = 1;
            this.BtnReject.Text = "拒收";
            this.BtnReject.UseVisualStyleBackColor = true;
            this.BtnReject.Click += new System.EventHandler(this.BtnReject_Click);
            // 
            // BtnRecv
            // 
            this.BtnRecv.Location = new System.Drawing.Point(438, 110);
            this.BtnRecv.Name = "BtnRecv";
            this.BtnRecv.Size = new System.Drawing.Size(106, 44);
            this.BtnRecv.TabIndex = 2;
            this.BtnRecv.Text = "接收";
            this.BtnRecv.UseVisualStyleBackColor = true;
            this.BtnRecv.Click += new System.EventHandler(this.BtnRecv_Click);
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMinBtn = false;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(569, 166);
            this.ucBackPanel.TabIndex = 0;
            // 
            // pbBase
            // 
            this.pbBase.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbBase.Location = new System.Drawing.Point(27, 43);
            this.pbBase.Name = "pbBase";
            this.pbBase.Size = new System.Drawing.Size(486, 20);
            this.pbBase.TabIndex = 3;
            this.pbBase.TabStop = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(27, 45);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(100, 16);
            this.pbProgress.TabIndex = 4;
            this.pbProgress.TabStop = false;
            // 
            // FrmRecvFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 166);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.pbBase);
            this.Controls.Add(this.BtnRecv);
            this.Controls.Add(this.BtnReject);
            this.Controls.Add(this.ucBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRecvFile";
            this.Text = "FrmRecvFile";
            this.Load += new System.EventHandler(this.FrmRecvFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FormControl.ucBackPanel ucBackPanel;
        private System.Windows.Forms.Button BtnReject;
        private System.Windows.Forms.Button BtnRecv;
        private System.Windows.Forms.PictureBox pbBase;
        private System.Windows.Forms.PictureBox pbProgress;
    }
}
namespace MyQQApp.FormControl
{
    partial class ucSelfHead
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHead = new System.Windows.Forms.Panel();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHead
            // 
            this.panelHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelHead.Controls.Add(this.panelStatus);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(100, 100);
            this.panelHead.TabIndex = 0;
            this.panelHead.Click += new System.EventHandler(this.panelHead_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelStatus.Location = new System.Drawing.Point(75, 75);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(25, 25);
            this.panelStatus.TabIndex = 0;
            this.panelStatus.Click += new System.EventHandler(this.panelStatus_Click);
            // 
            // ucSelfHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelHead);
            this.Name = "ucSelfHead";
            this.Size = new System.Drawing.Size(100, 100);
            this.panelHead.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.Panel panelStatus;
    }
}

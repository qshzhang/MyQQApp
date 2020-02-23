namespace MyQQApp.FormControl
{
    partial class ucBackPanel
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
            this.lbClose = new System.Windows.Forms.Label();
            this.lbMinWin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbClose
            // 
            this.lbClose.BackColor = System.Drawing.Color.Transparent;
            this.lbClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbClose.ForeColor = System.Drawing.Color.Black;
            this.lbClose.Location = new System.Drawing.Point(523, 10);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(35, 35);
            this.lbClose.TabIndex = 0;
            this.lbClose.Text = "X";
            this.lbClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbClose.Click += new System.EventHandler(this.btnClose_Click);
            this.lbClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.lbClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // lbMinWin
            // 
            this.lbMinWin.BackColor = System.Drawing.Color.Transparent;
            this.lbMinWin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMinWin.ForeColor = System.Drawing.Color.Black;
            this.lbMinWin.Location = new System.Drawing.Point(482, 10);
            this.lbMinWin.Name = "lbMinWin";
            this.lbMinWin.Size = new System.Drawing.Size(35, 35);
            this.lbMinWin.TabIndex = 1;
            this.lbMinWin.Text = "__";
            this.lbMinWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMinWin.Click += new System.EventHandler(this.lbMinWin_Click);
            this.lbMinWin.MouseEnter += new System.EventHandler(this.btnMin_MouseEnter);
            this.lbMinWin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            // 
            // ucBackPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbMinWin);
            this.Controls.Add(this.lbClose);
            this.Name = "ucBackPanel";
            this.Size = new System.Drawing.Size(566, 343);
            this.SizeChanged += new System.EventHandler(this.ucBackPanel_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucBackPanel_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ucBackPanel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ucBackPanel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ucBackPanel_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbClose;
        private System.Windows.Forms.Label lbMinWin;
    }
}

namespace MyQQApp.FormControl
{
    partial class ucLabelEdit
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
            this.lbMsg = new System.Windows.Forms.Label();
            this.txtEditMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.BackColor = System.Drawing.Color.Transparent;
            this.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.Location = new System.Drawing.Point(0, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(290, 24);
            this.lbMsg.TabIndex = 0;
            this.lbMsg.Text = "label1";
            this.lbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMsg.Click += new System.EventHandler(this.lbMsg_Click);
            // 
            // txtEditMsg
            // 
            this.txtEditMsg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtEditMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEditMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEditMsg.Location = new System.Drawing.Point(0, 0);
            this.txtEditMsg.Name = "txtEditMsg";
            this.txtEditMsg.Size = new System.Drawing.Size(290, 24);
            this.txtEditMsg.TabIndex = 1;
            this.txtEditMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEditMsg_KeyDown);
            // 
            // ucLabelEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtEditMsg);
            this.Controls.Add(this.lbMsg);
            this.Name = "ucLabelEdit";
            this.Size = new System.Drawing.Size(290, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.TextBox txtEditMsg;
    }
}

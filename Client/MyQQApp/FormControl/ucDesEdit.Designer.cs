namespace MyQQApp.FormControl
{
    partial class ucDesEdit
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
            this.txtVal = new System.Windows.Forms.TextBox();
            this.lbExpress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtVal
            // 
            this.txtVal.BackColor = System.Drawing.Color.White;
            this.txtVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVal.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVal.Location = new System.Drawing.Point(130, 8);
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(261, 35);
            this.txtVal.TabIndex = 0;
            // 
            // lbExpress
            // 
            this.lbExpress.BackColor = System.Drawing.Color.Transparent;
            this.lbExpress.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbExpress.Location = new System.Drawing.Point(3, 8);
            this.lbExpress.Name = "lbExpress";
            this.lbExpress.Size = new System.Drawing.Size(121, 35);
            this.lbExpress.TabIndex = 1;
            this.lbExpress.Text = "label1";
            this.lbExpress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucDesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lbExpress);
            this.Controls.Add(this.txtVal);
            this.Name = "ucDesEdit";
            this.Size = new System.Drawing.Size(397, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.Label lbExpress;
    }
}

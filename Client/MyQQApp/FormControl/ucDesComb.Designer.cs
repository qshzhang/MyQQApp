namespace MyQQApp.FormControl
{
    partial class ucDesComb
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
            this.lbExpress = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
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
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(130, 8);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(261, 36);
            this.comboBox.TabIndex = 2;
            // 
            // ucDesComb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.lbExpress);
            this.Name = "ucDesComb";
            this.Size = new System.Drawing.Size(397, 48);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbExpress;
        private System.Windows.Forms.ComboBox comboBox;
    }
}

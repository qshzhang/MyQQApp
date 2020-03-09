namespace MyQQApp.Forms
{
    partial class UpdateNameFrm
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
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMinBtn = false;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(506, 208);
            this.ucBackPanel.TabIndex = 0;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(78, 76);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(339, 28);
            this.txtGroupName.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(342, 138);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 31);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // UpdateNameFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 208);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.ucBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateNameFrm";
            this.Text = "UpdateGroupNameFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControl.ucBackPanel ucBackPanel;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Button btnOK;
    }
}
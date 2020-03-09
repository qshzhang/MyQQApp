namespace MyQQApp.Forms
{
    partial class SearchFriendFrm
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
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.colAccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNickname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSignature = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.ucBackPanel = new MyQQApp.FormControl.ucBackPanel();
            this.colDegree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchKey.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearchKey.Location = new System.Drawing.Point(12, 88);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(550, 35);
            this.txtSearchKey.TabIndex = 1;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAccount,
            this.colNickname,
            this.colSex,
            this.colSignature,
            this.colAge,
            this.colDegree,
            this.colIP});
            this.listView.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 145);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(659, 203);
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseDoubleClick);
            // 
            // colAccount
            // 
            this.colAccount.Text = "Account";
            this.colAccount.Width = 100;
            // 
            // colNickname
            // 
            this.colNickname.Text = "Nickname";
            this.colNickname.Width = 150;
            // 
            // colSex
            // 
            this.colSex.Text = "Sex";
            // 
            // colSignature
            // 
            this.colSignature.Text = "Signature";
            this.colSignature.Width = 150;
            // 
            // colAge
            // 
            this.colAge.Text = "Age";
            this.colAge.Width = 70;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(577, 88);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMinBtn = true;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(683, 446);
            this.ucBackPanel.TabIndex = 0;
            // 
            // colDegree
            // 
            this.colDegree.Text = "Degree";
            this.colDegree.Width = 73;
            // 
            // colIP
            // 
            this.colIP.Text = "IP";
            // 
            // SearchFriendFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 446);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.txtSearchKey);
            this.Controls.Add(this.ucBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SearchFriendFrm";
            this.Text = "SearchFriendFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControl.ucBackPanel ucBackPanel;
        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader colAccount;
        private System.Windows.Forms.ColumnHeader colNickname;
        private System.Windows.Forms.ColumnHeader colSex;
        private System.Windows.Forms.ColumnHeader colSignature;
        private System.Windows.Forms.ColumnHeader colAge;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ColumnHeader colDegree;
        private System.Windows.Forms.ColumnHeader colIP;
    }
}
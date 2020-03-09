namespace MyQQApp
{
    partial class MainFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UserTip = new System.Windows.Forms.ToolTip(this.components);
            this.lbMyNickname = new System.Windows.Forms.Label();
            this.lbSearch = new System.Windows.Forms.Label();
            this.Timer_UpdteUserStatus = new System.Windows.Forms.Timer(this.components);
            this.ucLabelEditSelfMsg = new MyQQApp.FormControl.ucLabelEdit();
            this.chatListBox = new MyQQApp.ChatListControl.ChatListBox();
            this.ucBackPanel = new MyQQApp.FormControl.ucBackPanel();
            this.ucSelfHead = new MyQQApp.FormControl.ucSelfHead();
            this.SuspendLayout();
            // 
            // lbMyNickname
            // 
            this.lbMyNickname.BackColor = System.Drawing.Color.Transparent;
            this.lbMyNickname.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMyNickname.ForeColor = System.Drawing.Color.White;
            this.lbMyNickname.Location = new System.Drawing.Point(134, 40);
            this.lbMyNickname.Name = "lbMyNickname";
            this.lbMyNickname.Size = new System.Drawing.Size(166, 28);
            this.lbMyNickname.TabIndex = 4;
            this.lbMyNickname.Text = "MyNickname";
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.BackColor = System.Drawing.Color.Transparent;
            this.lbSearch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSearch.Location = new System.Drawing.Point(329, 586);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(67, 24);
            this.lbSearch.TabIndex = 6;
            this.lbSearch.Text = "Search";
            this.lbSearch.Click += new System.EventHandler(this.lbSearch_Click);
            // 
            // Timer_UpdteUserStatus
            // 
            this.Timer_UpdteUserStatus.Tick += new System.EventHandler(this.Timer_UpdteUserStatus_Tick);
            // 
            // ucLabelEditSelfMsg
            // 
            this.ucLabelEditSelfMsg.BackColor = System.Drawing.Color.Transparent;
            this.ucLabelEditSelfMsg.Location = new System.Drawing.Point(134, 72);
            this.ucLabelEditSelfMsg.Msg = "label1";
            this.ucLabelEditSelfMsg.Name = "ucLabelEditSelfMsg";
            this.ucLabelEditSelfMsg.Size = new System.Drawing.Size(259, 30);
            this.ucLabelEditSelfMsg.TabIndex = 3;
            // 
            // chatListBox
            // 
            this.chatListBox.BackColor = System.Drawing.Color.SteelBlue;
            this.chatListBox.ForeColor = System.Drawing.Color.Black;
            this.chatListBox.ItemColor = System.Drawing.Color.SteelBlue;
            this.chatListBox.Location = new System.Drawing.Point(28, 153);
            this.chatListBox.Name = "chatListBox";
            this.chatListBox.Size = new System.Drawing.Size(365, 426);
            this.chatListBox.SubItemColor = System.Drawing.Color.SteelBlue;
            this.chatListBox.TabIndex = 0;
            this.chatListBox.Text = "chatListBox1";
            this.chatListBox.DoubleClickSubItem += new MyQQApp.ChatListControl.ChatListBox.ChatListEventHandler(this.chatListBox_DoubleClickSubItem);
            this.chatListBox.MouseEnterHead += new MyQQApp.ChatListControl.ChatListBox.ChatListEventHandler(this.chatListBox_MouseEnterHead);
            this.chatListBox.MouseLeaveHead += new MyQQApp.ChatListControl.ChatListBox.ChatListEventHandler(this.chatListBox_MouseLeaveHead);
            // 
            // ucBackPanel
            // 
            this.ucBackPanel.BackColor = System.Drawing.Color.Transparent;
            this.ucBackPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucBackPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucBackPanel.IsShowMinBtn = true;
            this.ucBackPanel.Location = new System.Drawing.Point(0, 0);
            this.ucBackPanel.Name = "ucBackPanel";
            this.ucBackPanel.Size = new System.Drawing.Size(421, 623);
            this.ucBackPanel.TabIndex = 1;
            this.ucBackPanel.Click += new System.EventHandler(this.ucBackPanel_Click);
            // 
            // ucSelfHead
            // 
            this.ucSelfHead.BackColor = System.Drawing.Color.Transparent;
            this.ucSelfHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucSelfHead.Location = new System.Drawing.Point(28, 12);
            this.ucSelfHead.Name = "ucSelfHead";
            this.ucSelfHead.SelfHeadImage = null;
            this.ucSelfHead.SelfStatusImage = null;
            this.ucSelfHead.Size = new System.Drawing.Size(100, 100);
            this.ucSelfHead.TabIndex = 7;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(421, 623);
            this.Controls.Add(this.ucSelfHead);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lbMyNickname);
            this.Controls.Add(this.ucLabelEditSelfMsg);
            this.Controls.Add(this.chatListBox);
            this.Controls.Add(this.ucBackPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainFrm";
            this.Text = "QQ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChatListControl.ChatListBox chatListBox;
        private FormControl.ucBackPanel ucBackPanel;
        private System.Windows.Forms.ToolTip UserTip;
        private FormControl.ucLabelEdit ucLabelEditSelfMsg;
        private System.Windows.Forms.Label lbMyNickname;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Timer Timer_UpdteUserStatus;
        private FormControl.ucSelfHead ucSelfHead;
    }
}


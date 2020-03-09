using MyQQApp.common;
using MyQQApp.FormControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQApp.Forms
{
    public partial class MenuFrm : Form
    {
        Boolean isNewFrmClicked = false;

        public delegate void UserInfoUpdateCallback(Boolean isUpdated, ChatListControl.ChatListSubItem chatListSubItem);
        public UserInfoUpdateCallback userInfoUpdateCallback;

        public delegate void UpdatedNameCallback(string id, string oldNname, string newName);
        public event UpdatedNameCallback UpdatedName;

        public delegate void StatusChangedCallback(int type);
        public event StatusChangedCallback StatusChanged;

        object internalPara;
        public MenuFrm(object para)
        {
            InitializeComponent();
            internalPara = para;

            const int height = 30;

            ucMenuItem ucMenuItemScan = new ucMenuItem();
            ucMenuItemScan.MenuDesc = "查看资料";
            ucMenuItemScan.IconImage = null;
            ucMenuItemScan.Height = height;
            ucMenuItemScan.MenuItemClick += OnMenuItemClickForInfo;
            this.Controls.Add(ucMenuItemScan);
            ucMenuItemScan.Location = new Point(0, 0);

            ucMenuItem ucMenuItemEdit = new ucMenuItem();
            ucMenuItemEdit.MenuDesc = "修改备注";
            ucMenuItemEdit.IconImage = null;
            ucMenuItemEdit.Height = height;
            ucMenuItemEdit.MenuItemClick += OnMenuItemClickForUpdateInfo;
            this.Controls.Add(ucMenuItemEdit);
            ucMenuItemEdit.Location = new Point(0, height);

            ucMenuItem ucMenuItemChat = new ucMenuItem();
            ucMenuItemChat.MenuDesc = "发起会话";
            ucMenuItemChat.IconImage = null;
            ucMenuItemChat.Height = height;
            ucMenuItemChat.MenuItemClick += OnMenuItemClickForChat;
            this.Controls.Add(ucMenuItemChat);
            ucMenuItemChat.Location = new Point(0, 2 * height);

            ucMenuItem ucMenuItemMoveFriend = new ucMenuItem();
            ucMenuItemMoveFriend.MenuDesc = "移动好友至";
            ucMenuItemMoveFriend.IconImage = null;
            ucMenuItemMoveFriend.Height = height;
            ucMenuItemMoveFriend.MenuItemClick += OnMenuItemClickForChat;
            this.Controls.Add(ucMenuItemMoveFriend);
            ucMenuItemMoveFriend.Location = new Point(0, 3 * height);

            this.Height = 4 * height;
        }

        public MenuFrm()
        {
            InitializeComponent();

            const int height = 30;

            for(int i = 0;i < (int)GlobalValue.UserStatus.END; i++)
            {
                ucMenuItem ucMenuItem = new ucMenuItem();
                ucMenuItem.MenuDesc = Enum.GetName(typeof(GlobalValue.UserStatus), i);
                ucMenuItem.Para = i;
                ucMenuItem.IconImage = common.CommonTools.GetImageByType(i);
                ucMenuItem.Height = height;
                ucMenuItem.MenuItemClick += OnMenuItemClickForStatus;
                this.Controls.Add(ucMenuItem);
                ucMenuItem.Location = new Point(0, i * height);
            }

            this.Height = ((int)GlobalValue.UserStatus.END) * height;
            this.BackColor = Color.White;
        }

        private void OnMenuItemClickForStatus(object obj)
        {
            if(null != StatusChanged)
            {
                StatusChanged((int)obj);
            }
            this.Close();
        }

        private void MenuFrm_Load(object sender, EventArgs e)
        {
            
        }

        public void OnMenuItemClickForInfo(object obj)
        {
            Friend friend = new Friend();

            friend.ID = ((ChatListControl.ChatListSubItem)internalPara).ID;
            friend.Nickname = ((ChatListControl.ChatListSubItem)internalPara).NicName;
            friend.PublicIP = ((ChatListControl.ChatListSubItem)internalPara).IpAddress;
            friend.LocalIP = ((ChatListControl.ChatListSubItem)internalPara).InnerIpAddress;
            friend.Remark = ((ChatListControl.ChatListSubItem)internalPara).DisplayName;
            friend.Signature = ((ChatListControl.ChatListSubItem)internalPara).PersonalMsg;
            friend.HeadImage = GlobalValue.DataFromServer.QueryUserHeadImageName(friend.ID);

            FriendInfoFrm userInfoFrm = new FriendInfoFrm(friend);
            userInfoFrm.Show();
            this.Close();
        }

        public void OnMenuItemClickForUpdateInfo(object obj)
        {
            isNewFrmClicked = true;
            this.Visible = false;

            UpdateNameFrm UpdateFrm = new UpdateNameFrm(((ChatListControl.ChatListSubItem)internalPara).DisplayName.Trim(), ((ChatListControl.ChatListSubItem)internalPara).ID);
            UpdateFrm.UpdateName += onUpdateInfoFrmCloseBefore;
            UpdateFrm.Show();
        }

        public void OnMenuItemClickForChat(object obj)
        {
            //if (DialogFrm.isContainedOpenedWindow(((ChatListControl.ChatListSubItem)internalPara).ID)) return;
            //DialogFrm dialogFrm = new DialogFrm((ChatListControl.ChatListSubItem)internalPara);
            //dialogFrm.Show();

            this.Close();
        }

        private void MenuFrm_Deactivate(object sender, EventArgs e)
        {
            if (isNewFrmClicked == true) return;
            this.Close();
        }

        private void onUpdateInfoFrmCloseBefore(string id, string oldName, string newName)
        {
            if(null != UpdatedName)
            {
                UpdatedName(id, oldName, newName);
            }
            this.Close();
        }
    }
}

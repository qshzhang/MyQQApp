using MyQQApp.ChatListControl;
using MyQQApp.common;
using MyQQApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQApp
{
    partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            ucBackPanel.onBtnClose_Click += OnBtnClose;
            ucBackPanel.onBtnMin_Click += MainFrm_MinWindow;
            chatListBox.RightClickSubItem += chatListBox_RightClickSubItem;
            chatListBox.RightClickItem += chatListBox_RightClickItem;
            chatListBox.GetNewPersonalMsgCallback += chatListBox_GetNewPersonalMsgCallback;
            chatListBox.RightClickGenGroup += chatListBox_RightClickGenGroup;


            ucLabelEditSelfMsg.ActionForExitEditCallback += UpdateUserSignature;

            ucSelfHead.SelfHeadClickCallback += picSelfHead_Click;

            ucSelfHead.SelfStatusClickCallback += panelStatus_Click;

            //ucLabelEditSearch.ActionForExitEditCallback += SearchFriendInFriendList;
        }

        private void OnBtnClose()
        {
            this.Close();
        }

        

        public void chatListBox_RightClickGenGroup()
        {
            UpdateNameFrm updateGroupFrm = new UpdateNameFrm("");
            updateGroupFrm.StartPosition = FormStartPosition.Manual;
            updateGroupFrm.Location = Control.MousePosition;
            updateGroupFrm.UpdateName += OnGenGroupCallback;
            updateGroupFrm.Show();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Boolean IsSuccess = GlobalValue.DataFromServer.UpdateUserStatus(
                GlobalValue.myself.ID, GlobalValue.myself.Status);

            GlobalValue.myself.CopyFrom(GlobalValue.DataFromServer.QueryUserInfo(GlobalValue.myself.ID));

            ucSelfHead.SelfHeadImage = common.CommonTools.GetImageByPicName(GlobalValue.myself.HeadImage);
            ucSelfHead.SelfStatusImage = common.CommonTools.GetImageByType((short)GlobalValue.myself.Status);
            lbMyNickname.Text = GlobalValue.myself.Nickname;
            ucLabelEditSelfMsg.Msg = GlobalValue.myself.Signature;

            Boolean IsUpdateSuccess = GlobalValue.DataFromServer.UpdateUserLastLoginTime(
                GlobalValue.myself.ID);

            Timer_UpdteUserStatus.Start();

            InitUdp();
            InitTcp();

            Boolean IsUpdateAddr = GlobalValue.DataFromServer.UpdateUserAddr(
                GlobalValue.myself.ID, NetTool.GetPublicIp(), NetTool.GetLocalIpAddress(), GlobalValue.myself.UdpPort, GlobalValue.myself.TcpPort);

            List<Friend> list = GlobalValue.DataFromServer.QueryRelationTabByMyAccount(GlobalValue.myself.ID);

            if (list.Count == 0)
            {
                GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, "query no friends");
                return;
            }

            Dictionary<string, List<Friend>> dictionary = new Dictionary<string, List<Friend>>();

            Dictionary<string, string> GroupPair = new Dictionary<string, string>();

            foreach (Friend tab in list)
            {
                if (!dictionary.Keys.Contains(tab.GroupID))
                {
                    dictionary[tab.GroupID] = new List<Friend>();
                    GroupPair[tab.GroupID] = tab.GroupName;
                }
                if (tab.ID.Length == 6)
                {
                    dictionary[tab.GroupID].Add(tab);
                }
            }
            foreach (string groupid in dictionary.Keys)
            {
                ChatListItem item = new ChatListItem(groupid, GroupPair[groupid]);
                foreach (Friend friend in dictionary[groupid])
                {
                    ChatListSubItem subItem = new ChatListSubItem(friend.Nickname, friend.Remark, friend.Signature);
                    subItem.ID = friend.ID;
                    subItem.HeadImage = CommonTools.GetImageByPicName(friend.HeadImage);
                    subItem.Status = friend.Status;
                    subItem.IpAddress = friend.PublicIP;
                    subItem.InnerIpAddress = friend.LocalIP;
                    subItem.UpdPort = friend.UdpPort;
                    subItem.TcpPort = friend.TcpPort;
                    subItem.GroupName = GroupPair[groupid];
                    item.SubItems.AddAccordingToStatus(subItem);
                }
                item.SubItems.Sort();
                chatListBox.Items.Add(item);
            }
            GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, "load friends list success");
            GlobalValue.QQLog.LogFlush();
        }

        private void chatListBox_DoubleClickSubItem(object sender, ChatListEventArgs e)
        {
            if (null == e.MouseOnSubItem) return;
            e.MouseOnSubItem.IsTwinkle = false;

            NetAddr netAddr = GlobalValue.DataFromServer.GetFriendAddr(e.MouseOnSubItem.ID);

            e.MouseOnSubItem.IpAddress = netAddr.PublicIP;
            e.MouseOnSubItem.InnerIpAddress = netAddr.LocalIP;
            e.MouseOnSubItem.UpdPort = netAddr.UdpPort;
            e.MouseOnSubItem.TcpPort = netAddr.TcpPort;

            int index = DialogFrm.GetIndexInOpenedFrm(e.MouseOnSubItem.ID);
            if (-1 != index)
            {
                DialogFrm.SetFrmActivated(index);
                DialogFrm.dialogFrmOpenlist[index].Dialog.updateFriendAddr(netAddr);
                return;
            }
            DialogFrm dialogFrm = new DialogFrm(e.SelectSubItem);
            dialogFrm.SendMsgToFriendCallback += SendMsgCallback;
            dialogFrm.Show();
        }

        private string chatListBox_GetNewPersonalMsgCallback(string account)
        {
            return GlobalValue.DataFromServer.GetUserSignature(account);
        }

        private void chatListBox_RightClickSubItem(object sender, ChatListEventArgs e)
        {
            RightMenu menu = new RightMenu(e.MouseOnSubItem);   
            menu.AddMenuItem("查看资料"); 
            menu.AddMenuItem("修改备注");
            menu.AddMenuItem("发起聊天");
            menu.AddMenuItem("删除好友");
            ((RightMenuItem)menu.MenuItems[0]).OnMenuItenClickCallback += MenuItemForViewFriendInfo;
            ((RightMenuItem)menu.MenuItems[1]).OnMenuItenClickCallback += MenuItemForUpdateFriendRemark;
            ((RightMenuItem)menu.MenuItems[2]).OnMenuItenClickCallback += MenuItemForChatWithFriend;
            ((RightMenuItem)menu.MenuItems[3]).OnMenuItenClickCallback += MenuItemForRemoveFriend;

            menu.AddMenuItem("移动好友至");

            string oldGroupId = GetFriendGroupId(e.MouseOnSubItem.ID);

            for (int i = 0;i < chatListBox.Items.Count;i++)
            {
                MoveFriendGroup para = new MoveFriendGroup(e.MouseOnSubItem.ID, chatListBox.Items[i].ID, chatListBox.Items[i].Text);
                ((RightMenuItem)menu.MenuItems[4]).AddMenuItem(chatListBox.Items[i].Text, para);

                ((RightMenuItem)menu.MenuItems[4].MenuItems[i]).OnMenuItenClickCallback += MenuItemForChangeGroup;

                if (chatListBox.Items[i].ID.CompareTo(oldGroupId) == 0)
                {
                    menu.MenuItems[4].MenuItems[i].Enabled = false;
                }
            }

            menu.Show(this, new Point(Control.MousePosition.X - this.Location.X, Control.MousePosition.Y - this.Location.Y));
        }

        private void chatListBox_RightClickItem(object sender, ChatGroupEventArgs e)
        {
            UpdateNameFrm updateGroupFrm = new UpdateNameFrm(e.SelectItem.Text, e.SelectItem.ID);
            updateGroupFrm.StartPosition = FormStartPosition.Manual;
            updateGroupFrm.Location = Control.MousePosition;
            updateGroupFrm.UpdateName += OnUpdateGroupName;
            updateGroupFrm.Show();
        }

        

        private void chatListBox_MouseEnterHead(object sender, ChatListEventArgs e)
        {
            UserTip.Active = true;
            UserTip.SetToolTip(this.chatListBox, "status: " + e.MouseOnSubItem.Status + "\nname: " + e.MouseOnSubItem.DisplayName);
        }

        private void chatListBox_MouseLeaveHead(object sender, ChatListEventArgs e)
        {
            UserTip.Active = false;
        }
        

        private void picSelfHead_Click()
        {
            MyselfInfoFrm userInfoFrm = new MyselfInfoFrm(GlobalValue.myself);
            userInfoFrm.UpdateMyselfInfoCallback += OnUpdateSelfInfoCallback;
            userInfoFrm.Show();
            GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, "self head click");
        }

        private void ucBackPanel_Click(object sender, EventArgs e)
        {
            ucLabelEditSelfMsg.exitEdit();
        }

        private void MainFrm_MinWindow()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelStatus_Click()
        {
            RightMenu menu = new RightMenu(null);
            for (int i = 0; i < (int)GlobalValue.UserStatus.END; i++)
            {
                menu.AddMenuItem(Enum.GetName(typeof(GlobalValue.UserStatus), i), i);
                ((RightMenuItem)menu.MenuItems[i]).OnMenuItenClickCallback = StatusChangedCallback;
            }
            menu.Show(this, new Point(Control.MousePosition.X - this.Location.X, Control.MousePosition.Y - this.Location.Y));
        }

        

        private void lbSearch_Click(object sender, EventArgs e)
        {
            SearchFriendFrm searchFriendFrm = new SearchFriendFrm();
            searchFriendFrm.mainFrmAddFriendCallback += ChatListAddFriend;
            searchFriendFrm.Show();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Boolean IsSuccess = GlobalValue.DataFromServer.UpdateUserStatus(
                GlobalValue.myself.ID, GlobalValue.UserStatus.OffLine);

            GlobalValue.QQLog.QuitLog();
        }

        private void Timer_UpdteUserStatus_Tick(object sender, EventArgs e)
        {
            UpdateUserStatusByEveryTimer();
        }

    }
}

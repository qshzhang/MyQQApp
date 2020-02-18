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
    partial class MainFrm
    {
        public void MenuItemForViewFriendInfo(object internalPara)
        {
            Friend friend = new Friend();
            DBOperator dBOperator = new DBOperator();

            friend.ID = ((ChatListControl.ChatListSubItem)internalPara).ID;
            friend.Nickname = ((ChatListControl.ChatListSubItem)internalPara).NicName;
            friend.IP = ((ChatListControl.ChatListSubItem)internalPara).IpAddress;
            friend.Remark = ((ChatListControl.ChatListSubItem)internalPara).DisplayName;
            friend.Signature = ((ChatListControl.ChatListSubItem)internalPara).PersonalMsg;
            friend.HeadImage = dBOperator.QueryUserHeadImageName(friend.ID);

            UserInfoFrm userInfoFrm = new UserInfoFrm(friend);
            userInfoFrm.Show();
        }

        public void MenuItemForUpdateFriendRemark(object internalPara)
        {
            UpdateNameFrm UpdateFrm = new UpdateNameFrm(((ChatListControl.ChatListSubItem)internalPara).DisplayName.Trim(), ((ChatListControl.ChatListSubItem)internalPara).ID);
            UpdateFrm.UpdateName += OnUpdateFriendRemark;
            UpdateFrm.Location = new Point(Control.MousePosition.X - this.Location.X, Control.MousePosition.Y - this.Location.Y);
            UpdateFrm.Show();
        }

        public void MenuItemForRemoveFriend(object internalPara)
        {
            string friendid = ((ChatListControl.ChatListSubItem)internalPara).ID;

            DBOperator dBOperator = new DBOperator();
            dBOperator.RemoveFriend(GlobalValue.myself.ID, friendid);

            for (int i = 0; i < chatListBox.Items.Count; i++)
            {
                if (chatListBox.Items[i].Text == ((ChatListControl.ChatListSubItem)internalPara).GroupName)
                {
                    for(int j = 0; j < chatListBox.Items[i].SubItems.Count; j++)
                    {
                        if(chatListBox.Items[i].SubItems[j].ID == friendid)
                        {
                            chatListBox.Items[i].SubItems.RemoveAt(j);
                            GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, string.Format("remove friend({0}, {1}) success", ((ChatListControl.ChatListSubItem)internalPara).GroupName, friendid));
                            return;
                        }
                    }
                }
            }
        }

        public void ChatListAddFriend(Friend friend)
        {
            DBOperator dBOperator = new DBOperator();
            User user = dBOperator.QueryUserInfo(friend.ID);
            ChatListSubItem subItem = new ChatListSubItem(user.Nickname, friend.Remark, user.Signature);
            subItem.ID = user.ID;
            subItem.HeadImage = CommonTools.GetImageByPicName(user.HeadImage);
            subItem.Status = user.Status;
            subItem.IpAddress = user.IP;
            subItem.UpdPort = user.UdpPort;
            subItem.TcpPort = user.TcpPort;
            subItem.PersonalMsg = user.Signature;

            for (int i = 0; i < chatListBox.Items.Count; i++)
            {
                if(chatListBox.Items[i].Text == friend.Groupname)
                {
                    chatListBox.Items[i].SubItems.AddAccordingToStatus(subItem);
                    break;
                }
            }

        }

        public void MenuItemForChatWithFriend(object internalPara)
        {
            ((ChatListControl.ChatListSubItem)internalPara).IsTwinkle = false;
            DBOperator dBOperator = new DBOperator();
            NetAddr netAddr = dBOperator.GetFriendAddr(((ChatListControl.ChatListSubItem)internalPara).ID);

            ((ChatListControl.ChatListSubItem)internalPara).IpAddress = netAddr.IP;
            ((ChatListControl.ChatListSubItem)internalPara).UpdPort = netAddr.UdpPort;
            ((ChatListControl.ChatListSubItem)internalPara).TcpPort = netAddr.TcpPort;

            string account = ((ChatListControl.ChatListSubItem)internalPara).ID;
            int index = DialogFrm.GetIndexInOpenedFrm(account);
            if (-1 != index)
            {
                DialogFrm.SetFrmActivated(index);
                DialogFrm.dialogFrmOpenlist[index].Dialog.updateFriendAddr(netAddr);
                return;
            }


            DialogFrm dialogFrm = new DialogFrm((ChatListControl.ChatListSubItem)internalPara);
            dialogFrm.SendMsgToFriendCallback += SendMsgCallback;
            dialogFrm.Show();
        }

        public void MenuItemForChangeGroup(object internalPara)
        {
            MoveFriendGroup moveFriendGroup = (MoveFriendGroup)internalPara;
            DBOperator dBOperator = new DBOperator();
            dBOperator.UpdateFriendGroup(GlobalValue.myself.ID, moveFriendGroup.friendAccount, moveFriendGroup.newGroupName);

            ChatListSubItem chatListSubItem = null;
            int newGroupIndex = 0;
            int oldGroupIndex = 0;
            int oldListIndex = -1;
            int index = -1;
            for (int i = 0;i < chatListBox.Items.Count;i++)
            {
                if(chatListBox.Items[i].Text.CompareTo(moveFriendGroup.newGroupName) == 0)
                {
                    newGroupIndex = i;
                }

                index = chatListBox.Items[i].GroupContainAccount(moveFriendGroup.friendAccount);
                if (index != -1)
                {
                    oldGroupIndex = i;
                    oldListIndex = index;
                    chatListSubItem = chatListBox.Items[i].SubItems[index];
                }
            }
            if(oldListIndex != -1)
            {
                chatListBox.Items[oldGroupIndex].SubItems.RemoveAt(oldListIndex);
                chatListBox.Items[newGroupIndex].SubItems.Add(chatListSubItem);
            }


            MessageBox.Show(moveFriendGroup.friendAccount + "--" + moveFriendGroup.newGroupName);
        }

        private void UpdateUserSignature(string sig)
        {
            DBOperator dBOperator = new DBOperator();
            dBOperator.UpdateUserSignature(GlobalValue.myself.ID, sig);
            GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, string.Format("signature changed:{0} -> {1}", GlobalValue.myself.Signature, sig));
            GlobalValue.myself.Signature = sig;
        }

//        private void SearchFriendInFriendList(string account)
//        {
//            MessageBox.Show(account);
//        }

        private void OnGenGroupCallback(string id, string oldName, string newName)
        {
            DBOperator dBOperator = new DBOperator();
            dBOperator.GenerateNewGroup(GlobalValue.myself.ID, newName);

            ChatListItem item = new ChatListItem(newName);
            chatListBox.Items.Add(item);
        }

        private void OnUpdateGroupName(string id, string oldName, string newName)
        {
            chatListBox.SelectGroup.Text = newName;
            DBOperator dBOperator = new DBOperator();
            dBOperator.UpdateGroupName(GlobalValue.myself.ID, oldName, newName);
            GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, string.Format("groupname changed:{0} -> {1}", oldName, newName));
        }

        private void OnUpdateSelfInfoCallback(User myself)
        {
            DBOperator dBOperator = new DBOperator();
            if (dBOperator.UpdateUserInfo(myself.ID, myself.Nickname, myself.Signature,
                myself.HeadImage, myself.Sex, myself.Age, myself.Degree))
            {
                #region#
                if(0 != myself.Nickname.CompareTo(GlobalValue.myself.Nickname))
                {
                    GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, 
                        string.Format("nickname changed:{0} -> {1}", GlobalValue.myself.Nickname, myself.Nickname));
                }

                if (0 != myself.Signature.CompareTo(GlobalValue.myself.Signature))
                {
                    GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO,
                        string.Format("signature changed:{0} -> {1}", GlobalValue.myself.Signature, myself.Signature));
                }
                #endregion#
                MessageBox.Show("update success");
                GlobalValue.myself.Nickname = myself.Nickname;
                GlobalValue.myself.Signature = myself.Signature;
                GlobalValue.myself.HeadImage = myself.HeadImage;
                GlobalValue.myself.Sex = myself.Sex;
                GlobalValue.myself.Age = myself.Age;
                GlobalValue.myself.Degree = myself.Degree;

                ucSelfHead.SelfHeadImage = common.CommonTools.GetImageByPicName(myself.HeadImage);

                this.lbMyNickname.Text = GlobalValue.myself.Nickname;
                this.ucLabelEditSelfMsg.Msg = GlobalValue.myself.Signature;
            }
            else
            {
                MessageBox.Show("update failed");
                GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_ERROR, "update selfinfo failed");
            }

        }

        private void StatusChangedCallback(object type)
        {
            ucSelfHead.SelfStatusImage = common.CommonTools.GetImageByType(Convert.ToInt16(type));
            DBOperator dBOperator = new DBOperator();
            dBOperator.UpdateUserStatus(GlobalValue.myself.ID, Convert.ToInt16(type));
            GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, string.Format("status changed:{0} -> {1}", GlobalValue.myself.Status, (GlobalValue.UserStatus)Convert.ToInt16(type)));
            GlobalValue.myself.Status = (GlobalValue.UserStatus)Convert.ToInt16(type);
        }

        private void UpdateUserStatusByEveryTimer()
        {
            DBOperator dBOperator = new DBOperator();
            foreach (ChatListItem item in chatListBox.Items)
            {
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    item.SubItems[i].Status = dBOperator.QueryFriendStatus(item.SubItems[i].ID);
                }
            }
        }


        private string GetFriendGroupName(string account)
        {
            int index = -1;
            for (int i = 0; i < chatListBox.Items.Count; i++)
            {
                index = chatListBox.Items[i].GroupContainAccount(account);
                if (index != -1)
                {
                    return chatListBox.Items[i].Text;
                }
            }

            return null;
         
        }

    }
}

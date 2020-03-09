using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQAppServer
{
    public class MsgDeal
    {
        private ServerUdpMessage ServerUdpMessage;
        public void InitServerUdp()
        {
            ServerUdpMessage = new ServerUdpMessage(GlobalValue.ServerPort);

            ServerUdpMessage.ReceiveMsgCallback += ReceiveMsgDeal;

            ServerUdpMessage.StartRevMsg();

        }

        private void ReceiveMsgDeal(CSMsgInfo msgInfo)
        {
            Json json = new Json(msgInfo.MsgContent);
            DBOperator dBOperator = new DBOperator();
            Json result = new Json();
            CSMessageType cSMessageType = CSMessageType.END;

            if (msgInfo.MsgType == CSMessageType.QueryIsUserAndPwdValid)
            {
                string account = json.JsonGetValueByKey(GlobalValue.AccountStr);
                string pwd = json.JsonGetValueByKey(GlobalValue.PasswordStr);

                cSMessageType = CSMessageType.QueryIsUserAndPwdValid;

                Boolean IsSuccess = dBOperator.IsValidAccount(account, pwd);

                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
                
            }
            else if (msgInfo.MsgType == CSMessageType.QueryUserHeadImageName)
            {
                string account = json.JsonGetValueByKey(GlobalValue.AccountStr);
                cSMessageType = CSMessageType.QueryUserHeadImageName;
                string name = dBOperator.QueryUserHeadImageName(account);
                result.JsonAddStringElement(GlobalValue.HeadImageNameStr, name);
            }
            else if(msgInfo.MsgType == CSMessageType.UpdateUserStatus)
            {
                Boolean flag = dBOperator.UpdateUserStatus(json.JsonGetValueByKey(GlobalValue.AccountStr), 
                    Convert.ToInt16(json.JsonGetValueByKey(GlobalValue.StatusStr)));
                cSMessageType = CSMessageType.UpdateUserStatus;

                result.JsonAddStringElement(GlobalValue.ResultStr, flag == true ? "1" : "0");
            }
            else if (msgInfo.MsgType == CSMessageType.UpdateUserLastLoginTime)
            {
                Boolean flag = dBOperator.UpdateUserLastLoginTime(
                    json.JsonGetValueByKey(GlobalValue.AccountStr));
                cSMessageType = CSMessageType.UpdateUserLastLoginTime;

                result.JsonAddStringElement(GlobalValue.ResultStr, flag == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.UpdateUserAddr)
            {
                Boolean flag = dBOperator.UpdateUserAddr(
                    json.JsonGetValueByKey(GlobalValue.AccountStr),
                    json.JsonGetValueByKey(GlobalValue.PublicIPStr),
                    json.JsonGetValueByKey(GlobalValue.LocalIPStr),
                    Convert.ToInt32(json.JsonGetValueByKey(GlobalValue.UDPPortStr)),
                    Convert.ToInt32(json.JsonGetValueByKey(GlobalValue.TCPPortStr)));
                cSMessageType = CSMessageType.UpdateUserAddr;

                result.JsonAddStringElement(GlobalValue.ResultStr, flag == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.QueryRelationTabByMyAccount)
            {
                //List<RelationTab> list = dBOperator.QueryRelationTabByMyAccount(json.JsonGetValueByKey("id"));
                List<Friend> list = dBOperator.QueryAllFriendAndGroupInfoByMyAccount(json.JsonGetValueByKey(GlobalValue.AccountStr));
                cSMessageType = CSMessageType.QueryRelationTabByMyAccount;

                result.JsonAddListObjectElement(GlobalValue.ResultStr, list.ConvertAll(s => (object)s));
            }
            else if(msgInfo.MsgType == CSMessageType.GetFriendAddr)
            {
                NetAddr netAddr = dBOperator.GetFriendAddr(json.JsonGetValueByKey(GlobalValue.AccountStr));
                cSMessageType = CSMessageType.GetFriendAddr;

                result.JsonAddObjectElement(GlobalValue.ResultStr, netAddr);
            }
            else if(msgInfo.MsgType == CSMessageType.GetUserSignature)
            {
                string str = dBOperator.GetUserSignature(json.JsonGetValueByKey(GlobalValue.AccountStr));
                cSMessageType = CSMessageType.GetUserSignature;

                result.JsonAddStringElement(GlobalValue.ResultStr, str);
            }
            else if(msgInfo.MsgType == CSMessageType.QueryFriendStatus)
            {
                GlobalValue.UserStatus userStatus = 
                    dBOperator.QueryFriendStatus(json.JsonGetValueByKey(GlobalValue.AccountStr));

                cSMessageType = CSMessageType.QueryFriendStatus;
                result.JsonAddIntElement(GlobalValue.ResultStr, (int)userStatus);
            }
            else if(msgInfo.MsgType == CSMessageType.UpdateFriendRemark)
            {
                string account = json.JsonGetValueByKey(GlobalValue.AccountStr);
                string friendid = json.JsonGetValueByKey(GlobalValue.FriendAccountStr);
                string remark = json.JsonGetValueByKey(GlobalValue.RemarkStr);

                Boolean flag = dBOperator.UpdateFriendRemark(account, friendid, remark);

                cSMessageType = CSMessageType.UpdateFriendRemark;
                result.JsonAddStringElement(GlobalValue.ResultStr, flag == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.InsertRelationTab)
            {
                string account = json.JsonGetValueByKey(GlobalValue.AccountStr);
                string friendid = json.JsonGetValueByKey(GlobalValue.FriendAccountStr);
                string group = json.JsonGetValueByKey(GlobalValue.GroupIDStr);
                string remark = json.JsonGetValueByKey(GlobalValue.RemarkStr);

                Boolean IsSuccess = dBOperator.InsertRelationTab(
                    account, friendid, group, remark);

                cSMessageType = CSMessageType.InsertRelationTab;
                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if (msgInfo.MsgType == CSMessageType.UpdateFriendGroup)
            {
                string account = json.JsonGetValueByKey(GlobalValue.AccountStr);
                string friendid = json.JsonGetValueByKey(GlobalValue.FriendAccountStr);
                string newgroup = json.JsonGetValueByKey(GlobalValue.GroupIDStr);

                Boolean IsSuccess = dBOperator.UpdateFriendGroup(account, friendid, newgroup);

                cSMessageType = CSMessageType.UpdateFriendGroup;
                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.GetGroupIdByAccount)
            {
                string account = json.JsonGetValueByKey(GlobalValue.AccountStr);

                List<string> groupids = dBOperator.GetGroupIdByAccount(account);

                cSMessageType = CSMessageType.GetGroupIdByAccount;
                result.JsonAddListObjectElement(GlobalValue.ResultStr, groupids.ConvertAll(s => (object)s));
            }
            else if(msgInfo.MsgType == CSMessageType.GenerateNewGroup)
            {
                string account = json.JsonGetValueByKey(GlobalValue.AccountStr);
                string newgroupid = json.JsonGetValueByKey(GlobalValue.GroupIDStr);
                string newgroupname = json.JsonGetValueByKey(GlobalValue.GroupNameStr);

                Boolean IsSuccess = dBOperator.GenerateNewGroup(account, newgroupid , newgroupname);

                cSMessageType = CSMessageType.GenerateNewGroup;

                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.UpdateGroupName)
            {
                string account = json.JsonGetValueByKey(GlobalValue.AccountStr);
                string groupid = json.JsonGetValueByKey(GlobalValue.GroupIDStr);
                string newgroupname = json.JsonGetValueByKey(GlobalValue.GroupNameStr);
                Boolean IsSuccess = dBOperator.UpdateGroupName(account, groupid, newgroupname);

                cSMessageType = CSMessageType.UpdateGroupName;

                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.UpdateUserInfo)
            {
                string id = json.JsonGetValueByKey(GlobalValue.AccountStr);
                string nick = json.JsonGetValueByKey(GlobalValue.NickNameStr);
                string sig = json.JsonGetValueByKey(GlobalValue.SignatureStr);
                string headimage = json.JsonGetValueByKey(GlobalValue.HeadImageNameStr);
                short sex = Convert.ToInt16(json.JsonGetValueByKey(GlobalValue.SexStr));
                short age = Convert.ToInt16(json.JsonGetValueByKey(GlobalValue.AgeStr));
                short degree = Convert.ToInt16(json.JsonGetValueByKey(GlobalValue.DegreeStr));
                Boolean IsSuccess = dBOperator.UpdateUserInfo(
                    id, nick, sig, headimage, sex, age, degree);

                cSMessageType = CSMessageType.UpdateUserInfo;

                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.UpdateUserSignature)
            {
                string id = json.JsonGetValueByKey(GlobalValue.AccountStr);
                string sig = json.JsonGetValueByKey(GlobalValue.SignatureStr);

                cSMessageType = CSMessageType.UpdateUserSignature;
                Boolean IsSuccess = dBOperator.UpdateUserSignature(id, sig);
                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if (msgInfo.MsgType == CSMessageType.GetFriendsByFuzzySearch)
            {
                List<User> list = dBOperator.GetFriendsByFuzzySearch(json.JsonGetValueByKey(GlobalValue.AccountStr));
                cSMessageType = CSMessageType.QueryRelationTabByMyAccount;

                result.JsonAddListObjectElement(GlobalValue.ResultStr, list.ConvertAll(s => (object)s));
            }
            else if(msgInfo.MsgType == CSMessageType.QueryUserInfo)
            {
                User user = dBOperator.QueryUserInfo(json.JsonGetValueByKey(GlobalValue.AccountStr));

                cSMessageType = CSMessageType.QueryUserInfo;
                result.JsonAddObjectElement(GlobalValue.ResultStr, (object)user);
            }
            else if(msgInfo.MsgType == CSMessageType.RemoveFriend)
            {
                Boolean IsSuccess = dBOperator.RemoveFriend(json.JsonGetValueByKey(GlobalValue.AccountStr),
                    json.JsonGetValueByKey(GlobalValue.FriendAccountStr));
                cSMessageType = CSMessageType.RemoveFriend;

                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.InsertLoginTab)
            {
                Boolean IsSuccess = dBOperator.InsertLoginTab(json.JsonGetValueByKey(GlobalValue.AccountStr),
                    json.JsonGetValueByKey(GlobalValue.PasswordStr));

                cSMessageType = CSMessageType.InsertLoginTab;

                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if (msgInfo.MsgType == CSMessageType.InsertUserInfoTab)
            {
                Boolean IsSuccess = dBOperator.InsertUserInfoTab(json.JsonGetValueByKey(GlobalValue.AccountStr),
                    json.JsonGetValueByKey(GlobalValue.NickNameStr), 
                    json.JsonGetValueByKey(GlobalValue.SignatureStr),
                    json.JsonGetValueByKey(GlobalValue.HeadImageNameStr),
                    Convert.ToInt16(json.JsonGetValueByKey(GlobalValue.SexStr)),
                    Convert.ToInt16(json.JsonGetValueByKey(GlobalValue.AgeStr)),
                    Convert.ToInt16(json.JsonGetValueByKey(GlobalValue.DegreeStr)));

                cSMessageType = CSMessageType.InsertUserInfoTab;

                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if (msgInfo.MsgType == CSMessageType.InsertGroupInfo)
            {
                Boolean IsSuccess = dBOperator.InsertGroupInfo(json.JsonGetValueByKey(GlobalValue.AccountStr),
                    json.JsonGetValueByKey(GlobalValue.GroupIDStr),
                    json.JsonGetValueByKey(GlobalValue.GroupNameStr));

                cSMessageType = CSMessageType.InsertGroupInfo;

                result.JsonAddStringElement(GlobalValue.ResultStr, IsSuccess == true ? "1" : "0");
            }
            else if(msgInfo.MsgType == CSMessageType.QueryGroupInfoByAccount)
            {
                List<GroupInfo> groupInfos = dBOperator.QueryGroupInfoByAccount(
                    json.JsonGetValueByKey(GlobalValue.AccountStr));

                cSMessageType = CSMessageType.QueryGroupInfoByAccount;

                result.JsonAddListObjectElement(GlobalValue.ResultStr, groupInfos.ConvertAll(s => (object)s));
            }
            SendMsgToClient(result, cSMessageType);
        }

        private void SendMsgToClient(Json msg, CSMessageType messageType)
        {
            string str = msg.JsonGetString(); ;
            CSMsgInfo message = new CSMsgInfo();
            int len = 0;
            short times = 0;

            NetAddr netAddr = new NetAddr();
            netAddr.PublicIP = "127.0.0.1";
            netAddr.LocalIP = "127.0.0.1";
            netAddr.UdpPort = GlobalValue.ClientPort;

            int pos = 0;
            while(pos < str.Length)
            {
                if(str.Length - pos > GlobalValue.SendMaxLenForOneTime)
                {
                    len = GlobalValue.SendMaxLenForOneTime;
                    times++;
                }
                else
                {
                    len = str.Length - pos;
                    times = 255;
                }
                message.MsgType = messageType;
                message.MsgContent = str.Substring(pos, len);
                message.MsgLen = len;
                message.Seq = times;
                message.SendTime = DateTime.Now.ToLongDateString();
                ServerUdpMessage.SendUdpMsg(netAddr, message);
                pos += GlobalValue.SendMaxLenForOneTime;
                times++;
            }
            
        }
    }
}

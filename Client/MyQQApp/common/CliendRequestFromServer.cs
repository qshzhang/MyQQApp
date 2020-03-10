using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class CliendRequestFromServer
    {
        Socket socket;
        NetAddr serverAddr = new NetAddr();

        public CliendRequestFromServer(int port)
        {
            serverAddr.PublicIP = GlobalValue.ServerIp;
            serverAddr.UdpPort = GlobalValue.ServerPort;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }

        #region 实现客户端操作数据库及返回

        public Boolean QueryIsUserAndPwdValid(string account, string pwd)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.PasswordStr, pwd);
            return InfoServerUpdateDB(json, CSMessageType.QueryIsUserAndPwdValid);
        }

        public string QueryUserHeadImageName(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);

            CSMsgInfo cSMsg = QueryDataFromServer(json, CSMessageType.QueryUserHeadImageName);
            Json result = new Json(cSMsg.MsgContent);

            return result.JsonGetValueByKey(GlobalValue.HeadImageNameStr);
        }

        public Boolean UpdateUserStatus(string account, GlobalValue.UserStatus status)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddIntElement(GlobalValue.StatusStr, Convert.ToInt16(status));

            return InfoServerUpdateDB(json, CSMessageType.UpdateUserStatus);
        }

        public Boolean UpdateUserLastLoginTime(string account)
        {
            Json json = new Json();
            json.JsonClear();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);

            return InfoServerUpdateDB(json, CSMessageType.UpdateUserLastLoginTime);
        }

        public Boolean UpdateUserAddr(string account, string publicip, string localip, int udpport, int tcpport)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.PublicIPStr, publicip);
            json.JsonAddStringElement(GlobalValue.LocalIPStr, localip);
            json.JsonAddIntElement(GlobalValue.UDPPortStr, udpport);
            json.JsonAddIntElement(GlobalValue.TCPPortStr, tcpport);
            return InfoServerUpdateDB(json, CSMessageType.UpdateUserAddr);
        }

        public List<Friend> QueryRelationTabByMyAccount(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);

            CSMsgInfo cSMsg = GlobalValue.DataFromServer.QueryDataFromServer(
                json, CSMessageType.QueryRelationTabByMyAccount);

            return JsonToFriendsTable(new Json(cSMsg.MsgContent));
        }

        public NetAddr GetFriendAddr(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            CSMsgInfo cSMsg = QueryDataFromServer(json, CSMessageType.GetFriendAddr);

            Json result = new Json(cSMsg.MsgContent);
            Json addr = new Json(result.JsonGetValueByKey(GlobalValue.ResultStr).Replace(GlobalValue.filedSplitStr, "\r\n"));
            NetAddr netAddr = new NetAddr();

            netAddr.PublicIP = addr.JsonGetValueByKey(GlobalValue.PublicIPStr);
            netAddr.LocalIP = addr.JsonGetValueByKey(GlobalValue.LocalIPStr);
            netAddr.UdpPort = Convert.ToInt16(addr.JsonGetValueByKey(GlobalValue.UDPPortStr));
            netAddr.TcpPort = Convert.ToInt16(addr.JsonGetValueByKey(GlobalValue.TCPPortStr));

            return netAddr;
        }

        public string GetUserSignature(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            CSMsgInfo cSMsg = QueryDataFromServer(json, CSMessageType.GetUserSignature);
            Json result = new Json(cSMsg.MsgContent);

            return result.JsonGetValueByKey(GlobalValue.ResultStr);
        }

        public GlobalValue.UserStatus QueryFriendStatus(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            CSMsgInfo cSMsg = QueryDataFromServer(json, CSMessageType.QueryFriendStatus);
            return (GlobalValue.UserStatus)Convert.ToInt16(new Json(cSMsg.MsgContent).JsonGetValueByKey(GlobalValue.ResultStr));
        }

        public Boolean UpdateFriendRemark(string account, string friendid, string remark)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.FriendAccountStr, friendid);
            json.JsonAddStringElement(GlobalValue.RemarkStr, remark);

            return InfoServerUpdateDB(json, CSMessageType.UpdateFriendRemark);
        }

        public Boolean InsertRelationTab(string account, string friendid, string groupid, string remark)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.FriendAccountStr, friendid);
            json.JsonAddStringElement(GlobalValue.GroupIDStr, groupid);
            json.JsonAddStringElement(GlobalValue.RemarkStr, remark);

            return InfoServerUpdateDB(json, CSMessageType.InsertRelationTab);
        }

        public Boolean UpdateFriendGroup(string account, string friendid, string newgroupid)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.FriendAccountStr, friendid);
            json.JsonAddStringElement(GlobalValue.GroupIDStr, newgroupid);

            return InfoServerUpdateDB(json, CSMessageType.UpdateFriendGroup);
        }

        public List<string> GetGroupIdByAccount(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);

            CSMsgInfo cSMsg = QueryDataFromServer(json, CSMessageType.GetGroupIdByAccount);


            return JsonToStringList(new Json(cSMsg.MsgContent));
        }


        public Boolean GenerateNewGroup(string account, string groupid, string groupname)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.GroupIDStr, groupid);
            json.JsonAddStringElement(GlobalValue.GroupNameStr, groupname);

            return InfoServerUpdateDB(json, CSMessageType.GenerateNewGroup);
        }

        public Boolean UpdateGroupName(string account, string groupid, string newName)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.GroupIDStr, groupid);
            json.JsonAddStringElement(GlobalValue.GroupNameStr, newName);

            return InfoServerUpdateDB(json, CSMessageType.UpdateGroupName);
        }

        public Boolean UpdateUserInfo(string id, string nick, string sig, 
            string headimage, short sex, short age, short degree)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, id);
            json.JsonAddStringElement(GlobalValue.NickNameStr, nick);
            json.JsonAddStringElement(GlobalValue.SignatureStr, sig);
            json.JsonAddStringElement(GlobalValue.HeadImageNameStr, headimage);
            json.JsonAddIntElement(GlobalValue.SexStr, sex);
            json.JsonAddIntElement(GlobalValue.AgeStr, age);
            json.JsonAddIntElement(GlobalValue.DegreeStr, degree);

            return InfoServerUpdateDB(json, CSMessageType.UpdateUserInfo);
        }

        public Boolean UpdateUserSignature(string account, string sig)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.SignatureStr, sig);

            return InfoServerUpdateDB(json, CSMessageType.UpdateUserSignature);
        }

        public List<User> GetFriendsByFuzzySearch(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);

            CSMsgInfo cSMsg = QueryDataFromServer(
                json, CSMessageType.GetFriendsByFuzzySearch);

            return JsonToUsersTable(new Json(cSMsg.MsgContent));
        }

        public User QueryUserInfo(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);

            CSMsgInfo cSMsg = QueryDataFromServer(json, CSMessageType.QueryUserInfo);

            return JsonToUser(new Json(cSMsg.MsgContent));
        }

        public Boolean RemoveFriend(string account, string friendid)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.FriendAccountStr, friendid);

            return InfoServerUpdateDB(json, CSMessageType.RemoveFriend);
        }

        public Boolean InsertLoginTab(string account, string pwd)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.PasswordStr, pwd);

            return InfoServerUpdateDB(json, CSMessageType.InsertLoginTab);
        }

        public Boolean InsertUserInfoTab(string ID, string Nickname, string Signature, string HeadImage, short Sex, short Age, short Degree)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, ID);
            json.JsonAddStringElement(GlobalValue.NickNameStr, Nickname);
            json.JsonAddStringElement(GlobalValue.SignatureStr, Signature);
            json.JsonAddStringElement(GlobalValue.HeadImageNameStr, HeadImage);
            json.JsonAddIntElement(GlobalValue.SexStr, Sex);
            json.JsonAddIntElement(GlobalValue.AgeStr, Age);
            json.JsonAddIntElement(GlobalValue.DegreeStr, Degree);

            return InfoServerUpdateDB(json, CSMessageType.InsertUserInfoTab);
        }

        public Boolean InsertGroupInfo(string account, string groupid, string groupname)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);
            json.JsonAddStringElement(GlobalValue.GroupIDStr, groupid);
            json.JsonAddStringElement(GlobalValue.GroupNameStr, groupname);

            return InfoServerUpdateDB(json, CSMessageType.InsertGroupInfo);
        }

        public List<GroupInfo> QueryGroupInfoByAccount(string account)
        {
            Json json = new Json();
            json.JsonAddStringElement(GlobalValue.AccountStr, account);

            CSMsgInfo cSMsg = QueryDataFromServer(json, CSMessageType.QueryGroupInfoByAccount);

            return JsonToGroupInfoTable(new Json(cSMsg.MsgContent));
        }

        public int QueryAccountTotalNum()
        {
            Json json = new Json();
            CSMsgInfo cSMsg = QueryDataFromServer(json, CSMessageType.QueryAccountTotalNum);

            return Convert.ToInt32(new Json(cSMsg.MsgContent).JsonGetValueByKey(GlobalValue.ResultStr));
        }

        #endregion



        #region 数据转换

        private List<GroupInfo> JsonToGroupInfoTable(Json json)
        {
            Json temp = new Json();
            List<GroupInfo> result = new List<GroupInfo>();
            string str = json.JsonGetValueByKey(GlobalValue.ResultStr);

            str = str.Substring(1, str.Length - 2);
            string[] groups = str.Split(',');

            foreach (string s in groups)
            {
                temp = new Json(s.Replace(GlobalValue.filedSplitStr, "\r\n"));

                GroupInfo tab = new GroupInfo();
                tab.GroupId = temp.JsonGetValueByKey(GlobalValue.GroupIDStr);
                tab.GroupName = temp.JsonGetValueByKey(GlobalValue.GroupNameStr).Replace(GlobalValue.commaReplaceStr, ","); ;
                result.Add(tab);
            }

            return result;
        }


        private User JsonToUser(Json json)
        {
            string str = json.JsonGetValueByKey(GlobalValue.ResultStr);
            Json temp = new Json(str.Replace(GlobalValue.filedSplitStr, "\r\n"));

            User tab = new User();
            tab.ID = temp.JsonGetValueByKey(GlobalValue.AccountStr);
            tab.Age = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.AgeStr));
            tab.Degree = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.DegreeStr));
            tab.HeadImage = temp.JsonGetValueByKey(GlobalValue.HeadImageNameStr);
            tab.PublicIP = temp.JsonGetValueByKey(GlobalValue.PublicIPStr);
            tab.LocalIP = temp.JsonGetValueByKey(GlobalValue.LocalIPStr);
            tab.LastLogin = temp.JsonGetValueByKey(GlobalValue.LastLoginStr);
            tab.Nickname = temp.JsonGetValueByKey(GlobalValue.NickNameStr).Replace(GlobalValue.commaReplaceStr, ","); ;
            tab.RegisterTime = temp.JsonGetValueByKey(GlobalValue.RegisterTimeStr);
            tab.Sex = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.SexStr));
            tab.Signature = temp.JsonGetValueByKey(GlobalValue.SignatureStr).Replace(GlobalValue.commaReplaceStr, ","); ;
            tab.Status = (GlobalValue.UserStatus)Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.StatusStr));
            tab.TcpPort = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.TCPPortStr));
            tab.UdpPort = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.UDPPortStr));

            return tab;
        }

        private List<User> JsonToUsersTable(Json json)
        {
            Json temp = new Json();
            List<User> result = new List<User>();
            string str = json.JsonGetValueByKey(GlobalValue.ResultStr);

            str = str.Substring(1, str.Length - 2);
            string[] groups = str.Split(',');

            foreach (string s in groups)
            {
                temp = new Json(s.Replace(GlobalValue.filedSplitStr, "\r\n"));

                User tab = new User();
                tab.ID = temp.JsonGetValueByKey(GlobalValue.AccountStr);
                tab.Age = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.AgeStr));
                tab.Degree = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.DegreeStr));
                tab.HeadImage = temp.JsonGetValueByKey(GlobalValue.HeadImageNameStr);
                tab.PublicIP = temp.JsonGetValueByKey(GlobalValue.PublicIPStr);
                tab.LocalIP = temp.JsonGetValueByKey(GlobalValue.LocalIPStr);
                tab.LastLogin = temp.JsonGetValueByKey(GlobalValue.LastLoginStr);
                tab.Nickname = temp.JsonGetValueByKey(GlobalValue.NickNameStr).Replace(GlobalValue.commaReplaceStr, ","); ;
                tab.RegisterTime = temp.JsonGetValueByKey(GlobalValue.RegisterTimeStr);
                tab.Sex = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.SexStr));
                tab.Signature = temp.JsonGetValueByKey(GlobalValue.SignatureStr).Replace(GlobalValue.commaReplaceStr, ","); ;
                tab.Status = (GlobalValue.UserStatus)Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.StatusStr));
                tab.TcpPort = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.TCPPortStr));
                tab.UdpPort = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.UDPPortStr));

                result.Add(tab);
            }

            return result;
        }

        private List<string> JsonToStringList(Json json)
        {
            string tmp;
            List<string> list = new List<string>();
            Json temp = new Json();
            string str = json.JsonGetValueByKey(GlobalValue.ResultStr);

            str = str.Substring(1, str.Length - 2);
            string[] groups = str.Split(',');

            foreach (string s in groups)
            {
                tmp = s.Trim();
                list.Add(tmp.Substring(1, tmp.Length - 2));
            }

            return list;
        }

        private List<Friend> JsonToFriendsTable(Json json)
        {
            Json temp = new Json();
            List<Friend> result = new List<Friend>();
            string str = json.JsonGetValueByKey(GlobalValue.ResultStr);

            str = str.Substring(1, str.Length - 2);
            string[] groups = str.Split(',');

            foreach (string s in groups)
            {
                temp = new Json(s.Replace(GlobalValue.filedSplitStr, "\r\n"));

                Friend tab = new Friend();
                tab.ID = temp.JsonGetValueByKey(GlobalValue.AccountStr);
                tab.Age = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.AgeStr));
                tab.GroupID = temp.JsonGetValueByKey(GlobalValue.GroupIDStr);
                tab.GroupName = temp.JsonGetValueByKey(GlobalValue.GroupNameStr).Replace(GlobalValue.commaReplaceStr, ",");
                tab.Remark = temp.JsonGetValueByKey(GlobalValue.RemarkStr).Replace(GlobalValue.commaReplaceStr, ","); ;
                tab.Degree = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.DegreeStr));
                tab.HeadImage = temp.JsonGetValueByKey(GlobalValue.HeadImageNameStr);
                tab.PublicIP = temp.JsonGetValueByKey(GlobalValue.PublicIPStr);
                tab.LocalIP = temp.JsonGetValueByKey(GlobalValue.LocalIPStr);
                tab.LastLogin = temp.JsonGetValueByKey(GlobalValue.LastLoginStr);
                tab.Nickname = temp.JsonGetValueByKey(GlobalValue.NickNameStr).Replace(GlobalValue.commaReplaceStr, ","); ;
                tab.RegisterTime = temp.JsonGetValueByKey(GlobalValue.RegisterTimeStr);
                tab.Sex = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.SexStr));
                tab.Signature = temp.JsonGetValueByKey(GlobalValue.SignatureStr).Replace(GlobalValue.commaReplaceStr, ","); ;
                tab.Status = (GlobalValue.UserStatus)Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.StatusStr));
                tab.TcpPort = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.TCPPortStr));
                tab.UdpPort = Convert.ToInt16(temp.JsonGetValueByKey(GlobalValue.UDPPortStr));

                result.Add(tab);
            }

            return result;
        }


        #endregion





        private CSMsgInfo QueryDataFromServer(Json msg, CSMessageType type)
        {
            List<CSMsgInfo> listMsg = new List<CSMsgInfo>();

            byte[] RcvData = new byte[1024];
            Array.Clear(RcvData, 0, 1024);

            EndPoint remotePoint = new IPEndPoint(IPAddress.Any, 0);

            CSMsgInfo message = new CSMsgInfo();
            message.MsgType = type;
            message.MsgContent = msg.JsonGetString();
            message.MsgLen = msg.JsonGetLen();
            message.SendTime = DateTime.Now.ToLongDateString();

            EndPoint point = new IPEndPoint(IPAddress.Parse(serverAddr.PublicIP), serverAddr.UdpPort);
            socket.SendTo(MessageToBytes(message), point);

            int RcvDataCount = 0;// socket.ReceiveFrom(RcvData, ref remotePoint);

            while((RcvDataCount = socket.ReceiveFrom(RcvData, ref remotePoint))>0)
            {
                byte[] RcvMessage = new byte[RcvDataCount];
                Array.Copy(RcvData, 0, RcvMessage, 0, RcvDataCount);

                CSMsgInfo msgInfo = BytesToMessage(RcvMessage);

                listMsg.Add(msgInfo);
                if(msgInfo.Seq == 255)
                {
                    break;
                }
            }

            CSMsgInfo cSMsgInfo = new CSMsgInfo();
            string json = "";
            foreach(CSMsgInfo cSMsg in listMsg)
            {
                json += cSMsg.MsgContent;
                cSMsgInfo.MsgType = cSMsg.MsgType;
            }
            cSMsgInfo.MsgContent = json;
            
            return cSMsgInfo;
        }

        public Boolean InfoServerUpdateDB(Json msg, CSMessageType type)
        {
            CSMsgInfo cSMsg = QueryDataFromServer(msg, type);
            Json json = new Json(cSMsg.MsgContent);

            return json.JsonGetValueByKey(GlobalValue.ResultStr) == "1" ? true : false;
        }

        private byte[] MessageToBytes(CSMsgInfo obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        private CSMsgInfo BytesToMessage(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Binder = new DeserializationBinder_s();
                return (CSMsgInfo)formatter.Deserialize(ms);
            }
        }
    }

    sealed class DeserializationBinder_s : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {

            if (typeName == "MyQQAppServer.CSMsgInfo")//ProjectSend序列化时的命名空间，SendClass序列化时的类 
            {
                typeName = "MyQQApp.common.CSMsgInfo";//ProjectReceive反序列化时的命名空间，ReceiveClass反序列化时的类
            }
            if (typeName == "MyQQAppServer.CSMessageType")
            {
                typeName = "MyQQApp.common.CSMessageType";
            }
            if (typeName == "MyQQAppServer.ServerUdpMessage")
            {
                typeName = "MyQQApp.common.ClientUdpMessage";
            }
            return Type.GetType(typeName, true);
        }
    }
}

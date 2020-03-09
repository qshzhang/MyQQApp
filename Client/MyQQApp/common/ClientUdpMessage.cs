﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public enum CSMessageType
    {
        QueryIsUserAndPwdValid = 0, 
        QueryUserHeadImageName, 
        UpdateUserStatus,
        UpdateUserLastLoginTime,
        UpdateUserAddr,
        QueryRelationTabByMyAccount,
        GetUserSignature,
        GetFriendGroupId,
        RemoveFriend,
        QueryUserInfo,
        GetFriendAddr,
        UpdateFriendGroup,
        UpdateUserSignature,
        GetGroupIdByAccount,
        UpdateGroupName,
        UpdateUserInfo,
        QueryFriendStatus,
        UpdateFriendRemark,
        InsertRelationTab,
        GenerateNewGroup,
        GetFriendsByFuzzySearch,
        InsertLoginTab,
        InsertUserInfoTab,
        InsertGroupInfo,
        QueryGroupInfoByAccount,
        END
    }

    [Serializable]
    public class CSMsgInfo
    {
        private string sendTime;
        private CSMessageType msgType;
        private string msgContent;
        private long msgLen;
        private short seq;

        public string SendTime { get => sendTime; set => sendTime = value; }
        public string MsgContent { get => msgContent; set => msgContent = value; }
        public long MsgLen { get => msgLen; set => msgLen = value; }
        public CSMessageType MsgType { get => msgType; set => msgType = value; }
        public short Seq { get => seq; set => seq = value; }
    }

    public class ClientUdpMessage
    {
        public delegate void RevMsgCallback(CSMsgInfo local);
        public RevMsgCallback ReceiveMsgCallback;

        //IPAddress.Parse(myNetAddr.IP) 将字符串的IP转换为IP
        private Socket RevSocket;
        private Socket SendSocket;
        public ClientUdpMessage(NetAddr myNetAddr)
        {
            SendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //SendSocket.Bind(new IPEndPoint(IPAddress.Parse(myNetAddr.IP), myNetAddr.Port));

            RevSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            RevSocket.Bind(new IPEndPoint(IPAddress.Parse(myNetAddr.PublicIP), myNetAddr.UdpPort));

        }

        public ClientUdpMessage(int port)
        {
            SendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //SendSocket.Bind(new IPEndPoint(IPAddress.Parse(myNetAddr.IP), myNetAddr.Port));

            RevSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            RevSocket.Bind(new IPEndPoint(IPAddress.Any, port));
        }

        ~ClientUdpMessage()
        {
            RevSocket.Close();
            SendSocket.Close();
        }

        public void SendUdpMsg(NetAddr friendNetAddr, CSMsgInfo message)
        {
            EndPoint point = new IPEndPoint(IPAddress.Parse(friendNetAddr.PublicIP), friendNetAddr.UdpPort);
            SendSocket.SendTo(MessageToBytes(message), point);

        }

        public void StartRevMsg()
        {
            Thread t = new Thread(ReciveMsg);//开启接收消息线程
            t.IsBackground = true;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            t.Start();
        }

        private void ReciveMsg()
        {
            byte[] buffer = new byte[1024];
            EndPoint remotePoint = new IPEndPoint(IPAddress.Any, 0);//用来保存发送方的ip和端口号
            while (true)
            {
                Array.Clear(buffer, 0, 1024);
                int length = RevSocket.ReceiveFrom(buffer, ref remotePoint);//接收数据报
                byte[] message = new byte[length];
                Array.Copy(buffer, 0, message, 0, length);

                CSMsgInfo msgInfo = BytesToMessage(message);

                NetAddr clientAddr = new NetAddr();
                clientAddr.PublicIP = ((IPEndPoint)remotePoint).Address.ToString();
                clientAddr.UdpPort = ((IPEndPoint)remotePoint).Port;

                DealReceiveMsg(msgInfo);
            }

        }

        private void DealReceiveMsg(CSMsgInfo local)
        {
            if (ReceiveMsgCallback != null)
            {
                ReceiveMsgCallback(local);
            }
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
                formatter.Binder = new DeserializationBinder();
                return (CSMsgInfo)formatter.Deserialize(ms);
            }
        }
    }

    sealed class DeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {

            if (typeName == "MyQQAppServer.CSMsgInfo")//ProjectSend序列化时的命名空间，SendClass序列化时的类 
            {
                typeName = "MyQQApp.common.CSMsgInfo";//ProjectReceive反序列化时的命名空间，ReceiveClass反序列化时的类
            }
            if(typeName == "MyQQAppServer.CSMessageType")
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

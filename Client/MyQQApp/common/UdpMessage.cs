using System;
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
    public class NetAddr
    {
        private string publicIP;
        private string localIP;
        private int udpPort;
        private int tcpPort;

        public string PublicIP { get => publicIP; set => publicIP = value; }
        public string LocalIP { get => localIP; set => localIP = value; }
        public int UdpPort { get => udpPort; set => udpPort = value; }
        public int TcpPort { get => tcpPort; set => tcpPort = value; }

    }

    [Serializable]
    public class MsgInfo
    {
        private string sendTime;
        private string account;
        private GlobalValue.MessageType msgType;
        private string msgContent;
        private long msgLen;
        private int tcpPort;

        public string SendTime { get => sendTime; set => sendTime = value; }
        public string Account { get => account; set => account = value; }
        public string MsgContent { get => msgContent; set => msgContent = value; }
        public long MsgLen { get => msgLen; set => msgLen = value; }
        public int TcpPort { get => tcpPort; set => tcpPort = value; }
        public GlobalValue.MessageType MsgType { get => msgType; set => msgType = value; }
    }

    public class LocalMessage
    {
        private NetAddr friendAddr;
        private MsgInfo msg;

        public LocalMessage(NetAddr addr, MsgInfo message)
        {
            FriendAddr = addr;
            Msg = message;
        }

        public NetAddr FriendAddr { get => friendAddr; set => friendAddr = value; }
        public MsgInfo Msg { get => msg; set => msg = value; }
    }

    public class UdpMessage
    {
        public delegate void RevMsgCallback(LocalMessage local);
        public RevMsgCallback ReceiveMsgCallback;

        //IPAddress.Parse(myNetAddr.IP) 将字符串的IP转换为IP
        private Socket RevSocket;
        private Socket SendSocket;
        public UdpMessage(NetAddr myNetAddr)
        {
            SendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //SendSocket.Bind(new IPEndPoint(IPAddress.Parse(myNetAddr.IP), myNetAddr.Port));

            RevSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            RevSocket.Bind(new IPEndPoint(IPAddress.Parse(myNetAddr.PublicIP), myNetAddr.UdpPort));

        }

        public UdpMessage(int port)
        {
            SendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //SendSocket.Bind(new IPEndPoint(IPAddress.Parse(myNetAddr.IP), myNetAddr.Port));

            RevSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            RevSocket.Bind(new IPEndPoint(IPAddress.Any, port));

        }

        ~UdpMessage()
        {
            RevSocket.Close();
            SendSocket.Close();
        }

        public void SendUdpMsg(NetAddr friendNetAddr, MsgInfo message)
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
                Array.Clear(buffer,0, 1024);
                int length = RevSocket.ReceiveFrom(buffer, ref remotePoint);//接收数据报
                byte[] message = new byte[length];
                Array.Copy(buffer, 0, message, 0, length);

                MsgInfo msgInfo = BytesToMessage(message);

                NetAddr friendAddr = new NetAddr();
                friendAddr.PublicIP = ((IPEndPoint)remotePoint).Address.ToString();
                friendAddr.UdpPort = ((IPEndPoint)remotePoint).Port;
                friendAddr.TcpPort = msgInfo.TcpPort;
                

                LocalMessage msg = new LocalMessage(friendAddr, msgInfo);

                DealReceiveMsg(msg);
            }

        }

        private void DealReceiveMsg(LocalMessage local)
        {
            if(ReceiveMsgCallback != null)
            {
                ReceiveMsgCallback(local);
            }
        }

        private byte[] MessageToBytes(MsgInfo obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                return ms.GetBuffer();
            }
        }

        private MsgInfo BytesToMessage(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                IFormatter formatter = new BinaryFormatter();
                return (MsgInfo)formatter.Deserialize(ms);
            }
        }
    }
}

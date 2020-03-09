using MyQQApp.common;
using MyQQApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace MyQQApp
{
    partial class MainFrm
    {
        List<LocalMessage> listMsg = new List<LocalMessage>();
        UdpMessage udpMessage;
        TcpMessage tcpMessage;

        System.Timers.Timer WaitRecvFileTimer = new System.Timers.Timer(60 * 1000);

        private void InitTcp()
        {
            GlobalValue.myself.TcpPort = NetTool.GenerateValidPort(PortType.TCP);
            tcpMessage = new TcpMessage(GlobalValue.myself.TcpPort);

            GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, "Init tcp success");
        }

        private void InitUdp()
        {
            GlobalValue.myself.UdpPort = NetTool.GenerateValidPort(PortType.UDP);

            udpMessage = new UdpMessage(GlobalValue.myself.UdpPort);

            udpMessage.ReceiveMsgCallback += ReceiveMsgDeal;

            udpMessage.StartRevMsg();

            GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, "Init udp success");
        }

        private void ReceiveMsgDeal(LocalMessage local)
        {
            string friendAccount = local.Msg.Account;
            int index = DialogFrm.GetIndexInOpenedFrm(friendAccount);
            if (-1 != index)
            {
                if(local.Msg.MsgType == GlobalValue.MessageType.TxtMsg)
                {
                    DialogFrm.dialogFrmOpenlist[index].Dialog.SetChatBoxContent(local.Msg.MsgContent);
                }
                else if (local.Msg.MsgType == GlobalValue.MessageType.FileMsg)
                {
                    WaitRecvFileTimer.Elapsed += new ElapsedEventHandler((s, e) => OnTimedEvent(s, e, local.FriendAddr.PublicIP, local.FriendAddr.TcpPort));
                    WaitRecvFileTimer.AutoReset = false;
                    WaitRecvFileTimer.Enabled = true;
                    WaitRecvFileTimer.Start();

                    FrmRecvFile frmRecvFile = new FrmRecvFile(local);
                    frmRecvFile.BtnAcceptRecvFile += AcceptRecvFile;
                    frmRecvFile.BtnRejectRecvFile += RejectRecvFile;
                    frmRecvFile.ShowDialog();
                    
                }
                return;
            }
            listMsg.Add(local);
            SetFriendHeadImageTwinkle(friendAccount);
        }

        private void SendMsgCallback(NetAddr netAddr, string msg, GlobalValue.MessageType messageType)
        {
            MsgInfo message = new MsgInfo();
            message.Account = GlobalValue.myself.ID;
            message.MsgType = messageType;
            message.MsgContent = msg;
            message.MsgLen = msg.Length;
            message.SendTime = DateTime.Now.ToLongDateString();
            message.TcpPort = GlobalValue.myself.TcpPort;

            udpMessage.SendUdpMsg(netAddr, message);

            if(messageType == GlobalValue.MessageType.FileMsg)
            {
                string filename = msg.Substring(0, msg.IndexOf(';'));
                long filelen = Convert.ToInt64(msg.Substring(msg.IndexOf(';') + 1));
                tcpMessage.ServerStartMonitor(filename, filelen);
            }
        }


        private void SetFriendHeadImageTwinkle(string account)
        {
            for(int i = 0;i < chatListBox.Items.Count;i++)
            {
                for(int j = 0;j < chatListBox.Items[i].SubItems.Count;j++)
                {
                    if(account.CompareTo(chatListBox.Items[i].SubItems[j].ID) == 0)
                    {
                        chatListBox.Items[i].SubItems[j].IsTwinkle = true;
                        return;
                    }
                }
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e, string ip, int port)
        {
            tcpMessage.ClientSendMsgRecvFile(ip, port, GlobalValue.ResponseType.NoResponse);
        }

        private void RejectRecvFile(LocalMessage local)
        {
            WaitRecvFileTimer.Stop();
            tcpMessage.ClientSendMsgRecvFile(local.FriendAddr.PublicIP, local.FriendAddr.TcpPort, GlobalValue.ResponseType.CancelRecv);
        }

        private void AcceptRecvFile(LocalMessage local)
        {
            int index = DialogFrm.GetIndexInOpenedFrm(local.Msg.Account);
            DialogFrm.dialogFrmOpenlist[index].Dialog.SetChatBoxContent(local.Msg.MsgContent);

            WaitRecvFileTimer.Stop();

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                long fileLen = Convert.ToInt64(local.Msg.MsgContent.Substring(local.Msg.MsgContent.IndexOf(';') + 1));

                tcpMessage.ClientStartMonitor(local.FriendAddr.PublicIP,
                    local.FriendAddr.TcpPort, saveFileDialog.FileName, fileLen);

            }
            else
            {
                tcpMessage.ClientSendMsgRecvFile(local.FriendAddr.PublicIP,
                    local.FriendAddr.TcpPort, GlobalValue.ResponseType.CancelRecv);
            }
            saveFileDialog.Dispose();
        }

    }
}

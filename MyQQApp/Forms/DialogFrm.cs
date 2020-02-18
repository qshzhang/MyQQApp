using MyQQApp.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQApp.Forms
{
    public partial class DialogFrm : Form
    {
        public delegate void SendMsgCallback(NetAddr friendNetAddr, string msg, GlobalValue.MessageType messageType);
        public SendMsgCallback SendMsgToFriendCallback;

        NetAddr Addr = new NetAddr();

        private ChatListControl.ChatListSubItem ichatListSubItem;

        public static List<AccountHandle> dialogFrmOpenlist = new List<AccountHandle>();

        public DialogFrm(ChatListControl.ChatListSubItem chatListSubItem)
        {
            InitializeComponent();
            this.panelContainer.Visible = false;

            this.ucBackPanel.onBtnClose_Click += BtnClose;
            this.ucBackPanel.onBtnMin_Click += DialogFrm_MinWindow;
            ichatListSubItem = chatListSubItem;
            dialogFrmOpenlist.Add(new AccountHandle(ichatListSubItem.ID, this, 0));

            Addr.IP = chatListSubItem.IpAddress;
            Addr.UdpPort = chatListSubItem.UpdPort;
            Addr.TcpPort = chatListSubItem.TcpPort;
        }

        private void BtnClose()
        {
            this.Close(); 
        }

        private void DialogFrm_Load(object sender, EventArgs e)
        {
            this.lbTitle.Text = ichatListSubItem.ID.ToString() + "(" + ichatListSubItem.DisplayName + ")";
        }

        private void panelShowFace_Click(object sender, EventArgs e)
        {
            MessageBox.Show("haha");
        }

        private void DialogFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            removeItem(ichatListSubItem.ID);
        }

        private void DialogFrm_MinWindow()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public static void SetFrmActivated(int index)
        {
            if (index < 0 || index > dialogFrmOpenlist.Count) return;
            dialogFrmOpenlist[index].Dialog.Activate();
        }

        private void removeItem(string id)
        {
            int index = -1;
            for(int i = 0;i < dialogFrmOpenlist.Count; i++)
            {
                if(dialogFrmOpenlist[i].Account.CompareTo(id) == 0)
                {
                    index = i;
                    break;
                }
            }
            if(index != -1)
            {
                dialogFrmOpenlist.RemoveAt(index);
            }
        }

        public static int GetIndexInOpenedFrm(string id)
        {
            for (int i = 0; i < dialogFrmOpenlist.Count; i++)
            {
                if (dialogFrmOpenlist[i].Account.CompareTo(id) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        public void SetChatBoxContent(string newMsg)
        {
            this.richBoxShowRecord.Text += ("\n" + newMsg);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(SendMsgToFriendCallback != null)
            {
                SendMsgToFriendCallback(Addr, rTxtInput.Text, GlobalValue.MessageType.TxtMsg);
            }
        }

        public void updateFriendAddr(NetAddr netAddr)
        {
            Addr.IP = netAddr.IP;
            Addr.UdpPort = netAddr.UdpPort;
            Addr.TcpPort = netAddr.TcpPort;
        }

        private void panelFoldFunction_Click(object sender, EventArgs e)
        {
            if(this.panelContainer.Visible)
            {
                this.panelContainer.Visible = false;
            }
            else
            {
                this.panelContainer.Visible = true;
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;

                FileInfo fileInfo = new FileInfo(filename);
                long fileLen = fileInfo.Length;

                if (SendMsgToFriendCallback != null)
                {
                    SendMsgToFriendCallback(Addr, filename + ";" + fileLen.ToString(), GlobalValue.MessageType.FileMsg);
                }
            }
            openFileDialog.Dispose();
        }

        private void btnCaptureScreen_Click(object sender, EventArgs e)
        {
            Image img = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size);
            FrmCaptureScreen body = new FrmCaptureScreen();
            body.BackgroundImage = img;
            body.Show();
        }
    }

    public class AccountHandle
    {
        private string account;
        private DialogFrm dialog;
        private int handle;

        public AccountHandle(string id, DialogFrm dialog, int hand)
        {
            Account = id;
            this.dialog = dialog;
            Handle = hand;
        }

        public AccountHandle() { }

        public string Account { get => account; set => account = value; }
        public int Handle { get => handle; set => handle = value; }
        public DialogFrm Dialog { get => dialog; set => dialog = value; }
    }
}

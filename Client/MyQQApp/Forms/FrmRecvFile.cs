using MyQQApp.common;
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
    public partial class FrmRecvFile : Form
    {
        public delegate void BtnRecvFileCallback(LocalMessage localMessage);
        public BtnRecvFileCallback BtnAcceptRecvFile;
        public BtnRecvFileCallback BtnRejectRecvFile;

        private LocalMessage localMessage;

        public FrmRecvFile(LocalMessage msg)
        {
            InitializeComponent();
            this.ucBackPanel.onBtnClose_Click += BtnClose;
            localMessage = msg;
        }

        public void SetProgress(UInt32 len)
        {
            long fileLen = Convert.ToInt64(localMessage.Msg.MsgContent.Substring(localMessage.Msg.MsgContent.IndexOf(';') + 1));
            pbProgress.Width = (int)(len * pbBase.Width / fileLen);
        }

        private void BtnClose()
        {
            this.Close();
        }

        private void BtnRecv_Click(object sender, EventArgs e)
        {
            if(null != BtnAcceptRecvFile)
            {
                BtnAcceptRecvFile(localMessage);
            }
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (null != BtnRejectRecvFile)
            {
                BtnRejectRecvFile(localMessage);
            }
        }

        private void FrmRecvFile_Load(object sender, EventArgs e)
        {
            pbProgress.Width = 0;
        }
    }
}

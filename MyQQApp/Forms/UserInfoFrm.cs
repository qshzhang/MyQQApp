using MyQQApp.ChatListControl;
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
    public partial class UserInfoFrm : Form
    {
        public delegate void UpdateSelfInfo(User user);
        public UpdateSelfInfo updateSelfInfo;

        private User user;

        private Boolean isRegister = false;

        private Boolean isUpdateInfo = true;

        private Boolean isAddFriend = false;

        public UserInfoFrm(Myself myself)
        {
            InitializeComponent();
            ucBackPanel.onBtnClose_Click += BtnClose;
            user = myself;
            isUpdateInfo = true;

            ucDEMix1.DescribeStr = "IP";
            ucDEMix2.DescribeStr = "Signature";
            ucDEMix3.Visible = false;

            ucDEMix2.ContentStr = user.Signature;
            ucDEMix1.ContentStr = user.IP;
        }

        public UserInfoFrm(Friend friend, Boolean isAdd = false)
        {
            InitializeComponent();
            ucBackPanel.onBtnClose_Click += BtnClose;

            isAddFriend = isAdd;
            
            isUpdateInfo = false;
            user = friend;

            if(!isAddFriend)
            {
                btnUpdate.Visible = false;
            }

            ucDEMix1.ContentStr = friend.Remark;
            ucDEMix3.ContentStr = friend.Signature;
            ucDEMix2.ContentStr = friend.IP;
        }

        public UserInfoFrm(Boolean isUpdateFrm, User usr)
        {
            InitializeComponent();
            if(!isUpdateFrm)
            {
                btnUpdate.Visible = false;
                isUpdateInfo = false;
            }
            ucBackPanel.onBtnClose_Click += BtnClose;
            user = usr;

            if(isUpdateFrm)
            {
                ucDEMix1.DescribeStr = "IP";
                ucDEMix2.DescribeStr = "Signature";
                ucDEMix3.Visible = false;
            }
            
        }

        public UserInfoFrm(Boolean Register)
        {
            InitializeComponent();

            btnUpdate.Visible = true;
            isUpdateInfo = true;

            isRegister = Register;

            ucBackPanel.onBtnClose_Click += BtnClose;
            user = new User();

            ucDEMix1.DescribeStr = "Signature";
            ucDEMix2.DescribeStr = "Password";
            ucDEMix3.DescribeStr = "Ensure";
            ucDEMix2.PasswordChr = '*';
            ucDEMix3.PasswordChr = '*';
        }

        private void BtnClose()
        {
            this.Close();
        }

        private void UserInfoFrm_Load(object sender, EventArgs e)
        {
            if (isRegister) return;
            ucDEId.ContentStr = user.ID;
            ucDENickName.ContentStr = user.Nickname;
            //ucDEMix1.ContentStr = iChatListSubItem.DisplayName;
            
            picHead.Image = common.CommonTools.GetImageByPicName(user.HeadImage);
            //if(!isUpdateInfo)
            //{
            //    ucDEMix1.ContentStr = ((Friend)user).Remark;
            //    ucDEMix3.ContentStr = user.Signature;
            //    ucDEMix2.ContentStr = user.IP;
            //}
            //else
            //{
            //    ucDEMix2.ContentStr = user.Signature;
            //    ucDEMix1.ContentStr = user.IP;
            //}
        }

        private void picHead_Click(object sender, EventArgs e)
        {
            if (!isUpdateInfo) return; 
            if(MouseButtons.Left == ((MouseEventArgs)e).Button)
            {
                //MessageBox.Show("更换头像");
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "(picture)|*.jpg;*.png;*.jpeg";
                fileDialog.Title = "select picture";
                if(fileDialog.ShowDialog() == DialogResult.OK)
                {
                    picHead.Image = Image.FromFile(fileDialog.FileName);
                    GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_INFO, "self head changed");
                }
            }
        }

        private void picHead_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picHead_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(null != updateSelfInfo)
            {
                if(isAddFriend)
                {
                    Friend friend = new Friend();
                    friend.ID = ucDEId.ContentStr;
                    friend.Remark = ucDEMix1.ContentStr;
                    friend.GroupName = "friends";
                    friend.GroupID = GlobalValue.myself.ID + "_000";

                    updateSelfInfo(friend);
                    return;
                }
                Myself myself = new Myself();
                myself.ID = ucDEId.ContentStr;
                myself.Nickname = ucDENickName.ContentStr;
                myself.HeadImage = common.CommonTools.SaveImageToFile(picHead.Image);

                myself.Sex = 0;
                myself.Age = 1;
                myself.Degree = 2;

                if (isRegister)
                {
                    myself.Signature = ucDEMix1.ContentStr;
                    myself.Password = ucDEMix2.ContentStr;
                }
                else
                {
                    myself.Signature = ucDEMix2.ContentStr;
                    myself.IP = ucDEMix1.ContentStr;
                }

                updateSelfInfo(myself);
            }
            this.Close();
        }
    }
}

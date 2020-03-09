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
    public partial class AddFriendFrm : Form
    {
        public delegate void AddFriend(Friend friend);
        public AddFriend AddFriendCallback;

        Friend friend;

        DataTable Sextable = new DataTable();
        DataTable DegreeTable = new DataTable();
        public AddFriendFrm(Friend friend)
        {
            InitializeComponent();
            ucBackPanel.onBtnClose_Click += BtnClose;
            this.friend = friend;
        } 

        private void BtnClose()
        {
            this.Close();
        }

        private void UserInfoFrm_Load(object sender, EventArgs e)
        {
            InitCombDegree();
            InitCombSex();
            InitCombGroup();

            picHead.Image = common.CommonTools.GetImageByPicName(friend.HeadImage);
            lbID.Text = "ID: " + friend.ID;
            txtNickname.ContentStr = friend.Nickname;
            txtSignature.ContentStr = friend.Signature;
            txtAge.ContentStr = friend.Age.ToString();
            combDegree.Content.SelectedValue = friend.Degree.ToString();
            combSex.Content.SelectedValue = friend.Sex;
            txtIP.ContentStr = friend.PublicIP == null ? "" : friend.PublicIP;
        }

        private void InitCombDegree()
        {
            DataTable dataTable = GlobalDataTable.GetDegreeTable();

            this.combDegree.Content.DataSource = dataTable;
            this.combDegree.Content.DisplayMember = "text";
            this.combDegree.Content.ValueMember = "value";
        }

        private void InitCombSex()
        {
            DataTable dataTable = GlobalDataTable.GetSexTable();

            this.combSex.Content.DataSource = dataTable;
            this.combSex.Content.DisplayMember = "text";
            this.combSex.Content.ValueMember = "value";
        }

        private void InitCombGroup()
        {
            List<GroupInfo> groups = GlobalValue.DataFromServer.QueryGroupInfoByAccount(GlobalValue.myself.ID);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("value", Type.GetType("System.String"));
            dataTable.Columns.Add("text", Type.GetType("System.String"));

            foreach(GroupInfo group in groups)
            {
                dataTable.Rows.Add(new object[] { group.GroupId, group.GroupName });
            }

            this.combGroup.Content.DataSource = dataTable;
            this.combGroup.Content.DisplayMember = "text";
            this.combGroup.Content.ValueMember = "value";

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            friend.Remark = txtRemark.ContentStr;
            friend.GroupID = combGroup.Content.SelectedValue.ToString();
            friend.GroupName = combGroup.Content.Text;

            if (null != AddFriendCallback)
            {
                AddFriendCallback(friend);
            }
        }
    }
}

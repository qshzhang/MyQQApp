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
    public partial class FriendInfoFrm : Form
    {
        Friend friend;

        DataTable Sextable = new DataTable();
        DataTable DegreeTable = new DataTable();
        public FriendInfoFrm(Friend friend)
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

            picHead.Image = common.CommonTools.GetImageByPicName(friend.HeadImage);
            lbID.Text = "ID: " + friend.ID;
            txtNickname.ContentStr = friend.Nickname;
            txtSignature.ContentStr = friend.Signature;
            txtAge.ContentStr = friend.Age.ToString();
            combDegree.Content.SelectedValue = friend.Degree.ToString();
            combSex.Content.SelectedValue = friend.Sex;
            txtRemark.ContentStr = friend.Remark.ToString();
            txtIP.ContentStr = friend.PublicIP.ToString();
            txtGroup.ContentStr = friend.GroupName.ToString();
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

    }
}

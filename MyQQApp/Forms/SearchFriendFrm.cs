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
    public partial class SearchFriendFrm : Form
    {
        public delegate void MainFrmAddFriendCallback(Boolean isNeedInsert, Friend friend);
        public MainFrmAddFriendCallback mainFrmAddFriendCallback;
        public SearchFriendFrm()
        {
            InitializeComponent();
            this.ucBackPanel.onBtnClose_Click += BtnClose;
            this.ucBackPanel.onBtnMin_Click += BtnMinWindow;
        }

        private void BtnClose()
        {
            this.Close();
        }

        private void BtnMinWindow()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listView.Items.Clear();

            DBOperator dBOperator = new DBOperator();
            List<User> list = dBOperator.GetFriendsByFuzzySearch(txtSearchKey.Text);

            foreach(User user in list)
            {
                ListViewItem viewItem = new ListViewItem();
                viewItem.Text = user.ID;
                viewItem.SubItems.Add(user.Nickname);
                viewItem.SubItems.Add(user.Sex.ToString());
                viewItem.SubItems.Add(user.Signature);
                viewItem.SubItems.Add(user.Age.ToString());

                listView.Items.Add(viewItem);
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listView.SelectedItems.Count == 0) return;
            Friend friend = new Friend();

            DBOperator dBOperator = new DBOperator();

            friend.ID = this.listView.SelectedItems[0].Text;
            friend.Nickname = this.listView.SelectedItems[0].SubItems[1].Text;
            friend.Signature = this.listView.SelectedItems[0].SubItems[3].Text;

            friend.HeadImage = dBOperator.QueryUserHeadImageName(friend.ID);

            UserInfoFrm frm = new UserInfoFrm(friend, true);
            frm.updateSelfInfo += OnAddFriend;
            frm.Show();
        }

        private void OnAddFriend(User user)
        {
            DBOperator dBOperator = new DBOperator();
            Boolean isNeedInsert = dBOperator.InsertRelationTab(GlobalValue.myself.ID, user.ID, ((Friend)user).Groupname, ((Friend)user).Remark);

            if(null != mainFrmAddFriendCallback)
            {
                mainFrmAddFriendCallback(isNeedInsert, (Friend)user);
            }
            
        }
    }
}

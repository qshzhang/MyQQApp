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

            List<User> users = GlobalValue.DataFromServer.GetFriendsByFuzzySearch(txtSearchKey.Text);

            foreach (User user in users)
            {
                ListViewItem viewItem = new ListViewItem();
                viewItem.Text = user.ID;
                viewItem.SubItems.Add(user.Nickname);
                viewItem.SubItems.Add(user.Sex.ToString());
                viewItem.SubItems.Add(user.Signature);
                viewItem.SubItems.Add(user.Age.ToString());

                viewItem.SubItems.Add(user.Degree.ToString());
                viewItem.SubItems.Add(user.PublicIP);

                listView.Items.Add(viewItem);
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.listView.SelectedItems.Count == 0) return;
            Friend friend = new Friend();

            friend.ID = this.listView.SelectedItems[0].Text;
            friend.Nickname = this.listView.SelectedItems[0].SubItems[1].Text;
            friend.Signature = this.listView.SelectedItems[0].SubItems[3].Text;
            friend.Sex = Convert.ToInt16(this.listView.SelectedItems[0].SubItems[2].Text);
            friend.Age = Convert.ToInt16(this.listView.SelectedItems[0].SubItems[4].Text);
            friend.Degree = Convert.ToInt16(this.listView.SelectedItems[0].SubItems[5].Text);
            friend.PublicIP = this.listView.SelectedItems[0].SubItems[6].Text;


            friend.HeadImage = GlobalValue.DataFromServer.QueryUserHeadImageName(friend.ID);

            AddFriendFrm frm = new AddFriendFrm(friend);
            frm.AddFriendCallback += OnAddFriend;
            frm.Show();
        }

        private void OnAddFriend(Friend user)
        {
            Boolean isNeedInsert = false;

            Boolean IsSuccess = GlobalValue.DataFromServer.InsertRelationTab(
                GlobalValue.myself.ID, user.ID, ((Friend)user).GroupID, ((Friend)user).Remark);

            if(true == IsSuccess)
            {
                isNeedInsert = true;
            }

            if(null != mainFrmAddFriendCallback)
            {
                mainFrmAddFriendCallback(isNeedInsert, (Friend)user);
            }
            
        }
    }
}

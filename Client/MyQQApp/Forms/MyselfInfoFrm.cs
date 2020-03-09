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
    public partial class MyselfInfoFrm : Form
    {
        public delegate void UpdateMyselfInfo(Myself myself);
        public UpdateMyselfInfo UpdateMyselfInfoCallback;
        
        private Myself myself;

        public MyselfInfoFrm(Myself myself)
        {
            InitializeComponent();
            ucBackPanel.onBtnClose_Click += BtnClose;
            this.myself = myself;
        }

        private void BtnClose()
        {
            this.Close();
        }

        private void UserInfoFrm_Load(object sender, EventArgs e)
        {
            InitCombSex();
            InitCombDegree();

            picHead.Image = common.CommonTools.GetImageByPicName(myself.HeadImage);
            lbID.Text = "ID: " + myself.ID;
            txtNickname.ContentStr = myself.Nickname;
            txtSignature.ContentStr = myself.Signature;
            txtAge.ContentStr = myself.Age.ToString();
            combDegree.Content.SelectedValue = myself.Degree.ToString();
            combSex.Content.SelectedValue = myself.Sex;
            txtIP.ContentStr = myself.PublicIP.ToString();
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

        private void picHead_Click(object sender, EventArgs e)
        {
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
            myself.Nickname = txtNickname.ContentStr;
            myself.Signature = txtSignature.ContentStr;
            myself.Sex = Convert.ToInt16(combSex.Content.SelectedValue);
            myself.Age = Convert.ToInt16(txtAge.ContentStr);
            myself.Degree = Convert.ToInt16(combDegree.Content.SelectedValue);
            myself.Password = txtIP.ContentStr;

            myself.HeadImage = common.CommonTools.SaveImageToFile(picHead.Image);

            if (null != UpdateMyselfInfoCallback)
            {
                UpdateMyselfInfoCallback(myself);
            }
        }
    }
}

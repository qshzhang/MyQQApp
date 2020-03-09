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
    public partial class RegisterFrm : Form
    {
        public delegate void RegisterAccount(Myself myself);
        public RegisterAccount RegisterAccountCallback;
        
        private Myself myself;

        public RegisterFrm(string id)
        {
            InitializeComponent();
            ucBackPanel.onBtnClose_Click += BtnClose;
            myself = new Myself();

            lbID.Text = "ID: " + id;
            myself.ID = id;
        }

        private void BtnClose()
        {
            this.Close();
        }

        private void UserInfoFrm_Load(object sender, EventArgs e)
        {
            picHead.Image = Image.FromFile("head/default.jpg");

            InitCombSex();
            InitCombDegree();
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
            if(txtPassword.ContentStr.CompareTo(txtEnsure.ContentStr) != 0)
            {
                MessageBox.Show("Password is not same, please check...");
                return;
            }

            myself.Nickname = txtNickname.ContentStr;
            myself.Signature = txtSignature.ContentStr;
            myself.Sex = Convert.ToInt16(combSex.Content.SelectedValue);
            myself.Age = Convert.ToInt16(txtAge.ContentStr);
            myself.Degree = Convert.ToInt16(combDegree.Content.SelectedValue);
            myself.Password = txtPassword.ContentStr;

            myself.HeadImage = common.CommonTools.SaveImageToFile(picHead.Image);

            if (null != RegisterAccountCallback)
            {
                RegisterAccountCallback(myself);
            }
        }
    }
}

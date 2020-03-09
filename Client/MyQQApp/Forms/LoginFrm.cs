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
using static MyQQApp.common.GlobalValue;

namespace MyQQApp.Forms
{
    public partial class LoginFrm : Form
    {
        PwdRecord pwdRecord;
        Dictionary<string, string> keyValuePairs;

        public LoginFrm()
        {
            InitializeComponent();
            this.ucBackPanel.onBtnClose_Click += BtnClose;
            this.ucBackPanel.onBtnMin_Click += LoginFrm_MinWindow;

            ucSelfHead.SelfHeadImage = CommonTools.GetImageByPicName("");
            ucSelfHead.SelfStatusClickCallback += selfStatusClick;
            GlobalValue.myself.Status = UserStatus.Online;

            pwdRecord = new PwdRecord("pwd.db");
            //GlobalValue.CSMsgDeal.SetRecvMsgCallback(ReceiveMsgDeal);

            //txtUserId.Text = CommonTools.GetIpAddress();
        }

        private void BtnClose()
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (GlobalValue.DataFromServer.QueryIsUserAndPwdValid(txtUserId.Text, txtPwd.Text))
            {
                common.GlobalValue.IsLoginOk = true;
                GlobalValue.myself.ID = txtUserId.Text;
                GlobalValue.myself.LastLogin = DateTime.Now.ToLongDateString();
                this.Close();
            }
            else
            {
                MessageBox.Show("username or passowrd are incorrect");
                GlobalValue.QQLog.LogWrite(GlobalValue.LOGLEVEL.LOG_LEVEL_ERROR, "LogFrm: username or passowrd are incorrect");
            }

        }

        private void LoginFrm_MinWindow()
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbRegister_Click(object sender, EventArgs e)
        {
            RegisterFrm registerFrm = new RegisterFrm("100005");
            registerFrm.RegisterAccountCallback += OnRegisterAccount;
            registerFrm.Show();
        }

        private void OnRegisterAccount(User myself)
        {
            GlobalValue.DataFromServer.InsertLoginTab(myself.ID, ((Myself)myself).Password);
            GlobalValue.DataFromServer.InsertUserInfoTab(myself.ID, myself.Nickname, myself.Signature, myself.HeadImage, myself.Sex, myself.Age, myself.Degree);
            Boolean flag = GlobalValue.DataFromServer.InsertGroupInfo(
                myself.ID, myself.ID + "_000", "friends");
            flag = true;
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            string account = txtUserId.Text.Trim();

            if (account.Length != GlobalValue.AccountLen) return;

            if(keyValuePairs.Keys.Contains(account))
            {
                txtPwd.Text = keyValuePairs[account];
                checkBoxRememberPwd.Checked = true;
            }
            else
            {
                txtPwd.Text = "";
                checkBoxRememberPwd.Checked = false;
            }

            string name = GlobalValue.DataFromServer.QueryUserHeadImageName(account);

            Image img = ucSelfHead.SelfHeadImage;
            try
            {
                ucSelfHead.SelfHeadImage = CommonTools.GetImageByPicName(name);
            }
            catch (Exception ex)
            {
                ucSelfHead.SelfHeadImage = img;
                GlobalValue.QQLog.LogWrite(LOGLEVEL.LOG_LEVEL_INFO, "pic path invalid or get image failed");
            }
        }

        private void selfStatusClick()
        {
            RightMenu menu = new RightMenu(null);
            for (int i = 0; i < (int)GlobalValue.UserStatus.END; i++)
            {
                menu.AddMenuItem(Enum.GetName(typeof(GlobalValue.UserStatus), i), i);
                ((RightMenuItem)menu.MenuItems[i]).OnMenuItenClickCallback = selfStatusChanged;
            }
            menu.Show(this, new Point(Control.MousePosition.X - this.Location.X, Control.MousePosition.Y - this.Location.Y));
        }

        private void selfStatusChanged(object type)
        {
            ucSelfHead.SelfStatusImage = common.CommonTools.GetImageByType(Convert.ToInt16(type));
            GlobalValue.myself.Status = (GlobalValue.UserStatus)Convert.ToInt16(type);
        }

        private void checkBoxRememberPwd_CheckStateChanged(object sender, EventArgs e)
        {
            if (txtUserId.Text.Trim().Length != GlobalValue.AccountLen) return;

            if (checkBoxRememberPwd.Checked)
            {
                pwdRecord.InsertPwd(txtUserId.Text.Trim(), txtPwd.Text.Trim());
            }
            else
            {
                pwdRecord.RemovePwd(txtUserId.Text.Trim());
            }
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            keyValuePairs = pwdRecord.ReadAllPwd();
            foreach(string id in keyValuePairs.Keys)
            {
                txtUserId.Items.Add(id);
            }

            txtUserId.SelectedIndex = 0;
        }

    }
}

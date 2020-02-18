﻿using MyQQApp.common;
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
        public LoginFrm()
        {
            InitializeComponent();
            this.ucBackPanel.onBtnClose_Click += BtnClose;
            this.ucBackPanel.onBtnMin_Click += LoginFrm_MinWindow;

            ucSelfHead.SelfHeadImage = CommonTools.GetImageByPicName("");
            ucSelfHead.SelfStatusClickCallback += selfStatusClick;
            GlobalValue.myself.Status = UserStatus.Online;
        }

        private void BtnClose()
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DBOperator dBOperator = new DBOperator();

            if (dBOperator.IsValidAccount(txtUserId.Text, txtPwd.Text))
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
            UserInfoFrm userInfoFrm = new UserInfoFrm(true);
            userInfoFrm.updateSelfInfo += OnRegisterAccount;
            userInfoFrm.Show();
        }

        private void OnRegisterAccount(User myself)
        {
            DBOperator dBOperator = new DBOperator();
            dBOperator.InsertLoginTab(myself.ID, ((Myself)myself).Password);
            dBOperator.InsertUserInfoTab(myself.ID, myself.Nickname, myself.Signature, myself.HeadImage, myself.Sex, myself.Age, myself.Degree);
        }

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            string account = txtUserId.Text.Trim();

            if (account.Length != GlobalValue.AccountLen) return;

            DBOperator dBOperator = new DBOperator();

            string name = dBOperator.QueryUserHeadImageName(account);

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
    }
}
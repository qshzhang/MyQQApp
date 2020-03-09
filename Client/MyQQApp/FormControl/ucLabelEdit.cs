using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQApp.FormControl
{
    public partial class ucLabelEdit : UserControl
    {
        public delegate void ActionForExitEditHandle(string sig);
        public ActionForExitEditHandle ActionForExitEditCallback;

        private String msg;

        public string Msg { get => lbMsg.Text; set => lbMsg.Text = value; }

        public ucLabelEdit()
        {
            InitializeComponent();

            txtEditMsg.AutoSize = false;
            txtEditMsg.Height = 30;

            lbMsg.Height = 30;

            txtEditMsg.Visible = false;
            msg = lbMsg.Text;
        }

        public ucLabelEdit(String msg)
        {
            InitializeComponent();
            lbMsg.Text = msg;

            this.Msg = msg;
            txtEditMsg.Visible = false;
        }

        private void lbMsg_Click(object sender, EventArgs e)
        {
            txtEditMsg.Text = lbMsg.Text;
            txtEditMsg.Visible = true;
            lbMsg.Visible = false;
        }

        private void txtEditMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lbMsg.Text = txtEditMsg.Text;
                lbMsg.Visible = true;
                txtEditMsg.Visible = false;
                Msg = lbMsg.Text;

                ActionForExitEdit(lbMsg.Text);
            }
        }

        public void exitEdit()
        {
            if (txtEditMsg.Visible == false) return;
            lbMsg.Text = txtEditMsg.Text;
            lbMsg.Visible = true;
            txtEditMsg.Visible = false;
            //Msg = lbMsg.Text;

            ActionForExitEdit(lbMsg.Text);
        }

        private void ActionForExitEdit(string sig)
        {
            if(null != ActionForExitEditCallback)
            {
                ActionForExitEditCallback(sig);
            }
        }
    }
}

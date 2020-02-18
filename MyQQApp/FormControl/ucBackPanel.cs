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
    public partial class ucBackPanel : UserControl
    {
        private Point frmPos;
        private Point mousePos;
        private Boolean isBeginMove = false;


        public bool IsShowMinBtn { get => lbMinWin.Visible; set => lbMinWin.Visible = value; }

        public ucBackPanel()
        {
            InitializeComponent();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            lbClose.BackColor = System.Drawing.Color.Red;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            lbClose.BackColor = System.Drawing.Color.Transparent;
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            lbMinWin.BackColor = System.Drawing.Color.Red;
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            lbMinWin.BackColor = System.Drawing.Color.Transparent;
        }

        public delegate void ucButton_Click();
        public event ucButton_Click onBtnClose_Click;
        public event ucButton_Click onBtnMin_Click;

        public void ucOnBtnClick()
        {
            if (null != onBtnClose_Click)
            {
                onBtnClose_Click();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ucOnBtnClick();
        }

        private void ucBackPanel_SizeChanged(object sender, EventArgs e)
        {
            this.lbClose.Location = new Point(this.Width - this.lbClose.Width - 1, 1);
            this.lbMinWin.Location = new Point(this.Width - this.lbClose.Width - 1 - this.lbMinWin.Width, 1);
        }

        private void ucBackPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form form = this.Parent as Form;
                if (form != null)
                {
                    isBeginMove = true;
                    frmPos = form.Location;
                    mousePos = Control.MousePosition;
                }
            }
        }

        private void ucBackPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isBeginMove)
            {
                Form form = this.Parent as Form;
                if (form != null)
                {
                    form.Location = frmPos + (Size)Control.MousePosition - (Size)mousePos;
                }
            }


        }

        private void lbMinWin_Click(object sender, EventArgs e)
        {
            if (null != onBtnMin_Click)
            {
                onBtnMin_Click();
            }
        }

        private void ucBackPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isBeginMove = false;
            }
        }
    }
}

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
    public partial class ucMenuItem : UserControl
    {
        public delegate void MenuItemClickHandle(object para = null);
        public event MenuItemClickHandle MenuItemClick;



        private object para;

        public ucMenuItem()
        {
            InitializeComponent();
            this.Width = 200;
            this.Height = 30;
            this.picIcon.Width = 24;
            this.picIcon.Height = 24;
            this.picIcon.Location = new Point(3, 3);
            this.lbMenuDesc.Height = this.Height;
            this.lbMenuDesc.Width = this.Width - this.Height - 20;
            this.lbMenuDesc.Location = new Point(this.Height + 20, 0);


            this.picIcon.Click += ucMenuItem_Click;
            this.lbMenuDesc.Click += ucMenuItem_Click;

            this.picIcon.MouseEnter += ucMenuItem_MouseEnter;
            this.lbMenuDesc.MouseEnter += ucMenuItem_MouseEnter;

            this.picIcon.MouseLeave += ucMenuItem_MouseLeave;
            this.lbMenuDesc.MouseLeave += ucMenuItem_MouseLeave;
        }

        public void OnMenuItemClick()
        {
            if (MenuItemClick != null)
                MenuItemClick(para);
        }

        public Image IconImage { set => picIcon.Image = value; }
        public string MenuDesc { get => lbMenuDesc.Text; set => lbMenuDesc.Text = value; }
        public object Para { get => para; set => para = value; }

        private void ucMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void ucMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void ucMenuItem_Click(object sender, EventArgs e)
        {
            OnMenuItemClick();
        }
    }
}

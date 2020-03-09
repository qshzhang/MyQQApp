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
    public partial class ucSelfHead : UserControl
    {
        public delegate void OnLeftButtonClick();
        public OnLeftButtonClick SelfHeadClickCallback;
        public OnLeftButtonClick SelfStatusClickCallback;

        public Image SelfHeadImage { get => this.panelHead.BackgroundImage; set => this.panelHead.BackgroundImage = value; }
        public Image SelfStatusImage { get => this.panelStatus.BackgroundImage; set => this.panelStatus.BackgroundImage = value; }

        public ucSelfHead()
        {
            InitializeComponent();
        }

        private void panelHead_Click(object sender, EventArgs e)
        {
            if(((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if(null != SelfHeadClickCallback)
                {
                    SelfHeadClickCallback();
                }
            }
        }

        private void panelStatus_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (null != SelfStatusClickCallback)
                {
                    SelfStatusClickCallback();
                }
            }
        }
    }
}

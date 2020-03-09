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
    public partial class ucDesEdit : UserControl
    {
        
        public String DescribeStr
        {
            get { return this.lbExpress.Text; }
            set { this.lbExpress.Text = value; }
        }

        public String ContentStr
        {
            get { return this.txtVal.Text; }
            set { this.txtVal.Text = value; }
        }

        public Char PasswordChr
        {
            get { return this.txtVal.PasswordChar; }
            set { this.txtVal.PasswordChar = value; }
        }

        public ucDesEdit()
        {
            InitializeComponent();
        }
    }
}

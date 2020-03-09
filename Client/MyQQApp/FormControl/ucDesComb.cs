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
    public partial class ucDesComb : UserControl
    {
        
        public String DescribeStr
        {
            get { return this.lbExpress.Text; }
            set { this.lbExpress.Text = value; }
        }

        public ComboBox Content
        {
            get { return this.comboBox; }
        }


        public ucDesComb()
        {
            InitializeComponent();
        }
    }
}

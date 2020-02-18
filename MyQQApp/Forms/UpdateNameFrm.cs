using MyQQApp.ChatListControl;
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
    public partial class UpdateNameFrm : Form
    {
        public delegate void UpdateNameCallback(string id, string oldName, string newName);
        public event UpdateNameCallback UpdateName;

        private String  groupName;
        private string id;

        public UpdateNameFrm(String name, string _id = "")
        {
            InitializeComponent();
            this.ucBackPanel.onBtnClose_Click += BtnClose;
            this.txtGroupName.Text = name;
            groupName = name;
            id = _id;
        }

        private void BtnClose()
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(null != UpdateName)
            {
                UpdateName(id, groupName, txtGroupName.Text);
            }
            
            this.Close();
        }
    }
}

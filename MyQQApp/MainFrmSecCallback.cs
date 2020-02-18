using MyQQApp.ChatListControl;
using MyQQApp.common;
using MyQQApp.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQApp
{
    partial class MainFrm
    {
        private void OnUpdateFriendRemark(string friendid, string oldName, string newName)
        {
            chatListBox.SelectSubItem.DisplayName = newName;
            DBOperator dBOperator = new DBOperator();
            dBOperator.UpdateFriendRemark(GlobalValue.myself.ID, friendid, newName);
        }
    }
}

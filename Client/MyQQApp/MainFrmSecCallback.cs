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
        private List<string> JsonToStringList(Json json)
        {
            string tmp;
            List<string> list = new List<string>();
            Json temp = new Json();
            string str = json.JsonGetValueByKey("result");

            str = str.Substring(1, str.Length - 2);
            string[] groups = str.Split(',');

            foreach (string s in groups)
            {
                tmp = s.Trim();
                list.Add(tmp.Substring(1, tmp.Length - 2));
            }

            return list;
        }


        private List<RelationTab> JsonToRelationTable(Json json)
        {
            Json temp = new Json();
            List<RelationTab> result = new List<RelationTab>();
            string str = json.JsonGetValueByKey("list");

            str = str.Substring(1, str.Length - 2);
            string[] groups = str.Split(',');

            foreach(string s in groups)
            {
                temp = new Json(s.Replace(GlobalValue.filedSplitStr, "\r\n"));

                RelationTab tab = new RelationTab();
                tab.MyAccount = temp.JsonGetValueByKey("myid");
                tab.FriendAccount = temp.JsonGetValueByKey("friendid");
                tab.GroupID = temp.JsonGetValueByKey("groupid");
                tab.GroupName = temp.JsonGetValueByKey("groupname");
                tab.Remark = temp.JsonGetValueByKey("remark");

                result.Add(tab);
            }

            return result;
        }


        private void OnUpdateFriendRemark(string friendid, string oldName, string newName)
        {
            chatListBox.SelectSubItem.DisplayName = newName;

            GlobalValue.DataFromServer.UpdateFriendRemark(GlobalValue.myself.ID,
                friendid, newName);

            
        }
    }
}

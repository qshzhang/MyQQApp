using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    class DBMatchClass
    {
    }

    public class RelationTab
    {
        private string myaccount;
        private string friendaccount;
        private string groupid;
        private string groupname;
        private string remark;

        public string MyAccount { get => myaccount; set => myaccount = value; }
        public string FriendAccount { get => friendaccount; set => friendaccount = value; }
        public string GroupName { get => groupname; set => groupname = value; }
        public string GroupID { get => groupid; set => groupid = value; }
        public string Remark { get => remark; set => remark = value; }

        public override string ToString()
        {
            string str = "";
            str += "myid: " + myaccount + GlobalValue.filedSplitStr;
            str += "friendid: " + friendaccount + GlobalValue.filedSplitStr;
            str += "groupid: " + groupid + GlobalValue.filedSplitStr;
            str += "groupname: " + GroupName + GlobalValue.filedSplitStr;
            str += "remark: " + remark;
            return str;
        }
    }

    public class LoginTab
    {
        private string account;
        private string password;
        private string lastLogin;
        private short status;
        private string publicIP;
        private string localIP;

        public string Account { get => account; set => account = value; }
        public string Password { get => password; set => password = value; }
        public string LastLogin { get => lastLogin; set => lastLogin = value; }
        public short Status { get => status; set => status = value; }
        public string PublicIP { get => publicIP; set => publicIP = value; }
        public string LocalIP { get => localIP; set => localIP = value; }

        public override string ToString()
        {
            string str = GlobalValue.filedSplitStr;
            str += "id: " + account + GlobalValue.filedSplitStr;
            str += "pwd: " + password + GlobalValue.filedSplitStr;
            str += "lastlogin: " + lastLogin + GlobalValue.filedSplitStr;
            str += "status: " + status + GlobalValue.filedSplitStr;
            str += "publicip: " + PublicIP + GlobalValue.filedSplitStr;
            str += "localip: " + LocalIP + GlobalValue.filedSplitStr;
            return str;
        }
    }

    public class UserInfo
    {
        private string account;
        private string nickname;
        private string signature;
        private string registerTime;
        private short sex;
        private short age;
        private short degree;
        private string headimage;

        public string Account { get => account; set => account = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Signature { get => signature; set => signature = value; }
        public string RegisterTime { get => registerTime; set => registerTime = value; }
        public short Sex { get => sex; set => sex = value; }
        public short Age { get => age; set => age = value; }
        public short Degree { get => degree; set => degree = value; }
        public string Headimage { get => headimage; set => headimage = value; }

        public override string ToString()
        {
            string str = GlobalValue.filedSplitStr;
            str += "id: " + account + GlobalValue.filedSplitStr;
            str += "nick: " + nickname + GlobalValue.filedSplitStr;
            str += "sig: " + signature + GlobalValue.filedSplitStr;
            str += "register: " + registerTime + GlobalValue.filedSplitStr;
            str += "sex: " + sex.ToString() + GlobalValue.filedSplitStr;
            str += "age: " + age.ToString() + GlobalValue.filedSplitStr;
            str += "degree: " + degree.ToString() + GlobalValue.filedSplitStr;
            str += "headimage: " + headimage + GlobalValue.filedSplitStr;
            return str;
        }
    }

    public class GroupInfo
    {
        private string groupid;
        private string groupname;

        public string GroupId { get => groupid; set => groupid = value; }
        public string GroupName { get => groupname; set => groupname = value; }

        public override string ToString()
        {
            string str = GlobalValue.filedSplitStr;
            str += GlobalValue.GroupIDStr + GlobalValue.ColonStr + groupid + GlobalValue.filedSplitStr;
            str += GlobalValue.GroupNameStr + GlobalValue.ColonStr + groupname.Replace(",", GlobalValue.commaReplaceStr) + GlobalValue.filedSplitStr;
            return str;
        }
    }
}

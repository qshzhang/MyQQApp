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
    }

    public class LoginTab
    {
        private string account;
        private string password;
        private string lastLogin;
        private short status;
        private string iP;

        public string Account { get => account; set => account = value; }
        public string Password { get => password; set => password = value; }
        public string LastLogin { get => lastLogin; set => lastLogin = value; }
        public short Status { get => status; set => status = value; }
        public string IP { get => iP; set => iP = value; }
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
    }
}

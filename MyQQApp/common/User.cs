using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class User
    {
        private String iD;
        private String nickname;
        private String signature;
        private String iP;
        private int udpPort;
        private int tcpPort;
        private string headImage;
        private GlobalValue.UserStatus status;
        private string lastLogin;
        private string registerTime;
        private short  sex;
        private short  age;
        private short  degree;

        public string ID { get => iD; set => iD = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Signature { get => signature; set => signature = value; }
        public string IP { get => iP; set => iP = value; }
        public string HeadImage { get => headImage; set => headImage = value; }
        public GlobalValue.UserStatus Status { get => status; set => status = value; }
        public string LastLogin { get => lastLogin; set => lastLogin = value; }
        public string RegisterTime { get => registerTime; set => registerTime = value; }
        public short Sex { get => sex; set => sex = value; }
        public short Age { get => age; set => age = value; }
        public short Degree { get => degree; set => degree = value; }
        public int UdpPort { get => udpPort; set => udpPort = value; }
        public int TcpPort { get => tcpPort; set => tcpPort = value; }
    }

    public class Myself : User
    {
        private String password;

        public string Password { get => password; set => password = value; }

        public void CopyFrom(User user)
        {
            ID = user.ID;
            Nickname = user.Nickname;
            Signature = user.Signature;
            IP = user.IP;
            UdpPort = user.UdpPort;
            TcpPort = user.TcpPort;
            HeadImage = user.HeadImage;
            Status = user.Status;
            LastLogin = user.LastLogin;
            RegisterTime = user.RegisterTime;
            Sex = user.Sex;
            Age = user.Age;
            Degree = user.Degree;
        }
    }

    public class Friend : User
    {
        private String remark;
        private string groupname;

        public string Remark { get => remark; set => remark = value; }
        public string Groupname { get => groupname; set => groupname = value; }
    }
}

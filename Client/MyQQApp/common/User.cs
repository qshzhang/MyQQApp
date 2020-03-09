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
        private String publicIP;
        private String localIP;
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
        public string PublicIP { get => publicIP; set => publicIP = value; }
        public string LocalIP { get => localIP; set => localIP = value; }
        public string HeadImage { get => headImage; set => headImage = value; }
        public GlobalValue.UserStatus Status { get => status; set => status = value; }
        public string LastLogin { get => lastLogin; set => lastLogin = value; }
        public string RegisterTime { get => registerTime; set => registerTime = value; }
        public short Sex { get => sex; set => sex = value; }
        public short Age { get => age; set => age = value; }
        public short Degree { get => degree; set => degree = value; }
        public int UdpPort { get => udpPort; set => udpPort = value; }
        public int TcpPort { get => tcpPort; set => tcpPort = value; }

        public override string ToString()
        {
            string str = GlobalValue.filedSplitStr;
            str += GlobalValue.AccountStr + GlobalValue.ColonStr + ID + GlobalValue.filedSplitStr;
            str += GlobalValue.NickNameStr + GlobalValue.ColonStr + Nickname.Replace(",", GlobalValue.commaReplaceStr) + GlobalValue.filedSplitStr;
            str += GlobalValue.SignatureStr + GlobalValue.ColonStr + Signature.Replace(",", GlobalValue.commaReplaceStr) + GlobalValue.filedSplitStr;
            str += GlobalValue.StatusStr + GlobalValue.ColonStr + (int)Status + GlobalValue.filedSplitStr;
            str += GlobalValue.PublicIPStr + GlobalValue.ColonStr + PublicIP + GlobalValue.filedSplitStr;
            str += GlobalValue.LocalIPStr + GlobalValue.ColonStr + LocalIP + GlobalValue.filedSplitStr;
            str += GlobalValue.UDPPortStr + GlobalValue.ColonStr + UdpPort + GlobalValue.filedSplitStr;
            str += GlobalValue.TCPPortStr + GlobalValue.ColonStr + TcpPort + GlobalValue.filedSplitStr;
            str += GlobalValue.HeadImageNameStr + GlobalValue.ColonStr + HeadImage + GlobalValue.filedSplitStr;
            str += GlobalValue.LastLoginStr + GlobalValue.ColonStr + LastLogin + GlobalValue.filedSplitStr;
            str += GlobalValue.SexStr + GlobalValue.ColonStr + Sex + GlobalValue.filedSplitStr;
            str += GlobalValue.AgeStr + GlobalValue.ColonStr + Age + GlobalValue.filedSplitStr;
            str += GlobalValue.DegreeStr + GlobalValue.ColonStr + Degree + GlobalValue.filedSplitStr;
            str += GlobalValue.RegisterTimeStr + GlobalValue.ColonStr + RegisterTime + GlobalValue.filedSplitStr;
            return str;
        }
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
            PublicIP = user.PublicIP;
            LocalIP = user.LocalIP;
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
        private string groupid;
        private string groupname;

        public string Remark { get => remark; set => remark = value; }
        public string GroupName { get => groupname; set => groupname = value; }
        public string GroupID { get => groupid; set => groupid = value; }

        public override string ToString()
        {
            string str = GlobalValue.filedSplitStr;
            str += GlobalValue.AccountStr + GlobalValue.ColonStr + ID + GlobalValue.filedSplitStr;
            str += GlobalValue.NickNameStr + GlobalValue.ColonStr + Nickname.Replace(",", GlobalValue.commaReplaceStr) + GlobalValue.filedSplitStr;
            str += GlobalValue.SignatureStr + GlobalValue.ColonStr + Signature.Replace(",", GlobalValue.commaReplaceStr) + GlobalValue.filedSplitStr;
            str += GlobalValue.StatusStr + GlobalValue.ColonStr + (int)Status + GlobalValue.filedSplitStr;
            str += GlobalValue.PublicIPStr + GlobalValue.ColonStr + PublicIP + GlobalValue.filedSplitStr;
            str += GlobalValue.LocalIPStr + GlobalValue.ColonStr + LocalIP + GlobalValue.filedSplitStr;
            str += GlobalValue.UDPPortStr + GlobalValue.ColonStr + UdpPort + GlobalValue.filedSplitStr;
            str += GlobalValue.TCPPortStr + GlobalValue.ColonStr + TcpPort + GlobalValue.filedSplitStr;
            str += GlobalValue.HeadImageNameStr + GlobalValue.ColonStr + HeadImage + GlobalValue.filedSplitStr;
            str += GlobalValue.LastLoginStr + GlobalValue.ColonStr + LastLogin + GlobalValue.filedSplitStr;
            str += GlobalValue.SexStr + GlobalValue.ColonStr + Sex + GlobalValue.filedSplitStr;
            str += GlobalValue.AgeStr + GlobalValue.ColonStr + Age + GlobalValue.filedSplitStr;
            str += GlobalValue.DegreeStr + GlobalValue.ColonStr + Degree + GlobalValue.filedSplitStr;
            str += GlobalValue.RegisterTimeStr + GlobalValue.ColonStr + RegisterTime + GlobalValue.filedSplitStr;
            str += GlobalValue.RemarkStr + GlobalValue.ColonStr + Remark.Replace(",", GlobalValue.commaReplaceStr) + GlobalValue.filedSplitStr;
            str += GlobalValue.GroupIDStr + GlobalValue.ColonStr + GroupID + GlobalValue.filedSplitStr;
            str += GlobalValue.GroupNameStr + GlobalValue.ColonStr + GroupName.Replace(",", GlobalValue.commaReplaceStr) + GlobalValue.filedSplitStr;
            return str;
        }
    }
}

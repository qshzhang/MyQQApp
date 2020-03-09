using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class GlobalValue
    {
        #region 常用字符串常量
        public static string AccountStr = "id";
        public static string FriendAccountStr = "friendid";
        public static string NickNameStr = "nick";
        public static string SignatureStr = "signature";
        public static string StatusStr = "status";
        public static string PublicIPStr = "publicip";
        public static string LocalIPStr = "localip";
        public static string TCPPortStr = "tcp";
        public static string UDPPortStr = "udp";
        public static string HeadImageNameStr = "headimage";
        public static string LastLoginStr = "lastlogin";
        public static string SexStr = "sex";
        public static string AgeStr = "age";
        public static string DegreeStr = "degree";
        public static string RegisterTimeStr = "registertime";
        public static string RemarkStr = "remark";
        public static string GroupIDStr = "groupid";
        public static string GroupNameStr = "groupname";
        public static string PasswordStr = "pwd";
        public static string ResultStr = "result";

        public static string ColonStr = ": ";
        public static string filedSplitStr = "___";

        public static string commaReplaceStr = "|__|";
        #endregion


        public static Boolean IsLoginOk = false;

        public static  Myself myself = new Myself();

        public static int AccountLen = 6;

        public static LogSys QQLog = new LogSys("QQ.log");

        public static int ServerPort = 1234;
        public static int ClientPort = 1222;

        public static string ServerIp = "127.0.0.1";

        public static CliendRequestFromServer DataFromServer = 
            new CliendRequestFromServer(GlobalValue.ClientPort);

        //在线状态
        public enum UserStatus
        {
            QMe = 0, Online, Away, Busy, DontDisturb, OffLine, END   //貌似对于列表而言 没有隐身状态
        }

        public enum MessageType
        {
            TxtMsg = 0, ImageMsg, FileMsg, VedioMsg, END
        }

        public enum ResponseType
        {
            RequestDownload = (Byte)0, DownOver, CancelRecv, NoResponse, END
        }

        public enum LOGLEVEL
        {
            LOG_LEVEL_INFO = 0, LOG_LEVEL_DEBUG, LOG_LEVEL_ERROR, LOG_LEVEL_FATAL, LOG_LEVEL_WARN, END
        }
    }
}

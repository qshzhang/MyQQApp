using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class GlobalValue
    {
        public static Boolean IsLoginOk = false;

        public static  Myself myself = new Myself();

        public static int AccountLen = 6;

        public static LogSys QQLog = new LogSys("QQ.log");

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

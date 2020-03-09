using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class LogSys
    {
        private string fileName;
        FileStream fs = null;
        StreamWriter streamWriter = null;

        public LogSys(string fileName)
        {
            this.fileName = fileName;
            fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            streamWriter = new StreamWriter(fs);
        }

        public void LogWrite(GlobalValue.LOGLEVEL LogLevel, string str)
        {
            //StackTrace st = new StackTrace(new StackFrame(true));
            //StackFrame sf = st.GetFrame(0);

            StackFrame sf = new StackFrame(1, true);

            string strLine = "[" + Enum.GetName(typeof(GlobalValue.LOGLEVEL), LogLevel) + "]";
            strLine += "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";

            strLine += (System.IO.Path.GetFileName(sf.GetFileName()) + " " + sf.GetFileLineNumber().ToString() + ": ");
            strLine += str;

            streamWriter.WriteLine(strLine);
        }

        public void LogFlush()
        {
            streamWriter.Close();
            fs.Close();

            fs = new FileStream(fileName, FileMode.Append, FileAccess.Write);
            streamWriter = new StreamWriter(fs);
        }

        public void QuitLog()
        {
            streamWriter.Close();
            fs.Close();
        }
    }

}

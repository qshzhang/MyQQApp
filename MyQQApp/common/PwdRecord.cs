using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    class PwdRecord
    {
        private string fileName;

        public PwdRecord(string file)
        {
            this.fileName = file;
        }

        public void InsertPwd(string id, string pwd)
        {
            if (pwd.Length == 0) return;

            FileStream fs = null;
            StreamWriter streamWriter = null;
            Dictionary<string, string> keyValuePairs = ReadAllPwd();

            fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            keyValuePairs[id] = pwd;

            streamWriter = new StreamWriter(fs);

            foreach(string account in keyValuePairs.Keys)
            {
                streamWriter.WriteLine(account + " " + keyValuePairs[account]);
            }

            
            streamWriter.Close();
            fs.Close();
        }

        public void RemovePwd(string id)
        {
            FileStream fs = null;
            StreamWriter streamWriter = null;
            Dictionary<string, string> keyValuePairs = ReadAllPwd();

            fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            streamWriter = new StreamWriter(fs);

            foreach (string account in keyValuePairs.Keys)
            {
                if (account.CompareTo(id) == 0) continue;
                streamWriter.WriteLine(account + " " + keyValuePairs[account]);
            }


            streamWriter.Close();
            fs.Close();
        }

        public Dictionary<string, string> ReadAllPwd()
        {
            string line = "";
            StreamReader streamReader = null;
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            streamReader = new StreamReader(fileName, Encoding.Default);

            while ((line = streamReader.ReadLine()) != null)
            {
                keyValuePairs[line.Substring(0, line.IndexOf(' '))] = line.Substring(line.IndexOf(' ') + 1);
            }

            streamReader.Close();

            return keyValuePairs;
        }
    }
}

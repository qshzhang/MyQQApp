using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class Json
    {
        private string _data = "";
        private int _pairCount = 0;

        public Json()
        {
            _data += "{\r\n}";
        }

        public Json(string str)
        {
            _data = str;
        }
        public void JsonAddStringElement(string key, string value)
        {
            string cont = key + ": " + value + "\r\n";
            int pos = _data.LastIndexOf("\r\n") + "\r\n".Length;

            _data = _data.Substring(0, pos);
            _data += (cont + "}");
        }

        public void JsonAddIntElement(string key, int value)
        {
            JsonAddStringElement(key, value.ToString());
        }

        public void JsonAddDateTimeElement(string key, DateTime value)
        {
            JsonAddStringElement(key, value.ToString());
        }

        public void JsonAddListObjectElement(string key, List<Object> value)
        {
            string liststring = "[";
            for (int i = 0; i < value.Count - 1; i++)
            {
                liststring += ("{" + value[i].ToString() + "},");
            }
            liststring += ("{" + value[value.Count - 1].ToString() + "}");
            liststring += "]";

            JsonAddStringElement(key, liststring);
        }

        public string JsonGetValueByKey(string key)
        {
            int keylen = key.Length;
            string[] cont = _data.Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string str in cont)
            {
                if (str.Length < keylen + 3) continue;
                if (str.Substring(0, keylen + 2).CompareTo(key + ": ") == 0)
                {
                    return str.Substring(keylen + 2);
                }
            }
            return "";
        }

        public string JsonGetString()
        {
            return _data;
        }

        public int JsonGetLen()
        {
            return _data.Length;
        }

        public void JsonClear()
        {
            _data += "{\r\n}";
        }
    }
}

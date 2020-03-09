using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyQQAppServer
{
    public partial class MainFrm : Form
    {

        MsgDeal gMsgDeal;

        public MainFrm()
        {
            InitializeComponent();

            gMsgDeal = new MsgDeal();
            gMsgDeal.InitServerUdp();

            //获取外部IP  
            textBox1.Text = GetPublicIp();
        }

        /// <summary>
        /// 功能：获取本地的外网IP地址
        /// 作者：黄海
        /// 时间：2016-07-22
        /// </summary>
        /// <returns></returns>
        private static string GetPublicIp()
        {
            var urlList = new List<string>
            {
                "http://ip.qq.com/",
                "http://pv.sohu.com/cityjson?ie=utf-8",
                "http://ip.taobao.com/service/getIpInfo2.php?ip=myip"
            };
            var tempip = "";
            foreach (var a in urlList)
            {
                try
                {
                    var req = WebRequest.Create(a);
                    req.Timeout = 20000;
                    var response = req.GetResponse();
                    var resStream = response.GetResponseStream();
                    if (resStream != null)
                    {
                        var sr = new StreamReader(resStream, Encoding.UTF8);
                        var htmlinfo = sr.ReadToEnd();
                        //匹配IP的正则表达式
                        var r = new Regex("((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|\\d)\\.){3}(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]\\d|[1-9])", RegexOptions.None);
                        var mc = r.Match(htmlinfo);
                        //获取匹配到的IP
                        tempip = mc.Groups[0].Value;
                        resStream.Close();
                        sr.Close();
                        response.Dispose();
                    }
                    return tempip;
                }
                catch (Exception err)
                {
                    //Console.WriteLine("当前探测URL:" + a + ",错误描述：" + err.ToString());
                }
            }
            return tempip;
        }

        public string GetExportIP()
        {
            //获取外部IP  
            string strUrl = "http://www.ip.cn/getip.php?action=getip&ip_url=&from=web";
            Uri uri = new Uri(strUrl);
            WebRequest webreq = WebRequest.Create(uri);
            Stream s = webreq.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(s, Encoding.Default);
            string all = sr.ReadToEnd();
            all = Regex.Replace(all, @"(\d+)", "000$1");
            all = Regex.Replace(all, @"0+(\d{3})", "$1");
            string reg = @"(\d{3}\.\d{3}\.\d{3}\.\d{3})";
            Regex regex = new Regex(reg);
            Match match = regex.Match(all);
            string ip = match.Groups[1].Value;
            return Regex.Replace(ip, @"0*(\d+)", "$1");
        }

    }
}

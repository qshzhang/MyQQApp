using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyQQApp.common
{
    public class NetTool
    {
        public static Boolean IsPortInUsed(int port, PortType type)
        {
            PortHelper portHelper = new PortHelper();
            return portHelper.portInUse(port, type);
        }

        public static int GenerateValidPort(PortType type)
        {
            int p = 9999;
            if (type == PortType.TCP) p = 8888;
            while (IsPortInUsed(p, type)) p++;
            return p;
        }

        public static string GetLocalIpAddress()
        {
            string hostName = Dns.GetHostName();   //获取本机名
            IPHostEntry localhost = Dns.GetHostByName(hostName);    //方法已过期，可以获取IPv4的地址
                                                                    //IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
            IPAddress localaddr = localhost.AddressList[0];

            return localaddr.ToString();
        }

        public static string GetPublicIp()
        {
            var urlList = new List<string>{"http://ip.qq.com/",
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
                }
            }
            return tempip;
        }
    }

    public class PortHelper
    {

        #region 指定类型的端口是否已经被使用了
        /// <summary>
        /// 指定类型的端口是否已经被使用了
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="type">端口类型</param>
        /// <returns></returns>
        public bool portInUse(int port, PortType type)
        {
            bool flag = false;
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipendpoints = null;
            if (type == PortType.TCP)
            {
                ipendpoints = properties.GetActiveTcpListeners();
            }
            else
            {
                ipendpoints = properties.GetActiveUdpListeners();
            }
            foreach (IPEndPoint ipendpoint in ipendpoints)
            {
                if (ipendpoint.Port == port)
                {
                    flag = true;
                    break;
                }
            }
            ipendpoints = null;
            properties = null;
            return flag;
        }
        #endregion

    }

    #region 端口枚举类型
    /// <summary>
    /// 端口类型
    /// </summary>
    public enum PortType
    {
        /// <summary>
        /// TCP类型
        /// </summary>
        TCP,
        /// <summary>
        /// UDP类型
        /// </summary>
        UDP
    }
    #endregion
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
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
            IPAddress localaddr = localhost.AddressList[1];

            return localaddr.ToString();
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

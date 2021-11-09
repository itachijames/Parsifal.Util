using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Parsifal.Util
{
    public class NetHelper
    {
        /// <summary>
        /// 指定端口是否被占用
        /// </summary>
        /// <param name="port">端口</param>
        /// <returns>被占用返回true;否则false</returns>
        /// <exception cref="ArgumentOutOfRangeException">端口数值异常</exception>
        public static bool IsPortOccuped(int port)
        {
            if (port > IPEndPoint.MaxPort || port < IPEndPoint.MinPort)
                throw new ArgumentOutOfRangeException(nameof(port));
            try
            {
                var iproperties = IPGlobalProperties.GetIPGlobalProperties();
                var tcpEps = iproperties.GetActiveTcpListeners();
                var udpEps = iproperties.GetActiveUdpListeners();
                var tcpConn = iproperties.GetActiveTcpConnections();
                if (tcpEps.Any(p => p.Port == port)
                    || udpEps.Any(p => p.Port == port)
                    || tcpConn.Any(c => c.LocalEndPoint.Port == port))
                {
                    return true;
                }
            }
            catch
            { }
            return false;
        }
        /// <summary>
        /// 获取本地IPv4地址
        /// </summary>
        public static IEnumerable<IPAddress> GetLocalIPv4()
        {
            return Dns.GetHostAddresses(Dns.GetHostName())
                .Where(p => p.AddressFamily == AddressFamily.InterNetwork);
        }
        /// <summary>
        /// 获取本地所有可用地址
        /// </summary>
        /// <returns>所有网络适配器可用IP地址</returns>
        public static IEnumerable<IPAddress> GetLocalIPs()
        {
            var nis = NetworkInterface.GetAllNetworkInterfaces()
                .Where(i => i.OperationalStatus == OperationalStatus.Up);
            foreach (var ni in nis)
            {
                var ips = ni.GetIPProperties();
                foreach (var addI in ips.UnicastAddresses)
                {
                    yield return addI.Address;
                }
            }
        }
        /// <summary>
        /// 是否为私有地址
        /// </summary>
        /// <param name="address">ip地址</param>
        /// <returns>为私有地址时返回true;否则false</returns>
        /// <exception cref="ArgumentNullException"><paramref name="address"/>为空</exception>
        public static bool IsPrivateAddress(IPAddress address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));
            if (address.AddressFamily != AddressFamily.InterNetwork)
                return false;
            var ipBytes = address.GetAddressBytes();
            if (ipBytes[0] == 192 && ipBytes[1] == 168)
                return true;
            if (ipBytes[0] == 172 && ipBytes[1] >= 16 && ipBytes[1] <= 31)
                return true;
            if (ipBytes[0] == 169 && ipBytes[1] == 254)
                return true;
            if (ipBytes[0] == 10)
                return true;
            return false;
        }
    }
}

using System;
using System.Linq;
using System.Threading;
using Parsifal.Util.Net;
using Xunit;

namespace Parsifal.Util.UnitTest
{
    public class NetFuncTest
    {
        [Fact]
        public void TcpServerAndClientTest()
        {
            var random = new Random(new Guid().GetHashCode());
            var curAddrStr = NetHelper.GetLocalIPv4().First().ToString();
            int srvPort = random.Next(10000, 49151);

            var server = new SimpleTcpServer(curAddrStr, srvPort);
            server.Start();

            var client = new SimpleTcpClient(curAddrStr, srvPort);
            client.Connect();
            Thread.Sleep(1000);

            Assert.True(client.Connected);

            var buffer = new byte[1024];
            int recCount = 0;
            server.ReceiveDataFrom += (ep, data) =>
            {
                recCount = data.Length;
                Buffer.BlockCopy(data, 0, buffer, 0, recCount);
            };
            var data = new byte[16];
            random.NextBytes(data);
            client.Send(data);
            Thread.Sleep(1000);

            Assert.Equal(data, buffer.Take(recCount).ToArray());
        }
    }
}

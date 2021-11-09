using System.Linq;
using Xunit;

namespace Parsifal.Util.UnitTest
{
    public class HelperTest
    {
        [Fact]
        public void NetTest()
        {
            var localIPs = NetHelper.GetLocalIPv4();

            var ips = NetHelper.GetLocalIPs().ToList();
        }
    }
}

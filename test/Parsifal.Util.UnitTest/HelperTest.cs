using Xunit;

namespace Parsifal.Util.UnitTest
{
    public class HelperTest
    {
        [Fact]
        public void NetTest()
        {
            var localIPs = NetHelper.GetLocalIPv4();
            Assert.True(localIPs.Length >= 1);
        }
    }
}

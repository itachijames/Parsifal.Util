using Xunit;

namespace Parsifal.Util.UnitTest
{
    public class EnvironmentTest
    {
        [Fact]
        public void OSTest()
        {
            Assert.True(EnvironmentHelper.IsWindow() || EnvironmentHelper.IsLinux());

        }
    }
}

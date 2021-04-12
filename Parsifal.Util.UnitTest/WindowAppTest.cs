using System.Runtime.Versioning;
using Parsifal.Util.Window;
using Xunit;

namespace Parsifal.Util.UnitTest
{
    public class WindowAppTest
    {
#if WINDOWS
        [SupportedOSPlatform("windows")]
        [Fact]
        public void FindAppTest()
        {
            var app = new AppModuleInfo
            {
                ProcessName = "notepad++"
            };

            var isFind = WindowHelper.FindWindow(app, out _);
            Assert.False(isFind);
        }

#endif
    }
}

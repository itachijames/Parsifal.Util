using System.Runtime.Versioning;
using Parsifal.Util.Windows;
using Xunit;

namespace Parsifal.Util.UnitTest
{
    public class WindowsFuncTest
    {
#if WINDOWS

        [SupportedOSPlatform("windows")]
        [Fact]
        public void FindAppTest()
        {
            var app = new AppModuleInfo
            {
                ProcessName = "notepad"
            };

            var isFind = WindowsHelper.FindWindow(app, out _);
            Assert.False(isFind);
        }

#endif
    }
}
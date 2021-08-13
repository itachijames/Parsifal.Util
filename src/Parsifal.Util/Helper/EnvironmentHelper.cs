using System;
using System.Runtime.InteropServices;

namespace Parsifal.Util
{
    public class EnvironmentHelper
    {
        /// <summary>
        /// 是否为Windows系统
        /// </summary>
        /// <returns>是Windows返回true;否则false</returns>
        public static bool IsWindow()
        {
#if NETFRAMEWORK
            var p = Environment.OSVersion.Platform;
            return p == PlatformID.Win32NT || p == PlatformID.Win32Windows || p == PlatformID.WinCE || p == PlatformID.Win32S;
#else
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif
        }
        /// <summary>
        /// 是否为Linux系统
        /// </summary>
        /// <returns>是Linux返回true;否则false</returns>
        public static bool IsLinux()
        {
#if NETFRAMEWORK
            return false;
#else
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#endif
        }
    }
}

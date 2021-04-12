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
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }
        /// <summary>
        /// 是否为Linux系统
        /// </summary>
        /// <returns>是Linux返回true;否则false</returns>
        public static bool IsLinux()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }
    }
}

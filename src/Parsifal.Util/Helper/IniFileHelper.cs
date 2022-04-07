using System.Runtime.InteropServices;
using System.Text;

namespace Parsifal.Util
{
#if NET6_0_OR_GREATER
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public class IniFileHelper
    {
        private const string WIN_DLL_NAME = "kernel32.dll";

        [DllImport(WIN_DLL_NAME, CharSet = CharSet.Unicode)]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);
        [DllImport(WIN_DLL_NAME, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">项名</param>
        /// <param name="skey">键</param> 
        /// <param name="path">路径</param>
        /// <returns>键值</returns>
        public static string IniRead(string section, string skey, string path)
        {
            const int maxValueLength = 512;
            var result = new StringBuilder(maxValueLength);
            _ = GetPrivateProfileString(section, skey, "", result, (uint)result.Capacity, path);
            return result.ToString();
        }
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">项名</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="path">路径</param>
        public static void IniWrite(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }
    }
}

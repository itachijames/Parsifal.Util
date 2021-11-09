using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Parsifal.Util.Windows
{
    /// <summary>
    /// 枚举窗口
    /// </summary>
    /// <param name="hWnd">窗口句柄</param>
    /// <param name="appModule">应用</param>
    /// <returns>继续枚举返回true;停止则返回false</returns>
    // 第二个参数可设为其他任意类型对象(需要加ref);设为IntPtr指针类型则可适用于更多情况
    internal delegate bool EnumWindowsProc(IntPtr hWnd, ref AppModuleInfo appModule);

    internal partial class WindowApi
    {// Windows用户界面接口
        private const string User32Dll = "User32.dll";

        /// <summary>
        /// 枚举窗口
        /// </summary>
        /// <param name="lpEnumFunc">窗口枚举回调</param>
        /// <param name="appModule">应用</param>
        /// <returns></returns>
        [DllImport(User32Dll, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, ref AppModuleInfo appModule);
        /// <summary>
        /// 获取窗口类名
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpClassName">缓存</param>
        /// <param name="nMaxCount">缓存大小</param>
        /// <returns>字符数</returns>
        [DllImport(User32Dll, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        /// <summary>
        /// 获取父窗口
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <returns></returns>
        [DllImport(User32Dll, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);
        /// <summary>
        /// 获取窗口名
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpString">缓存</param>
        /// <param name="nMaxCount">缓存大小</param>
        /// <returns>字符数</returns>
        [DllImport(User32Dll, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        /// <summary>
        /// 获取窗口进程ID
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpdwProcessId">进程ID</param>
        /// <returns>创建窗口的线程ID</returns>
        [DllImport(User32Dll, SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        /// <summary>
        /// 是否为窗口
        /// </summary>
        /// <param name="hWnd">句柄</param>
        /// <returns></returns>
        [DllImport(User32Dll)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);
        /// <summary>
        /// 将创建指定窗口的线程置于前台并激活该窗口
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <returns>成功置于前台返回true;否则false</returns>
        [DllImport(User32Dll)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="nCmdShow">显示命令</param>
        /// <returns>操作成功返回true;否则false</returns>
        [DllImport(User32Dll)]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    }
}

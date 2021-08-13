using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Parsifal.Util.Window
{
#if NET5_0_OR_GREATER
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif
    public class WindowHelper
    {
        /// <summary>
        /// 关机
        /// </summary>
        public static void Shutdown()
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 0")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi);
        }
        /// <summary>
        /// 重启
        /// </summary>
        public static void Restart()
        {
            var psi = new ProcessStartInfo("shutdown", "/r /t 0")
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(psi);
        }
        /// <summary>
        /// 指定程序是否在运行
        /// </summary>
        /// <param name="process">进程名</param>
        /// <param name="pid">进程ID</param>
        /// <returns>如果在运行返回true;否则false</returns>
        /// <remarks>如果进程有多个实例在运行，则<paramref name="pid"/>返回任一进程ID</remarks>
        public static bool IsAppRunning(string process, out int pid)
        {
            pid = 0;
            var ps = Process.GetProcessesByName(process);
            if (ps.Length > 0)
            {
                pid = ps[0].Id;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 展示窗口
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <remarks><paramref name="hWnd"/>为窗口句柄，而非进程句柄</remarks>
        public static void SwitchToWindow(IntPtr hWnd)
        {
            if (WindowApi.IsWindow(hWnd))
            {
                WindowApi.ShowWindowAsync(hWnd, (int)WindowShowType.SW_SHOWMAXIMIZED);
                WindowApi.SetForegroundWindow(hWnd);
            }
        }
        /// <summary>
        /// 用指定类型展现窗口
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="showType">展现类型</param>
        public static void ShowWindow(IntPtr hWnd, WindowShowType showType)
        {
            if (WindowApi.IsWindow(hWnd))
            {
                WindowApi.ShowWindowAsync(hWnd, (int)showType);
            }
        }
        /// <summary>
        /// 查找指定窗口
        /// </summary>
        /// <param name="appModule">应用信息</param>
        /// <param name="hWnd">窗口句柄</param>
        /// <returns>找到指定窗口返回true;否则false</returns>
        public static bool FindWindow(AppModuleInfo appModule, out IntPtr hWnd)
        {
            hWnd = IntPtr.Zero;
            var result = WindowApi.EnumWindows(new EnumWindowsProc(SearthWindowsCallback), ref appModule);
            if (!result)
            {
                if (appModule.WindowHandle != null)
                {
                    hWnd = (IntPtr)appModule.WindowHandle;
                    return true;
                }
            }
            return false;

#if !NETFRAMEWORK
            static
#endif
            bool SearthWindowsCallback(IntPtr win, ref AppModuleInfo module)
            {
                if (WindowApi.GetParent(win) == IntPtr.Zero)
                {//无父窗口，顶级窗口
                    var sb = new StringBuilder(256);
                    if (!string.IsNullOrEmpty(module.ClassName))
                    {//按类名查找
                        if (WindowApi.GetClassName(win, sb, sb.Capacity) > 0)
                        {
                            if (sb.ToString().StartsWith(module.ClassName))
                            {
                                module.WindowHandle = win;
                                return false;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(module.WindowName))
                    {//按窗口名查找
                        if (WindowApi.GetWindowText(win, sb, sb.Capacity) > 0)
                        {
                            if (sb.ToString().StartsWith(module.WindowName))
                            {
                                module.WindowHandle = win;
                                return false;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(module.ProcessName))
                    {//按进程名查找
                        var ids = Process.GetProcessesByName(module.ProcessName).Select(p => p.Id).ToArray();
                        _ = WindowApi.GetWindowThreadProcessId(win, out uint pid);
                        if (ids.Contains((int)pid))
                        {
                            module.WindowHandle = win;
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}

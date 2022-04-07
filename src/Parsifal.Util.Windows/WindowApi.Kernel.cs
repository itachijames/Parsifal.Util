using System.Runtime.InteropServices;

namespace Parsifal.Util.Windows
{
    /// <summary>
    /// WindowApi
    /// </summary>
    internal partial class WindowApi
    {// 内存、IO、中断等系统内核功能接口
        private const string KERNEL_32_DLL = "Kernel32.dll";

        /// <summary>
        /// 标准输入设备
        /// </summary>
        public const int STD_INPUT_HANDLE = -10;

        /// <summary>
        /// 标准输出设备
        /// </summary>
        public const int STD_OUTPUT_HANDLE = -11;

        /// <summary>
        /// 标准错误设备
        /// </summary>
        public const int STD_ERROR_HANDLE = -12;

        /// <summary>
        /// Sets the last-error code for the calling thread.
        /// </summary>
        /// <param name="dwErrorCode">The last-error code for the thread.</param>
        [DllImport(KERNEL_32_DLL, SetLastError = true)]
        public static extern void SetLastError(uint dwErrorCode);

        /// <summary>
        /// Retrieves the calling thread's last-error code value
        /// </summary>
        /// <remarks>You should never PInvoke to GetLastError. Call <see cref="Marshal.GetLastWin32Error"/> instead!</remarks>
        /// <returns>calling thread's last-error code</returns>
        [Obsolete("Call Marshal.GetLastWin32Error instead", true)]
        [DllImport(KERNEL_32_DLL)]
        public static extern uint GetLastError();

        /// <summary>
        /// 获取指定标准设备的句柄
        /// </summary>
        /// <param name="nStdHandle">标准设备</param>
        /// <returns>标准设备句柄</returns>
        [DllImport(KERNEL_32_DLL)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        /// <summary>
        /// 获取控制台[输入缓冲区的当前输入模式或屏幕缓冲区的当前输出模式]
        /// </summary>
        /// <param name="hConsoleHandle">输入缓冲区或屏幕缓冲区的句柄</param>
        /// <param name="lpMOde">当前模式</param>
        /// <returns>成功返回true;否则false</returns>
        [DllImport(KERNEL_32_DLL)]
        public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMOde);

        /// <summary>
        /// 设置控制台[输入缓冲区的输入模式或屏幕缓冲区的输出模式]
        /// </summary>
        /// <param name="hConsoleHandle">输入缓冲区或屏幕缓冲区的句柄</param>
        /// <param name="dwMode">要设置的输入或输出模式</param>
        /// <returns>成功返回true;否则false</returns>
        [DllImport(KERNEL_32_DLL)]
        public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
    }

    [Flags]
    internal enum ConsoleInputModes : uint
    {
        ENABLE_PROCESSED_INPUT = 0x0001,
        ENABLE_LINE_INPUT = 0x0002,
        ENABLE_ECHO_INPUT = 0x0004,
        ENABLE_WINDOW_INPUT = 0x0008,
        ENABLE_MOUSE_INPUT = 0x0010,
        ENABLE_INSERT_MODE = 0x0020,
        ENABLE_QUICK_EDIT_MODE = 0x0040,
        ENABLE_EXTENDED_FLAGS = 0x0080,
        ENABLE_AUTO_POSITION = 0x0100
    }

    [Flags]
    internal enum ConsoleOutputModes : uint
    {
        ENABLE_PROCESSED_OUTPUT = 0x0001,
        ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002,
        ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004,
        DISABLE_NEWLINE_AUTO_RETURN = 0x0008,
        ENABLE_LVB_GRID_WORLDWIDE = 0x0010
    }
}
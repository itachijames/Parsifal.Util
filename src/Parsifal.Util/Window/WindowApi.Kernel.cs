using System;
using System.Runtime.InteropServices;

namespace Parsifal.Util.Window
{
    /// <summary>
    /// WindowApi
    /// </summary>
    internal partial class WindowApi
    {// 内存、IO、中断等系统内核功能接口
        private const string Kernel32Dll = "Kernel32.dll";

        /// <summary>
        /// Sets the last-error code for the calling thread.
        /// </summary>
        /// <param name="dwErrorCode">The last-error code for the thread.</param>
        [DllImport(Kernel32Dll, SetLastError = true)]
        public static extern void SetLastError(uint dwErrorCode);
        /// <summary>
        /// Retrieves the calling thread's last-error code value
        /// </summary>
        /// <remarks>You should never PInvoke to GetLastError. Call <see cref="Marshal.GetLastWin32Error"/> instead!</remarks>
        /// <returns>calling thread's last-error code</returns>
        [Obsolete("Call Marshal.GetLastWin32Error instead", true)]
        [DllImport(Kernel32Dll)]
        public static extern uint GetLastError();
    }
}

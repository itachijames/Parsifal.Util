namespace Parsifal.Util.Windows
{
    public class AppModuleInfo
    {
        /// <summary>
        /// 进程名
        /// </summary>
        public string ProcessName { get; set; }
        /// <summary>
        /// 窗口名
        /// </summary>
        public string WindowName { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 应用路径
        /// </summary>
        public string AppPath { get; set; }
        /// <summary>
        /// 进程ID
        /// </summary>
        public uint? ProcessID { get; set; }
        /// <summary>
        /// 窗口句柄
        /// </summary>
        public IntPtr? WindowHandle { get; set; }
    }
}
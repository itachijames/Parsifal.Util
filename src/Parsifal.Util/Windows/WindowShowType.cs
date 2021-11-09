namespace Parsifal.Util.Windows
{
    /// <summary>
    /// window窗口展现类型
    /// </summary>
    public enum WindowShowType
    {
        /// <summary>
        /// 隐藏窗口
        /// </summary>
        SW_HIDE = 0,
        /// <summary>
        /// 激活并显示指定窗口，如果该窗口被最大化或最小化，将还原其原本的大小和位置
        /// </summary>
        SW_SHOWNORMAL = 1,
        /// <summary>
        /// 激活并最小化指定窗口
        /// </summary>
        SW_SHOWMINIMIZED = 2,
        /// <summary>
        /// 激活并最大化指定窗口
        /// </summary>
        SW_SHOWMAXIMIZED = 3,
        /// <summary>
        /// 以其最近的大小和位置显示指定窗口，当前窗口保持激活
        /// </summary>
        SW_SHOWNOACTIVATE = 4,
        /// <summary>
        /// 以当前位置和大小激活窗口
        /// </summary>
        SW_SHOW = 5,
        /// <summary>
        /// 将指定的窗口最小化
        /// </summary>
        SW_MINIMIZE = 6,
        /// <summary>
        /// 窗口最小化，激活窗口仍然维持激活状态
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,
        /// <summary>
        /// 以窗口原来的状态显示窗口，激活窗口仍然维持激活状态
        /// </summary>
        SW_SHOWNA = 8,
        /// <summary>
        /// 还原指定的窗口
        /// </summary>
        SW_RESTORE = 9,
        /// <summary>
        /// 以传递到createprocess函数中的startupinfo记录中指定的sw_flag方式显示窗口
        /// </summary>
        SW_SHOWDEFAULT = 10,
        /// <summary>
        /// 强制最小化
        /// </summary>
        SW_FORCEMINIMIZE = 11
    }
}

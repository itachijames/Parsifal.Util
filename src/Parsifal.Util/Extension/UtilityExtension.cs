using System;
using System.Linq;
using System.Text;

namespace Parsifal.Util
{
    public static class UtilityExtension
    {
        /// <summary>
        /// 字节数值比较
        /// </summary>
        public static bool IsEqual(this byte[] first, byte[] second)
        {
            if (first == null || second == null)
                return false;
            return first.SequenceEqual(second);
        }
        /// <summary>
        /// 获取简要信息
        /// </summary>
        /// <param name="exception">异常</param>
        /// <returns></returns>
        public static string GetBriefMessage(this Exception exception)
        {
            var sb = new StringBuilder();
            if (exception != null)
            {
                sb.Append(exception.Message);
                if (exception.InnerException != null)
                {
                    sb.Append($": {GetBriefMessage(exception.InnerException)}");
                }
            }
            return sb.ToString();
        }
    }
}

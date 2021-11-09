using System;
using System.Linq;
using System.Text;

namespace Parsifal.Util
{
    public static class UtilityExtension
    {
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
        /// <summary>
        /// 字节数组转Hex字符串
        /// </summary>
        /// <param name="source">待转换字节数组</param>
        /// <param name="uppercase">是否大写,默认true</param>
        /// <returns>Hex字符串</returns>
#if NET6_0_OR_GREATER
        [Obsolete("Use Convert.ToHexString instead", false)]
#endif
        public static string BytesToHexString(this byte[] source, bool uppercase = true)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
            {
                sb.Append(source[i].ToString(uppercase ? "X2" : "x2"));
            }
            return sb.ToString();
        }
        /// <summary>
        /// 字符串转换Hex字符串
        /// </summary>
        /// <param name="source">原始字符串</param>
        /// <param name="uppercase">是否大写</param>
        /// <returns>Hex字符串</returns>
        public static string StringToHexString(this string source, bool uppercase = true)
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(source))
            {
                for (int i = 0; i < source.Length; i++)
                {
                    sb.Append(Convert.ToInt32(source[i]).ToString(uppercase ? "X2" : "x2"));
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Hex字符串转字节数组
        /// </summary>
        /// <param name="hexString">Hex字符串</param>
        /// <returns>对应字节数组</returns>
        /// <exception cref="ArgumentException">字符串为空或长度为奇数</exception>
        /// <exception cref="FormatException">字符串含非十六进制字符</exception>
#if NET6_0_OR_GREATER
        [Obsolete("Use Convert.FromHexString instead", false)]
#endif
        public static byte[] HexStringToBytes(this string hexString)
        {
            if (string.IsNullOrEmpty(hexString) || (hexString.Length & 1) == 1)
                throw new ArgumentException("源字符串长度异常", nameof(hexString));
            if (hexString.Any(x => !Uri.IsHexDigit(x)))
                throw new FormatException("源字符串中含非法字符");
            var returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return returnBytes;
        }
        /// <summary>
        /// Hex字符串转字符串
        /// </summary>
        /// <param name="hexString">Hex字符串</param>
        /// <returns>字符串</returns>
        /// <exception cref="ArgumentException">字符串为空或长度为奇数</exception>
        /// <exception cref="FormatException">字符串含非十六进制字符</exception>
        public static string HexStringToString(this string hexString)
        {
            if (string.IsNullOrEmpty(hexString) || (hexString.Length & 1) == 1)
                throw new ArgumentException("字符串长度异常", nameof(hexString));
            if (hexString.Any(x => !Uri.IsHexDigit(x)))
                throw new FormatException("字符串中含非法字符");
            var sb = new StringBuilder();
            for (int i = 0; i < hexString.Length / 2; i++)
            {
                sb.Append(Convert.ToChar(Convert.ToUInt32(hexString.Substring(i * 2, 2), 16)));
            }
            return sb.ToString();
        }
    }
}

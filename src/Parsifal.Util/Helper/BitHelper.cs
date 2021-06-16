using System;

namespace Parsifal.Util
{
    public class BitHelper
    {
        /// <summary>
        /// 获取整数指定位（二进制时）的值
        /// </summary>
        /// <param name="value">待判定数</param>
        /// <param name="index">（从右向左，从0起）位索引</param>
        /// <returns>指定位为1时返回true,为0返回false</returns>
        /// <exception cref="ArgumentOutOfRangeException">位数索引<paramref name="index"/>越界</exception>
        public static bool GetIntBitValue(int value, ushort index)
        {
            if (index > 31)
                throw new ArgumentOutOfRangeException(nameof(index));
            return ((value >> index) & 1) == 1;
        }
        /// <summary>
        /// 获取字节指定位（二进制时）的值
        /// </summary>
        /// <param name="value">待判定值</param>
        /// <param name="index">（从右向左，从0起）位索引</param>
        /// <returns>指定位为1时返回true,为0返回false</returns>
        /// <exception cref="ArgumentOutOfRangeException">位数索引<paramref name="index"/>越界</exception>
        public static bool GetByteBitValue(byte value, ushort index)
        {
            if (index > 7)
                throw new ArgumentOutOfRangeException(nameof(index));
            return (value & (1 << index)) > 0;
        }
    }
}

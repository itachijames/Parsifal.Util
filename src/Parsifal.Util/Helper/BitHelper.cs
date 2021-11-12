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
        /// <summary>
        /// 获取字节从0起连续位的值
        /// </summary>
        /// <param name="value">原字节</param>
        /// <param name="index">（从右向左，从0起）位索引</param>
        /// <returns></returns>
        public static byte GetByteValue(byte value, ushort index)
        {
            return GetByteValue(value, 0, index);
        }
        /// <summary>
        /// 获取字节连续位的值
        /// </summary>
        /// <param name="value">原字节</param>
        /// <param name="startIndex">开始索引</param>
        /// <param name="endIndex">结束索引</param>
        /// <returns>所有指定位组成的新的字节</returns>
        public static byte GetByteValue(byte value, ushort startIndex, ushort endIndex)
        {
            const ushort byteMaxIndex = 7;
            if (endIndex < startIndex)
                throw new ArgumentException("结束索引不能小于开始索引");
            if (startIndex > byteMaxIndex || endIndex > byteMaxIndex)
                throw new ArgumentOutOfRangeException("索引值异常");
            var m1 = byteMaxIndex - endIndex;
            byte temp = (byte)(value << m1);
            return (byte)(temp >> (m1 + startIndex));
        }
    }
}

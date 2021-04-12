using System;

namespace Parsifal.Util.CRC
{
    public abstract class CrcBase : ICrc
    {
        public abstract CrcArgument Argument { get; }
        /// <summary>
        /// 获取CRC值
        /// </summary>
        /// <remarks>无需校验参数</remarks>
        protected abstract ulong GetCrcValue(byte[] data, int offset, int length);

        #region ICrc
#if NETSTANDARD2_0
        public byte[] GetCrc(byte[] data)
        {
            return GetCrc(data, 0);
        }
        public byte[] GetCrc(byte[] data, int offset)
        {
            return GetCrc(data, offset, data.Length - offset);
        }
#endif
        public byte[] GetCrc(byte[] data, int offset, int length)
        {
            CheckArgument(data, offset, length);
            var value = GetCrcValue(data, offset, length);
            return GetBytes(value, Argument.Width);
        }
        #endregion

        private static void CheckArgument(byte[] data, int offset, int length)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (data.Length == 0)
                throw new ArgumentException("Data length is 0", nameof(data));
            if (offset < 0 || offset >= data.Length)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (length <= 0 || offset + length > data.Length)
                throw new ArgumentOutOfRangeException(nameof(length));
        }
        private static byte[] GetBytes(ulong value, int width)
        {
            int count = (width - 1) / 8 + 1;//结果字节数
            //var result = BitConverter.GetBytes(value);
            //return result[0..^(8 - count)];
            value &= ((ulong.MaxValue) >> (64 - width));
            var result = new byte[count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)value;
                value >>= 8;
            }
            return result;
        }
    }
}

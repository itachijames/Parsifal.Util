using System;

namespace Parsifal.Util.CRC
{
    public abstract class CrcBase : ICrc
    {
        public abstract CrcArgument Argument { get; }
        /// <summary>计算CRC</summary>
        /// <remarks>无需校验参数</remarks>
        protected abstract ulong CalculateCrc(byte[] data, int offset, int length, ulong initial = 0);

        #region ICrc
        public ulong GetCrcValue(byte[] data)
        {
            return GetCrcValue(data, 0);
        }
        public ulong GetCrcValue(byte[] data, int offset)
        {
            return GetCrcValue(data, offset, data.Length - offset);
        }
        public ulong GetCrcValue(byte[] data, int offset, int length)
        {
            CheckArgument(data, offset, length);
            var value = CalculateCrc(data, offset, length);
            return value & GetMask(Argument.Width);//将高位无意义值屏蔽
        }
        public byte[] GetCrcBytes(byte[] data)
        {
            return GetCrcBytes(data, 0);
        }
        public byte[] GetCrcBytes(byte[] data, int offset)
        {
            return GetCrcBytes(data, offset, data.Length - offset);
        }
        public byte[] GetCrcBytes(byte[] data, int offset, int length)
        {
            CheckArgument(data, offset, length);
            var value = CalculateCrc(data, offset, length);
            return GetBytes(value, Argument.Width);
        }
        public ulong Append(ulong initial, byte[] data)
        {
            return Append(initial, data, 0);
        }
        public ulong Append(ulong initial, byte[] data, int offset)
        {
            return Append(initial, data, offset, data.Length - offset);
        }
        public ulong Append(ulong initial, byte[] data, int offset, int length)
        {
            CheckArgument(data, offset, length);
            var value = CalculateCrc(data, offset, length, initial);
            return value & GetMask(Argument.Width);
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
            value &= GetMask(width);
            var result = new byte[count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)value;
                value >>= 8;
            }
            return result;
        }
        private static ulong GetMask(int width)
        {
            return ulong.MaxValue >> (64 - width);
        }
    }
}

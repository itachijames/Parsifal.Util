using System;

namespace Parsifal.Util.CRC
{
    /// <summary>
    /// CRC
    /// </summary>
    public interface ICrc
    {
        /// <summary>
        /// CRC参数
        /// </summary>
        CrcArgument Argument { get; }
        /// <summary>
        /// 计算数据CRC值
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        byte[] GetCrc(byte[] data)
#if !NETSTANDARD2_0
            => GetCrc(data, 0)
#endif
            ;
        //#endif
        /// <summary>
        /// 计算数据CRC值
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移量</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/>超出范围</exception>
#if NETSTANDARD2_0
        byte[] GetCrc(byte[] data, int offset);
#else
        byte[] GetCrc(byte[] data, int offset) => GetCrc(data, offset, data.Length - offset);
#endif
        /// <summary>
        /// 计算数据CRC值
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移量</param>
        /// <param name="length">长度</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/>或<paramref name="length"/>超出范围</exception>
        byte[] GetCrc(byte[] data, int offset, int length);
    }
}

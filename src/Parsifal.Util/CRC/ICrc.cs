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
        ulong GetCrcValue(byte[] data);
        /// <summary>
        /// 计算数据CRC值
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移量</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/>超出范围</exception>
        ulong GetCrcValue(byte[] data, int offset);
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
        ulong GetCrcValue(byte[] data, int offset, int length);
        /// <summary>
        /// 计算数据CRC字节数组
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        byte[] GetCrcBytes(byte[] data);
        /// <summary>
        /// 计算数据CRC字节数组
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移量</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/>超出范围</exception>
        byte[] GetCrcBytes(byte[] data, int offset);
        /// <summary>
        /// 计算数据CRC字节数组
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移量</param>
        /// <param name="length">长度</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/>或<paramref name="length"/>超出范围</exception>
        byte[] GetCrcBytes(byte[] data, int offset, int length);
        /// <summary>
        /// 追加计算数据CRC值
        /// </summary>
        /// <param name="initial">初始值</param>
        /// <param name="data">数据</param>
        /// <returns>CRC检验值</returns>
        ulong Append(ulong initial, byte[] data);
        /// <summary>
        /// 追加计算数据CRC值
        /// </summary>
        /// <param name="initial">初始值</param>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移量</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/>超出范围</exception>
        ulong Append(ulong initial, byte[] data, int offset);
        /// <summary>
        /// 追加计算数据CRC值
        /// </summary>
        /// <param name="initial">初始值</param>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移量</param>
        /// <param name="length">长度</param>
        /// <returns>CRC检验值</returns>
        /// <exception cref="ArgumentNullException"><paramref name="data"/>为空</exception>
        /// <exception cref="ArgumentException"><paramref name="data"/>长度为0</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/>或<paramref name="length"/>超出范围</exception>
        ulong Append(ulong initial, byte[] data, int offset, int length);
    }
}

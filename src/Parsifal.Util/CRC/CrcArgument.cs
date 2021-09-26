using System;
using System.Text;

namespace Parsifal.Util.CRC
{
    /// <summary>
    /// CRC参数
    /// </summary>
    public class CrcArgument
    {
        /// <summary>
        /// 算法位宽
        /// </summary>
        /// <remarks>CRC比特数</remarks>
        public int Width { get; }
        /// <summary>
        /// 多项式
        /// </summary>
        /// <remarks>一般为十六进制表示,且忽略最高位的1</remarks>
        public ulong Polynomial { get; }
        /// <summary>
        /// 初始值
        /// </summary>
        /// <remarks>算法初始化预置值</remarks>
        public ulong InitValue { get; }
        /// <summary>
        /// 输入反转
        /// </summary>
        /// <remarks>待测数据的每个字节是否按位反转</remarks>
        public bool ReflectIn { get; }
        /// <summary>
        /// 输出反转
        /// </summary>
        /// <remarks>计算之后、异或输出之前，整个数据是否按位反转</remarks>
        public bool ReflectOut { get; }
        /// <summary>
        /// 结果异或值
        /// </summary>
        /// <remarks>计算结果与此参数异或后得到最终的CRC值</remarks>
        public ulong XorValue { get; }

        /// <summary>创建指定值的CRC参数</summary>
        /// <param name="width">位宽</param>
        /// <param name="polynomial">多项式</param>
        /// <param name="initial">初值</param>
        /// <param name="isInputReflected">输入是否反转</param>
        /// <param name="isOutputReflected">输出是否反转</param>
        /// <param name="outputXor">输出异或值</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="width"/>为负</exception>
        public CrcArgument(int width, ulong polynomial, ulong initial, bool isInputReflected, bool isOutputReflected, ulong outputXor)
        {
            if (width <= 0 || width > 64)
                throw new ArgumentOutOfRangeException(nameof(width), width, "Only support under 64 bit!");
            Width = width;
            Polynomial = polynomial;
            InitValue = initial;
            ReflectIn = isInputReflected;
            ReflectOut = isOutputReflected;
            XorValue = outputXor;
        }

        public override string ToString()
        {
            var expression = new StringBuilder($"x{Width}");
            for (int i = Width - 1; i > 0; i--)
            {
                if (IsBitOne(Polynomial, i))
                {
                    expression.Append($" + x{i}");
                }
            }
            expression.Append(" + 1");
            return expression.ToString();

#if !NETFRAMEWORK
            static
#endif
            bool IsBitOne(ulong value, int index)
            {//二进制时指定位是否为1
                return ((value >> index) & 1) == 1;
            }
        }
    }
}

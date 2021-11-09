using System;
using System.Reflection;

namespace Parsifal.Util.CRC
{
    public class CrcFactory
    {
        /*
         * 通过基准测试，发现当前具体实现算法的效率在某些时候反而不如通用算法，其原因在于每次迭代时都会将结果进行强制转换格式（如ushort），造成性能浪费
         * 对于百万级的数据，两种实现均能控制在2ms以下（与具体机器性能有关），此处其实无所谓做所谓最佳的抉择
         * 
         * BenchmarkDotNet = v0.13.1, OS = Windows 10.0.19041.388 (2004/May2020Update/20H1)
         * Intel Core i7 - 7700K CPU 4.20GHz(Kaby Lake), 1 CPU, 8 logical and 4 physical cores
         * .NET SDK = 6.0.100
         * [Host]     : .NET 6.0.0(6.0.21.52210), X64 RyuJIT
         * DefaultJob: .NET 6.0.0(6.0.21.52210), X64 RyuJIT
         * 
         * | Method | length | type | Mean | Error | StdDev | Allocated |
         * | ----------------------------- | -------- | ------------- | -------------:| ----------:| ----------:| ----------:|
         * | CalcCrcWithSpecificAlgorithm | 1000 | CRC_16_CCITT | 2.213 μs | 0.0049 μs | 0.0044 μs | - |
         * | CalcCrcWithGeneralAlgotithm | 1000 | CRC_16_CCITT | 1.806 μs | 0.0146 μs | 0.0137 μs | - |
         * | CalcCrcWithSpecificAlgorithm | 1000 | CRC_32 | 1.979 μs | 0.0042 μs | 0.0037 μs | - |
         * | CalcCrcWithGeneralAlgotithm | 1000 | CRC_32 | 1.803 μs | 0.0150 μs | 0.0140 μs | - |
         * | CalcCrcWithSpecificAlgorithm | 1000 | CRC_64_JONES | 1.978 μs | 0.0027 μs | 0.0025 μs | - |
         * | CalcCrcWithGeneralAlgotithm | 1000 | CRC_64_JONES | 1.807 μs | 0.0150 μs | 0.0140 μs | - |
         * | CalcCrcWithSpecificAlgorithm | 1000000 | CRC_16_CCITT | 2,215.317 μs | 4.6947 μs | 4.3914 μs | 2 B |
         * | CalcCrcWithGeneralAlgotithm | 1000000 | CRC_16_CCITT | 1,786.238 μs | 8.5234 μs | 7.1174 μs | 1 B |
         * | CalcCrcWithSpecificAlgorithm | 1000000 | CRC_32 | 1,977.204 μs | 2.2261 μs | 1.7380 μs | 2 B |
         * | CalcCrcWithGeneralAlgotithm | 1000000 | CRC_32 | 1,786.693 μs | 4.1578 μs | 3.8892 μs | 1 B |
         * | CalcCrcWithSpecificAlgorithm | 1000000 | CRC_64_JONES | 1,980.612 μs | 6.9945 μs | 6.5427 μs | 2 B |
         * | CalcCrcWithGeneralAlgotithm | 1000000 | CRC_64_JONES | 1,788.823 μs | 5.0010 μs | 4.1760 μs | 1 B |
         */

        /// <summary>
        /// 获取指定类型的CRC算法
        /// </summary>
        /// <param name="type">crc类型</param>
        /// <exception cref="NotSupportedException">未实现的算法或内部错误</exception>
        public static ICrc GetCrc(CrcAlgorithmType type)
        {//对部分有具体计算方法的算法类型直接使用其实现，其他则采用通用算法
            if (type != CrcAlgorithmType.None)
            {
                const string SpecifiedNamaspace = "Parsifal.Util.CRC.Algorithm";
                var name = Enum.GetName(typeof(CrcAlgorithmType), type);
                var instance = Assembly.GetExecutingAssembly().CreateInstance($"{SpecifiedNamaspace}.{name}");
                if (instance != null)
                {
                    return (ICrc)instance;
                }
                else
                {
                    var field = typeof(CrcStandardParam).GetField(name, BindingFlags.Public | BindingFlags.Static);
                    if (field != null)
                    {
                        var argument = (CrcArgument)field.GetValue(typeof(CrcArgument));
                        return new GeneralCRC(argument);
                    }
                }
            }
            throw new NotSupportedException();
        }
        /// <summary>
        /// 获取指定参数对应的CRC算法
        /// </summary>
        /// <param name="argument">crc参数</param>
        public static ICrc GetCrc(CrcArgument argument)
        {
            return new GeneralCRC(argument);
        }
    }
}

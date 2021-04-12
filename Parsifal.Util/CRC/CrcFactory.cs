using System;
using System.Reflection;

namespace Parsifal.Util.CRC
{
    public class CrcFactory
    {
        /// <summary>
        /// 获取指定类型的CRC算法
        /// </summary>
        /// <param name="type">crc类型</param>
        /// <exception cref="NotSupportedException">未实现的算法或内部错误</exception>
        public static ICrc Get(CrcAlgorithmType type)
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
        public static ICrc Get(CrcArgument argument)
        {
            return new GeneralCRC(argument);
        }
    }
}

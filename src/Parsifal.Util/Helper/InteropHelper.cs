using System;
using System.Runtime.InteropServices;

namespace Parsifal.Util
{
    /// <summary>
    /// 互操作辅助
    /// </summary>
    public class InteropHelper
    {
        /// <summary>
        /// byte数组转换成其对应结构体
        /// </summary>
        /// <typeparam name="T">结构体</typeparam>
        /// <param name="datas">待转换字节数组</param>
        /// <returns></returns>
        public static T ByteArrayToStruct<T>(byte[] datas)
            where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            if (size > datas.Length)
                return default;
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(datas, 0, structPtr, size);
#if NETFRAMEWORK
                return (T)Marshal.PtrToStructure(structPtr, typeof(T));
#else
                return Marshal.PtrToStructure<T>(structPtr);
#endif
            }
            finally
            {
                Marshal.FreeHGlobal(structPtr);
            }
        }
        /// <summary>
        /// 非托管指针指向数据提取
        /// </summary>
        /// <typeparam name="T">结构体</typeparam>
        /// <param name="p">数据指针</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public static T[] MarshalPtrToStructs<T>(IntPtr p, int count)
            where T : struct
        {
            var result = new T[count];
            try
            {
                int size = Marshal.SizeOf(typeof(T));
                IntPtr tempPtr;
                for (int i = 0; i < count; i++)
                {
                    tempPtr = new IntPtr(p.ToInt64()) + size * i;
                    //tempPtr = new IntPtr(p.ToInt64() + size * i);
#if NETFRAMEWORK
                    result[i] = (T)Marshal.PtrToStructure(tempPtr, typeof(T));
#else
                    result[i] = Marshal.PtrToStructure<T>(tempPtr);
#endif
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parsifal.Util
{
    public static class LinqExtension
    {
        /// <summary>
        /// 判断两个集合是否相同(具有相同元素,不论顺序)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>相同时返回true,否则false</returns>
        /// <exception cref="ArgumentNullException">参数为空</exception>
        public static bool IsEquivalent<T>(this IEnumerable<T> first, IEnumerable<T> second)
            where T : IEquatable<T>
        {
            if (ReferenceEquals(first, second))
                return true;
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return first.Count() == second.Count()
                && !first.Except(second).Any();
        }
        /// <summary>
        /// 集合内容转字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string CollectionToString<T>(this IEnumerable<T> input, char separator = ',')
        {
            if (input == null)
                return string.Empty;
            var sb = new StringBuilder();
            foreach (var item in input)
            {
                sb.Append(item).Append(separator);
            }
            sb = sb.Remove(sb.Length - 1, 1);//移除最后一个分隔
            return sb.ToString();
        }
    }
}
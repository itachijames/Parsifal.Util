using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Parsifal.Util
{
    public static class EnumExtension
    {
        /// <summary>
        /// 获取所有项
        /// </summary>
        public static IEnumerable<T> GetAllItems<T>() where T : struct, Enum
        {
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                yield return (T)item;
            }
        }
        /// <summary>
        /// 获取枚举Description属性值
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nameInstend">没有Description属性时是否用枚举名代替</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value, bool nameInstend = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
                return null;
            var attribute = Attribute.GetCustomAttribute(type.GetField(name), typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute == null && nameInstend == true)
                return name;
            return attribute?.Description;
        }
    }
}

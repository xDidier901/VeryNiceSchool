using Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data.Utilities
{
    public static class EnumUtils
    {
        /// <summary>
        /// Gets the description attribute of an enum element.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum element)
        {
            Type type = element.GetType();
            MemberInfo[] memberInfo = type.GetMember(element.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] atributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (atributes != null && atributes.Length > 0)
                {
                    return ((DescriptionAttribute)atributes[0]).Description;
                }
            }
            return element.ToString();
        }

        /// <summary>
        /// Transforms an enum into an array of Select2itemDTO type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Select2ItemDTO[] ToSelectItems<T>() where T : IConvertible
        {
            try
            {
                var results = Enum.GetValues(typeof(T)).Cast<T>().ToList().Select(x => new Select2ItemDTO
                {
                    text = Regex.Replace(x.ToString(), "([a-z])([A-Z])", "$1 $2"),
                    id = x.GetHashCode()
                }).ToArray();

                return results;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

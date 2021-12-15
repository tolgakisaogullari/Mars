using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Mars.Common
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets display name of the enum
        /// </summary>
        public static string GetDisplayName(this Enum enumValue)
        {
            MemberInfo member = enumValue.GetType().GetMember(enumValue.ToString())?.FirstOrDefault();

            var attribute = member?.GetCustomAttribute<DisplayAttribute>();

            if (member == null || attribute == null)
            {
                return enumValue.ToString();
            }

            return attribute.Name;
        }
    }
}
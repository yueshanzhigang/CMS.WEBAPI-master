using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Common
{
    public static class EnumExtension
    {
        public static string EnumToJson(this Type type)
        {
            if (!type.IsEnum)
                throw new InvalidOperationException("enum expected");

            var results =
                System.Enum.GetValues(type).Cast<object>()
                    .ToDictionary(enumValue => enumValue.ToString(), enumValue => (int)enumValue);
            return string.Format("{{ \"{0}\" : {1} }}", type.Name, Newtonsoft.Json.JsonConvert.SerializeObject(results));
        }
    }
}

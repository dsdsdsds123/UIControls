using ExSimpleIoc.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Extensions
{
    public static class AliasMaskExtensions
    {
        public static string GetPropertyInfoAliasMark(this PropertyInfo Property)
        {
            return Property.IsDefined(typeof(AliasAttribute), true) ? Property.GetCustomAttribute<AliasAttribute>().Alias : "";
        }

        public static string GetFieldInfoAliasMark(this FieldInfo field)
        {
            return field.IsDefined(typeof(AliasAttribute), true) ? field.GetCustomAttribute<AliasAttribute>().Alias : "";
        }

        public static string GetParameterInfoAliasMark(this ParameterInfo parameter)
        {
            return parameter.IsDefined(typeof(AliasAttribute), true) ? parameter.GetCustomAttribute<AliasAttribute>().Alias : "";
        }

    }
}

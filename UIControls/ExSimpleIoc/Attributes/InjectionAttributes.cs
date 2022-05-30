using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInjectionAttribute : Attribute { }


    [AttributeUsage(AttributeTargets.Field)]
    public class FieldInjectionAttribute : Attribute { }


    [AttributeUsage(AttributeTargets.Method)]
    public class MethodInjectionAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Constructor)]
    public class PreferAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class ConstantParameterAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    public class AliasAttribute : Attribute
    {
        public AliasAttribute() { }
        public AliasAttribute(string alias)
        {
            Alias = alias;
        }
        public string Alias { get; set; }
    }
}
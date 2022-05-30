using ExSimpleIoc.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Extensions
{
    internal static class ObjectExtensions
    {
        public static void DoPropertyInjection(this object instance, Func<Type, string, object> factory)
        {
            var properties = instance.GetType().GetProperties().Where(p => p.IsDefined(typeof(PropertyInjectionAttribute), true));
            foreach (var property in properties)
            {
                property.SetValue(instance, factory.Invoke(property.PropertyType, property.GetPropertyInfoAliasMark()));
            }
        }

        public static void DoFieldInjection(this object instance, Func<Type, string, object> factory)
        {
            var Fields = instance.GetType().GetFields().Where(f => f.IsDefined(typeof(FieldInjectionAttribute), true));
            foreach (var field in Fields)
            {
                field.SetValue(instance, factory.Invoke(field.FieldType, field.GetFieldInfoAliasMark()));
            }
        }


        public static void DoMethodInjection(this object instance, Func<Type, string, object> factory)
        {
            var methods = instance.GetType().GetMethods().Where(m => m.IsDefined(typeof(MethodInjectionAttribute), true)).ToArray();
            foreach (var method in methods)
            {
                List<object> methodParameters = new List<object>();
                foreach (var para in method.GetParameters())
                {
                    methodParameters.Add(factory(para.ParameterType, para.GetParameterInfoAliasMark()));
                }
                method.Invoke(instance, methodParameters.ToArray());
            }
        }


        public static void DoInjection(this object instance, Func<Type, string, object> factory)
        {
            instance.DoPropertyInjection(factory);
            instance.DoFieldInjection(factory);
            instance.DoMethodInjection(factory);
        }
    }
}

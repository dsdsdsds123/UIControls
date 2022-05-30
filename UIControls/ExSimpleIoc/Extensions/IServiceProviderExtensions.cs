using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Extensions
{
    public static class IServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider provider, string key = "")
        {
            return (T)provider.GetType().GetMethod("GetService", new Type[] { typeof(string) }).MakeGenericMethod(typeof(T)).Invoke(provider, new object[] { key });
        }

        public static T GetService<T>(this IServiceProvider provider)
        {
            return provider.GetService<T>("");
        }
    }
}

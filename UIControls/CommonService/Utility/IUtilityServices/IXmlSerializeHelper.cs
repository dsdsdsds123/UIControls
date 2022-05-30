using CommonServices.Utility.UtilityServices;
using ExSimpleIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonServices.Utility.IUtilityServices
{
    public interface IXmlSerializeHelper
    {
        bool XmlSerialize<T>(T obj, string xmlPath);

        T XmlDeSerialize<T>(string xmlPath) where T : class;
    }


    public static class XmlSerializeHelperExtensions
    {
        public static IServiceCollection AddXmlSerializeHelper(this IServiceCollection services)
        {
            services.AddTransient<IXmlSerializeHelper, XmlSerializeHelper>();
            return services;
        }
    }
}

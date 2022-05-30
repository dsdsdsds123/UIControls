using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc
{
    //这hot-fix分支下的代码
    public class IServiceProviderImpl : IServiceProvider
    {
        private IServiceCollection _Services;
        public IServiceProviderImpl(IServiceCollection services)
        {
            _Services = services;
        }
        public object GetService(Type serviceType)
        {
            return _Services.GetService(serviceType);
        }

        public T GetService<T>(string key = "")
        {
            return _Services.GetService<T>(key);
        }
    }
}

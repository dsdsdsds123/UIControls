using ExSimpleIoc;
using ExSimpleIoc.AppServices;
using ExSimpleIoc.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonServices.Log
{
    public static class ILogServiceExtensions
    {
        public static IServiceCollection AddCommonLog(this IServiceCollection services, Action<LogOption> option = null)
        {
            LogOption config = new LogOption();
            option?.Invoke(config);
            services.AddSingleton(typeof(LogOption), config);
            services.Replace<ILogService, CommonLogService>();
            return services;
        }

        public static IServiceCollection AddCommonLog(this IServiceCollection services)
        {
            return services.AddCommonLog(null);
        }


        public static IApplicationBuilder UseCommonLog(this IApplicationBuilder app)
        {
            return app;
        }
    }
}

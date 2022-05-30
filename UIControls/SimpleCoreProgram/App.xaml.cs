using CommonServices.Log;
using CommonServices.Utility.IUtilityServices;
using ExSimpleIoc;
using ExSimpleIoc.AppServices;
using SimpleCoreProgram.Middlewares;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleCoreProgram
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : ApplicationBase
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddConsoleControl();
            services.AddFileHelper();
            services.AddUtils();
            services.AddImageHelper();
            services.AddXmlSerializeHelper();
            services.AddCommonLog(o=> 
            {
                o.ShowConsole = true;
                o.WriteFile = false;
            });
        }

        protected override void Configure(IApplicationBuilder app)
        {
            base.Configure(app);
            app.UseTick();
        }
    }
}

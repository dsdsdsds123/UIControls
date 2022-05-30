using ExSimpleIoc.Extensions;
using ExSimpleIoc.IServices;
using ExSimpleIoc.Middlewares;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ExSimpleIoc.AppServices
{
    public abstract class ApplicationBase : Application
    {
        private IServiceCollection _IServiceCollection = new ServiceCollection();
        public IServiceProvider _Services { get; set; }



        public ApplicationBase()
        {
            ConfigureServiceCollection();
        }


        private void ConfigureServiceCollection()
        {
            ConfigureDefaultService(_IServiceCollection);

            ConfigureServices(_IServiceCollection);

            _Services = _IServiceCollection.BuildServiceProvider();
        }


        private void ConfigureDefaultService(IServiceCollection services)
        {
            services.AddSingleton<IApplicationBuilder, ApplicationBuilder>();
            services.AddSingleton<Application>(this);
            services.AddSingleton<ILogService, DefaultLogService>();
            services.AddSingleton<Dispatcher>(Current.Dispatcher);
        }




        protected override void OnStartup(StartupEventArgs e)
        {

            Configure(_Services.GetService<IApplicationBuilder>());

            ILogService _LogService = _Services.GetService<ILogService>();
            _LogService?.Info("**************************************************************************");
            _LogService?.Info($"SYSTEM:{Process.GetCurrentProcess().ProcessName},Version:{GetVersionInfo()} START NOW:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
            _LogService?.Info("**************************************************************************");
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            ILogService _LogService = _Services.GetService<ILogService>();
            try
            {
                _LogService?.Info("**************************************************************************");
                _LogService?.Info($"SYSTEM:{Process.GetCurrentProcess().ProcessName},Version:{GetVersionInfo()} EXIT NOW:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}");
                _LogService?.Info("**************************************************************************");
            }
            catch (Exception ex)
            {
                _LogService?.Error($"Exception occurred while system exit,exception message:{ex.Message}");
            }
            finally
            {
                base.OnExit(e);
            }
        }

        /// <summary>
        /// 配置服务对应关系
        /// </summary>
        /// <param name="serviceCollection"></param>
        protected virtual void ConfigureServices(IServiceCollection services)
        {

        }



        /// <summary>
        /// 配置中间件 做程序初始化操作
        /// </summary>
        /// <param name="app"></param>
        protected virtual void Configure(IApplicationBuilder app)
        {
            _ = app.UseDispatcherUnhandledException()
                .UseUnhandledException()
                .UseUnobservedTaskException();
            _ = app.UseEnsureSingleProcess();
        }

        protected string GetVersionInfo()
        {
            Version version = Assembly.GetEntryAssembly().GetName().Version;
            return $"V{version.Major}.{version.Minor},{version.Build}";
        }

    }
}

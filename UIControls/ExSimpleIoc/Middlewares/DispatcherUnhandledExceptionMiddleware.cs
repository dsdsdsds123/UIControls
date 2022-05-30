using ExSimpleIoc.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Middlewares
{
    public static class DispatcherUnhandledExceptionMiddleware
    {
        public static IApplicationBuilder UseDispatcherUnhandledException(this IApplicationBuilder app)
        {
            app.Current.DispatcherUnhandledException += (sender, e) =>
            {
                app._Logger?.Error($"Application Error,exception message:{e.Exception.Message},StackTrace:{e.Exception.StackTrace}");
                e.Handled = true;
            };
            return app;
        }
    }
}

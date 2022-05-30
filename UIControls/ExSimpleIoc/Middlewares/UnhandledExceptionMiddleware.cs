using ExSimpleIoc.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Middlewares
{
   public static class UnhandledExceptionMiddleware
    {
        public static IApplicationBuilder UseUnhandledException(this IApplicationBuilder app)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception error = (Exception)e.ExceptionObject;

                app._Logger?.Critical($"Some error occurred,the operation has been abandon,please try again,if try agin can not solve the problem,please contact the" +
                    $"administrator");
                app._Logger?.Critical($"Application will exit:{e.IsTerminating},Error message:{error.Message},StackTrace:{error.StackTrace}");
            };
            return app;
        }
    }
}

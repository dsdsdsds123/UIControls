using ExSimpleIoc.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Middlewares
{
    public static class UnobservedTaskExceptionMiddleware
    {
        public static IApplicationBuilder UseUnobservedTaskException(this IApplicationBuilder app)
        {
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                string errorMsg = string.Join("\r\n", e.Exception.InnerExceptions.Select(ex => $"Exception type:{ex.GetType().FullName}," +
            $"Exception message:{ex.Message},Exception from:{ex.Source},Exception StackTrace:" +
              $"{ex.StackTrace}"));
                app._Logger?.Error(errorMsg);

                e.SetObserved();
            };
            return app;
        }
    }
}

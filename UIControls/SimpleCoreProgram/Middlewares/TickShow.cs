using ExSimpleIoc.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleCoreProgram.Middlewares
{
   public static class TickShow
    {
        public static IApplicationBuilder UseTick(this IApplicationBuilder app)
        {
            Task.Factory.StartNew(()=> 
            {
                while (true)
                {
                    Console.WriteLine("**********************************************");
                    Task.Delay(2000).Wait();
                }
            });
            return app;
        }
    }
}

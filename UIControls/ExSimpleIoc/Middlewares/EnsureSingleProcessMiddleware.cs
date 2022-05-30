using ExSimpleIoc.AppServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ExSimpleIoc.Middlewares
{
    public static class EnsureSingleProcessMiddleware
    {
        private static Mutex mutex;

        public static IApplicationBuilder UseEnsureSingleProcess(this IApplicationBuilder app)
        {
            Process current = Process.GetCurrentProcess();
            mutex = new Mutex(true, current.ProcessName, out bool createNew);
            if (!createNew)
            {
                MessageBox.Show($"当前系统已有进程正在执行,不允许重复开启");
                app.Current.Shutdown();
            }
            return app;
        }
    }
}

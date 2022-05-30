using CommonServices.Utility.UtilityServices;
using ExSimpleIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonServices.Utility.IUtilityServices
{
    public interface IConsoleOperation
    {
        void ShowConsole();
        void HideConsole();
    }

    public static class ConsoleControlExtensions
    {
        public static IServiceCollection AddConsoleControl(this IServiceCollection services)
        {
            services.AddTransient<IConsoleOperation, ConsoleOperation>();
            return services;
        }
    }
}

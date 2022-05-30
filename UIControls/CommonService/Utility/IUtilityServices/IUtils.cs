using CommonServices.Utility.UtilityServices;
using ExSimpleIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonServices.Utility.IUtilityServices
{
    public interface IUtils
    {
        IntPtr ArrayToIntptr(byte[] source);

        long GetHardDiskSpace(string str_HardDiskName);

        long GetHardDiskFreeSpace(string str_HardDiskName);

        bool CheckCapacityMoreThanLimit(string dir, int limit);
    }

    public static class UtilsExtensions
    {
        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddTransient<IUtils, Utils>();
            return services;
        }
    }
}

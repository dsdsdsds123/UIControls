using CommonServices.Utility.UtilityServices;
using ExSimpleIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonServices.Utility.IUtilityServices
{
    public interface IFileHelper
    {
        byte[] FileToByte(string fileUrl);

        bool ByteToFile(byte[] byteArray, string fileName);
    }

    public static class FileHelperExtentions
    {
        public static IServiceCollection AddFileHelper(this IServiceCollection services)
        {
            services.AddTransient<IFileHelper, FileHelper>();
            return services;
        }
    }
}

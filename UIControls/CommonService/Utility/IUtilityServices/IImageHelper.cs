using CommonServices.Utility.UtilityServices;
using ExSimpleIoc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonServices.Utility.IUtilityServices
{
    public interface IImageHelper
    {
        System.Drawing.Bitmap BytesToImg(byte[] bytes, int w, int h);

        byte[] GetByteStreamFromBitmap(int width, int height, int channel, System.Drawing.Bitmap img);

        Bitmap ToGrayBitmap(byte[] rawValues, int width, int height);




        byte[] RgbToGrayScale(Bitmap original);
    }

    public static class ImageHelperExtensions
    {
        public static IServiceCollection AddImageHelper(this IServiceCollection services)
        {
            services.AddTransient<IImageHelper, ImageHelper>();
            return services;
        }
    }
}

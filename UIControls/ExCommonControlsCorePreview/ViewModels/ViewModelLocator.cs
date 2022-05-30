using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExCommonControlsCorePreview.ViewModels
{
    public class ViewModelLocator
    {
        public IServiceProvider _Provider { get; set; }
        public ViewModelLocator()
        {
            _Provider = ConfigureService();
        }


        public IServiceProvider ConfigureService()
        {
            IServiceCollection _Container = new ServiceCollection();
            _Container.AddTransient<MainViewModel>();
            return _Container.BuildServiceProvider();
        }

        public MainViewModel Main => _Provider.GetService<MainViewModel>();
    }
}

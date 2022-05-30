using ExSimpleIoc.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ExSimpleIoc.AppServices
{
    public interface IApplicationBuilder
    {
        Application Current { get; }
        ILogService _Logger { get; }
        Application Build();
    }

    public class ApplicationBuilder : IApplicationBuilder
    {
        public Application Current { get; }
        public ILogService _Logger { get; }
        public ApplicationBuilder(Application app, ILogService logger)
        {
            Current = app;
            _Logger = logger;
        }
        public Application Build() => Current;
    }
}

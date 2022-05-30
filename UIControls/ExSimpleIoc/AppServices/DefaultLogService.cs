using ExSimpleIoc.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.AppServices
{
    public class DefaultLogService : ILogService
    {
        public void Critical(string msg) => ShowMessage(msg, "Critical");
        public void Debug(string msg) => ShowMessage(msg, "Debug");
        public void Error(string msg) => ShowMessage(msg, "Error");
        public void Info(string msg) => ShowMessage(msg, "Info");
        public void Trace(string msg) => ShowMessage(msg, "Trace");
        public void Warn(string msg) => ShowMessage(msg, "Warn");

        private void ShowMessage(string msg, string tag) => Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")} [{tag}]: {msg}");

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.IServices
{
    public interface ILogService
    {
        void Error(string msg);
        void Debug(string msg);
        void Trace(string msg);
        void Warn(string msg);
        void Info(string msg);
        void Critical(string msg);
    }
}

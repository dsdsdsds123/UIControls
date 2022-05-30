using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Common
{
    public enum LifeTime
    {
        Transient,
        Singleton,
        Scoped
    }

    public class RegisterInfo
    {
        public Type ImplementType { get; set; }
        public object Instance { get; set; } = default;
        public LifeTime LifeTime { get; set; } = LifeTime.Transient;
        public object[] ConstantParaList { get; set; } = default;

        public Func<object> Factory { get; set; }
    }
}

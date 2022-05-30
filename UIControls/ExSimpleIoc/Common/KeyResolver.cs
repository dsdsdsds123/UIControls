using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Common
{
    public static class KeyResolver
    {
        public static readonly string SUFFIX = "REGISTRY";
        public static string GetKey(Type type, string key = "") => type.FullName + "*****[" + key + "]*****" + SUFFIX;
    }
}

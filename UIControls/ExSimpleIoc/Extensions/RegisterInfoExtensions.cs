using ExSimpleIoc.Attributes;
using ExSimpleIoc.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ExSimpleIoc.Extensions
{
    public static class RegisterInfoExtensions
    {
        public static bool GetInstanceFromRegisterinfo(this RegisterInfo registerInfo, Dictionary<string, object> scopeDic, string key, out object result)
        {
            result = null;
            switch (registerInfo.LifeTime)
            {
                case LifeTime.Transient:
                    break;
                case LifeTime.Singleton:
                    result = registerInfo.Instance;
                    return result != null;
                case LifeTime.Scoped:
                    if (scopeDic.ContainsKey(key))
                    {
                        result = scopeDic[key];
                        return true;
                    }
                    break;
                default:
                    throw new Exception($"{registerInfo.ImplementType} lifeTime is not valid...");
            }
            return false;
        }

        public static void SetInstanceForRegisterInfo(this RegisterInfo registerInfo, Dictionary<string, object> scopeDic, string key, object instance)
        {
            switch (registerInfo.LifeTime)
            {
                case LifeTime.Transient:
                    break;
                case LifeTime.Singleton:
                    registerInfo.Instance = instance;
                    break;
                case LifeTime.Scoped:
                    scopeDic.Add(key, instance);
                    break;
                default:
                    throw new Exception($"{registerInfo.ImplementType} lifeTime is not valid...");
            }
        }


        public static object MakeInstance(this RegisterInfo registerInfo, Func<Type, string, object> factory)
        {
            object instance = default;
            if (registerInfo.Factory != null) return registerInfo.Factory.Invoke();

            ConstructorInfo ctor = registerInfo.GetConstructorInfo();

            List<object> ctorParameters = new List<object>();
            int sIndex = 0;
            foreach (var para in ctor.GetParameters())
            {
                if (para.IsDefined(typeof(ConstantParameterAttribute), true)) ctorParameters.Add(registerInfo.ConstantParaList[sIndex++]);
                else
                    ctorParameters.Add(factory(para.ParameterType, para.GetParameterInfoAliasMark()));
            }

            instance = ctor.Invoke(ctorParameters.ToArray());
            return instance;
        }



        public static ConstructorInfo GetConstructorInfo(this RegisterInfo registerInfo)
        {
            Type type = registerInfo.ImplementType;
            if (type.IsInterface) throw new ArgumentException($"{type.FullName} can not be interface...");

            var selectedConstructor = type.GetConstructors().Where(c => c.IsDefined(typeof(PreferAttribute), true)).FirstOrDefault();

            selectedConstructor = selectedConstructor != null ? selectedConstructor
                : type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();
            return selectedConstructor;
        }
    }
}

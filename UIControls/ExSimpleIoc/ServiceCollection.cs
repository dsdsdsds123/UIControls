using ExSimpleIoc.Common;
using ExSimpleIoc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExSimpleIoc.Common.KeyResolver;

//this is ExSimpleIoc core container
namespace ExSimpleIoc
{
    public class ServiceCollection : IServiceCollection
    {
        private static readonly object _syncLock = new object();

        private readonly Dictionary<string, RegisterInfo> _registriesDictionary = new Dictionary<string, RegisterInfo>();

        private Dictionary<string, object> ScopeInstanceDictionary = new Dictionary<string, object>();

        private ServiceCollection(Dictionary<string, RegisterInfo> registries)
        {
            _registriesDictionary = registries;
            ScopeInstanceDictionary = new Dictionary<string, object>();
        }

        public ServiceCollection()
        {

        }

        public IServiceCollection BuildScope()
        {
            return new ServiceCollection(this._registriesDictionary);
        }





        public void Register<TInterface, TIpml>(LifeTime lifeTime = LifeTime.Transient, string key = "", object[] constantParas = null)
        {
            Register(typeof(TInterface), typeof(TIpml), lifeTime, key, constantParas);
        }

        public void Register(Type interfaceType, Type implType, LifeTime lifeTime = LifeTime.Transient, string key = "", object[] constantParas = null)
        {
            RegisterInfo registerInfo = new RegisterInfo() { ImplementType = implType, LifeTime = lifeTime, ConstantParaList = constantParas };
            lock (_syncLock)
            {
                _registriesDictionary.Add(GetKey(interfaceType, key), registerInfo);
            }
        }





        #region Transient LifeTime
        public void AddTransient<TInterface, TIpml>() where TIpml : TInterface
        {
            AddTransient(typeof(TInterface), typeof(TIpml));
        }

        public void AddTransient<TInterface, TIpml>(string alias) where TIpml : TInterface
        {
            AddTransient(typeof(TInterface), typeof(TIpml), alias);
        }

        public void AddTransient<T>() where T : class
        {
            AddTransient(typeof(T));
        }
        public void AddTransient<T>(string alias) where T : class
        {
            AddTransient(typeof(T), alias);
        }

        public void AddTransient(Type interfaceType, Type impl)
        {
            Register(interfaceType, impl, LifeTime.Transient, "", null);
        }
        public void AddTransient(Type interfaceType, Type impl, string alias)
        {
            Register(interfaceType, impl, LifeTime.Transient, alias, null);
        }

        public void AddTransient(Type impl)
        {
            if (impl.IsInterface) throw new Exception($"{impl.FullName} can not be interface");
            Register(impl, impl, LifeTime.Transient, "", null);
        }
        public void AddTransient(Type impl, string alias)
        {
            if (impl.IsInterface) throw new Exception($"{impl.FullName} can not be interface");
            Register(impl, impl, LifeTime.Transient, alias, null);
        }

        public void AddTransient(Type type, Func<object> factory, string key = "")
        {
            RegisterInfo regesterInfo = new RegisterInfo() { ImplementType = type, Factory = factory, LifeTime = LifeTime.Transient };
            _registriesDictionary.Add(GetKey(type, key), regesterInfo);
        }
        public void AddTransient<T>(Func<object> factory, string key = "")
        {
            AddSingleton(typeof(T), factory, key);
        }

        #endregion


        #region Scoped LifeTime
        public void AddScope<TInterface, TIpml>() where TIpml : TInterface
        {
            AddScope(typeof(TInterface), typeof(TIpml));
        }

        public void AddScope<TInterface, TIpml>(string alias) where TIpml : TInterface
        {
            AddScope(typeof(TInterface), typeof(TIpml), alias);
        }

        public void AddScope<T>() where T : class
        {
            AddScope(typeof(T));
        }
        public void AddScope<T>(string alias) where T : class
        {
            AddScope(typeof(T), alias);
        }

        public void AddScope(Type interfaceType, Type impl)
        {
            Register(interfaceType, impl, LifeTime.Scoped, "", null);
        }
        public void AddScope(Type interfaceType, Type impl, string alias)
        {
            Register(interfaceType, impl, LifeTime.Scoped, alias, null);
        }

        public void AddScope(Type impl)
        {
            if (impl.IsInterface) throw new Exception($"{impl.FullName} can not be interface");
            Register(impl, impl, LifeTime.Scoped, "", null);
        }
        public void AddScope(Type impl, string alias)
        {
            if (impl.IsInterface) throw new Exception($"{impl.FullName} can not be interface");
            Register(impl, impl, LifeTime.Scoped, alias, null);
        }

        public void AddScope(Type type, Func<object> factory, string key = "")
        {
            RegisterInfo regesterInfo = new RegisterInfo() { ImplementType = type, Factory = factory, LifeTime = LifeTime.Scoped };
            _registriesDictionary.Add(GetKey(type, key), regesterInfo);
        }
        public void AddScope<T>(Func<object> factory, string key = "")
        {
            AddScope(typeof(T), factory, key);
        }

        #endregion

        #region Singleton LifeTime
        public void AddSingleton<TInterface, TIpml>() where TIpml : TInterface
        {
            AddSingleton(typeof(TInterface), typeof(TIpml));
        }

        public void AddSingleton<TInterface, TIpml>(string alias) where TIpml : TInterface
        {
            AddSingleton(typeof(TInterface), typeof(TIpml), alias);
        }

        public void AddSingleton<T>() where T : class
        {
            AddSingleton(typeof(T));
        }
        public void AddSingleton<T>(string alias) where T : class
        {
            AddSingleton(typeof(T), alias);
        }

        public void AddSingleton(Type interfaceType, Type impl)
        {
            Register(interfaceType, impl, LifeTime.Singleton, "", null);
        }
        public void AddSingleton(Type interfaceType, Type impl, string alias)
        {
            Register(interfaceType, impl, LifeTime.Singleton, alias, null);
        }

        public void AddSingleton(Type impl)
        {
            if (impl.IsInterface) throw new Exception($"{impl.FullName} can not be interface");
            Register(impl, impl, LifeTime.Singleton, "", null);
        }
        public void AddSingleton(Type impl, string alias)
        {
            if (impl.IsInterface) throw new Exception($"{impl.FullName} can not be interface");
            Register(impl, impl, LifeTime.Singleton, alias, null);
        }
        public void AddSingleton<T>(object instance, string key = "")
        {
            AddSingleton(typeof(T), instance, key);
        }
        public void AddSingleton(Type type, object instance, string key = "")
        {
            RegisterInfo regesterInfo = new RegisterInfo() { ImplementType = type, Instance = instance, LifeTime = LifeTime.Singleton };
            _registriesDictionary.Add(GetKey(type, key), regesterInfo);
        }

        public void AddSingleton(Type type, Func<object> factory, string key = "")
        {
            RegisterInfo regesterInfo = new RegisterInfo() { ImplementType = type, Factory = factory, LifeTime = LifeTime.Singleton };
            _registriesDictionary.Add(GetKey(type, key), regesterInfo);
        }
        public void AddSingleton<T>(Func<object> factory, string key = "")
        {
            AddSingleton(typeof(T), factory, key);
        }

        #endregion




        public T GetService<T>(string key = "")
        {
            return (T)GetService(typeof(T), key);
        }


        public object GetService(Type type)
        {
            return GetService(type, "");
        }

        private object GetService(Type type, string alias)
        {
            object instance = default;

            string key = GetKey(type, alias);

            if (!_registriesDictionary.ContainsKey(key)) throw new Exception($"{type.FullName} with alias:{alias} has not been registerd...");

            RegisterInfo registerInfo = _registriesDictionary[key];

            if (registerInfo.GetInstanceFromRegisterinfo(ScopeInstanceDictionary, key, out instance)) return instance;

            instance = registerInfo.MakeInstance(GetService);

            instance.DoInjection(GetService);

            registerInfo.SetInstanceForRegisterInfo(ScopeInstanceDictionary, key, instance);


            return instance;
        }



        public void Replace<TInterface,TImplement>(string alias = "")
        {
            Replace(typeof(TInterface),typeof(TImplement),alias);
        }


        public void Replace(Type interfaceType, Type implType, string alias = "")
        {
            lock (_syncLock)
            {
                string key = GetKey(interfaceType, alias);
                if (_registriesDictionary.ContainsKey(key))
                {
                    _registriesDictionary[key].ImplementType = implType;
                }
            }
        }


        public IServiceProvider BuildServiceProvider()
        {
            IServiceProvider provider = new IServiceProviderImpl(this);
            AddSingleton<IServiceProvider>(provider);
            return provider;
        }
    }
}



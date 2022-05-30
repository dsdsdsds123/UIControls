using ExSimpleIoc.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExSimpleIoc
{
    public interface IServiceCollection
    {
        T GetService<T>(string key = "");
        object GetService(Type type);

        void Register<TInterface, TIpml>(LifeTime lifeTime = LifeTime.Transient, string key = "", object[] constantParas = null);
        void Register(Type interfaceType, Type implType, LifeTime lifeTime = LifeTime.Transient, string key = "", object[] constantParas = null);






        #region Transient LifeTime
        void AddTransient<TInterface, TIpml>() where TIpml : TInterface;
        void AddTransient<TInterface, TIpml>(string alias) where TIpml : TInterface;
        void AddTransient<T>() where T : class;
        void AddTransient<T>(string alias) where T : class;

        void AddTransient(Type interfaceType, Type impl);
        void AddTransient(Type interfaceType, Type impl, string alias);

        void AddTransient(Type impl);
        void AddTransient(Type impl, string alias);
        void AddTransient(Type type, Func<object> factory, string key = "");
        void AddTransient<T>(Func<object> factory, string key = "");
        #endregion

        void Replace(Type interfaceType, Type implType, string alias = "");
        void Replace<TInterface, TImplement>(string alias = "");

        #region Scoped LifeTime
        void AddScope<TInterface, TIpml>() where TIpml : TInterface;
        void AddScope<TInterface, TIpml>(string alias) where TIpml : TInterface;
        void AddScope<T>() where T : class;
        void AddScope<T>(string alias) where T : class;
        void AddScope(Type interfaceType, Type impl);
        void AddScope(Type interfaceType, Type impl, string alias);

        void AddScope(Type impl);
        void AddScope(Type impl, string alias);
        void AddScope(Type type, Func<object> factory, string key = "");
        void AddScope<T>(Func<object> factory, string key = "");

        #endregion

        #region Singleton LifeTime
        void AddSingleton<TInterface, TIpml>() where TIpml : TInterface;

        void AddSingleton<TInterface, TIpml>(string alias) where TIpml : TInterface;

        void AddSingleton<T>() where T : class;
        void AddSingleton<T>(string alias) where T : class;
        void AddSingleton(Type interfaceType, Type impl);
        void AddSingleton(Type interfaceType, Type impl, string alias);

        void AddSingleton(Type impl);
        void AddSingleton(Type impl, string alias);

        void AddSingleton<T>(object instance, string key = "");
        void AddSingleton(Type type, object instance, string key = "");

        void AddSingleton(Type type, Func<object> factory, string key = "");
        void AddSingleton<T>(Func<object> factory, string key = "");

        #endregion

        IServiceProvider BuildServiceProvider();
    }
}

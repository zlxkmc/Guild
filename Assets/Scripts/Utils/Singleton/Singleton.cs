using System;
using System.Reflection;

namespace Utils.Singleton
{
    /// <summary>
    /// 单例模板，需要私有无参构造方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    ConstructorInfo[] constructorInfos = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    ConstructorInfo constructorInfo = Array.Find(constructorInfos, c => c.GetParameters().Length == 0);
                    if (constructorInfo == null)
                    {
                        throw new Exception("Instance or notPublic method not found");
                    }

                    _instance = constructorInfo.Invoke(null) as T;
                }

                return _instance;
            }
        }
        protected Singleton() { }
    }
}
using System;
using UnityEngine;

namespace Utils.Singleton
{
    /// <summary>
    /// 单例模板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MonoSingleton<T>  : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    string typeName = typeof(T).Name;
                    //个数大于一个
                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        throw new Exception("MonoBehaviorSingleton: \"" + typeName + "\" More than 1");
                    }
 
                    _instance = FindObjectOfType<T>();
                    //场景中没找到
                    if (_instance == null)
                    {
                        GameObject gameObject = GameObject.Find(typeof(T).Name);
                        if (gameObject == null)
                        {
                            gameObject = new GameObject(typeName);
                        }
                        _instance = gameObject.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }
        protected MonoSingleton() { }

        void  OnDestroy()
        {
            _instance = null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public static class ResManager
    {
        public static Dictionary<string, Sprite> Sprites { get; private set; } = new Dictionary<string, Sprite>();
        public static Dictionary<string, GameObject> Prefabs { get; private set; } = new Dictionary<string, GameObject>();

        public static void Init()
        {
            AssetBundle ab = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/AB/baseasset");
            Sprites = Load<Sprite>(ab);
            Prefabs = Load<GameObject>(ab);

            //Sprite[] spriteArray = ab.LoadAllAssets<Sprite>();

            //foreach (Sprite sp in spriteArray)
            //{
            //    Sprites.Add(sp.name, sp);
            //}

            
        }

        private static Dictionary<string, T> Load<T>(AssetBundle ab) where T : Object
        {
            T[] ts = ab.LoadAllAssets<T>();
            
            Dictionary<string, T> res = new Dictionary<string, T>();

            foreach(T t in ts)
            {
                res.Add(t.name, t);
            }

            return res;
        }
    }

}

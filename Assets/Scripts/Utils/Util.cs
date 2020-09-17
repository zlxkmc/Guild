using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils
{
    public class Util
    {
        /// <summary>
        /// 复制文本到剪切板
        /// </summary>
        /// <param name="text"></param>
        public static void CopyText(string text)
        {
            GUIUtility.systemCopyBuffer = text;
        }
        /// <summary>
        /// layerMask转化从layer数字
        /// </summary>
        /// <param name="layerMask"></param>
        /// <returns></returns>
        public static int LayerMaskToLayer(LayerMask layerMask)
        {
            int value = layerMask.value;
            return (int) Mathf.Log(value, 2);
        }

        /// <summary>
        /// 2d物体朝向目标位置
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="pos"></param>
        public static void Trans2DLookPos(Transform transform, Vector3 pos)
        {
            Vector2 dir = (pos - transform.position).normalized;
            Trans2DLookDir(transform, dir);
        }

        /// <summary>
        /// 2d物体朝向目标方向
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="pos"></param>
        public static void Trans2DLookDir(Transform transform, Vector3 dir)
        {
            float angle = -(Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T">要创建对象的类型</typeparam>
        /// <param name="nameSpace">类型所在命名空间</param>
        /// <param name="className">类型名</param>
        /// <param name="parameters">构造函数参数</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string nameSpace, string className, object[] args)
        {
            string fullName = nameSpace + "." + className;
            Type type = Type.GetType(fullName);
            if (type == null)
            {
                return default;
            }
            T obj = (T) Activator.CreateInstance(type, args);
            //T obj = (T) type.Assembly.CreateInstance(fullName);
            return obj;
        }

        //public static Encoding EncodingCN => Encoding.GetEncoding("gb2312");

        /// <summary>
        /// 鼠标是否在ui1上
        /// </summary>
        public static bool IsMouseOverUI()
        {
            return ScreenPointGameObjects(Input.mousePosition).Count > 0;
        }


        /// <summary>
        /// 得到屏幕某点的ui物体
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public static List<GameObject> ScreenPointGameObjects(Vector2 pos)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            if (EventSystem.current != null)
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                eventData.position = pos;
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, results);
                results.ForEach(item => gameObjects.Add(item.gameObject));
            }

            return gameObjects;
        }

        /// <summary>
        /// 根据路径查找物体
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Transform FindByPath(Transform transform, string path)
        {
            string[] names = path.Split('/');
            Transform curTrans = transform;

            foreach (var name in names)
            {
                curTrans = curTrans.Find(name);
                if (curTrans == null)
                {
                    break;
                }
            }

            return curTrans;
        }

        /// <summary>
        /// 根据路径查找物体
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Transform FindByPath(string path)
        {
            string[] names = path.Split('/');

            Transform curTrans = GameObject.Find(names[0]).transform;
            if(curTrans != null)
            {
                for (int i = 1; i < names.Length; i++)
                {
                    curTrans = curTrans.Find(names[i]);
                    if (curTrans == null)
                    {
                        break;
                    }
                }
            }

            return curTrans;
        }

    }
}
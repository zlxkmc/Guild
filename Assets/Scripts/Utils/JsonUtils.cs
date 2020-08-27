using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Utils
{
    public static class JsonUtils
    {

        /// <summary>
        ///Json文件转对象
        /// </summary>
        public static T JsonFileToObject<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            T datas = JsonToObject<T>(json);

            return datas;
        }

        /// <summary>
        ///Json转对象
        /// </summary>
        public static T JsonToObject<T>(string json)
        {
            T datas = JsonConvert.DeserializeObject<T>(json);

            return datas;
        }

        /// <summary>
        /// 对象转json文件
        /// </summary>
        public static void ObjectToJsonFile<T>(T obj, string filePath)
        {
            string json = ObjectToJson<T>(obj);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// 对象转json
        /// </summary>
        public static string ObjectToJson<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }
    }
}
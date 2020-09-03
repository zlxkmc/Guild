using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
    public static class GameConfig
    {
        public static List<ItemConfig> Items { get; private set; }
        public static List<SkillConfig> Skills { get; private set; }


        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            Items = JsonUtils.JsonFileToObject<List<ItemConfig>>(Application.streamingAssetsPath + "/Config/Items.json");
            Skills = JsonUtils.JsonFileToObject<List<SkillConfig>>(Application.streamingAssetsPath + "/Config/Skills.json");
        }

    }
}



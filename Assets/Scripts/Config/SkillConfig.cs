using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SkillConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 冷却
        /// </summary>
        public double Cd { get; set; }

        /// <summary>
        /// 技能类型
        /// </summary>
        public SkillType Type { get; set; }

        /// <summary>
        /// 脚本
        /// </summary>
        public string ScriptName { get; set; }


        /// <summary>
        /// 图标路径
        /// </summary>
        public string IconPath { get; set; }
    }
}

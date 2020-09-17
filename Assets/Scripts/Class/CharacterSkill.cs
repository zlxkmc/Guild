using System;
using System.Collections.Generic;


namespace Game
{
    public class CharacterSkill
    {
        private SkillConfig _config;

        public CharacterSkill(string skillId)
        {
            _config = GameConfig.Skills.Find(item => item.Id == skillId);
            Level = 1;
        }
        /// <summary>
        /// 技能id
        /// </summary>
        public string Id { get => _config.Id; }
        /// <summary>
        /// 技能等级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 技能经验
        /// </summary>
        public int Exp { get; set; }
        /// <summary>
        /// 当前冷却
        /// </summary>
        public int CurCd { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get => _config.Name; }

        /// <summary>
        /// 冷却
        /// </summary>
        public double Cd { get => _config.Cd; }

        /// <summary>
        /// 图标路径
        /// </summary>
        public string IconPath { get => _config.IconPath; }

        /// <summary>
        /// 技能类型
        /// </summary>
        public SkillType Type { get => _config.Type; }

        /// <summary>
        /// 脚本
        /// </summary>
        public string ScriptName { get => _config.ScriptName; }
    }
}

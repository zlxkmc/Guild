
using UnityEngine;

namespace Game
{
    public abstract class SkillScript
    {
        /// <summary>
        /// 技能拥有者
        /// </summary>
        public Character Owner { get; private set; }
        /// <summary>
        /// 角色对应的技能
        /// </summary>
        public CharacterSkill CharacterSkill { get; private set; }

        public SkillScript(Character owner, CharacterSkill skill)
        {
            Owner = owner;
            CharacterSkill = skill;
        }

        /// <summary>
        /// 是否能使用
        /// </summary>
        public abstract bool IsCanUse();
        /// <summary>
        /// 当使用时
        /// </summary>
        public virtual void OnUse()
        {
            Debug.Log(Owner.name + " 使用技能 " + CharacterSkill.Name);
        }

        /// <summary>
        /// 技能描述
        /// </summary>
        /// <returns></returns>
        public virtual string Describe()
        {
            return "";

        }
    }
}

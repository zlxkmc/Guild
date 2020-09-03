
using UnityEngine;

namespace Game
{
    public abstract class BaseSkill
    {
        /// <summary>
        /// 技能拥有者
        /// </summary>
        public Character Owner { get; private set; }
        /// <summary>
        /// 角色对应的技能
        /// </summary>
        public Skill Skill { get; private set; }

        public BaseSkill(Character owner, Skill skill)
        {
            Owner = owner;
            Skill = skill;
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
            Debug.Log(Owner.Name + " 使用技能 " + Skill.Name);
        }
    }
}

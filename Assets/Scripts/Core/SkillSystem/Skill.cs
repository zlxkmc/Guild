

namespace Core.SkillSystem
{
    /// <summary>
    /// 技能脚本
    /// </summary>
    public abstract class Skill
    {
        /// <summary>
        /// 技能名
        /// </summary>
        public abstract string SkillName { get;}

        /// <summary>
        /// 技能类型
        /// </summary>
        public abstract SkillType SkillType { get; }

        /// <summary>
        /// 技能图标
        /// </summary>
        public abstract string IconName { get; }

        ///// <summary>
        ///// 某个角色是否满足学习条件
        ///// </summary>
        ///// <param name="character">要学习的角色</param>
        ///// <returns>能否学习</returns>
        //public abstract bool MeetStudyCondition(Character character);

        ///// <summary>
        ///// 当被某个角色激活时
        ///// <param name="character">角色</param>
        ///// </summary>
        //public abstract void OnActive(Character character);

        ///// <summary>
        ///// 当被某个角色停止激活时
        ///// <param name="character">角色</param>
        ///// </summary>
        //public abstract void OnStopActive(Character character);


        ///// <summary>
        ///// 当技能等级提升时
        ///// </summary>
        ///// <param name="character">拥有的角色</param>
        //public abstract void OnLevelUp(Character character);

    }
}


namespace Game.SkillSystem
{
    /// <summary>
    /// 主动技能
    /// </summary>
    public abstract class ActiveSkill : Skill
    {
        /// <summary>
        /// 魔法消耗
        /// </summary>
        public abstract int MpCost { get; }

        /// <summary>
        /// 体力消耗
        /// </summary>
        public abstract int PpCost { get; }

        /// <summary>
        /// 冷却时间
        /// </summary>
        public abstract double Cd { get; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct DamageInfo
    {
        /// <summary>
        /// 期望伤害
        /// </summary>
        public int ExpectDamage { get; set; }
        public Unit Attacker { get; set; }
        public Unit BeAttacker { get; set; }
        public string SkillId { get; set; }
    }
}

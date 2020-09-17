using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
    /// <summary>
    /// 单位
    /// </summary>
    public abstract class Unit : MonoBehaviour
    {
        /// <summary>
        /// 当前生命值
        /// </summary>
        public int Hp { get => _hp; set => _hp = value; }
        /// <summary>
        /// 最大生命值
        /// </summary>
        public abstract int MaxHp { get; }
        /// <summary>
        /// 单位类型
        /// </summary>
        public abstract UnitType UnitType { get; }
        /// <summary>
        /// 队伍类型
        /// </summary>
        public abstract TeamType TeamType { get; }

        [SerializeField]
        private int _hp;

        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="damageInfo"></param>
        public void TakeDamage(Unit attacker, int damage, string skillId)
        {
            DamageInfo damageInfo = new DamageInfo()
            {
                ExpectDamage = damage,
                Attacker = attacker,
                BeAttacker = this,
                SkillId = skillId
            };

            OnTakeDamage(damageInfo);
        }

        /// <summary>
        /// 当受到伤害
        /// </summary>
        /// <param name="damageInfo"></param>
        protected virtual void OnTakeDamage(DamageInfo damageInfo)
        {
            Debug.Log(gameObject.name + " 受到 " + damageInfo.ExpectDamage + " 点伤害");

            _hp -= damageInfo.ExpectDamage;
            if (_hp <= 0)
            {
                _hp = 0;
            }
        }

    }
}
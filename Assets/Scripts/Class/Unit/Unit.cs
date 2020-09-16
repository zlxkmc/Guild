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
        /// 单位类型
        /// </summary>
        public abstract UnitType UnitType { get; }

        [SerializeField]
        private int _hp;

        /// <summary>
        /// 当受到伤害
        /// </summary>
        /// <param name="damageInfo"></param>
        protected virtual void OnTakeDamage(DamageInfo damageInfo)
        {

        }

        /// <summary>
        /// 受到伤害
        /// </summary>
        /// <param name="damageInfo"></param>
        public void TakeDamage(DamageInfo damageInfo)
        {
            _hp -= damageInfo.Damage;
            if(_hp <= 0)
            {
                _hp = 0;
            }

            OnTakeDamage(damageInfo);
            // TODO ...
        }
    }
}
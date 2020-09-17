using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
    /// <summary>
    /// 怪物
    /// </summary>
    public abstract class Monster : Unit
    {
        public override UnitType UnitType => UnitType.Monster;

        /// <summary>
        /// 当前魔法值
        /// </summary>
        public int Mp { get => _mp; set => _mp = value; }

        /// <summary>
        /// 当前体力值
        /// </summary>
        public int Pp { get => _pp; set => _pp = value; }


        /// <summary>
        /// 基础生命上限
        /// </summary>
        public int BaseMaxHp { get => _baseMaxHp; set => _baseMaxHp = value; }

        /// <summary>
        /// 基础魔法上限
        /// </summary>
        public int BaseMaxMp { get => _baseMaxMp; set => _baseMaxMp = value; }

        /// <summary>
        /// 基础体力上限
        /// </summary>
        public int BaseMaxPp { get => _baseMaxPp; set => _baseMaxPp = value; }

        /// <summary>
        /// 基础力量
        /// </summary>
        public int BaseStr { get => _baseStr; set => _baseStr = value; }

        /// <summary>
        /// 基础敏捷
        /// </summary>
        public int BaseDex { get => _baseDex; set => _baseDex = value; }

        /// <summary>
        /// 基础运气
        /// </summary>
        public int BaseLuc { get => _baseLuc; set => _baseLuc = value; }

        /// <summary>
        /// 基础智力
        /// </summary>
        public int BaseInt { get => _baseInt; set => _baseInt = value; }

        /// <summary>
        /// 基础耐力
        /// </summary>
        public int BaseSta { get => _baseSta; set => _baseSta = value; }

        /// <summary>
        /// 生命上限
        /// </summary>
        public override int MaxHp
        {
            get { return BaseMaxHp + 2 * Sta; }
        }

        /// <summary>
        /// 魔法上限
        /// </summary>
        public int MaxMp
        {
            get { return BaseMaxMp + 2 * Int; }
        }

        /// <summary>
        /// 体力上限
        /// </summary>
        public int MaxPp
        {
            get { return BaseMaxPp + 2 * Sta; }
        }

        /// <summary>
        /// 力量
        /// </summary>
        public int Str
        {
            get { return BaseStr ; }
        }

        /// <summary>
        /// 敏捷
        /// </summary>
        public int Dex
        {
            get { return BaseDex ; }
        }

        /// <summary>
        /// 运气
        /// </summary>
        public int Luc
        {
            get { return BaseLuc; }
        }

        /// <summary>
        /// 智力
        /// </summary>
        public int Int
        {
            get { return BaseInt ; }
        }

        /// <summary>
        /// 耐力
        /// </summary>
        public int Sta
        {
            get { return BaseSta ; }
        }

        /// <summary>
        /// 移动速度率
        /// </summary>
        public float MoveSpeedRate
        {
            get { return (1 + 0.01f * Dex); }
        }

        /// <summary>
        /// 背包
        /// </summary>
        public Bag Bag { get; private set; } = new Bag();


        [SerializeField]
        private int _mp;
        [SerializeField]
        private int _pp;
        [SerializeField]
        private int _statPoint;
        [SerializeField]
        private int _baseMaxHp;
        [SerializeField]
        private int _baseMaxMp;
        [SerializeField]
        private int _baseMaxPp;
        [SerializeField]
        private int _baseStr;
        [SerializeField]
        private int _baseDex;
        [SerializeField]
        private int _baseLuc;
        [SerializeField]
        private int _baseInt;
        [SerializeField]
        private int _baseSta;
    }
}
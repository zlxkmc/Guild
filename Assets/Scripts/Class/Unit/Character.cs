using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
    /// <summary>
    /// 角色
    /// </summary>
    public abstract class Character : Unit
    {
        public override UnitType UnitType => UnitType.Character;

        /// <summary>
        /// 当前魔法值
        /// </summary>
        public int Mp { get => _mp; set => _mp = value; }

        /// <summary>
        /// 当前体力值
        /// </summary>
        public int Pp { get => _pp; set => _pp = value; }

        /// <summary>
        /// 可分配属性点
        /// </summary>
        public int StatPoint { get => _statPoint; set => _statPoint = value; }

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
        /// 分配力量
        /// </summary>
        public int AllocatedStr { get => _allocatedStr; set => _allocatedStr = value; }

        /// <summary>
        /// 分配敏捷
        /// </summary>
        public int AllocatedDex { get => _allocatedDex; set => _allocatedDex = value; }

        /// <summary>
        /// 分配运气
        /// </summary>
        public int AllocatedLuc { get => _allocatedLuc; set => _allocatedLuc = value; }

        /// <summary>
        /// 分配智力
        /// </summary>
        public int AllocatedInt { get => _allocatedInt; set => _allocatedInt = value; }

        /// <summary>
        /// 分配耐力
        /// </summary>
        public int AllocatedSta { get => _allocatedSta; set => _allocatedSta = value; }

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
            get { return BaseStr + AllocatedStr; }
        }

        /// <summary>
        /// 敏捷
        /// </summary>
        public int Dex
        {
            get { return BaseDex + AllocatedDex; }
        }

        /// <summary>
        /// 运气
        /// </summary>
        public int Luc
        {
            get { return BaseLuc + AllocatedLuc; }
        }

        /// <summary>
        /// 智力
        /// </summary>
        public int Int
        {
            get { return BaseInt + AllocatedInt; }
        }

        /// <summary>
        /// 耐力
        /// </summary>
        public int Sta
        {
            get { return BaseSta + AllocatedSta; }
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
        [SerializeField]
        private int _allocatedStr;
        [SerializeField]
        private int _allocatedDex;
        [SerializeField]
        private int _allocatedLuc;
        [SerializeField]
        private int _allocatedInt;
        [SerializeField]
        private int _allocatedSta;


        /// <summary>
        /// 分配属性点
        /// </summary>
        public void AllocatedStatPoint(StatPointType type, int num)
        {
            if (StatPoint < num)
            {
                return;
            }

            switch (type)
            {
                case StatPointType.Str:
                    AllocatedStr += num;
                    break;
                case StatPointType.Dex:
                    AllocatedDex += num;
                    break;
                case StatPointType.Luc:
                    AllocatedLuc += num;
                    break;
                case StatPointType.Int:
                    AllocatedInt += num;
                    break;
                case StatPointType.Sta:
                    AllocatedSta += num;
                    break;
            }

            StatPoint -= num;
        }

        /// <summary>
        ///  花费体力，不够不会消耗
        /// </summary>
        /// <param name="value"></param>
        /// <returns>是否成功消耗</returns>
        public bool CostPp(int value)
        {
            if (Pp >= value)
            {
                Pp -= value;

                return true;
            }
            else
            {
                return false;
            }
        }


        #region equipment

        /// <summary>
        /// 使用的装备
        /// </summary>
        private Dictionary<EquipmentSlotType, Item> _equipments = new Dictionary<EquipmentSlotType, Item>();

        /// <summary>
        /// 物品能否装备
        /// </summary>
        /// <returns></returns>
        public bool CanEquipItem(Item item)
        {
            bool can = false;

            if (item != null)
            {
                switch (item.Type)
                {
                    case ItemType.Weapon:
                        can = true;
                        break;
                }
            }

            return can;
        }

        /// <summary>
        /// 取得某个槽的装备
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Item GetEquipment(EquipmentSlotType type)
        {
            Item item = null;

            if (_equipments.ContainsKey(type))
            {
                item = _equipments[type];
            }
            else
            {
                _equipments.Add(type, null);
            }

            return item;
        }

        /// <summary>
        /// 装备物品
        /// </summary>
        /// <param name="item"></param>
        public bool Equip(Item item, EquipmentSlotType type)
        {
            if (item == null)
            {
                Debug.LogError("装备的物品为null");
                return false;
            }

            if (CanEquipItem(item))
            {
                // 装备
                if (_equipments.ContainsKey(type))
                {
                    _equipments[type] = item;
                }
                else
                {
                    _equipments.Add(type, item);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 卸下装备
        /// </summary>
        /// <param name="type"></param>
        /// <returns>卸下的装备</returns>
        public Item UnEquip(EquipmentSlotType type)
        {
            if (_equipments.ContainsKey(type))
            {
                Item item = _equipments[type];
                _equipments[type] = null;

                return item;
            }
            else
            {
                _equipments.Add(type, null);
                return null;
            }
        }

        #endregion
        
        #region skill

        /// <summary>
        /// 拥有的技能
        /// </summary>
        private List<CharacterSkill> _skills = new List<CharacterSkill>();

        /// <summary>
        /// 技能数量
        /// </summary>
        public int SkillCount { get => _skills.Count; }

        /// <summary>
        /// 取得技能
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public CharacterSkill GetSkill(string skillId)
        {
            return _skills.Find(v => v.Id == skillId);
        }

        /// <summary>
        /// 第几个技能
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CharacterSkill GetSkill(int index)
        {
            return _skills[index];
        }

        /// <summary>
        /// 学习进技能
        /// </summary>
        public void StudySkill(string skillId)
        {
            if (GetSkill(skillId) == null) // 没学过该技能
            {
                CharacterSkill skill = new CharacterSkill(skillId);
                _skills.Add(skill);
            }
        }

        /// <summary>
        /// 主动使用技能
        /// </summary>
        /// <param name="skillId"></param>
        public void UseSkill(string skillId)
        {
            CharacterSkill skill = GetSkill(skillId);
            if (skill.CurCd <= 0)
            {
                SkillScript baseSkill = Util.CreateInstance<SkillScript>("Game.SkillScripts", skill.ScriptName, new object[] { this, skill });
                if (baseSkill.IsCanUse())
                {
                    baseSkill.OnUse();
                }
            }

        }

        #endregion
    }
}
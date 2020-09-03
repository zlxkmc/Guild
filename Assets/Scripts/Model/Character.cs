using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Character
    {
        /// <summary>
        /// 对应的角色控制器
        /// </summary>
        private CharacterController CharacterController
        {
            get
            {
                if(_characterController == null)
                {
                    CharacterController[] objs = GameObject.FindObjectsOfType<CharacterController>();
                    foreach (var obj in objs)
                    {
                        if(obj.Character == this)
                        {
                            _characterController = obj;
                            break;
                        }
                    }
                }

                return _characterController;
            }
        }
        private CharacterController _characterController;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 当前生命值
        /// </summary>
        public int Hp { get; set; }

        /// <summary>
        /// 当前魔法值
        /// </summary>
        public int Mp { get; set; }

        /// <summary>
        /// 当前体力值
        /// </summary>
        public int Pp { get; set; }

        /// <summary>
        /// 可分配属性点
        /// </summary>
        public int StatPoint { get; set; }

        /// <summary>
        /// 基础生命上限
        /// </summary>
        public int BaseMaxHp { get; set; }

        /// <summary>
        /// 基础魔法上限
        /// </summary>
        public int BaseMaxMp { get; set; }

        /// <summary>
        /// 基础体力上限
        /// </summary>
        public int BaseMaxPp { get; set; }

        /// <summary>
        /// 基础力量
        /// </summary>
        public int BaseStr { get; set; }

        /// <summary>
        /// 基础敏捷
        /// </summary>
        public int BaseDex { get; set; }

        /// <summary>
        /// 基础运气
        /// </summary>
        public int BaseLuc { get; set; }

        /// <summary>
        /// 基础智力
        /// </summary>
        public int BaseInt { get; set; }

        /// <summary>
        /// 基础耐力
        /// </summary>
        public int BaseSta { get; set; }

        /// <summary>
        /// 分配力量
        /// </summary>
        public int AllocatedStr { get; set; }

        /// <summary>
        /// 分配敏捷
        /// </summary>
        public int AllocatedDex { get; set; }

        /// <summary>
        /// 分配运气
        /// </summary>
        public int AllocatedLuc { get;  set; }

        /// <summary>
        /// 分配智力
        /// </summary>
        public int AllocatedInt { get; set; }

        /// <summary>
        /// 分配耐力
        /// </summary>
        public int AllocatedSta { get; set; }

        /// <summary>
        /// 生命上限
        /// </summary>
        public int MaxHp
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
        /// 位置
        /// </summary>
        public Vector2 Pos { get => CharacterController.transform.position; set => CharacterController.transform.position = value; }

        /// <summary>
        /// 背包
        /// </summary>
        public Bag Bag { get; private set; } = new Bag();

        /// <summary>
        /// 分配属性点
        /// </summary>
        public void AllocatedStatPoint(StatPointType type, int num)
        {
            if(StatPoint < num)
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
            if(Pp >= value)
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

            if(_equipments.ContainsKey(type))
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
                if(_equipments.ContainsKey(type))
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
        private List<Skill> _skills = new List<Skill>();

        /// <summary>
        /// 取得技能
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public Skill GetSkill(string skillId)
        {
            return _skills.Find(v => v.Id == skillId);
        }

        /// <summary>
        /// 学习进技能
        /// </summary>
        public void StudySkill(string skillId)
        {
            if(GetSkill(skillId) == null) // 没学过该技能
            {
                Skill skill = new Skill(skillId);
                _skills.Add(skill);
            }
        }

        /// <summary>
        /// 主动使用技能
        /// </summary>
        /// <param name="skillId"></param>
        public void UseSkill(string skillId)
        {
            Skill skill = GetSkill(skillId);
            if(skill.CurCd <= 0)
            {
                BaseSkill baseSkill = Util.CreateInstance<BaseSkill>("Game.Skills", skill.ScriptName, new object[] { this, skill });
                if (baseSkill.IsCanUse())
                {
                    baseSkill.OnUse();
                }
            }
            
        }

        #endregion
    }
}
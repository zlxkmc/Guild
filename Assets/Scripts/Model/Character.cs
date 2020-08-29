using System;

namespace Game
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Character
    {
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
        /// 背包
        /// </summary>
        public Bag Bag { get; private set; } = new Bag();

        /// <summary>
        /// 装备
        /// </summary>
        public Item[] Equipments { get; private set; } = new Item[10];


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

        public Item GetEquipment(EquipmentSlotType type)
        {
            return Equipments[(int)type];
        }

        /// <summary>
        /// 装备物品
        /// </summary>
        /// <param name="item"></param>
        public bool Equip(Item item, EquipmentSlotType type)
        {
            bool success = false;

            if(item != null)
            {
                switch (type)
                {
                    case EquipmentSlotType.Weapon:
                        if (item.Type == ItemType.Weapon)
                            success = true;
                        break;
                }
            }

            if (success)
            {
                Equipments[(int)type] = item;
            }

            return success;
        }
    }
}
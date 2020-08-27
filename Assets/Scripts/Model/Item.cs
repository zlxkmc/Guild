
using System;
using System.Collections.Generic;

namespace Game
{
    /// <summary>
    /// 物品
    /// </summary>
    public class Item
    {
        private ItemConfig _config;

        public Item(string id)
        {
            _config = GameConfig.Items.Find(item => item.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Id { get => _config.Id; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get => _config.Name; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get => _config.Describe; }
        /// <summary>
        /// 价值
        /// </summary>
        public int Value { get => _config.Value; }

        /// <summary>
        /// 重量
        /// </summary>
        public int Weight { get => _config.Weight; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get => _config.Type; }

        /// <summary>
        /// 图标名
        /// </summary>
        public string IconName { get => _config.IconName; }

        /// <summary>
        /// 能否堆叠
        /// </summary>
        public bool Stack { get => _config.Stack; }

        /// <summary>
        /// 两个物品能否堆叠
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        public static bool IsCanStack(Item item1, Item item2)
        {
            // TODO 修改
            if (item1.Id == item2.Id && item1.Stack && item2.Stack)
            {
                return true;
            }

            return false;
        }
    }
}

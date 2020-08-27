using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    //TODO 修改
    public class ItemConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; }
        /// <summary>
        /// 价值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 图标名
        /// </summary>
        public string IconName { get; set; }

        /// <summary>
        /// 能否堆叠
        /// </summary>
        public bool Stack { get; set; }

    }
 
}


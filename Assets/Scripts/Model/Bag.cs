using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 背包
    /// </summary>
    public class Bag 
    {
        /// <summary>
        /// 背包的物品组
        /// </summary>
        private ItemGroup[] _itemGroups = new ItemGroup[0];

        /// <summary>
        /// 大小（格子数量，物品组数量）
        /// </summary>
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                ItemGroup[] newItemGroup = new ItemGroup[value];
                _itemGroups.CopyTo(newItemGroup, 0);

                _itemGroups = newItemGroup;
                _size = value;
            }
        }

        private int _size;

        /// <summary>
        /// 所有物品总重量
        /// </summary>
        public float ItemsWeight
        {
            get
            {
                float weight = 0;

                foreach (var itemGroup in _itemGroups)
                {
                    if (itemGroup != null)
                    {
                        weight += itemGroup.Item.Weight * itemGroup.Count;
                    }
                }
                
                return weight;
            }
        }

        /// <summary>
        /// 查找物品组
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        public ItemGroup FindItemGroup(Predicate<ItemGroup> match)
        {
            foreach (var itemGroup in _itemGroups)
            {
                if(itemGroup != null)
                {
                    if(match(itemGroup))
                    {
                        return itemGroup;
                    }
                }
            }
            
            return null;
        }

        /// <summary>
        /// 遍历物品组
        /// </summary>
        /// <param name="action"></param>
        public void ForEachItemGroups(Action<ItemGroup> action)
        {
            foreach (var itemGroup in _itemGroups)
            {
                if (itemGroup != null)
                {
                    action(itemGroup);
                }
            }
        }

        /// <summary>
        /// 背包某个位置的物品组
        /// <param name="pos"></param>
        /// <returns></returns>
        /// </summary>
        public ItemGroup GetItemGroup(int pos)
        {
            return _itemGroups[pos];
        }

        /// <summary>
        /// 添加物品，从前往后（可以用另一种方式实现）
        /// <param name="item">物品</param>
        /// <param name="count">数量</param>
        /// <retures>剩余未添加的数量</retures>
        /// </summary>
        public int AddItem(Item item, int count)
        {
            if(count == 0)
            {
                return 0;
            }

            int last = count;
            int maxStack = GameSetting.ItemMaxStack;

            //可以堆叠的物品组
            ItemGroup itemGroup = FindItemGroup(v => Item.IsCanStack(v.Item, item) && v.Count < maxStack);


            if (itemGroup == null) // 没有可以堆叠的地方
            {
                int emptyPos = FindFirstEmptyPos();

                if(emptyPos == -1)  // 没有空位置
                {
                    return last;
                }

                //新物品组
                ItemGroup newItemGroup = new ItemGroup()
                {
                    Item = item,
                    Count = 0
                };

                _itemGroups[emptyPos] = newItemGroup;

                if (item.Stack)
                {
                    if (last <= maxStack) // 可以放完
                    {
                        newItemGroup.Count = last;
                    }
                    else // 放不完，还要新格子
                    {
                        newItemGroup.Count = maxStack;
                        last -= maxStack;

                        return AddItem(item, last);
                    }
                }
                else
                {
                    newItemGroup.Count = 1;
                    last -= 1;
                    return AddItem(item, last);
                }

            }
            else // 有可以堆叠的地方
            {
                int space = maxStack - itemGroup.Count;
                if(space >= last) // 可以堆下
                {
                    itemGroup.Count += last;
                    last = 0;
                }
                else // 堆不下 
                {
                    itemGroup.Count += space;
                    last -= space;

                    // 还没放完
                    return AddItem(item, last);
                }
            }

            return 0;
        }

        /// <summary>
        /// 添加物品到某个位置
        /// <param name="item">物品</param>
        /// <param name="count">数量</param>
        /// <param name="pos">位置</param>
        /// <retures>剩余未添加的数量</retures>
        /// </summary>
        public int AddItem(Item item, int count, int pos)
        {
            ItemGroup itemGroup = _itemGroups[pos];
            
            if(itemGroup == null) // 目标位置没有物品
            {
                ItemGroup newItemGroup = new ItemGroup()
                {
                    Item = item,
                };

                int addedCount;

                if (item.Stack) // 可以堆叠
                {
                    if (count <= GameSetting.ItemMaxStack)
                    {
                        addedCount = count;
                    }
                    else
                    {
                        addedCount = GameSetting.ItemMaxStack;
                    }
                }
                else // 不能堆叠
                {
                    addedCount = 1;
                }

                newItemGroup.Count = addedCount;

                _itemGroups[pos] = newItemGroup;

                return count - addedCount;
            }
            else // 目标位置有物品
            {
                if(Item.IsCanStack(item, itemGroup.Item)) // 可以堆叠
                {
                    int space = GameSetting.ItemMaxStack - itemGroup.Count;

                    if (count <= space) // 全部堆过去
                    {
                        itemGroup.Count += count;
                        return 0;
                    }
                    else // 只能堆一部份
                    {
                        itemGroup.Count += space;
                        return count - space;
                    }
                }
                else
                {
                    return count;
                }
            }
        }

        /// <summary>
        /// 移动物品组
        /// </summary>
        /// <param name="originalPos">原位置</param>
        /// <param name="targetPos">目标位置</param>
        public void MoveItemGroup(int originalPos, int targetPos)
        {
            if (originalPos == targetPos)
            {
                return;
            }

            // 要移动的物品组
            ItemGroup originalItemGroup = _itemGroups[originalPos];
            ItemGroup targetItemGroup = _itemGroups[targetPos];

            if (originalItemGroup == null)
            {
                Debug.LogError("要移动的位置不存在物品");
                return;
            }

            int maxStack = GameSetting.ItemMaxStack;
            
            if(targetItemGroup != null && Item.IsCanStack(originalItemGroup.Item, targetItemGroup.Item)) // 目标位置有可以堆叠的物品
            {
                int space = maxStack - targetItemGroup.Count;
                if(originalItemGroup.Count <= space) // 全部堆过去
                {
                    targetItemGroup.Count += originalItemGroup.Count;
                    RemoveItemGroup(originalPos);
                }
                else // 只能堆一部份
                {
                    targetItemGroup.Count += space;
                    originalItemGroup.Count -= space;
                }
            }
            else
            {
                // 交换
                _itemGroups[originalPos] = targetItemGroup;
                _itemGroups[targetPos] = originalItemGroup;
            }
        }

        /// <summary>
        /// 移除某个位置的物品组
        /// </summary>
        /// <param name="pos">要移除的位置</param>
        public void RemoveItemGroup(int pos)
        {
            _itemGroups[pos] = null;
        }

        /// <summary>
        /// 背包的第一个空位
        /// </summary>
        private int FindFirstEmptyPos()
        {
            for (int i = 0; i < Size; i++)
            {
                if (_itemGroups[i] == null) // 说明i位置没有物品组
                {
                    return i;
                }
            }

            return -1;
        }



        /*
        /// <summary>
        /// 移除对应id的物品，数量为count
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        public bool Remove(int id, int count)
        {
            List<ItemGroup> items = _content.FindAll(item => item.ItemData.Id == id);
            foreach (var itemGroup in items)
            {
                if (itemGroup.Count < count)
                {
                    count -= itemGroup.Count;
                    itemGroup.Count = 0;
                }
                else
                {
                    itemGroup.Count -= count;
                    count = 0;
                    break;
                }
            }

            _content.RemoveAll(item => item.Count == 0);

            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 是否包含一定数量的某id物品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool IsContainItem(int id,int count)
        {
            List<ItemGroup> items = _content.FindAll(item => item.ItemData.Id == id);
            foreach (var itemGroup in items)
            {
                count -= itemGroup.Count;
                if (count <= 0)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// 得到对应位置的数据
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ItemGroup GetItem(int index)
        {
            return _content.Find(item => item.Index == index);
        }
        */
    }
}
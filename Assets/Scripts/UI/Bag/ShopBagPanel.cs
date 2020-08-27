
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    /// <summary>
    /// 商店背包
    /// </summary>
    public class ShopBagPanel : BagPanel
    {
        public override GridManagerFlag Flag => GridManagerFlag.ShopBag;

        public override void OnGridDragEnd(Grid originalGrid, Grid targetGrid, PointerEventData eventData)
        {
            base.OnGridDragEnd(originalGrid, targetGrid, eventData);

            BagGrid originalBagGrid = (BagGrid)originalGrid;
            BagGrid targetBagGrid = (BagGrid)targetGrid;

            if (targetGrid != null)
            {
                if (targetGrid.Manager.Flag == GridManagerFlag.PlayerBag) // 拖到玩家的背包格子上
                {
                    // 出售
                    BagPanel playerBagPanel = targetBagGrid.Manager;
                    Bag playerBag = playerBagPanel.Bag;

                    ItemGroup purchased = Bag.RemoveItemGroup(originalBagGrid.Index);
                    purchased.Count = playerBagPanel.Bag.AddItemGroup(purchased, targetBagGrid.Index);

                    if (purchased.Count > 0) // 没卖完
                    {
                        Bag.AddItemGroup(purchased, originalBagGrid.Index);
                    }
                }
            }
        }
    }
}

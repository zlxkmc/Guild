
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    /// <summary>
    /// 玩家的背包
    /// </summary>
    public class PlayerBagPanel : BagPanel
    {
        public override GridManagerFlag Flag => GridManagerFlag.PlayerBag;

        public override void OnGridDragEnd(Grid originalGrid, Grid targetGrid, PointerEventData eventData)
        {
            base.OnGridDragEnd(originalGrid, targetGrid, eventData);

            BagGrid originalBagGrid = (BagGrid)originalGrid;
            BagGrid targetBagGrid = (BagGrid)targetGrid;

            if (targetGrid != null)
            {
                if(targetGrid.Manager.Flag == GridManagerFlag.ShopBag) // 拖到商店的格子上
                {
                    // 出售
                    BagPanel shopBagPanel = targetBagGrid.Manager;
                    Bag shopBag = shopBagPanel.Bag;

                    ItemGroup selling = Bag.RemoveItemGroup(originalBagGrid.Index);
                    selling.Count = shopBagPanel.Bag.AddItemGroup(selling, targetBagGrid.Index);

                    if(selling.Count > 0) // 没卖完
                    {
                        Bag.AddItemGroup(selling, originalBagGrid.Index);
                    }
                }
            }
        }
    }
}

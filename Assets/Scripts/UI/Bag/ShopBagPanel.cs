
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
        public override SlotManagerFlag Flag => SlotManagerFlag.ShopBagPanel;

        public override void OnSlotDragEnd(Slot originalSlot, Slot targetSlot, PointerEventData eventData)
        {
            base.OnSlotDragEnd(originalSlot, targetSlot, eventData);

            BagSlot originalBagSlot = (BagSlot)originalSlot;
            
            if (targetSlot != null && originalBagSlot.ItemGroup != null)
            {
                if (targetSlot.Manager == this) // 在同一SlotManager中拖拽
                {
                    BagSlot targetBagSlot = (BagSlot)targetSlot;
                    Bag.MoveItemGroup(originalBagSlot.Index, targetBagSlot.Index);
                }
                else if (targetSlot.Manager.Flag == SlotManagerFlag.PlayerBagPanel) // 拖到玩家的背包格子上
                {
                    BagSlot targetBagSlot = (BagSlot)targetSlot;

                    // 出售
                    BagPanel playerBagPanel = targetBagSlot.Manager;
                    Bag playerBag = playerBagPanel.Bag;

                    ItemGroup purchased = Bag.RemoveItemGroup(originalBagSlot.Index);
                    purchased.Count = playerBagPanel.Bag.AddItemGroup(targetBagSlot.Index, purchased);

                    if (purchased.Count > 0) // 没卖完
                    {
                        Bag.AddItemGroup(originalBagSlot.Index, purchased);
                    }
                }
            }
        }
    }
}

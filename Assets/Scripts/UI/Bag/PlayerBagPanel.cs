
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
        public override SlotManagerFlag Flag => SlotManagerFlag.PlayerBag;

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
                else if (targetSlot.Manager.Flag == SlotManagerFlag.ShopBag) // 拖到商店的格子上
                {
                    BagSlot targetBagSlot = (BagSlot)targetSlot;

                    // 出售
                    BagPanel shopBagPanel = targetBagSlot.Manager;
                    Bag shopBag = shopBagPanel.Bag;

                    ItemGroup selling = Bag.RemoveItemGroup(originalBagSlot.Index);
                    selling.Count = shopBagPanel.Bag.AddItemGroup(selling, targetBagSlot.Index);

                    if(selling.Count > 0) // 没卖完
                    {
                        Bag.AddItemGroup(selling, originalBagSlot.Index);
                    }
                }
                else if(targetSlot.Manager.Flag == SlotManagerFlag.PlayerEquipments) // 拖到装备槽上
                {
                    EquipmentSlot targetEquipmentSlot = (EquipmentSlot)targetSlot;
                    Character character = targetEquipmentSlot.Manager.Character;
                    Item equipment = originalBagSlot.ItemGroup.Item;
                    // 替换装备
                    Item replaceEquipment = targetEquipmentSlot.Item;

                    if (character.Equip(equipment, targetEquipmentSlot.EquipmentSlotType)) // 装备成功
                    {
                        Bag.RemoveItem(originalBagSlot.Index, 1);
                        if(replaceEquipment != null)
                        {
                            Bag.AddItem(replaceEquipment, 1, originalBagSlot.Index);
                        }

                    }
                }
            }
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    public class EquipmentPanel : SlotManager
    {        
        public override SlotManagerFlag Flag => SlotManagerFlag.PlayerEquipments;

        /// <summary>
        /// 武器槽
        /// </summary>
        [SerializeField]
        private EquipmentSlot _weaponSlot;

        /// <summary>
        /// 显示的角色
        /// </summary>
        public Character Character { get; set; }

        /// <summary>
        /// 鼠标在的槽
        /// </summary>
        public new EquipmentSlot PointerOverSlot { get => (EquipmentSlot)base.PointerOverSlot; }
        /// <summary>
        /// 拖拽中的槽
        /// </summary>
        public new EquipmentSlot DraggingSlot { get => (EquipmentSlot)base.DraggingSlot; }

        private Bag _bag;
        private ItemInfoPanel _itemInfoPanel;

        public override void Update()
        {
            base.Update();

            if (DraggingSlot != null)
            {
                if (DraggingSlot.Item != null)
                {
                    DraggingSlot.Content.transform.position = Input.mousePosition;
                    DraggingSlot.Content.transform.parent = GameObject.Find("Canvas").transform;
                }
            }
        }


        public override void OnPointerUpSlot(Slot slot, PointerEventData eventData)
        {
            base.OnPointerUpSlot(slot, eventData);

            EquipmentSlot equipmentSlot = (EquipmentSlot)slot;

            equipmentSlot.Content.transform.parent = equipmentSlot.transform;
            equipmentSlot.Content.transform.localPosition = Vector2.zero;
        }


        public override void OnPointerOverSlot(Slot slot)
        {
            base.OnPointerOverSlot(slot);

            EquipmentSlot equipmentSlot = (EquipmentSlot)slot;

            if (equipmentSlot.Item != null && equipmentSlot != DraggingSlot)
            {
                if (_itemInfoPanel == null)
                {
                    _itemInfoPanel = Instantiate(ResManager.Prefabs["ItemInfoPanel"], transform).GetComponent<ItemInfoPanel>();
                }

                _itemInfoPanel.SetPos(equipmentSlot.transform.position);
                _itemInfoPanel.gameObject.SetActive((true));
                _itemInfoPanel.Item = equipmentSlot.Item;
            }
        }

        public override void OnPointerExitSlot(Slot slot, PointerEventData eventData)
        {
            base.OnPointerExitSlot(slot, eventData);

            if (PointerOverSlot == null && _itemInfoPanel != null)
            {
                Destroy(_itemInfoPanel.gameObject);
                _itemInfoPanel = null;
            }
        }

        public override void OnSlotDragEnd(Slot originalSlot, Slot targetSlot, PointerEventData eventData)
        {
            base.OnSlotDragEnd(originalSlot, targetSlot, eventData);
        }
    }
}
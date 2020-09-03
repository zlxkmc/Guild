
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    /// <summary>
    /// 背包面板
    /// </summary>
    public abstract class BagPanel : SlotManager
    {
        [Tooltip("槽的容器")]
        [SerializeField]
        private Transform _content;

        [Tooltip("背包槽的模板")]
        [SerializeField]
        private BagSlot _slot;

        public Bag Bag
        {
            get
            {
                return _bag;
            }
            set
            {
                if (value == _bag)
                {
                    return;
                }

                if (_bag == null)
                {
                    for (int i = 0; i < value.Size; i++)
                    {
                        GameObject go = Instantiate(_slot.gameObject, _content);
                        go.SetActive(true);
                    }
                }
                else
                {
                    //槽不够
                    if (_bag.Size < value.Size)
                    {
                        for (int i = _bag.Size; i < value.Size; i++)
                        {
                            GameObject go = Instantiate(_slot.gameObject, _content);
                            go.SetActive(true);
                            BagSlot slot = go.GetComponent<BagSlot>();
                        }
                    }
                    else // 槽多了
                    {
                        for (int i = _bag.Size - 1; i >= value.Size; i--)
                        {
                            Destroy(_content.GetChild(i));
                        }
                    }
                }

                _bag = value;
            }
        }


        /// <summary>
        /// 鼠标在的槽
        /// </summary>
        public new BagSlot PointerOverSlot { get => (BagSlot)base.PointerOverSlot; }
        /// <summary>
        /// 拖拽中的槽
        /// </summary>
        public new BagSlot DraggingSlot { get => (BagSlot)base.DraggingSlot; }

        private Bag _bag;
        private ItemInfoPanel _itemInfoPanel;

        public override void Update()
        {
            base.Update();

            if(DraggingSlot != null)
            {
                if(DraggingSlot.ItemGroup != null)
                {
                    DraggingSlot.ItemGroupGo.transform.position = Input.mousePosition;
                    DraggingSlot.ItemGroupGo.transform.parent = GameObject.Find("Canvas").transform;
                }
            }
        }


        public override void OnPointerUpSlot(Slot slot, PointerEventData eventData)
        {
            base.OnPointerUpSlot(slot, eventData);

            BagSlot bagSlot = (BagSlot)slot;

            bagSlot.ItemGroupGo.transform.parent = bagSlot.transform;
            bagSlot.ItemGroupGo.transform.localPosition = Vector2.zero;
        }


        public override void OnPointerOverSlot(Slot slot)
        {
            base.OnPointerOverSlot(slot);

            BagSlot bagSlot = (BagSlot)slot;

            if (bagSlot.ItemGroup != null && bagSlot != DraggingSlot)
            {
                if (_itemInfoPanel == null)
                {
                    _itemInfoPanel = Instantiate(Resources.Load<GameObject>("Prefabs/UI/ItemInfoPanel"), transform).GetComponent<ItemInfoPanel>();
                }

                _itemInfoPanel.SetPos(bagSlot.transform.position);
                _itemInfoPanel.gameObject.SetActive((true));
                _itemInfoPanel.Item = bagSlot.ItemGroup.Item;
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


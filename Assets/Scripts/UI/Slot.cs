using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    /// <summary>
    /// 槽
    /// </summary>
    public abstract class Slot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// 该槽的管理者
        /// </summary>
        public SlotManager Manager { get => transform.GetComponentInParent<SlotManager>(); }

        /// <summary>
        /// 是否鼠标在上面
        /// </summary>
        public bool PointerOver { get; private set; }

        /// <summary>
        /// 拖拽中
        /// </summary>
        public bool Draging { get; private set; }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            if (PointerOver)
            {
                OnPointerOver();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Manager.OnPointerDownSlot(this, eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Manager.OnPointerUpSlot(this, eventData);

            if (Draging) // 拖拽结束
            {
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, results);

                // 拖拽的目标格子
                Slot targetSlot = null;

                foreach (var rr in results)
                {
                    targetSlot = rr.gameObject.GetComponent<Slot>();
                    if (targetSlot != null)
                    {
                        break;
                    }
                }

                Manager.OnSlotDragEnd(this, targetSlot, eventData);
            }
            Draging = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Draging = true;
            Manager.OnDragSlot(this, eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerOver = true;
            Manager.OnPointerEnterSlot(this, eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerOver = false;
            Manager.OnPointerExitSlot(this, eventData);
        }

        public void OnPointerOver()
        {
            Manager.OnPointerOverSlot(this);
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    /// <summary>
    /// 槽管理者
    /// </summary>
    public abstract class SlotManager : MonoBehaviour
    {
        /// <summary>
        /// 标志
        /// </summary>
        public abstract SlotManagerFlag Flag { get; }

        /// <summary>
        /// 鼠标所在的槽
        /// </summary>
        public Slot PointerOverSlot { get => _pointerOverSlot; }
        /// <summary>
        /// 拖拽中的槽
        /// </summary>
        public Slot DraggingSlot { get => _draggingSlot; }

        private Slot _pointerOverSlot;
        private Slot _draggingSlot;

        public virtual void Update()
        {
            
        }

        /// <summary>
        /// 在某个槽上按下
        /// </summary>
        /// <param name="slot">对应的槽</param>
        /// /// <param name="eventData"></param>
        public virtual void OnPointerDownSlot(Slot slot, PointerEventData eventData)
        {

        }

        /// <summary>
        /// 在之前按下的槽抬起
        /// </summary>
        /// <param name="slot">对应的槽</param>
        /// <param name="eventData"></param>
        public virtual void OnPointerUpSlot(Slot slot, PointerEventData eventData)
        {
            if(slot == _draggingSlot)
            {
                _draggingSlot = null;
            }
        }

        /// <summary>
        /// 拖拽某个槽
        /// </summary>
        /// <param name="slot">对应的槽</param>
        /// <param name="eventData"></param>
        public virtual void OnDragSlot(Slot slot, PointerEventData eventData)
        {
            _draggingSlot = slot;
        }

        /// <summary>
        /// 拖拽某个槽结束，可以与其他SlotManager交互
        /// </summary>
        /// <param name="originalSlot">拖拽的槽</param>
        /// <param name="targetSlot">目标槽，不一定是属于该manager的</param>
        /// /// <param name="eventData"></param>
        public virtual void OnSlotDragEnd(Slot originalSlot, Slot targetSlot, PointerEventData eventData)
        {

        }

        /// <summary>
        ///进入某个槽
        /// </summary>
        /// <param name="slot">对应的槽</param>
        /// /// <param name="eventData"></param>
        public virtual void OnPointerEnterSlot(Slot slot, PointerEventData eventData)
        {

        }


        /// <summary>
        ///离开某个槽
        /// </summary>
        /// <param name="slot">对应的槽</param>
        /// /// <param name="eventData"></param>
        public virtual void OnPointerExitSlot(Slot slot, PointerEventData eventData)
        {
            if(slot == _pointerOverSlot)
            {
                _pointerOverSlot = null;
            }
        }

        /// <summary>
        /// 在某个槽上
        /// </summary>
        /// <param name="slot"></param>
        public virtual void OnPointerOverSlot(Slot slot)
        {
            _pointerOverSlot = slot;
        }
    }
}

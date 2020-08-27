
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
        /// <summary>
        /// 拖拽中的格子
        /// </summary>
        private BagGrid _draggingGrid;
        /// <summary>
        /// 拖拽的物品组ui
        /// </summary>
        private Transform _draggingTarget;
        /// <summary>
        /// 鼠标进入的格子
        /// </summary>
        private BagGrid _enteredGird;

        public override void OnGridDrag(BagGrid bagGrid, PointerEventData eventData)
        {
            if(bagGrid.ItemGroup != null)
            {
                _draggingGrid = bagGrid;
                _draggingTarget = _draggingGrid.ItemGroupTrans;
                _draggingTarget.position = Input.mousePosition;
                _draggingTarget.parent = transform;
            }
        }

        public override void OnGridPointerDown(BagGrid bagGrid, PointerEventData eventData)
        {

        }

        public override void OnGridPointerEnter(BagGrid bagGrid, PointerEventData eventData)
        {
            _enteredGird = bagGrid;
        }

        public override void OnGridPointerExit(BagGrid bagGrid, PointerEventData eventData)
        {
            if(bagGrid == _enteredGird)
            {
                _enteredGird = null;
            }
        }

        public override void OnGridPointerUp(BagGrid bagGrid, PointerEventData eventData)
        {
            if(_draggingGrid != null)
            {
                _draggingTarget.parent = _draggingGrid.transform;
                _draggingTarget.localPosition = Vector2.zero;

                if(_enteredGird != null)
                {
                    Bag.MoveItemGroup(_draggingGrid.Pos, _enteredGird.Pos);
                }

                _draggingGrid = null;
                _draggingTarget = null;
            }
        }
    }
}

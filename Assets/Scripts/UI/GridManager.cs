using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    /// <summary>
    /// 格子管理者
    /// </summary>
    public abstract class GridManager : MonoBehaviour
    {
        /// <summary>
        /// 标志
        /// </summary>
        public abstract GridManagerFlag Flag { get; }

        /// <summary>
        /// 鼠标所在的格子
        /// </summary>
        public Grid PointerOverGrid { get => _pointerOverGrid; }
        /// <summary>
        /// 拖拽中的格子
        /// </summary>
        public Grid DraggingGrid { get => _draggingGrid; }

        private Grid _pointerOverGrid;
        private Grid _draggingGrid;

        public virtual void Update()
        {
            
        }

        /// <summary>
        /// 在某个格子上按下
        /// </summary>
        /// <param name="grid">对应的格子</param>
        /// /// <param name="eventData"></param>
        public virtual void OnPointerDownGrid(Grid grid, PointerEventData eventData)
        {

        }

        /// <summary>
        /// 在之前按下的格子抬起
        /// </summary>
        /// <param name="grid">对应的格子</param>
        /// <param name="eventData"></param>
        public virtual void OnPointerUpGrid(Grid grid, PointerEventData eventData)
        {
            if(grid == _draggingGrid)
            {
                _draggingGrid = null;
            }
        }

        /// <summary>
        /// 拖拽某个格子
        /// </summary>
        /// <param name="grid">对应的格子</param>
        /// <param name="eventData"></param>
        public virtual void OnDragGrid(Grid grid, PointerEventData eventData)
        {
            _draggingGrid = grid;
        }

        /// <summary>
        /// 拖拽某个格子结束，可以与其他GridManager交互
        /// </summary>
        /// <param name="originalGrid">拖拽的格子</param>
        /// <param name="targetGrid">目标格子，不一定是属于该manager的</param>
        /// /// <param name="eventData"></param>
        public virtual void OnGridDragEnd(Grid originalGrid, Grid targetGrid, PointerEventData eventData)
        {

        }

        /// <summary>
        ///进入某个格子
        /// </summary>
        /// <param name="grid">对应的格子</param>
        /// /// <param name="eventData"></param>
        public virtual void OnPointerEnterGrid(Grid grid, PointerEventData eventData)
        {

        }


        /// <summary>
        ///离开某个格子
        /// </summary>
        /// <param name="grid">对应的格子</param>
        /// /// <param name="eventData"></param>
        public virtual void OnPointerExitGrid(Grid grid, PointerEventData eventData)
        {
            if(grid == _pointerOverGrid)
            {
                _pointerOverGrid = null;
            }
        }

        /// <summary>
        /// 在某个格子上
        /// </summary>
        /// <param name="grid"></param>
        public virtual void OnPointerOverGrid(Grid grid)
        {
            _pointerOverGrid = grid;
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI
{
    /// <summary>
    /// 格子
    /// </summary>
    public abstract class Grid : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// 该格子的管理者
        /// </summary>
        public GridManager Manager { get => transform.GetComponentInParent<GridManager>(); }

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
            Manager.OnPointerDownGrid(this, eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Manager.OnPointerUpGrid(this, eventData);

            if (Draging) // 拖拽结束
            {
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, results);

                // 拖拽的目标格子
                Grid targetGrid = null;

                foreach (var rr in results)
                {
                    targetGrid = rr.gameObject.GetComponent<Grid>();
                    if (targetGrid != null)
                    {
                        break;
                    }
                }

                Manager.OnGridDragEnd(this, targetGrid, eventData);
            }
            Draging = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Draging = true;
            Manager.OnDragGrid(this, eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerOver = true;
            Manager.OnPointerEnterGrid(this, eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerOver = false;
            Manager.OnPointerExitGrid(this, eventData);
        }

        public void OnPointerOver()
        {
            Manager.OnPointerOverGrid(this);
        }
    }
}

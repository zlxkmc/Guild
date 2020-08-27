
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
    public abstract class BagPanel : GridManager
    {
        [Tooltip("格子容器")]
        [SerializeField]
        private Transform _content;

        [Tooltip("格子模板")]
        [SerializeField]
        private BagGrid _grid;

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
                        GameObject go = Instantiate(_grid.gameObject, _content);
                        go.SetActive(true);
                        BagGrid grid = go.GetComponent<BagGrid>();
                    }
                }
                else
                {
                    //格子不够
                    if (_bag.Size < value.Size)
                    {
                        for (int i = _bag.Size; i < value.Size; i++)
                        {
                            GameObject go = Instantiate(_grid.gameObject, _content);
                            go.SetActive(true);
                            BagGrid grid = go.GetComponent<BagGrid>();
                        }
                    }
                    else // 格子多了
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
        /// 鼠标在的格子
        /// </summary>
        public new BagGrid PointerOverGrid { get => (BagGrid)base.PointerOverGrid; }
        /// <summary>
        /// 拖拽中的格子
        /// </summary>
        public new BagGrid DraggingGrid { get => (BagGrid)base.DraggingGrid; }

        private Bag _bag;
        private ItemInfoPanel _itemInfoPanel;

        public override void Update()
        {
            base.Update();

            if(DraggingGrid != null)
            {
                if(DraggingGrid.ItemGroup != null)
                {
                    DraggingGrid.ItemGroupGo.transform.position = Input.mousePosition;
                    DraggingGrid.ItemGroupGo.transform.parent = GameObject.Find("Canvas").transform;
                }
            }
        }


        public override void OnPointerUpGrid(Grid grid, PointerEventData eventData)
        {
            base.OnPointerUpGrid(grid, eventData);

            BagGrid bagGrid = (BagGrid)grid;

            bagGrid.ItemGroupGo.transform.parent = bagGrid.transform;
            bagGrid.ItemGroupGo.transform.localPosition = Vector2.zero;
        }


        public override void OnPointerOverGrid(Grid grid)
        {
            base.OnPointerOverGrid(grid);

            BagGrid bagGrid = (BagGrid)grid;

            if (bagGrid.ItemGroup != null && bagGrid != DraggingGrid)
            {
                if (_itemInfoPanel == null)
                {
                    _itemInfoPanel = Instantiate(ResManager.Prefabs["ItemInfoPanel"], transform).GetComponent<ItemInfoPanel>();
                }

                _itemInfoPanel.SetPos(bagGrid.transform.position);
                _itemInfoPanel.gameObject.SetActive((true));
                _itemInfoPanel.Item = bagGrid.ItemGroup.Item;
            }
        }

        public override void OnPointerExitGrid(Grid grid, PointerEventData eventData)
        {
            base.OnPointerExitGrid(grid, eventData);

            if (PointerOverGrid == null && _itemInfoPanel != null)
            {
                Destroy(_itemInfoPanel.gameObject);
                _itemInfoPanel = null;
            }
        }

        public override void OnGridDragEnd(Grid originalGrid, Grid targetGrid, PointerEventData eventData)
        {
            base.OnGridDragEnd(originalGrid, targetGrid, eventData);

            BagGrid originalBagGrid = (BagGrid)originalGrid;
            BagGrid targetBagGrid = (BagGrid)targetGrid;

            if (targetGrid != null && targetGrid.Manager == this) // 在同一GridManager中拖拽
            {
                Bag.MoveItemGroup(originalBagGrid.Index, targetBagGrid.Index);
            }
        }
    }
}


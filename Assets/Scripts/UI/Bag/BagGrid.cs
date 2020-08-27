using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class BagGrid : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [Tooltip("物品图片")]
        [SerializeField]
        private Image _itemImage;

        [Tooltip("数量文本")]
        [SerializeField]
        private Text _countText;

        [Tooltip("可以用来拖拽的整体")]
        [SerializeField]
        private Transform _itemGroupTrans;

        /// <summary>
        /// 这个格子的物品组
        /// </summary>
        public ItemGroup ItemGroup { get => _bagPanel.Bag.GetItemGroup(Pos); }

        /// <summary>
        /// 可以用来拖拽的整体
        /// </summary>
        public Transform ItemGroupTrans { get => _itemGroupTrans; }

        /// <summary>
        /// 在背包中的位置
        /// </summary>
        public int Pos { get => transform.GetSiblingIndex(); }

        /// <summary>
        /// 所属的背包面板
        /// </summary>
        private BagPanel _bagPanel;

        // Start is called before the first frame update
        void Start()
        {
            _bagPanel = transform.GetComponentInParent<BagPanel>();
        }

        // Update is called once per frame
        void Update()
        {
            if(ItemGroup == null)
            {
                _itemImage.sprite = null;
                _itemImage.gameObject.SetActive(false);
                _countText.gameObject.SetActive(false);
            }
            else
            {
                string iconName = ItemGroup.Item.IconName;
                Sprite icon = ResManager.Sprites[iconName];

                 _itemImage.sprite = icon;
                _itemImage.gameObject.SetActive(true);

                _countText.text = ItemGroup.Count + "";
                _countText.gameObject.SetActive(true);
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _bagPanel.OnGridPointerDown(this, eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _bagPanel.OnGridPointerUp(this, eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _bagPanel.OnGridDrag(this, eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _bagPanel.OnGridPointerEnter(this, eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _bagPanel.OnGridPointerExit(this, eventData);
        }
    }

}

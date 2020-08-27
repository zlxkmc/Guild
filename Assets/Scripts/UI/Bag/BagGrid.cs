using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    /// <summary>
    /// 背包格子
    /// </summary>
    public class BagGrid : Grid
    {
        [Tooltip("物品图片")]
        [SerializeField]
        private Image _itemImage;

        [Tooltip("数量文本")]
        [SerializeField]
        private Text _countText;

        [Tooltip("可以用来拖拽的整体")]
        [SerializeField]
        private GameObject _itemGroupGo;

        /// <summary>
        /// 这个格子的物品组
        /// </summary>
        public ItemGroup ItemGroup { get => Manager.Bag.GetItemGroup(Index); }

        /// <summary>
        /// 可以用来拖拽的整体
        /// </summary>
        public GameObject ItemGroupGo { get => _itemGroupGo; }

        /// <summary>
        /// 在背包中的索引
        /// </summary>
        public int Index { get => transform.GetSiblingIndex(); }

        /// <summary>
        /// 所属的管理者
        /// </summary>
        public new BagPanel Manager { get => (BagPanel)base.Manager; }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();

            if(ItemGroup == null)
            {
                _itemImage.sprite = null;
                _itemGroupGo.SetActive(false);
            }
            else
            {
                _itemGroupGo.SetActive(true);

                string iconName = ItemGroup.Item.IconName;
                Sprite icon = ResManager.Sprites[iconName];

                 _itemImage.sprite = icon;

                _countText.text = ItemGroup.Count + "";
            }
        }
    }

}

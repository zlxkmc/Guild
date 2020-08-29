using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class EquipmentSlot : Slot
    {
        [Tooltip("装备槽类型")]
        [SerializeField]
        private EquipmentSlotType _equipmentSlotType;

        [Tooltip("物品图片")]
        [SerializeField]
        private Image _itemImage;

        [Tooltip("数量文本")]
        [SerializeField]
        private Text _countText;

        [Tooltip("可以用来拖拽的整体")]
        [SerializeField]
        private GameObject _content;

        /// <summary>
        /// 这个槽的物品组
        /// </summary>
        public Item Item { get => Manager.Character.GetEquipment(_equipmentSlotType); }

        /// <summary>
        /// 内容
        /// </summary>
        public GameObject Content { get => _content; }

        /// <summary>
        /// 所属的管理者
        /// </summary>
        public new EquipmentPanel Manager { get => (EquipmentPanel)base.Manager; }
        /// <summary>
        /// 装备槽类型
        /// </summary>
        public EquipmentSlotType EquipmentSlotType { get => _equipmentSlotType; }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();

            if (Item == null)
            {
                _itemImage.sprite = null;
                Content.SetActive(false);
            }
            else
            {
                Content.SetActive(true);

                string iconName = Item.IconName;
                Sprite icon = ResManager.Sprites[iconName];
                _itemImage.sprite = icon;

               // _countText.text = ItemGroup.Count + "";
            }
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ItemInfoPanel : MonoBehaviour
    {
        public Item Item
        {
            get { return _item; }
            set
            {
                _item = value;
            }
        }

        [SerializeField]
        private Text _infoText;

        private Item _item;

        private void Awake()
        {
            _infoText.text = "";
        }

        private void Update()
        {
            if (Item == null)
            {
                _infoText.text = "";
            }
            else
            {
                string text = "";
                text += Item.Name + System.Environment.NewLine;
                text += "重量 " + Item.Weight + System.Environment.NewLine;
                text += "价值 " + Item.Value;
                _infoText.text = text;
            }
        }

        /// <summary>
        /// 设置位置，尽量不超出边界
        /// </summary>
        /// <param name="pos"></param>
        public void SetPos(Vector3 pos)
        {
            RectTransform rect = transform.GetComponent<RectTransform>();
            float width = rect.sizeDelta.x;
            float height = rect.sizeDelta.y;

            Vector2 pivot = new Vector2();

            if(pos.x + width <= Screen.width) // 优先靠右
            {
                pivot.x = 0;
            }
            else // 左
            {
                pivot.x = 1;
            }

            if(pos.y - height >= 0) // 优先靠下
            {
                pivot.y = 1;
            }
            else // 上
            {
                pivot.y = 0;
            }

            rect.pivot = pivot;
            rect.position = pos;            
        }
    }
}
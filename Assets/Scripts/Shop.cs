using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Game
{
    public class Shop : MonoBehaviour
    {
        public Bag Bag { get; private set; }

        /// <summary>
        /// 焦点，鼠标在上面，描边，选中
        /// </summary>
        public bool Focus { get; private set; }

        private BagPanel _bagPanel;
        private SpriteOutline _spriteOutline;

        void Start()
        {
            _spriteOutline = transform.GetComponent<SpriteOutline>();

            Bag = new Bag();
            Bag.Size = 30;

            Bag.AddItem(new Item("0"), 5);
            Bag.AddItem(new Item("1"), 5);
        }

        void Update()
        {
            if (Focus)
            {
                _spriteOutline.Outline = true;
            }
            else
            {
                _spriteOutline.Outline = false;
            }
        }

        private void OnMouseDown()
        {
            if(Focus)
            {
                if (_bagPanel == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/UI/Bag"), GameObject.Find("Canvas").transform);
                    Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2));
                    go.transform.position = new Vector3(pos.x, pos.y, GameObject.Find("Canvas").transform.position.z);
                    go.SetActive(true);
                    _bagPanel = go.GetComponent<BagPanel>();

                    _bagPanel.Bag = Bag;
                }
            }
        }

        private void OnMouseOver()
        {
            if (Util.IsMouseOverUI())
            {
                Focus = false;
            }
            else
            {
                Focus = true;
            }
        }

        private void OnMouseExit()
        {
            Focus = false;
        }
    }
}

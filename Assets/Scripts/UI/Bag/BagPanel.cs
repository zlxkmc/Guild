
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class BagPanel : MonoBehaviour
    {
        [Tooltip("格子容器")]
        [SerializeField]
        private Transform _content;

        [Tooltip("格子模板")]
        [SerializeField]
        private BagGrid _grid;


        private Bag _bag;

        public Bag Bag {
            get
            {
                return _bag;
            }
            set
            {
                if(value == _bag)
                {
                    return;
                }

                if(_bag == null)
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


        // Start is called before the first frame update
        void Start()
        {
            _grid.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 在某个格子上按下
        /// </summary>
        /// <param name="bagGrid">对应的格子</param>
        /// /// <param name="eventData"></param>
        public virtual void OnGridPointerDown(BagGrid bagGrid, PointerEventData eventData)
        {

        }

        /// <summary>
        /// 在某个格子上抬起
        /// </summary>
        /// <param name="bagGrid">对应的格子</param>
        /// <param name="eventData"></param>
        public virtual void OnGridPointerUp(BagGrid bagGrid, PointerEventData eventData)
        {

        }

        /// <summary>
        /// 拖拽某个格子
        /// </summary>
        /// <param name="bagGrid">对应的格子</param>
        /// /// <param name="eventData"></param>
        public virtual void OnGridDrag(BagGrid bagGrid, PointerEventData eventData)
        {

        }

        /// <summary>
        ///进入某个格子
        /// </summary>
        /// <param name="bagGrid">对应的格子</param>
        /// /// <param name="eventData"></param>
        public virtual void OnGridPointerEnter(BagGrid bagGrid, PointerEventData eventData)
        {

        }


        /// <summary>
        ///离开某个格子
        /// </summary>
        /// <param name="bagGrid">对应的格子</param>
        /// /// <param name="eventData"></param>
        public virtual void OnGridPointerExit(BagGrid bagGrid, PointerEventData eventData)
        {

        }
    }
}


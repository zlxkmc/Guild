using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class UIInit : MonoBehaviour
    {
        // Start is called before the first frame update

        private StatePanel _playerStatePanel;
        private PlayerBagPanel _playerBagPanel;

        void Start()
        {
            _playerStatePanel = transform.Find("PlayerState").GetComponent<StatePanel>();
            _playerBagPanel = transform.Find("PlayerBag").GetComponent<PlayerBagPanel>();

            _playerStatePanel.gameObject.SetActive(true);

            _playerBagPanel.Bag = GameData.Player.Bag;
            _playerBagPanel.gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

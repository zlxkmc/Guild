using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class UIInit : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField]
        private StatePanel _playerStatePanel;

        [SerializeField]
        private PlayerBagPanel _playerBagPanel;

        [SerializeField]
        private EquipmentPanel _playerEquipmentPanel;

        [SerializeField]
        private SkillPanel _playerSkillPanel;
        

        void Start()
        {
            _playerStatePanel.gameObject.SetActive(true);

            _playerBagPanel.Bag = GameData.Player.Bag;
            _playerBagPanel.gameObject.SetActive(true);

            _playerEquipmentPanel.Character = GameData.Player;

            _playerSkillPanel.Character = GameData.Player;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    /// <summary>
    /// 角色属性面板
    /// </summary>
    public class StatePanel : MonoBehaviour
    {
        [SerializeField]
        private Text _hpText;

        [SerializeField]
        private Text _mpText;

        [SerializeField]
        private Text _ppText;

        [SerializeField]
        private Text _statPointText;

        [SerializeField]
        private Text _strText;

        [SerializeField]
        private Text _dexText;

        [SerializeField]
        private Text _lucText;

        [SerializeField]
        private Text _intText;

        [SerializeField]
        private Text _staText;

        [SerializeField]
        private Button _addStrBtn;

        [SerializeField]
        private Button _addDexBtn;

        [SerializeField]
        private Button _addLucBtn;

        [SerializeField]
        private Button _addIntBtn;

        [SerializeField]
        private Button _addStaBtn;


        public Character Player { get => GameData.Player; }


        private void Start()
        {
            _addStrBtn.onClick.AddListener(() =>
            {
                Player.AllocatedStatPoint(StatPointType.Str, 1);
            });

            _addDexBtn.onClick.AddListener(() =>
            {
                Player.AllocatedStatPoint(StatPointType.Dex, 1);
            });

            _addLucBtn.onClick.AddListener(() =>
            {
                Player.AllocatedStatPoint(StatPointType.Luc, 1);
            });

            _addIntBtn.onClick.AddListener(() =>
            {
                Player.AllocatedStatPoint(StatPointType.Int, 1);
            });

            _addStaBtn.onClick.AddListener(() =>
            {
                Player.AllocatedStatPoint(StatPointType.Sta, 1);
            });
        }

        private void Update()
        {
            _hpText.text = Player.Hp + "/" + Player.MaxHp;
            _mpText.text = Player.Mp + "/" + Player.MaxMp;
            _ppText.text = Player.Pp + "/" + Player.MaxPp;
            _statPointText.text = Player.StatPoint + "";
            _strText.text = Player.Str + "";
            _dexText.text = Player.Dex + "";
            _lucText.text = Player.Luc + "";
            _intText.text = Player.Int + "";
            _staText.text = Player.Sta + "";
        }
    }
}


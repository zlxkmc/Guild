
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Game
{
    public class HpBar : MonoBehaviour
    {

        [SerializeField]
        private Image _bar;

        private Unit _unit;

        private void Start()
        {
            _unit = GetComponentInParent<Unit>();
        }

        void Update()
        {
            if(_unit != null && _bar != null)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(_unit.transform.position);
                if (screenPos.x > Screen.width || screenPos.x < 0 || screenPos.y > Screen.height || screenPos.y < 0)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }

                _bar.fillAmount = _unit.Hp * 1f / _unit.MaxHp;
            }
        }
    }

}

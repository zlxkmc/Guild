
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.SkillEntity
{
    public class KnifeLight : MonoBehaviour
    {
        /// <summary>
        /// 记录攻击过的单位
        /// </summary>
        private List<Unit> _attakced = new List<Unit>();

        public AttackEvent onAttack = new AttackEvent();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Unit target = collision.gameObject.GetComponent<Unit>();
            if(target != null)
            {
                if(_attakced.Contains(target) == false)
                {
                    _attakced.Add(target);
                    onAttack.Invoke(target);
                }
            }
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }


    }

}

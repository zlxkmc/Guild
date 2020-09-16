using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SkillEntity
{
    public class Huikan : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Unit target = collision.gameObject.GetComponent<Unit>();

        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }

}

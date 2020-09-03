using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.AnimEvents
{
    public class HuikanAnimEvent : MonoBehaviour
    {
        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }

}

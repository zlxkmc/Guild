using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class Demo1Init : MonoBehaviour
    {
        public void Awake()
        {
            UnitFactory.CreatePlayer();
        }
    }
}

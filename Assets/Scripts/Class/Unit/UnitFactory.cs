using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Game
{
    public class UnitFactory
    {
        public static GameObject CreatePlayer()
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Unit/Player"));

            return go;
        }
    }
}

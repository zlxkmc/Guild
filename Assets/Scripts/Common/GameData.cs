
using UnityEngine;

namespace Game
{
    public static class GameData
    {
        public static Player Player { get => GameObject.FindObjectOfType<Player>(); }

        public static void Init()
        {

        }
    }
}




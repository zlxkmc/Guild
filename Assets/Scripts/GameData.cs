
using UnityEngine;

namespace Game
{
    public static class GameData
    {
        public static Character Player { get; private set; }

        public static void Init()
        {
            Player = new Character()
            {
                BaseMaxHp = 100,
                BaseMaxMp = 100,
                BaseMaxPp = 100,
                BaseDex = 5,
                BaseInt = 5,
                BaseLuc = 5,
                BaseSta = 5,
                BaseStr = 5,
                StatPoint = 5,
                Name = "角色",
                Hp = 100,
                Mp = 100,
                Pp = 100,
            };

            Player.Bag.Size = 30;

            // test
            Item item1 = new Item("1");
            Debug.Log(Player.Bag.AddItem(item1, 3));

            Item item2 = new Item("2");
            Debug.Log(Player.Bag.AddItem(item2, 4));

            Debug.Log(Player.Bag.AddItem(item1, 1, 1));

            Debug.Log(Player.Bag.AddItem(item2, 1, 2));

            Debug.Log(Player.Bag.AddItem(item1, 2, 2));

            Debug.Log(Player.Bag.AddItem(item2, 2, 3));

            Debug.Log(Player.Bag.AddItem(item2, 5, 4));

            Debug.Log(Player.Bag.AddItem(item1, 5, 10));

            Debug.Log(Player.Bag.AddItem(item2, 5, 11));
            Debug.Log(Player.Bag.AddItem(item2, 33, 12));
            Debug.Log(Player.Bag.AddItem(item2, 77, 13));
            Debug.Log(Player.Bag.AddItem(item2, 99, 14));
        }
    }
}




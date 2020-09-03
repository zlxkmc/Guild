
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
            Player.StudySkill("0");


            Item item1 = new Item("0");
            Debug.Log(Player.Bag.AddItem(item1, 3));

            Item item2 = new Item("1");
            Debug.Log(Player.Bag.AddItem(item2, 4));

            Debug.Log(Player.Bag.AddItem(1, item1, 1));

            Debug.Log(Player.Bag.AddItem(2, item2, 1));

            Debug.Log(Player.Bag.AddItem(2, item1, 2));

            Debug.Log(Player.Bag.AddItem(3, item2, 2));

            Debug.Log(Player.Bag.AddItem(4, item2, 5));

            Debug.Log(Player.Bag.AddItem(10, item1, 5));

            Debug.Log(Player.Bag.AddItem(11, item2, 5));
            Debug.Log(Player.Bag.AddItem(12, item2, 33));
            Debug.Log(Player.Bag.AddItem(13, item2, 77));
            Debug.Log(Player.Bag.AddItem(14, item2, 99));
        }
    }
}




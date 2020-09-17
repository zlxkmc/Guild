using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

namespace Game
{
    public class Player : Character
    {
        /// <summary>
        /// 移动速度
        /// </summary>
        private float MoveSpeed
        {
            get { return GameSetting.MoveSpeed * GameData.Player.MoveSpeedRate; }
        }

        public override TeamType TeamType => TeamType.Player;

        private void Awake()
        {
            BaseMaxHp = 100;
            BaseMaxMp = 100;
            BaseMaxPp = 100;
            BaseDex = 5;
            BaseInt = 5;
            BaseLuc = 5;
            BaseSta = 5;
            BaseStr = 5;
            StatPoint = 5;
            Hp = 100;
            Mp = 100;
            Pp = 100;

            // test
            StudySkill("0");

            Bag.Size = 30;

            Item item1 = new Item("0");
            Bag.AddItem(item1, 3);

            Item item2 = new Item("1");
            Bag.AddItem(item2, 4);
            Bag.AddItem(1, item1, 1);
            Bag.AddItem(2, item2, 1);
            Bag.AddItem(2, item1, 2);
            Bag.AddItem(3, item2, 2);
            Bag.AddItem(4, item2, 5);
            Bag.AddItem(10, item1, 5);
            Bag.AddItem(11, item2, 5);
            Bag.AddItem(12, item2, 33);
            Bag.AddItem(13, item2, 77);
            Bag.AddItem(14, item2, 99);
        }

        void Start()
        {
        }

        void Update()
        {
            Move();
            //Aspect();

            if (Input.GetKeyDown(KeyCode.Mouse0) && Util.IsMouseOverUI() == false)
            {
                UseSkill("0");
            }
        }

        /// <summary>
        /// 移动
        /// </summary>
        private void Move()
        {
            Vector3 newPos = transform.position;
            Vector3 moveVector = new Vector3();

            if (Input.GetKey(KeyCode.W))
            {
                moveVector += new Vector3(0, Time.deltaTime * MoveSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveVector += new Vector3(-Time.deltaTime * MoveSpeed, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveVector += new Vector3(0, -Time.deltaTime * MoveSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveVector += new Vector3(Time.deltaTime * MoveSpeed, 0);
            }

            newPos += moveVector;

            transform.position = newPos;
        }

        /// <summary>
        /// 朝向
        /// </summary>
        private void Aspect()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.y > transform.position.x) // 上
            {

            }
            else if (mousePos.y < transform.position.x) // 下
            {

            }
            else if (mousePos.x < transform.position.x) // 左
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            }
            else if (mousePos.x > transform.position.x) // 右
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180, transform.eulerAngles.z);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CharacterController : MonoBehaviour
    {
        // TODO 临时
        public Character Character { get; set; } = GameData.Player;

        /// <summary>
        /// 移动速度
        /// </summary>
        private float MoveSpeed
        {
            get { return GameSetting.MoveSpeed * GameData.Player.MoveSpeedRate; }
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            //Aspect();
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Character.UseSkill("0");
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

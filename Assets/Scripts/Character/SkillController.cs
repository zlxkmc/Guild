using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(CharacterController))]
    public class SkillController : MonoBehaviour
    {
        public CharacterController CharacterController { get => GetComponent<CharacterController>(); }

        public Character Character { get => CharacterController.Character; }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
